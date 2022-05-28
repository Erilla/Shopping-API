using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingAPI.EntityFramework.Entities
{
    public class SpecificPriceEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }

        public CustomerEntity Customer { get; set; }

        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public ProductEntity Product { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
