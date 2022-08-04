
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using XF_GencoVideo.Models;

namespace XF_GencoVideo.Services
{
    public static class DbService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            //making sure the database is already created
            if (db != null)
            {
                return;
            }
            // Get an absolute path to the database file
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "GencoVideoDb.db");

            db = new SQLiteAsyncConnection(databasePath);



            //method to delete all records in specified table
            //await db.DeleteAllAsync<Booking>();

            //drop specified table
            await db.DropTableAsync<Booking>();
            await db.DropTableAsync<Client>();

            await db.CreateTableAsync<Booking>();
            await db.CreateTableAsync<Client>();


        }
        #region Booking
        public static async Task AddBooking( DateTime bookingDate, DateTime filmingDate,
            string videoType, string comment, bool paid, double deposit, string location, int clientId)
        {
            await Init();

            var booking = new Booking
            {
                ClientId = clientId,
                BookingDate = bookingDate.Date, 
                FilmingDate = filmingDate.Date,
                VideoType = videoType,
                Comment = comment,
                Paid = paid,
                Deposit = deposit,
                Location = location
            };
           var id = await db.InsertAsync(booking);
        }
        public static async Task DeleteBooking(int id)
        {
            await Init();

            await db.DeleteAsync<Booking>(id);
        }
        public static async Task<IEnumerable<Booking>> GetBooking()
        {
            await Init();

            var booking = await db.Table<Booking>().ToListAsync();
            return booking;
        }
        #endregion

        #region Client
        public static async Task<Client> AddClient(string name, string email, string phone, bool corporate)
        {
            await Init();

            var client = new Client
            {
                ClientName = name,
                ClientEmail = email,
                ClientPhone = phone,
                Corporate = corporate
              
            };
            await db.InsertAsync(client);
            return client;
        }
        public static async Task DeleteClient(int id)
        {
            await Init();

            await db.DeleteAsync<Client>(id);
        }
        public static async Task<IEnumerable<Client>> GetClients()
        {
            await Init();

            var client = await db.Table<Client>().ToListAsync();
            return client;
        }
        #endregion

        #region Video
        //public static async Task AddVideo(DateTime bookingDate, DateTime filmingDate,
        //    string videoType, string comment, bool paid, double deposit, string location)
        //{
        //    await Init();

        //    var booking = new Booking
        //    {
        //        BookingDate = bookingDate.Date,
        //        FilmingDate = filmingDate.Date,
        //        VideoType = videoType,
        //        Comment = comment,
        //        Paid = paid,
        //        Deposit = deposit,
        //        Location = location
        //    };
        //    var id = await db.InsertAsync(booking);
        //}
        //public static async Task DeleteVideo(int id)
        //{
        //    await Init();

        //    await db.DeleteAsync<Booking>(id);
        //}
        //public static async Task<IEnumerable<Booking>> GetVideo()
        //{
        //    await Init();

        //    var booking = await db.Table<Booking>().ToListAsync();
        //    return booking;
        //}
        #endregion
    }
}
