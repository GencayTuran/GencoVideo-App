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
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        public ProfilePage(string email)
        {
            //UserViewModel userVM = new UserViewModel();
            //var emailToken = Xamarin.Essentials.SecureStorage.GetAsync("tokenEmail");
            //email = userVM.Email;
        }

        //protected override bool OnBackButtonPressed()
        //{
        //    base.OnBackButtonPressed();
        //    HomePage.VideoMediaElement.Play();
        //    return true;
        //}

        
    }
}