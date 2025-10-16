using MauiBankingExercise.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace MauiBankingExercise.Services
{
    public class BankingApiService : IBankingService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public BankingApiService(HttpClient httpClient, string? baseUrl = null)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl ?? "https://localhost:7001";
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/customers");
                response.EnsureSuccessStatusCode();
                
                var customers = await response.Content.ReadFromJsonAsync<List<Customer>>();
                return customers ?? new List<Customer>();
            }
            catch (Exception)
            {
                return new List<Customer>();
            }
        }

        public async Task<Customer?> GetCustomerByIdAsync(int customerId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/customers/{customerId}");
                
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return null;
                
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Customer>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Account>> GetAccountByCustomerIdAsync(int customerId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/accounts/customer/{customerId}");
                response.EnsureSuccessStatusCode();
                
                var accounts = await response.Content.ReadFromJsonAsync<List<Account>>();
                return accounts ?? new List<Account>();
            }
            catch (Exception)
            {
                return new List<Account>();
            }
        }

        public async Task<Account?> GetAccountByIdAsync(int accountId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/accounts/{accountId}");
                
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return null;
                
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Account>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Transaction>> GetTransactionsByAccountIdAsync(int accountId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/transactions/account/{accountId}");
                response.EnsureSuccessStatusCode();
                
                var transactions = await response.Content.ReadFromJsonAsync<List<Transaction>>();
                return transactions ?? new List<Transaction>();
            }
            catch (Exception)
            {
                return new List<Transaction>();
            }
        }

        public async Task<List<TransactionType>> GetAllTransactionTypesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/transactions/types");
                response.EnsureSuccessStatusCode();
                
                var transactionTypes = await response.Content.ReadFromJsonAsync<List<TransactionType>>();
                return transactionTypes ?? new List<TransactionType>();
            }
            catch (Exception)
            {
                return new List<TransactionType>();
            }
        }

        public async Task<bool> CreateTransactionAsync(Transaction transaction)
        {
            try
            {
                var json = JsonSerializer.Serialize(transaction);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                var response = await _httpClient.PostAsync("api/transactions", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> ValidateWithdrawalAsync(int accountId, decimal amount)
        {
            try
            {
                var validationRequest = new { AccountId = accountId, Amount = amount };
                var json = JsonSerializer.Serialize(validationRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                var response = await _httpClient.PostAsync("api/transactions/validate-withdrawal", content);
                
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return false;
                
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadFromJsonAsync<bool>();
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Customer?> GetCustomerByIdFullFetchAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/customers/{id}/full");
                
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return null;
                
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Customer>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<CustomerDisplayModel>> GetCustomersWithBankAndTypeAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/customers/display");
                response.EnsureSuccessStatusCode();
                
                var customers = await response.Content.ReadFromJsonAsync<List<CustomerDisplayModel>>();
                return customers ?? new List<CustomerDisplayModel>();
            }
            catch (Exception)
            {
                return new List<CustomerDisplayModel>();
            }
        }

        public async Task<CustomerDisplayModel?> GetCustomerDisplayModelByIdAsync(int customerId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/customers/{customerId}/display");
                
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return null;
                
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<CustomerDisplayModel>();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}