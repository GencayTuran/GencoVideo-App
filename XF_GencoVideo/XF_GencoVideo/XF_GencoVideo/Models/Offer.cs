using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XF_GencoVideo.Models
{
    public class Offer : UpcomingProjects
    {
        [PrimaryKey]
        public string VideoType { get; set; }
        public double StartPrice { get; set; }
        public string OfferInfo { get; set; }

        public Offer(string videoType, double startPrice, string offerInfo)
        {
            VideoType = videoType;
            StartPrice = startPrice;
            OfferInfo = offerInfo;
        }
    }
}
