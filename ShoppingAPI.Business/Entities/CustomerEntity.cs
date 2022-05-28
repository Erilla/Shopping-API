using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI.EntityFramework.Entities
{
    public class CustomerEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
