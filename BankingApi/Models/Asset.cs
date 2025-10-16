using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingApi.Models
{
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }

        [ForeignKey("AssetType")]
        public int AssetTypeId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        // Navigation properties
        public AssetType AssetType { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
    }
}
