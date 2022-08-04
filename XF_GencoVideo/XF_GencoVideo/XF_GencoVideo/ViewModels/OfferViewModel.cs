using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XF_GencoVideo.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace XF_GencoVideo.ViewModels
{
    public class OfferViewModel
    {
        public ObservableCollection<Offer> Offers { get; set; }
        public ICommand AddOfferCommand => new Command(AddOffer); //connects with the void
        public ICommand RemoveOfferCommand => new Command(RemoveOffer); //connects with the void
        public string NewOffer { get; set; } //gets value from view (user input)


        public OfferViewModel()
        {
            //creating an empty observable collection for pricelist
            Offers = new ObservableCollection<Offer>
            {
                //adding the Offers
                new Offer("DGN", 500,""),
                new Offer("PROMO", 350, ""),
                new Offer("SOZ", 350, "")
            };

            //the same thing:
            //Offers.Add(new Offer("DGN", 500, ""));
            //Offers.Add(new Offer("PROMO", 350, ""));
            //Offers.Add(new Offer("SOZ", 350, ""));
        }

        void AddOffer()
        {
            //user input value gets added to ObservableCollection
            Offers.Add(new Offer(NewOffer, 0, ""));
        }

        void RemoveOffer(object o)
        {
            //user input value gets added to ObservableCollection
            Offer offerBeingRemoved = o as Offer;
            Offers.Remove(offerBeingRemoved);
            //Console.WriteLine(offerBeingRemoved.TypeVideo);
        }


    }
}
