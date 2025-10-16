using System.ComponentModel.DataAnnotations;

namespace BankingApi.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        // Foreign Keys
        public int AccountId { get; set; }
        public int TransactionTypeId { get; set; }

        // Navigation Properties
        public virtual Account Account { get; set; } = null!;
        public virtual TransactionType TransactionType { get; set; } = null!;
    }
}
