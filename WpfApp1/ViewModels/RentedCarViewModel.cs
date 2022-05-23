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
    public class RentedCarViewModel : ObservableRecipient
    {
        private ApiClient _apiClient = new ApiClient();

        public ObservableCollection<Renting> Renters { get; set; }

        public RelayCommand Search { get; set; }

        private string _searchCar;

        public string SearchCar
        {
            get => _searchCar;
            set
            {
                SetProperty(ref _searchCar, value);
            }
        }

        public RentedCarViewModel()
        {
            Renters = new ObservableCollection<Renting>();
            Search = new RelayCommand(SearchModels);
        }

        private void SearchModels()
        {
            Renters.Clear();
            string endpoint = "http://localhost:30439/car/rentedcar/" + SearchCar;
            _apiClient
                .GetAsync<List<Renting>>(endpoint)
                .ContinueWith((renter) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        renter.Result.ForEach((renter) =>
                        {
                            Renters.Add(renter);
                        });
                    });
                });
        }
    }
}
