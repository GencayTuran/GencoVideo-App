using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using XF_GencoVideo.Models;

namespace XF_GencoVideo.ViewModels
{
    public class FireBaseHelper
    {
        //connect app wth firebase using API Url
        public static FirebaseClient firebase = new FirebaseClient("https://xfgencovideo-default-rtdb.europe-west1.firebasedatabase.app/");

        #region User
        //Read All
        public static async Task<List<User>> GetAllUsers()
        {
            try
            {
                var userlist = (await firebase
                .Child("Users")
                .OnceAsync<User>()).Select(item =>
                new User
                {
                    Email = item.Object.Email,
                    Password = item.Object.Password,
                    Nickname = item.Object.Nickname //
                }).ToList();
                return userlist;
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Read
        public static async Task<User> GetUser(string email)
        {
            try
            {
                var allUsers = await GetAllUsers();
                await firebase
                .Child("Users")
                .OnceAsync<User>();
                return allUsers.Where(a => a.Email == email).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error:{e}");

                return null;
            }
        }

        //Insert a User
        public static async Task<bool> AddUser(string email, string password, string nickname)
        {
            //auto id using Guid
            Guid guid = Guid.NewGuid();
            string userId = $"USER_{guid}";

            //string userId;
            ////custom auto id
            //if (GetAllUsers().Result != null)
            //{
            //int idCount = GetAllUsers().Result.Count;
            //userId = $"USER_{idCount + 1}";
            //}
            //else
            //{
            //userId = $"USER_1";
            //}

            try
            {
                await firebase
                .Child("Users")
                .PostAsync(new User() { UserId = userId, Email = email, Password = password, Nickname = nickname }); //
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error:{e}");
                return false;
            }
            

        }

        //Update
        public static async Task<bool> UpdateUser(string email, string password)
        {
            try
            {
                var updateUser = (await firebase
                .Child("Users")
                .OnceAsync<User>()).Where(a => a.Object.Email == email).FirstOrDefault();
                await firebase
                .Child("Users")
                .Child(updateUser.Key)
                .PutAsync(new User() { Email = email, Password = password});
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Delete User    
        public static async Task<bool> DeleteUser(string email)
        {
            try
            {
                var deleteUser = (await firebase
                .Child("Users")
                .OnceAsync<User>()).Where(a => a.Object.Email == email).FirstOrDefault();
                await firebase.Child("Users").Child(deleteUser.Key).DeleteAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error:{e}");
                return false;
            }
        }
        #endregion

       
       

        //public async Task CreateId(string clientId, string bookingId)
        //{
        //    //auto id using Guid
        //    Guid guidBooking = Guid.NewGuid();
        //    bookingId = $"BOOKING_{guidBooking}"; //auto id using Guid

        //    Guid guidClient = Guid.NewGuid();
        //    clientId = $"CLIENT_{guidClient}";
        //}


    }


}

