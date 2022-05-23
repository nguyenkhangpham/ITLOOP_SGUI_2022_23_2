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
    public class ModelsWindowViewModel : ObservableRecipient
    {
        private ApiClient _apiClient = new ApiClient();


        public ObservableCollection<CarStore> CarStores { get; set; }
        public ObservableCollection<Car> Cars { get; set; }
        public ObservableCollection<string> kindOfCategory { get; set; }

        private CarStore _selectedCarStore;

        public CarStore SelectedCarStore
        {
            get => _selectedCarStore;
            set
            {
                SetProperty(ref _selectedCarStore, value);
            }
        }

        private int _selectedCarStoreIndex;

        public int SelectedCarStoreIndex
        {
            get => _selectedCarStoreIndex;
            set
            {
                SetProperty(ref _selectedCarStoreIndex, value);
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

        private string _selectedCategory;
        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                SetProperty(ref _selectedCategory, value);
            }
        }

        public RelayCommand AddModelCommand { get; set; }
        public RelayCommand EditModelCommand { get; set; }
        public RelayCommand DeleteModelCommand { get; set; }

        public ModelsWindowViewModel()
        {
            CarStores = new ObservableCollection<CarStore>();
            Cars = new ObservableCollection<Car>();
            kindOfCategory = new ObservableCollection<string>() { "Electronic", "Gasoline", "Sport", "Festival", "Supercar" };

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
            AddModelCommand = new RelayCommand(AddModel);
            EditModelCommand = new RelayCommand(EditModel);
            DeleteModelCommand = new RelayCommand(DeleteModel);
        }
        private string _nameOfModel;

        public string NameOfModel
        {
            get => _nameOfModel;
            set
            {
                SetProperty(ref _nameOfModel, value);
            }
        }

        private void AddModel()
        {
            _apiClient
                .PostAsync(new CarStore
                {
                    Name = NameOfModel,
                    Category = SelectedCategory,
                    Id = CarStores.Count + 1
                }, "http://localhost:5000/carstore")
                .ContinueWith((task) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        CarStores.Add(new CarStore
                        {
                            Name = NameOfModel,
                            Category = SelectedCategory,
                            Id= CarStores.Count + 1
                        });
                    });
                }); ;
        }

        private void EditModel()
        {
            _apiClient
                .PutAsync(SelectedCarStore, "http://localhost:30439/carstore")
                .ContinueWith((task) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                    });
                });
        }

        private void DeleteModel()
        {
            _apiClient
                .DeleteAsync(SelectedCarStore.Id, "http://localhost:30439/carstore")
                .ContinueWith((task) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        CarStores.Remove(SelectedCarStore);
                    });
                });
        }
    }
}
