using System.ComponentModel;
using Xamarin.Forms;
using XF_GencoVideo.ViewModels;

namespace XF_GencoVideo.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}