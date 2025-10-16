using System.ComponentModel.DataAnnotations;

namespace BankingApi.Models
{
    public class AccountType
    {
        [Key]
        public int AccountTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
