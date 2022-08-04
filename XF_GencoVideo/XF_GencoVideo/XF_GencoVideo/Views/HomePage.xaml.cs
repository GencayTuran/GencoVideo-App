using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//YoutubeExplode
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using Xamarin.CommunityToolkit.UI.Views;

namespace XF_GencoVideo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            LoadVideo();
            //LoadProjects();


            VideoMediaElement = videoMediaElement;
        }

        public async void LoadProjects()
        {
            lstUpcomingProjects.BeginRefresh();
        }

        public static MediaElement VideoMediaElement { get; set; }
        public async void LoadVideo()
        {
            videoActivityIndicator.IsVisible = true;


            var youtube = new YoutubeClient();

            //video ID or URL
            var video = await youtube.Videos.GetAsync("https://youtu.be/tzjZAcOcpy4");

            //gets video properties from youtube
            var title = video.Title;
            var duration = video.Duration;

            //for getting the stream elements
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync("https://youtu.be/tzjZAcOcpy4");

            var streamInfo = streamManifest.GetVideoOnlyStreams().GetWithHighestVideoQuality();

            if (streamInfo != null)
            {
                //gets stream
                var stream = await youtube.Videos.Streams.GetAsync(streamInfo);

                videoMediaElement.Source = streamInfo.Url;
            }

            LblVideoTitle.Text = title;


        }

        private void VideoMediaElement_MediaOpened(object sender, EventArgs e)
        {
            videoActivityIndicator.IsVisible = false;
        }

        private async void ProfileButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//main/profile");
            //videoMediaElement.Pause();

        }

        private async void VideoElement_Tapped(object sender, EventArgs e)
        {
            //goes directly to tab
            await Shell.Current.GoToAsync("//videos");
        }

    }
}