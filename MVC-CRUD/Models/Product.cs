using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public  string ProductName { get; set; }
        [Required]
        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double TotalPrice { get; set; }
    }
}
