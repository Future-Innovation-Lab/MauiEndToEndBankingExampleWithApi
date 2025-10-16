using BankingApi.Data;
using BankingApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly BankingContext _context;

        public AccountsController(BankingContext context)
        {
            _context = context;
        }

        // GET: api/accounts/customer/{customerId}
        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccountByCustomerId(int customerId)
        {
            var accounts = await _context.Accounts
                .Where(a => a.CustomerId == customerId)
                .ToListAsync();

            return Ok(accounts);
        }

        // GET: api/accounts/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccountById(int id)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(a => a.AccountId == id);

            if (account == null)
                return NotFound();

            return Ok(account);
        }

        // POST: api/accounts
        [HttpPost]
        public async Task<ActionResult<Account>> CreateAccount(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAccountById), new { id = account.AccountId }, account);
        }

        // PUT: api/accounts/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Account account)
        {
            if (id != account.AccountId)
                return BadRequest();

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AccountExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/accounts/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
                return NotFound();

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> AccountExists(int id)
        {
            return await _context.Accounts.AnyAsync(a => a.AccountId == id);
        }
    }
}
