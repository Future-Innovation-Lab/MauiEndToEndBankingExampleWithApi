using BankingApi.Data;
using BankingApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LookupController : ControllerBase
    {
        private readonly BankingContext _context;

        public LookupController(BankingContext context)
        {
            _context = context;
        }

        // GET: api/lookup/customer-types
        [HttpGet("customer-types")]
        public async Task<ActionResult<IEnumerable<CustomerType>>> GetCustomerTypes()
        {
            return Ok(await _context.CustomerTypes.ToListAsync());
        }

        // GET: api/lookup/account-types
        [HttpGet("account-types")]
        public async Task<ActionResult<IEnumerable<AccountType>>> GetAccountTypes()
        {
            return Ok(await _context.AccountTypes.ToListAsync());
        }

        // GET: api/lookup/transaction-types
        [HttpGet("transaction-types")]
        public async Task<ActionResult<IEnumerable<TransactionType>>> GetTransactionTypes()
        {
            return Ok(await _context.TransactionTypes.ToListAsync());
        }

        // GET: api/lookup/auth-types
        [HttpGet("auth-types")]
        public async Task<ActionResult<IEnumerable<AuthType>>> GetAuthTypes()
        {
            return Ok(await _context.AuthTypes.ToListAsync());
        }

        // GET: api/lookup/asset-types
        [HttpGet("asset-types")]
        public async Task<ActionResult<IEnumerable<AssetType>>> GetAssetTypes()
        {
            return Ok(await _context.AssetTypes.ToListAsync());
        }
    }
}
