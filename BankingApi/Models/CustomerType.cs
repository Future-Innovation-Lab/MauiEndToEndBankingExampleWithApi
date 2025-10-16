using System.ComponentModel.DataAnnotations;

namespace BankingApi.Models
{
    public class CustomerType
    {
        [Key]
        public int CustomerTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
