using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLite;

namespace XF_GencoVideo.Models
{
    public class Video : UpcomingProjects
    {
        //videoUrl is the unique Id that we get from the youtube Url (via user input)
        [PrimaryKey]
        public string VideoUrl { get; set; }
        public string VideoName { get; set; }
        public string Description { get; set; }

        //bookingId foreign key here

        //public Video(string videoUrl, int bookingId, string description)
        //{
        //    VideoUrl = videoUrl;
        //    BookingId = bookingId;
        //    Description = description;
        //}

    }


}
