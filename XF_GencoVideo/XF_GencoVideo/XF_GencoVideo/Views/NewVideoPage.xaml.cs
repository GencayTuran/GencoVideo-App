using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF_GencoVideo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewVideoPage : ContentPage
    {
        public NewVideoPage()
        {
            InitializeComponent();
        }

        private async void BtnAddVideo_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//main");
        }
    }
}