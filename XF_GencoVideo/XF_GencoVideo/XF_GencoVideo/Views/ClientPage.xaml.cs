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
    public partial class ClientPage : ContentPage
    {
        public ClientPage()
        {
            InitializeComponent();
            //Load();
        }

        public async void Load()
        {
            MyClients.BeginRefresh();
            //CheckCorporate();
        }

        //private async void CheckCorporate()
        //{
        //   var lblCorporate = MyClients.FindByName<Label>("LblCorporate").Text;

        //    if (lblCorporate == "True")
        //    {
        //        lblCorporate = "Corporate";
        //    }
        //    else
        //    {
        //        lblCorporate = "Non-Corporate";
        //    }
         
        //}

        private async void BtnNewClient_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//main/newclient");
        }

        //private void BtnCheckCorp_Clicked(object sender, EventArgs e)
        //{
        //    CheckCorporate();
        //}
    }
}