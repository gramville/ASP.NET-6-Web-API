using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Product_Brand_Category.Model
{
    public class Brand
    {
        [Key]
      //  [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
