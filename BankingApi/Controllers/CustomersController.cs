using BankingApi.Data;
using BankingApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly BankingContext _context;

        public CustomersController(BankingContext context)
        {
            _context = context;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            var customers = await _context.Customers
                .Include(c => c.Bank)
                .Include(c => c.CustomerType)
                .Include(c => c.Accounts)
                .ToListAsync();

            return Ok(customers);
        }

        // GET: api/customers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // GET: api/customers/{id}/full
        [HttpGet("{id}/full")]
        public async Task<ActionResult<Customer>> GetCustomerByIdFullFetch(int id)
        {
            var customer = await _context.Customers
                .Include(c => c.Bank)
                .Include(c => c.CustomerType)
                .Include(c => c.Accounts)
                    .ThenInclude(a => a.AccountType)
                .Include(c => c.Accounts)
                    .ThenInclude(a => a.Transactions)
                        .ThenInclude(t => t.TransactionType)
                .Include(c => c.Auths)
                    .ThenInclude(a => a.AuthType)
                .Include(c => c.Assets)
                    .ThenInclude(a => a.AssetType)
                .FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // GET: api/customers/display
        [HttpGet("display")]
        public async Task<ActionResult<IEnumerable<CustomerDisplayModel>>> GetCustomersWithBankAndType()
        {
            var customers = await _context.Customers
                .Include(c => c.Bank)
                .Include(c => c.CustomerType)
                .Include(c => c.Accounts)
                .Select(c => new CustomerDisplayModel
                {
                    CustomerId = c.CustomerId,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    PhysicalAddress = c.PhysicalAddress,
                    IdentityNumber = c.IdentityNumber,
                    Nationality = c.Nationality,
                    BankId = c.BankId,
                    BankName = c.Bank.BankName,
                    BankAddress = c.Bank.BankAddress,
                    BranchCode = c.Bank.BranchCode,
                    ContactPhoneNumber = c.Bank.ContactPhoneNumber,
                    ContactEmail = c.Bank.ContactEmail,
                    IsBankActive = c.Bank.IsActive,
                    OperatingHours = c.Bank.OperatingHours,
                    CustomerTypeId = c.CustomerTypeId,
                    CustomerTypeName = c.CustomerType.Name,
                    Accounts = c.Accounts.ToList()
                })
                .OrderBy(c => c.LastName)
                .ThenBy(c => c.FirstName)
                .ToListAsync();

            return Ok(customers);
        }

        // GET: api/customers/{id}/display
        [HttpGet("{id}/display")]
        public async Task<ActionResult<CustomerDisplayModel>> GetCustomerDisplayModelById(int id)
        {
            var customer = await _context.Customers
                .Include(c => c.Bank)
                .Include(c => c.CustomerType)
                .Include(c => c.Accounts)
                .Select(c => new CustomerDisplayModel
                {
                    CustomerId = c.CustomerId,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    PhysicalAddress = c.PhysicalAddress,
                    IdentityNumber = c.IdentityNumber,
                    Nationality = c.Nationality,
                    BankId = c.BankId,
                    BankName = c.Bank.BankName,
                    BankAddress = c.Bank.BankAddress,
                    BranchCode = c.Bank.BranchCode,
                    ContactPhoneNumber = c.Bank.ContactPhoneNumber,
                    ContactEmail = c.Bank.ContactEmail,
                    IsBankActive = c.Bank.IsActive,
                    OperatingHours = c.Bank.OperatingHours,
                    CustomerTypeId = c.CustomerTypeId,
                    CustomerTypeName = c.CustomerType.Name,
                    Accounts = c.Accounts.ToList()
                })
                .FirstOrDefaultAsync(c => c.CustomerId == id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // POST: api/customers
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.CustomerId }, customer);
        }

        // PUT: api/customers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
                return BadRequest();

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CustomerExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/customers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                return NotFound();

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> CustomerExists(int id)
        {
            return await _context.Customers.AnyAsync(c => c.CustomerId == id);
        }
    }
}
