using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XF_GencoVideo.ViewModels;
using XF_GencoVideo.Views;

namespace XF_GencoVideo
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            Device.SetFlags(new string[] { "MediaElement_Experimental" });
            InitializeComponent();

            Routing.RegisterRoute("registration", typeof(RegistrationPage));
            Routing.RegisterRoute("profile", typeof(ProfilePage));
            Routing.RegisterRoute("newbooking", typeof(NewBookingPage));
            Routing.RegisterRoute("newclient", typeof(NewClientPage));
            Routing.RegisterRoute("newvideo", typeof(NewVideoPage));
        }

    }
}
