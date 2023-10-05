using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceProject.Models
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string? ProductName { get; set; }
        public string? ProductImage { get; set; }
        [Required]
        public double Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category  { get; set; }
        public List<OrderDetail> OrderDetail  { get; set; }
        public List<CartDetail> CartDetail { get; set; }
        [NotMapped]
        public string CategoryName { get; set;}
    }
}
