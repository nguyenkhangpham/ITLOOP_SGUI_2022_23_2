using ITLOOP_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
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
    public class MostExpensiveCarViewModel : ObservableRecipient
    {
        private ApiClient _apiClient = new ApiClient();

        public ObservableCollection<Renting> Renters { get; set; }

        public MostExpensiveCarViewModel()
        {
            Renters = new ObservableCollection<Renting>();
            Show();
        }

        private void Show()
        {
            Renters.Clear();
            string endpoint = "http://localhost:30439/renting/themostexpensivecar";
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
