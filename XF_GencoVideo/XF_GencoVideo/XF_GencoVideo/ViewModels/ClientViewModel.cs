using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using XF_GencoVideo.Models;
using XF_GencoVideo.Services;

namespace XF_GencoVideo.ViewModels
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        public ObservableRangeCollection<Client> Clients { get; set; }

        //Command
        public AsyncCommand AddCommand { get; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Client> RemoveCommand { get; }


        //inputs new booking
        public string NewClientName { get; set; }
        public string NewClientEmail { get; set; }
        public string NewClientPhone { get; set; }
        public bool NewClientCorporate { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IsBusy"));
            }
        }

        public ClientViewModel()
        {
            Clients = new ObservableRangeCollection<Client>();

            AddCommand = new AsyncCommand(Add);
            RefreshCommand = new AsyncCommand(Refresh);
            RemoveCommand = new AsyncCommand<Client>(Remove);
        }

        async Task Add()
        {
          //bool to string here

            await DbService.AddClient(NewClientName, NewClientEmail,
                NewClientPhone, NewClientCorporate);

            await Refresh();
        }
        async Task Remove(Client client)
        {
            await DbService.DeleteClient(client.Id);
            await Refresh();
        }


        async Task Refresh()
        {
            try
            {
                IsBusy = true;
                await Task.Delay(2000);
                Clients.Clear();

                var clients = await DbService.GetClients();

                //foreach (var item in clients)
                //{
                //    Clients.Add(item);
                //}

                Clients.AddRange(clients);
                IsBusy = false;

            }
            catch (Exception ex)
            {

                throw;
            }





        }
    }
}
