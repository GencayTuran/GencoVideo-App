using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF_GencoVideo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewBookingPage : ContentPage
    {
        public NewBookingPage()
        {
            InitializeComponent();
            Load();

        }

        public void Load()
        {
            BookingDatePicker.Date = DateTime.Now.Date;
            FilmingDatePicker.Date = DateTime.Now.Date;

            //hard coded videoTypes (TODO)
            string[] lstTypes = { "DGN", "NSN", "SOZ", "PROMO", "OTHER"};

            foreach ( string item in lstTypes)
            {
                VideoTypePicker.Items.Add(item);
            }

        }

        private void BtnToday_Clicked(object sender, EventArgs e)
        {

        }

        private async void BtnAddBooking_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//main");
        }
    }
}