using ITLOOP_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Clients;
using System.ComponentModel;
using System.Windows;


namespace WpfApp1.ViewModels
{
    public class CarsWindowViewModel : ObservableRecipient
    {
        private ApiClient _apiClient = new ApiClient();

        public ObservableCollection<Car> Cars { get; set; }

        private Car _selectedCar;
        public Car SelectedCar
        {
            get => _selectedCar;
            set
            {
                SetProperty(ref _selectedCar, value);
            }
        }

        private int _selectedCarIndex;

        public int SelectedCarIndex
        {
            get => _selectedCarIndex;
            set
            {
                SetProperty(ref _selectedCarIndex, value);
            }
        }

        public RelayCommand AddCarCommand { get; set; }
        public RelayCommand EditCarCommand { get; set; }
        public RelayCommand DeleteCarCommand { get; set; }
        public CarsWindowViewModel()
        {
            Cars = new ObservableCollection<Car>();

            _apiClient
                .GetAsync<List<Car>>("http://localhost:30439/car")
                .ContinueWith((cars) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        cars.Result.ForEach((cars) =>
                        {
                            Cars.Add(cars);
                        });
                    });
                });

            AddCarCommand = new RelayCommand(AddCar);
            EditCarCommand = new RelayCommand(EditCar);
            DeleteCarCommand = new RelayCommand(DeleteCar);
        }
        private string _nameOfCar;

        public string NameOfCar
        {
            get => _nameOfCar;
            set
            {
                SetProperty(ref _nameOfCar, value);
            }
        }
        private void AddCar()
        {
            _apiClient
                .PostAsync(new Car
                {
                    CarName = NameOfCar,
                }, "http://localhost:30439/car")
                .ContinueWith((task) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Cars.Add(new Car
                        {
                            CarName = NameOfCar,
                            Id = Cars.Count + 1
                        });
                    });
                }); ;
        }

        private void EditCar()
        {
            _apiClient
                .PutAsync(SelectedCar, "http://localhost:30439/car")
                .ContinueWith((task) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                    });
                });
        }

        private void DeleteCar()
        {
            _apiClient
                .DeleteAsync(SelectedCar.Id, "http://localhost:30439/car")
                .ContinueWith((task) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Cars.Remove(SelectedCar);
                    });
                });
        }

    }
}
