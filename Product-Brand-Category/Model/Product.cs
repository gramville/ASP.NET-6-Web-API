using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product_Brand_Category.Model
{
    public class Product
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required (ErrorMessage = "Name is required")]
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public DateTime? DateOfPurchase { get; set; }
        public string AvailabilityStatus { get; set; }
        public int CategoryId { get; set; } // foreign key value
        [ForeignKey(nameof(CategoryId))]
        public int BrandId { get; set; } // foreign key value
        [ForeignKey(nameof(BrandId))]
        public bool Active { get; set; }


        //public virtual Brand Brand { get; set; }
        //public virtual Category Category { get; set; }
    }
}
