using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using XF_GencoVideo.Views;
using Firebase.Database;

namespace XF_GencoVideo.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //public Command LoginCommand { get; }

        public LoginViewModel()
        {
            //LoginCommand = new Command(OnLoginClicked);
        }


        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public Command LoginCommand
        {
            get
            {
                return new Command(Login);
            }
        }

        private async void Login()
        {
            //null or empty field validation, check weather email and password is null or empty    

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                //call GetUser function which we define in Firebase helper class    
                var user = await FireBaseHelper.GetUser(Email);
                //firebase return null valuse if user data not found in database    
                if (user != null)
                    if (Email == user.Email && Password == user.Password)
                    {

                        await App.Current.MainPage.DisplayAlert("Login Success", "", "Ok");

                        //pass Confirmation to login
                        //await App.Current.MainPage.Navigation.PushAsync(new LoginPage(successful));

                        //Navigate to HomePage page after successfuly login    
                        await Shell.Current.GoToAsync("//main");

                        //Set SecureStorage for remembering logs
                        await Xamarin.Essentials.SecureStorage.SetAsync("tokenEmail", Email);
                        await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "1");

                    }
                    else
                        await App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
                else
                    await App.Current.MainPage.DisplayAlert("Login Fail", "User not found", "OK");
            }
        }

        public async void GoToMainAsync()
        {
            await Shell.Current.GoToAsync("//main");
        }

        //private async void OnLoginClicked(object obj)
        //{
        //    // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
        //    await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        //}
    }
}
