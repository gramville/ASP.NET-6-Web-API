using System.ComponentModel.DataAnnotations;

namespace Product_Brand_Category.Model
{
    public class ProductModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public DateTime? DateOfPurchase { get; set; }
        public string AvailabilityStatus { get; set; }
        public bool Active { get; set; }
    }
}
