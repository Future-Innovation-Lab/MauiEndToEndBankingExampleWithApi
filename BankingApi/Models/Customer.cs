using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingApi.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(255)]
        public string PhysicalAddress { get; set; } = string.Empty;

        [MaxLength(20)]
        public string IdentityNumber { get; set; } = string.Empty;

        [ForeignKey("CustomerType")]
        public int CustomerTypeId { get; set; }

        public int GenderTypeId { get; set; }
        public int RaceTypeId { get; set; }
        
        [MaxLength(50)]
        public string Nationality { get; set; } = string.Empty;
        
        public int MaritalStatusId { get; set; }
        public int EmploymentStatusId { get; set; }

        [ForeignKey("Bank")]
        public int BankId { get; set; }

        // Navigation properties
        public Bank Bank { get; set; } = null!;
        public CustomerType CustomerType { get; set; } = null!;
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
        public ICollection<Auth> Auths { get; set; } = new List<Auth>();
        public ICollection<Asset> Assets { get; set; } = new List<Asset>();
    }
}
