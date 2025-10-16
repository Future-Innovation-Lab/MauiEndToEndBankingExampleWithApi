using MauiBankingExercise.Models;
using MauiBankingExercise.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using System;
using System.Linq;

namespace MauiBankingExercise.ViewModels
{
    [QueryProperty(nameof(AccountId), "accountId")]
    public partial class CreateTransactionViewModel : BaseViewModel
    {
        private readonly IBankingService _bankingService;

        [ObservableProperty]
        private Account? account;

        [ObservableProperty]
        private string accountId = string.Empty;

        [ObservableProperty]
        private decimal amount;

        [ObservableProperty]
        private string description = string.Empty;

        [ObservableProperty]
        private TransactionType? selectedTransactionType;

        [ObservableProperty]
        private ObservableCollection<TransactionType> transactionTypes = new();

        [ObservableProperty]
        private string validationMessage = string.Empty;

        [ObservableProperty]
        private bool isValid = false;

        public IAsyncRelayCommand SubmitTransactionCommand { get; }
        public IAsyncRelayCommand LoadDataCommand { get; }

        public CreateTransactionViewModel(IBankingService bankingService)
        {
            _bankingService = bankingService;
            Title = "Create Transaction";
            SubmitTransactionCommand = new AsyncRelayCommand(SubmitTransactionAsync);
            LoadDataCommand = new AsyncRelayCommand(LoadDataAsync);
        }

        partial void OnAccountIdChanged(string value)
        {
            if (int.TryParse(value, out int id))
            {
                _ = LoadAccountAsync(id);
            }
        }

        partial void OnAmountChanged(decimal value)
        {
            ValidateTransaction();
        }

        partial void OnSelectedTransactionTypeChanged(TransactionType? value)
        {
            ValidateTransaction();
        }

        partial void OnDescriptionChanged(string value)
        {
            ValidateTransaction();
        }

        public override async Task OnFirstAppearAsync()
        {
            await base.OnFirstAppearAsync();
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var types = await _bankingService.GetAllTransactionTypesAsync();
            TransactionTypes.Clear();
            foreach (var type in types)
            {
                TransactionTypes.Add(type);
            }

            if (int.TryParse(AccountId, out int id))
            {
                await LoadAccountAsync(id);
            }
        }

        private async Task LoadAccountAsync(int accountId)
        {
            Account = await _bankingService.GetAccountByIdAsync(accountId);
            if (Account != null)
            {
                Title = $"New Transaction - {Account.AccountNumber}";
            }
            // Trigger initial validation to ensure button state is correct
            ValidateTransaction();
        }

        private void ValidateTransaction()
        {
            IsValid = true;
            ValidationMessage = string.Empty;

            if (Amount <= 0)
            {
                IsValid = false;
                ValidationMessage = "Amount must be greater than zero.";
                return;
            }

            if (SelectedTransactionType == null)
            {
                IsValid = false;
                ValidationMessage = "Please select a transaction type.";
                return;
            }

            if (string.IsNullOrWhiteSpace(Description))
            {
                IsValid = false;
                ValidationMessage = "Description is required.";
                return;
            }

            if (Account == null)
            {
                IsValid = false;
                ValidationMessage = "Account information not available.";
                return;
            }

            // Check for withdrawal validation
            if (SelectedTransactionType.Name == "Withdrawal")
            {
                if (Amount > Account.AccountBalance)
                {
                    IsValid = false;
                    ValidationMessage = $"Insufficient funds. Available balance: {Account.AccountBalance:C}";
                    return;
                }
            }

            ValidationMessage = "Transaction is valid.";
        }

        private async Task SubmitTransactionAsync()
        {
            if (!IsValid || Account == null || SelectedTransactionType == null)
            {
                await Application.Current?.MainPage?.DisplayAlert("Error", ValidationMessage, "OK");
                return;
            }

            try
            {
                IsBusy = true;

                var transaction = new Transaction
                {
                    AccountId = Account.AccountId,
                    TransactionTypeId = SelectedTransactionType.TransactionTypeId,
                    Amount = SelectedTransactionType.Name == "Withdrawal" ? -Amount : Amount,
                    Description = Description,
                    TransactionDate = DateTime.Now
                };

                var success = await _bankingService.CreateTransactionAsync(transaction);

                if (success)
                {
                    await Application.Current?.MainPage?.DisplayAlert("Success", "Transaction completed successfully!", "OK");
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    await Application.Current?.MainPage?.DisplayAlert("Error", "Transaction failed. Please try again.", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current?.MainPage?.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
