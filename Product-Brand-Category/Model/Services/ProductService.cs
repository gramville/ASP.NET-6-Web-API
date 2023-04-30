using Microsoft.EntityFrameworkCore;

namespace Product_Brand_Category.Model.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context) 
        {
            _context = context; 
        }
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void Update(Product product) 
        {
            var upd = GetById(product.id);
            if (upd != null)
                return;
            else
            {
                upd.ProductName = product.ProductName;
                upd.Price = product.Price;
                upd.DateOfPurchase = product.DateOfPurchase;    
                upd.AvailabilityStatus = product.AvailabilityStatus;
                upd.CategoryId = product.CategoryId;
                upd.BrandId = product.BrandId;
                upd.Active = product.Active;
                _context.SaveChanges();

            }
        }
        public void Delete(int id) 
        {
            var deletedProduct = GetById(id);
            _context.Remove(deletedProduct);
            _context.SaveChanges(); 
        }
        public Product GetById(int id) 
        {
            var product = _context.Products.Find(id);
            if ( product == null) 
            {
                return null;
            }
            return product;
        }
        public List<Product> GetAll() 
        {
            var products = _context.Products.ToList();
            return products;
        }
        public bool Exists(int id)
        {
           var exist = _context.Products.Any(t => t.id == id);
            return exist;
        }
        public bool CategoryExists(int id)
        {
            var exist = _context.Categories.Any(t => t.CategoryId == id);
            return exist;
            
        }
        public bool BrandExists(int id)
        {
            var exist = _context.Brands.Any(t => t.BrandId == id);
            return exist;

        }

        public Category GetCategory(int id)
        {

            var category = _context.Categories.Find(id);
            return category;
        }

        public Brand GetBrand(int id)
        {

            var brand = _context.Brands.Find(id);
            return brand;
        }

    }
}
