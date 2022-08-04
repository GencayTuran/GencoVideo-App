//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Text;
//using System.Threading.Tasks;
//using Xamarin.CommunityToolkit.ObjectModel;
//using XF_GencoVideo.Models;

//namespace XF_GencoVideo.ViewModels
//{
//    public class VideoViewModel : INotifyPropertyChanged
//    {
//        public event PropertyChangedEventHandler PropertyChanged;

//        //collections for the pickers in add page
//        public List<Video> VideoTypes { get; set; }
//        public List<Client> Clients { get; set; }

//        //Collection for displaying the videos
//        public ObservableRangeCollection<Video> Videos {get; set;}

//        //inputs in add page
//        public string NewVideoUrl { get; set; }
//        public string NewDescription { get; set; }
//        public string NewLocation { get; set; }

//        //commands
//        public AsyncCommand AddCommand { get; }
//        public AsyncCommand RefreshCommand { get; }
//        public AsyncCommand<Video> RemoveCommand { get; }


//        public VideoViewModel()
//        {
//            Videos = new ObservableRangeCollection<Video>();
//            VideoTypes = new List<Video>();
//            Clients = new List<Client>();

//            AddCommand = new AsyncCommand(Add);
//            RefreshCommand = new AsyncCommand(Refresh);
//            RemoveCommand = new AsyncCommand<Video>(Remove);

//        }

//        async Task Add()
//        {

//            await DbService.AddBooking(bookingDate, filmingDate,
//                NewVideoType, NewComment, NewPaid, NewDeposit, NewLocation);

//            await DbService.AddClient(NewClientName, NewClientEmail,
//                NewClientPhone, NewClientCorporate);

//            await Refresh();
//        }
//        async Task Remove(Video video)
//        {
//            await DbService.DeleteVideo(video.BookingId);
//            await Refresh();
//        }


//        async Task Refresh()
//        {
//            try
//            {
//                //IsBusy = true;
//                await Task.Delay(2000);
//                Videos.Clear();

//                var videos = await DbService.GetBooking();

//                videos = videos.OrderBy(x => x.FilmingDate).ToList();


//                //foreach (var item in bookings)
//                //{
//                //    Bookings.Add(item);
//                //}

//                Videos.AddRange(videos);
//                //IsBusy = false;

//            }
//            catch (Exception ex)
//            {

//                throw;
//            }





//        }

//    }
//}
