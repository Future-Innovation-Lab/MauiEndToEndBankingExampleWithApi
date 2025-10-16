
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiBankingExercise.Services;
using MauiBankingExercise.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MauiBankingExercise.ViewModels
{
    public partial class CustomersViewModel : BaseViewModel
    {
        private readonly IBankingService _bankingService;
        private List<Customer> _allCustomers = new();
        public ObservableCollection<Customer> Customers { get; } = new();

        [ObservableProperty]
        private Customer? selectedCustomer;

        [ObservableProperty]
        private string searchText = string.Empty;

        public ICommand CustomerSelectedCommand { get; }
        public IAsyncRelayCommand LoadCustomersCommand { get; }
        public IRelayCommand SearchCommand { get; }

        public CustomersViewModel(IBankingService bankingService)
        {
            _bankingService = bankingService;
            CustomerSelectedCommand = new RelayCommand(OnCustomerSelectionChanged);
            LoadCustomersCommand = new AsyncRelayCommand(LoadCustomersAsync);
            SearchCommand = new RelayCommand(PerformSearch);
            Title = "Customers";
        }

        public override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();
            SelectedCustomer = null; // Clear selection when returning to view
            await LoadCustomersAsync();
        }

        private async Task LoadCustomersAsync()
        {
            var customers = await _bankingService.GetAllCustomersAsync();
            _allCustomers = customers;
            Customers.Clear();
            foreach (var customer in customers)
                Customers.Add(customer);
        }

        partial void OnSearchTextChanged(string value)
        {
            PerformSearch();
        }

        private void PerformSearch()
        {
            Customers.Clear();
            
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                // Show all customers if search is empty
                foreach (var customer in _allCustomers)
                    Customers.Add(customer);
            }
            else
            {
                // Filter customers based on search text
                var filteredCustomers = _allCustomers.Where(c => 
                    c.FirstName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                    c.LastName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                    c.Email.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                    c.Bank?.BankName?.Contains(SearchText, StringComparison.OrdinalIgnoreCase) == true ||
                    c.CustomerType?.Name?.Contains(SearchText, StringComparison.OrdinalIgnoreCase) == true);
                    
                foreach (var customer in filteredCustomers)
                    Customers.Add(customer);
            }
        }

        private async void OnCustomerSelected(Customer? customer)
        {
            if (customer == null)
                return;
                
            var navParams = new ShellNavigationQueryParameters
            {
                { "customerId", customer.CustomerId.ToString() }
            };
            await Shell.Current.GoToAsync("CustomerDashboardView", navParams);
            
            // Clear selection to allow re-selection
            SelectedCustomer = null;
        }

        private void OnCustomerSelectionChanged()
        {
            if (SelectedCustomer != null)
            {
                OnCustomerSelected(SelectedCustomer);
            }
        }
    }
}
