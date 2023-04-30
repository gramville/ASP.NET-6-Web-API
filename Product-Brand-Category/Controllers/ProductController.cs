using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Brand_Category.Model;
using Product_Brand_Category.Model.Services;

namespace Product_Product_Category.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpGet(Name = "Get All Products")]
        public IActionResult GetProducts()
        {
            var products = _service.GetAll();

            if (products.Count() == 0)
            {
                return BadRequest("No Products found");
            }

            return Ok(products);
            /* return Ok(_service.Products.ToList());
           /*  if( product == null)
                 return BadRequest("No Product found");
             return Ok(Product);*/

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _service.GetById(id);
            if (product == null)
                return BadRequest("No product with id " + id + " is found");
            return Ok(product);
        }
        [HttpPost]
        public IActionResult PostCreate(int CategoryId, int BrandId, ProductModel ProductModel)
        {
            var exists = _service.Exists(ProductModel.id);
            if (exists)
            {
                return BadRequest("The Product id " + ProductModel.id + " already exists in the table");
            }
            var CategoryExists = _service.CategoryExists(CategoryId);
            if (!CategoryExists) 
            {
                return BadRequest("The category id you specified does not exist");
            }
            var BrandExists = _service.CategoryExists(BrandId);
            if (!BrandExists)
            {
                return BadRequest("The category id you specified does not exist");
            }
            var brand = _service.GetBrand(BrandId);
            var category = _service.GetCategory(CategoryId);
            Product product = new Product();
           // product.id = ProductModel.id;
            product.ProductName = ProductModel.ProductName;
            product.Price = ProductModel.Price;
            product.DateOfPurchase = ProductModel.DateOfPurchase;
            product.AvailabilityStatus = ProductModel.AvailabilityStatus;
            product.CategoryId = CategoryId;
            product.BrandId=BrandId;
            product.Active = ProductModel.Active;
            _service.Add(product);
            return Ok("Product has been added");
            //return Ok(GetProducts());
        }
        [HttpPut]
        public IActionResult PutUPdate(/*int CategoryId, int BrandId,*/ Product Product)
        {
            var upd = _service.GetById(Product.id);
            if (upd is null)
            {
                return BadRequest("No Product with id " + Product.id + " is found");
            }
            var CategoryExists = _service.CategoryExists(Product.CategoryId);
            if (!CategoryExists)
            {
                return BadRequest("The category id you specified does not exist");
            }
            var BrandExists = _service.CategoryExists(Product.BrandId);
            if (!BrandExists)
            {
                return BadRequest("The category id you specified does not exist");
            }

            /*Product product = new Product();
            product.id = ProductModel.id;
            product.ProductName = ProductModel.ProductName;
            product.Price = ProductModel.Price;
            product.DateOfPurchase = ProductModel.DateOfPurchase;
            product.AvailabilityStatus = ProductModel.AvailabilityStatus;
            product.CategoryId = CategoryId;
            product.BrandId = BrandId;
            product.Active = ProductModel.Active;*/
            _service.Update(Product);
            return Ok("Product has been updated");
            //return Ok(GetProducts());
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var del = _service.GetById(id);
            if (del is null)
                return BadRequest("No Product with id " + id + " is found");
            _service.Delete(id);
            return Ok("Product has been deleted");
        }
    }
}
