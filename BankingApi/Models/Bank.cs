using System.ComponentModel.DataAnnotations;

namespace BankingApi.Models
{
    public class Bank
    {
        [Key]
        public int BankId { get; set; }

        [Required]
        [MaxLength(100)]
        public string BankName { get; set; } = string.Empty;

        [MaxLength(255)]
        public string BankAddress { get; set; } = string.Empty;

        [MaxLength(10)]
        public string BranchCode { get; set; } = string.Empty;

        [MaxLength(20)]
        public string ContactPhoneNumber { get; set; } = string.Empty;

        [MaxLength(100)]
        public string ContactEmail { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        [MaxLength(100)]
        public string OperatingHours { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}
