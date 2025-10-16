using MauiBankingExercise.Models;

namespace MauiBankingExercise.Services
{
    public interface IBankingService
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(int customerId);
        Task<List<Account>> GetAccountByCustomerIdAsync(int customerId);
        Task<Account?> GetAccountByIdAsync(int accountId);
        Task<List<Transaction>> GetTransactionsByAccountIdAsync(int accountId);
        Task<List<TransactionType>> GetAllTransactionTypesAsync();
        Task<bool> CreateTransactionAsync(Transaction transaction);
        Task<bool> ValidateWithdrawalAsync(int accountId, decimal amount);
        Task<Customer?> GetCustomerByIdFullFetchAsync(int id);
        Task<List<CustomerDisplayModel>> GetCustomersWithBankAndTypeAsync();
        Task<CustomerDisplayModel?> GetCustomerDisplayModelByIdAsync(int customerId);
    }
}