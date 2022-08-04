using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using XF_GencoVideo.Models;
using XF_GencoVideo.Services;

namespace XF_GencoVideo.ViewModels
{
    public class BookingViewModel : INotifyPropertyChanged
    {

        public ObservableRangeCollection<Booking> Bookings { get; set; }
        public ObservableRangeCollection<Client> Clients { get; set; }

        //Command
        public AsyncCommand AddCommand { get; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Booking> RemoveCommand { get; }

        //Table
        //public string ClientName { get; set; }
        //public DateTime FilmingDate { get; set; }
        //public string VideoType { get; set; }
        //public bool Paid { get; set; }


        //inputs new booking
        public string NewClientName { get; set; }
        public string NewClientEmail { get; set; }
        public string NewClientPhone { get; set; }
        public bool NewClientCorporate { get; set; }

        public DateTime NewBookingDate { get; set; }
        public DateTime NewFilmingDate { get; set; }
        public string NewVideoType { get; set; }
        public string NewComment { get; set; }
        public bool NewPaid { get; set; }
        public double NewDeposit { get; set; }
        public string NewLocation { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

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

        public BookingViewModel()
        {
            Bookings = new ObservableRangeCollection<Booking>();
            Clients = new ObservableRangeCollection<Client>();

            AddCommand = new AsyncCommand(Add);
            RefreshCommand = new AsyncCommand(Refresh);
            RemoveCommand = new AsyncCommand<Booking>(Remove);
            
        }

        async Task Add()
        {
            DateTime bookingDate = NewBookingDate.Date;
            DateTime filmingDate = NewFilmingDate.Date;

            var client = await DbService.AddClient(NewClientName, NewClientEmail, NewClientPhone, NewClientCorporate);

            //adding booking
            await DbService.AddBooking(bookingDate, filmingDate, NewVideoType, NewComment, NewPaid, NewDeposit, NewLocation, client.Id);

            await Refresh();

        }
        async Task Remove(Booking booking)
        {
            await DbService.DeleteBooking(booking.Id);
            await Refresh();
        }
        async Task RemoveClient(Client client)
        {
            await DbService.DeleteClient(client.Id);
            await Refresh();
        }

       
        async Task Refresh()
        {
            try
            {
                IsBusy = true;
                await Task.Delay(2000);
                Bookings.Clear();

                var bookings = await DbService.GetBooking();

                bookings = bookings.OrderBy(x => x.FilmingDate).ToList();


                //foreach (var item in bookings)
                //{
                //    Bookings.Add(item);
                //}

                Bookings.AddRange(bookings);
                IsBusy = false;

            }
            catch (Exception ex)
            {

                throw;
            }
         


            
            
        }

    }
}
