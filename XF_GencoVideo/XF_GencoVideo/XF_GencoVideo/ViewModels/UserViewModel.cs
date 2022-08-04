using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Firebase.Database;
using System.ComponentModel;
using XF_GencoVideo.Views;

namespace XF_GencoVideo.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        //declaration nickname, email and password
        public event PropertyChangedEventHandler PropertyChanged;
        private string email;
        public string Email { get; set; }

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

        public UserViewModel()
        {
            var emailToken = Xamarin.Essentials.SecureStorage.GetAsync("tokenEmail").Result;
            Email = emailToken;
        }

        //Logout Command
        public Command LogOutCommand
        {
            get
            {
                return new Command(() =>
                {
                    Shell.Current.GoToAsync("//login");
                    Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "0");
                    

                });
            }
        }

        //update user email password and nickname??
        public Command UpdateCommand

        {
            get { return new Command(Update); }
        }
        private async void Update()
        {
            

            try
            {
                if (!string.IsNullOrEmpty(Password))
                {
                    var isupdate = await FireBaseHelper.UpdateUser(Email, Password);
                    if (isupdate)
                        await App.Current.MainPage.DisplayAlert("Update Success", "", "Ok");
                    else
                        await App.Current.MainPage.DisplayAlert("Error", "Record not updated", "Ok");
                }
                else
                    await App.Current.MainPage.DisplayAlert("Password Require", "Please Enter your password", "Ok");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error:{e}");
            }
        }

        //delete user
        public Command DeleteCommand

        {
            get { return new Command(Delete); }
        }
        private async void Delete()
        {
            try
            {
                var isdelete = await FireBaseHelper.DeleteUser(Email);
                if (isdelete)
                {
                    await Xamarin.Essentials.SecureStorage.SetAsync("isLogged", "0");
                    await Shell.Current.GoToAsync("//login");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Record not delete", "Ok");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine($"Error:{e}");
            }
        }

    }
}
