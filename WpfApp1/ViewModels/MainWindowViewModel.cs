using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Windows;


namespace WpfApp1.ViewModels
{
    public class MainWindowViewModel
    {
        public RelayCommand ManageCarsCommand { get; set; }
        public RelayCommand ManageCarStoresCommand { get; set; }
        public RelayCommand ManageRentingsCommand { get; set; }

        public RelayCommand RentersOfModel { get; set; }
        public RelayCommand ModelsOfRenter { get; set; }
        public RelayCommand CarStoreInfor { get; set; }
        public RelayCommand MostExpensiveCar { get; set; }

        public MainWindowViewModel()
        {
            ManageCarsCommand = new RelayCommand(OpenCarsWindow);
            ManageCarStoresCommand = new RelayCommand(OpenModelsWindow);
            ManageRentingsCommand = new RelayCommand(OpenRentersWindow);
            RentersOfModel = new RelayCommand(OpenRentersOfModelWindow);
            ModelsOfRenter = new RelayCommand(OpenModelsOfRenterWindow);
            CarStoreInfor = new RelayCommand(OpenCarStoreInforWindow);
            MostExpensiveCar = new RelayCommand(OpenMostExpensiveCarrWindow);
        }

        private void OpenCarsWindow()
        {
            new CarsWindow().Show();
        }
        private void OpenModelsWindow()
        {
            new ModelsWindow().Show();
        }
        private void OpenRentersWindow()
        {
            new RentersWindow().Show();
        }

        private void OpenRentersOfModelWindow()
        {
            new RentersOfModelWindow().Show();
        }

        private void OpenModelsOfRenterWindow()
        {
            new ModelsOfRenterWindow().Show();
        }

        private void OpenCarStoreInforWindow()
        {
            new CarStoreInforWindow().Show();
        }

        private void OpenMostExpensiveCarrWindow()
        {
            new MostExpensiveCar().Show();
        }

    }
}
