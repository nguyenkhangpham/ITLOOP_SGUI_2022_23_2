using ITLOOP_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Clients;

namespace WpfApp1.ViewModels
{
    public class ModelsOfRenterViewModel : ObservableRecipient
    {
        private ApiClient _apiClient = new ApiClient();

        public ObservableCollection<CarStore> CarStores { get; set; }

        public RelayCommand Search { get; set; }

        private string _searchRenter;

        public string SearchRenter
        {
            get => _searchRenter;
            set
            {
                SetProperty(ref _searchRenter, value);
            }
        }

        public ModelsOfRenterViewModel()
        {
            CarStores = new ObservableCollection<CarStore>();
            Search = new RelayCommand(SearchRenters);
        }

        private void SearchRenters()
        {
            CarStores.Clear();
            string endpoint = "http://localhost:30439/carstore/getrenters/" + SearchRenter;
            _apiClient
                .GetAsync<List<CarStore>>(endpoint)
                .ContinueWith((carstore) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        carstore.Result.ForEach((carstore) =>
                        {
                            CarStores.Add(carstore);
                        });
                    });
                });
        }
    }
}
