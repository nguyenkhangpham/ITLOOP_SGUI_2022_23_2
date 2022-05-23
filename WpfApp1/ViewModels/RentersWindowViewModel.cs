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
    public class RentersWindowViewModel : ObservableRecipient
    {
        private ApiClient _apiClient = new ApiClient();

        public ObservableCollection<Renting> Renters { get; set; }

        public ObservableCollection<CarStore> CarStores { get; set; }

        private Renting _selectedRenter;

        public Renting SelectedRenter
        {
            get => _selectedRenter;
            set
            {
                SetProperty(ref _selectedRenter, value);
            }
        }

        private int _selectedRenterIndex;

        public int SelectedRenterIndex
        {
            get => _selectedRenterIndex;
            set
            {
                SetProperty(ref _selectedRenterIndex, value);
            }
        }

        private CarStore _selectedModel;

        public CarStore SelectedModel
        {
            get => _selectedModel;
            set
            {
                SetProperty(ref _selectedModel, value);
            }
        }

        private int _selectedModelIndex;

        public int SelectedModelIndex
        {
            get => _selectedModelIndex;
            set
            {
                SetProperty(ref _selectedModelIndex, value);
            }
        }

        public RelayCommand AddRenterCommand { get; set; }
        public RelayCommand EditRenterCommand { get; set; }
        public RelayCommand DeleteRenterCommand { get; set; }

        public RentersWindowViewModel()
        {
            Renters = new ObservableCollection<Renting>();
            CarStores = new ObservableCollection<CarStore>();
            _apiClient
                .GetAsync<List<Renting>>("http://localhost:30439/renting")
                .ContinueWith((renters) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        renters.Result.ForEach((renters) =>
                        {
                            Renters.Add(renters);
                        });
                    });
                });
            _apiClient
                .GetAsync<List<CarStore>>("http://localhost:30439/carstore")
                .ContinueWith((carstores) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        carstores.Result.ForEach((carstores) =>
                        {
                            CarStores.Add(carstores);
                        });
                    });
                });

            AddRenterCommand = new RelayCommand(AddRenter);
            EditRenterCommand = new RelayCommand(EditRenter);
            DeleteRenterCommand = new RelayCommand(DeleteRenter);
        }
        private string _nameOfRenter;

        public string NameOfRenter
        {
            get => _nameOfRenter;
            set
            {
                SetProperty(ref _nameOfRenter, value);
            }
        }

        private int _modelIDOfRenter;

        public int ModelIDOfRenter
        {
            get => _modelIDOfRenter;
            set
            {
                SetProperty(ref _modelIDOfRenter, value);
            }
        }

        private int _amountOfRenterer;

        public int AmountOfRenterer
        {
            get => _amountOfRenterer;
            set
            {
                SetProperty(ref _amountOfRenterer, value);
            }
        }

        private void AddRenter()
        {
            _apiClient
                .PostAsync(new Renting
                {
                    RenterName = NameOfRenter,
                    Amount = AmountOfRenterer,
                    Id = SelectedModelIndex + 1
                }, "http://localhost:5000/renting")
                .ContinueWith((task) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Renters.Add(new Renting
                        {
                            RenterName = NameOfRenter,
                            Amount = AmountOfRenterer,
                            CarId = SelectedModelIndex + 1,
                            Id = Renters.Count + 1
                        });
                    });
                }); ;
        }

        private void EditRenter()
        {
            _apiClient
                .PutAsync(SelectedRenter, "http://localhost:30439/renting")
                .ContinueWith((task) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                    });
                });
        }

        private void DeleteRenter()
        {
            _apiClient
                .DeleteAsync(SelectedRenter.Id, "http://localhost:30439/renting")
                .ContinueWith((task) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Renters.Remove(SelectedRenter);
                    });
                });
        }
    }
}
