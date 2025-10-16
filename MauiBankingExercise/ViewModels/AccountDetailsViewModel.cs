using MauiBankingExercise.Models;
using MauiBankingExercise.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MauiBankingExercise.ViewModels
{
    [QueryProperty(nameof(AccountId), "accountId")]
    public partial class AccountDetailsViewModel : BaseViewModel
    {
        private readonly IBankingService _bankingService;

        [ObservableProperty]
        private Account? account;

        [ObservableProperty]
        private ObservableCollection<Transaction> transactions = new();

        [ObservableProperty]
        private string accountId = string.Empty;

        [ObservableProperty]
        private Transaction? selectedTransaction;

        public IAsyncRelayCommand LoadDataCommand { get; }
        public IAsyncRelayCommand CreateTransactionCommand { get; }
        public IRelayCommand TransactionSelectedCommand { get; }

        public AccountDetailsViewModel(IBankingService bankingService)
        {
            _bankingService = bankingService;
            Title = "Account Details";
            LoadDataCommand = new AsyncRelayCommand(LoadDataAsync);
            CreateTransactionCommand = new AsyncRelayCommand(NavigateToCreateTransactionAsync);
            TransactionSelectedCommand = new RelayCommand(OnTransactionSelectionChanged);
        }

        partial void OnAccountIdChanged(string value)
        {
            if (int.TryParse(value, out int id))
            {
                _ = LoadAccountAsync(id);
                _ = LoadTransactionsAsync(id);
            }
        }

        public override async Task OnFirstAppearAsync()
        {
            await base.OnFirstAppearAsync();
            // Data loading is handled in OnAppearingAsync() to avoid double loading
        }

        public override async Task OnAppearingAsync()
        {
            await base.OnAppearingAsync();
            // Refresh data every time the page appears (including when returning from CreateTransactionView)
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            if (int.TryParse(AccountId, out int id))
            {
                await LoadAccountAsync(id);
                await LoadTransactionsAsync(id);
            }
        }

        private async Task LoadAccountAsync(int accountId)
        {
            Account = await _bankingService.GetAccountByIdAsync(accountId);
            if (Account != null)
            {
                Title = $"Account: {Account.AccountNumber}";
            }
        }

        private async Task LoadTransactionsAsync(int accountId)
        {
            var transactions = await _bankingService.GetTransactionsByAccountIdAsync(accountId);
            Transactions.Clear();
            foreach (var transaction in transactions)
            {
                Transactions.Add(transaction);
            }
        }

        private async Task NavigateToCreateTransactionAsync()
        {
            if (Account == null) return;

            var navParams = new ShellNavigationQueryParameters
            {
                { "accountId", Account.AccountId.ToString() }
            };
            await Shell.Current.GoToAsync("CreateTransactionView", navParams);
        }

        private void OnTransactionSelectionChanged()
        {
            if (SelectedTransaction != null)
            {
                SelectedTransaction = null;
            }
        }
    }
}
