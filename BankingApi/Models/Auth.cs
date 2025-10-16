using System.ComponentModel.DataAnnotations;

namespace BankingApi.Models
{
    public class Auth
    {
        [Key]
        public int AuthId { get; set; }

        [Required]
        [StringLength(255)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string Password { get; set; } = string.Empty;

        // Foreign Keys
        public int CustomerId { get; set; }
        public int AuthTypeId { get; set; }

        // Navigation Properties
        public virtual Customer Customer { get; set; } = null!;
        public virtual AuthType AuthType { get; set; } = null!;
    }
}
