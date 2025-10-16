using BankingApi.Data;
using BankingApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly BankingContext _context;

        public TransactionsController(BankingContext context)
        {
            _context = context;
        }

        // GET: api/transactions/account/{accountId}
        [HttpGet("account/{accountId}")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactionsByAccountId(int accountId)
        {
            var transactions = await _context.Transactions
                .Where(t => t.AccountId == accountId)
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();

            return Ok(transactions);
        }

        // GET: api/transactions/types
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<TransactionType>>> GetAllTransactionTypes()
        {
            var transactionTypes = await _context.TransactionTypes.ToListAsync();
            return Ok(transactionTypes);
        }

        // POST: api/transactions
        [HttpPost]
        public async Task<ActionResult<Transaction>> CreateTransaction(Transaction transaction)
        {
            using var dbTransaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Insert the new transaction
                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();

                // Update account balance
                var account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId == transaction.AccountId);
                if (account != null)
                {
                    account.AccountBalance += transaction.Amount;
                    await _context.SaveChangesAsync();
                }

                await dbTransaction.CommitAsync();
                return CreatedAtAction(nameof(GetTransactionById), new { id = transaction.TransactionId }, transaction);
            }
            catch
            {
                await dbTransaction.RollbackAsync();
                return StatusCode(500, "Failed to create transaction");
            }
        }

        // POST: api/transactions/validate-withdrawal
        [HttpPost("validate-withdrawal")]
        public async Task<ActionResult<bool>> ValidateWithdrawal([FromBody] WithdrawalValidationRequest request)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId == request.AccountId);
            if (account == null)
                return NotFound();

            bool isValid = account.AccountBalance >= request.Amount;
            return Ok(isValid);
        }

        // GET: api/transactions/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransactionById(int id)
        {
            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(t => t.TransactionId == id);

            if (transaction == null)
                return NotFound();

            return Ok(transaction);
        }
    }

    public class WithdrawalValidationRequest
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
