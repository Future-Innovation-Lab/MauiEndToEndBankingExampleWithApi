using BankingApi.Data;
using BankingApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BanksController : ControllerBase
    {
        private readonly BankingContext _context;

        public BanksController(BankingContext context)
        {
            _context = context;
        }

        // GET: api/banks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bank>>> GetAllBanks()
        {
            var banks = await _context.Banks.ToListAsync();
            return Ok(banks);
        }

        // GET: api/banks/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Bank>> GetBankById(int id)
        {
            var bank = await _context.Banks.FirstOrDefaultAsync(b => b.BankId == id);
            if (bank == null)
                return NotFound();

            return Ok(bank);
        }
    }
}
