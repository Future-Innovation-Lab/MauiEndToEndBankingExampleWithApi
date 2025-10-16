using MauiBankingExercise.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;

namespace MauiBankingExercise.Services
{
    public class BankingDatabaseService : IBankingService
    {
        private SQLiteConnection _dbConnection;

        public string GetDatabasePath()
        {
            string filename = "banking.db";
            string pathToDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(pathToDb, filename);
        }

        public BankingDatabaseService()
        {
            string dbPath = GetDatabasePath();
            _dbConnection = new SQLiteConnection(dbPath);

            BankingSeeder.Seed(_dbConnection);
        }

        public Task<List<Customer>> GetAllCustomersAsync()
        {
            return Task.Run(() =>
            {
                var customers = _dbConnection.Table<Customer>().ToList();
                
                foreach (var customer in customers)
                {
                    customer.Bank = _dbConnection.Table<Bank>().FirstOrDefault(b => b.BankId == customer.BankId);
                    customer.Accounts = _dbConnection.Table<Account>().Where(a => a.CustomerId == customer.CustomerId).ToList();
                    customer.CustomerType = _dbConnection.Table<CustomerType>().FirstOrDefault(ct => ct.CustomerTypeId == customer.CustomerTypeId);
                }
                
                return customers;
            });
        }

        public Task<Customer?> GetCustomerByIdAsync(int customerId)
        {
            return Task.Run(() => (Customer?)_dbConnection.Table<Customer>().FirstOrDefault(c => c.CustomerId == customerId));
        }

        public Task<List<Account>> GetAccountByCustomerIdAsync(int customerId)
        {
            return Task.Run(() => _dbConnection.Table<Account>().Where(x => x.CustomerId == customerId).ToList());
        }

        public Task<Account?> GetAccountByIdAsync(int accountId)
        {
            return Task.Run(() => (Account?)_dbConnection.Table<Account>().FirstOrDefault(a => a.AccountId == accountId));
        }

        public Task<List<Transaction>> GetTransactionsByAccountIdAsync(int accountId)
        {
            return Task.Run(() => _dbConnection.Table<Transaction>().Where(t => t.AccountId == accountId).OrderByDescending(t => t.TransactionDate).ToList());
        }

        public Task<List<TransactionType>> GetAllTransactionTypesAsync()
        {
            return Task.Run(() => _dbConnection.Table<TransactionType>().ToList());
        }

        public Task<bool> CreateTransactionAsync(Transaction transaction)
        {
            return Task.Run(() =>
            {
                try
                {
                    // Start a transaction for both operations
                    _dbConnection.BeginTransaction();

                    // Insert the new transaction
                    _dbConnection.Insert(transaction);

                    // Update account balance
                    var account = _dbConnection.Table<Account>().FirstOrDefault(a => a.AccountId == transaction.AccountId);
                    if (account != null)
                    {
                        // For deposits, amount is positive; for withdrawals, amount should be negative
                        account.AccountBalance += transaction.Amount;
                        _dbConnection.Update(account);
                    }

                    _dbConnection.Commit();
                    return true;
                }
                catch
                {
                    _dbConnection.Rollback();
                    return false;
                }
            });
        }

        public async Task<bool> ValidateWithdrawalAsync(int accountId, decimal amount)
        {
            var account = await GetAccountByIdAsync(accountId);
            return account != null && account.AccountBalance >= amount;
        }

        public Task<Customer?> GetCustomerByIdFullFetchAsync(int id)
        {
            return Task.Run(() =>
            {
                var customer = _dbConnection.Table<Customer>().Where(x => x.CustomerId == id).FirstOrDefault();

                if (customer != null)
                    _dbConnection.GetChildren(customer, true);

                return (Customer?)customer;
            });
        }

        public Task<List<CustomerDisplayModel>> GetCustomersWithBankAndTypeAsync()
        {
            return Task.Run(() =>
            {
                var query = @"
                    SELECT 
                        c.CustomerId,
                        c.FirstName,
                        c.LastName,
                        c.Email,
                        c.PhoneNumber,
                        c.PhysicalAddress,
                        c.IdentityNumber,
                        c.Nationality,
                        c.BankId,
                        b.BankName,
                        b.BankAddress,
                        b.BranchCode,
                        b.ContactPhoneNumber,
                        b.ContactEmail,
                        b.IsActive as IsBankActive,
                        b.OperatingHours,
                        c.CustomerTypeId,
                        ct.Name as CustomerTypeName
                    FROM Customer c
                    INNER JOIN Bank b ON c.BankId = b.BankId
                    INNER JOIN CustomerType ct ON c.CustomerTypeId = ct.CustomerTypeId
                    ORDER BY c.LastName, c.FirstName";

                var results = _dbConnection.Query<CustomerDisplayModel>(query);
                
                foreach (var customer in results)
                {
                    customer.Accounts = _dbConnection.Table<Account>()
                        .Where(a => a.CustomerId == customer.CustomerId)
                        .ToList();
                }

                return results;
            });
        }

        public Task<CustomerDisplayModel?> GetCustomerDisplayModelByIdAsync(int customerId)
        {
            return Task.Run(() =>
            {
                var query = @"
                    SELECT 
                        c.CustomerId,
                        c.FirstName,
                        c.LastName,
                        c.Email,
                        c.PhoneNumber,
                        c.PhysicalAddress,
                        c.IdentityNumber,
                        c.Nationality,
                        c.BankId,
                        b.BankName,
                        b.BankAddress,
                        b.BranchCode,
                        b.ContactPhoneNumber,
                        b.ContactEmail,
                        b.IsActive as IsBankActive,
                        b.OperatingHours,
                        c.CustomerTypeId,
                        ct.Name as CustomerTypeName
                    FROM Customer c
                    INNER JOIN Bank b ON c.BankId = b.BankId
                    INNER JOIN CustomerType ct ON c.CustomerTypeId = ct.CustomerTypeId
                    WHERE c.CustomerId = ?";

                var result = _dbConnection.Query<CustomerDisplayModel>(query, customerId).FirstOrDefault();
                
                if (result != null)
                {
                    result.Accounts = _dbConnection.Table<Account>()
                        .Where(a => a.CustomerId == result.CustomerId)
                        .ToList();
                }

                return result;
            });
        }

    }
}
