using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF_GencoVideo.Services;
using XF_GencoVideo.Views;

namespace XF_GencoVideo
{
    public partial class App : Application
    {

        public App()
        {
            Device.SetFlags(new string[] { "MediaElement_Experimental" });
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            //MainPage = new NavigationPage(new LoginPage());

            //await Shell.Current.GoToAsync("//LoginPage");
            try
            {
            var isLogged = Xamarin.Essentials.SecureStorage.GetAsync("isLogged").Result;
            if (isLogged == "1")
            {
                //MainPage = new NavigationPage(new NewVideoPage());

                MainPage = new AppShell();
                Shell.Current.GoToAsync("//main");
            }
            else
            {
                //MainPage = new NavigationPage(new LoginPage());
                MainPage = new AppShell();
            }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
