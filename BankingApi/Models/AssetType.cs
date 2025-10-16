using System.ComponentModel.DataAnnotations;

namespace BankingApi.Models
{
    public class AssetType
    {
        [Key]
        public int AssetTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
