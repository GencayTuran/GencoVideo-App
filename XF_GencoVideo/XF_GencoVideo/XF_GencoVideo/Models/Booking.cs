using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using static XF_GencoVideo.ViewModels.HomeViewModel;

namespace XF_GencoVideo.Models
{
    public class Booking : BaseModel
    {
        public DateTime BookingDate { get; set; }
        public string Comment { get; set; }
        public bool Paid { get; set; }
        public double Deposit { get; set; }
        public string Location { get; set; }

        [ForeignKey(typeof(Client))]
        public int ClientId { get; set; }

        //public Booking(string bookingId, string adminId, DateTime bookingDate, DateTime filmingDate, string typeVideo, string comment, bool paid, double deposit)
        //{
        //    BookingId = bookingId;
        //    AdminId = adminId;
        //    BookingDate = bookingDate;
        //    FilmingDate = filmingDate;
        //    TypeVideo = typeVideo;
        //    Comment = comment;
        //    Paid = paid;
        //    Deposit = deposit;
        //}

    }
}
