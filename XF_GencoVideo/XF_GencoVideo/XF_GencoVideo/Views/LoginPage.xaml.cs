using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF_GencoVideo.ViewModels;

namespace XF_GencoVideo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

        

        }

        //public static void ClearInputs()
        //{
        //    UserViewModel userVM = new UserViewModel();

        //    if (userVM.Succes)
        //    {
        //        EmailEntry.Text = string.Empty;
        //        PasswordEnrty.Text = string.Empty;
        //    }

        //}

      
 

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//login/registration");
        }
    }
}