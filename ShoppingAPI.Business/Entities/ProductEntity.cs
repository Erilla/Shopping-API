using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI.EntityFramework.Entities
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string? ProductCode { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }
    }
}
