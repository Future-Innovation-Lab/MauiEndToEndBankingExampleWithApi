using System.ComponentModel.DataAnnotations;

namespace BankingApi.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountNumber { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTime DateOpened { get; set; } = DateTime.UtcNow;

        [Required]
        public decimal AccountBalance { get; set; } = 0;

        // Foreign Keys
        public int CustomerId { get; set; }
        public int AccountTypeId { get; set; }

        // Navigation Properties
        public virtual Customer Customer { get; set; } = null!;
        public virtual AccountType AccountType { get; set; } = null!;
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
