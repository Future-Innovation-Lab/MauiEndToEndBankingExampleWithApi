using MauiBankingExercise.Models;
using MauiBankingExercise.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiBankingExercise.ViewModels
{
    [QueryProperty(nameof(CustomerId), "customerId")]
    public partial class CustomerDashboardViewModel : BaseViewModel
    {
        private readonly IBankingService _bankingService;

        [ObservableProperty]
        private Customer? customer;

        [ObservableProperty]
        private ObservableCollection<Account> accounts = new();

        [ObservableProperty]
        private string customerId = string.Empty;

        [ObservableProperty]
        private Account? selectedAccount;

        public ICommand AccountSelectedCommand { get; }

        public CustomerDashboardViewModel(IBankingService bankingService)
        {
            _bankingService = bankingService;
            Title = "Customer Dashboard";
            AccountSelectedCommand = new RelayCommand(OnAccountSelectionChanged);
        }

        partial void OnCustomerIdChanged(string value)
        {
            if (int.TryParse(value, out int id))
            {
                _ = LoadCustomerAsync(id);
                _ = LoadAccountsAsync(id);
            }
        }

        public override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();
            SelectedAccount = null; // Clear selection when returning to view
        }

        private async Task LoadCustomerAsync(int customerId)
        {
            Customer = await _bankingService.GetCustomerByIdAsync(customerId);
        }

        private async Task LoadAccountsAsync(int customerId)
        {
            var accounts = await _bankingService.GetAccountByCustomerIdAsync(customerId);
            Accounts.Clear();
            foreach (var account in accounts)
            {
                Accounts.Add(account);
            }
        }

        private async void OnAccountSelected(Account? account)
        {
            if (account == null)
                return;

            var navParams = new ShellNavigationQueryParameters
            {
                { "accountId", account.AccountId.ToString() }
            };
            await Shell.Current.GoToAsync("AccountDetailsView", navParams);
            
            // Clear selection to allow re-selection
            SelectedAccount = null;
        }

        private void OnAccountSelectionChanged()
        {
            if (SelectedAccount != null)
            {
                OnAccountSelected(SelectedAccount);
            }
        }
    }
}
