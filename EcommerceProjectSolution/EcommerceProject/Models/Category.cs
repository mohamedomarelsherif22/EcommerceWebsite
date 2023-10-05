using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.Models
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }

    }
}
