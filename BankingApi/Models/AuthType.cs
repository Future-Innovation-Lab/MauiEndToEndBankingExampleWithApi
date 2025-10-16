using System.ComponentModel.DataAnnotations;

namespace BankingApi.Models
{
    public class AuthType
    {
        [Key]
        public int AuthTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
