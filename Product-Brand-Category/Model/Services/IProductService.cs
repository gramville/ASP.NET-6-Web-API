namespace Product_Brand_Category.Model.Services
{
    public interface IProductService
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        Product GetById(int id);    
        List<Product> GetAll();
        bool Exists(int id);
        bool CategoryExists(int id);
        bool BrandExists(int id);
        Brand GetBrand(int id);
        Category GetCategory(int id);
    }
}
