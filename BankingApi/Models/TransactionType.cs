using System.ComponentModel.DataAnnotations;

namespace BankingApi.Models
{
    public class TransactionType
    {
        [Key]
        public int TransactionTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
