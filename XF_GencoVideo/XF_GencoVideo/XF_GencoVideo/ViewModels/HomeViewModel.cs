using System;
using System.Collections.Generic;
using System.Text;
using XF_GencoVideo.Models;
using XF_GencoVideo.Data;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Linq;
using Firebase.Database;

using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using Xamarin.CommunityToolkit.UI.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using XF_GencoVideo.Services;
using Xamarin.CommunityToolkit.ObjectModel;

namespace XF_GencoVideo.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public List<Video> Videos { get; set; }

        //public ICommand RefreshCommand => new Command(LoadVideos);
        //public ICommand LoadPageCommand => new Command(LoadVideos); //moet nog gemaakt worden in xaml check github
        public ICommand GetVideoCommand => new Command(GetRandomUrl);
        public AsyncCommand RefreshCommand { get; }

        //Upcoming projects
        //public string ClientName { get; set; }
        //public DateTime FilmingDate { get; set; }
        //public string VideoType { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private string nickname;
        public string Nickname
        {
            get { return nickname; }
            set
            {
                nickname = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Nickname"));
            }
        }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IsBusy"));
            }
        }

        public ObservableRangeCollection<BaseModel> UpcomingProjects { get; set; }

        public HomeViewModel()
        {

           //Task.Run(async () => await GetRandomUrl());

           UpcomingProjects = new ObservableRangeCollection<BaseModel>();
           RefreshCommand = new AsyncCommand(LoadUpcomingProjects);

        }


        async Task LoadUpcomingProjects()
        {
                try
                {
                    IsBusy = true;
                    await Task.Delay(2000);
                    UpcomingProjects.Clear();

                    var bookings = await DbService.GetBooking();
                //    var clients = await DbService.GetClients();

                bookings.Where(x => x.FilmingDate > DateTime.Now);
                //clients.Select(x => x.ClientName);

                //var uProjects = clients.Concat(bookings);



                //foreach (var item in bookings)
                //{
                //    Bookings.Add(item);
                //}

                //UpcomingProjects.AddRange(uProjects);
                UpcomingProjects.AddRange(bookings);

                IsBusy = false;

                }
                catch (Exception ex)
                {

                    throw;
                }
        }
        
        public void GetRandomUrl()
        {
            //getting id's from Videos via Linq
            //var lstUrls = SeedData.GetVideos().Select(v => v.VideoId).ToList();
            //var lstUri = Videos.Select(v => new Uri(v.VideoId)).ToList();

            //declaration
            var rndNumber = new Random();
            int index = 0;

            //await Task.Delay(3000);

            //get random indexnumber
            //index = rndNumber.Next(0, SeedData.GetVideos().Count);
           
            //indexnumber in list into the string prop
            //VideoUrl = lstUrls[index];

            //LoadVideo();

          
        }

     

    }
    }
