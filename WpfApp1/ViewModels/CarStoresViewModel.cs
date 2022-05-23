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
    public class CarStoresViewModel : ObservableRecipient
    {
        private ApiClient _apiClient = new ApiClient();

        public ObservableCollection<Car> Cars { get; set; }

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

        public CarStoresViewModel()
        {
            Cars = new ObservableCollection<Car>();
            Search = new RelayCommand(SearchRenters);
        }

        private void SearchRenters()
        {
            Cars.Clear();
            string endpoint = "http://localhost:30439/carstore/carstores/" + SearchCar;
            _apiClient
                .GetAsync<List<Car>>(endpoint)
                .ContinueWith((car) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        car.Result.ForEach((car) =>
                        {
                            Cars.Add(car);
                        });
                    });
                });
        }
    }
}

