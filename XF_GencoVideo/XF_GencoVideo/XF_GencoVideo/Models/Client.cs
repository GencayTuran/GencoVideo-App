using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace XF_GencoVideo.Models
{
    public class Client : BaseModel
    {   
        public string ClientEmail { get; set; }
        public string ClientPhone { get; set; }
        public bool Corporate { get; set; }

        [OneToMany]
        public List<Booking> Bookings { get; set; }

        //public Client(string name, string email, string phone, bool corporate)
        //{
        //    Name = name;
        //    Email = email;
        //    Phone = phone;
        //    Corporate = corporate;
        //}

    }
}
