using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Firebase.Database;
using Xamarin.Forms;
using XF_GencoVideo.Views;

namespace XF_GencoVideo.ViewModels
{
    public class RegistrationViewModel: INotifyPropertyChanged
    {


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
        public event PropertyChangedEventHandler PropertyChanged;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        private string confirmpassword;
        public string ConfirmPassword
        {
            get { return confirmpassword; }
            set
            {
                confirmpassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ConfirmPassword"));
            }
        }


        public Command RegisterCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (Password == ConfirmPassword)
                    {
                        Register();
                    }
                    else
                    {
                    App.Current.MainPage.DisplayAlert("", "Password must be same as above!", "OK");
                    }
                         
                });
            }
        }
        private async void Register()
        {
            //null or empty field validation, check weather email and password is null or empty    

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                //call AddUser function from FireBaseHelper 
                var user = await FireBaseHelper.AddUser(Email, Password, Nickname);
                //AddUser return true if data insert successfuly     
                if (user)
                {
                    await App.Current.MainPage.DisplayAlert("Registration Success", "", "Ok");
                    
                    //pass user email to HomePage    
                    await App.Current.MainPage.Navigation.PushAsync(new ProfilePage(Email));

                    //Navigate to HomePage after successfuly Register
                    await Shell.Current.GoToAsync("//login");
                    
                    //Set SecureStorage for remembering logs
                    await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "1");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Registration Fail", "OK");
                }

            }
        }
    }
}
