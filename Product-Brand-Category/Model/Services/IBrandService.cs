namespace Product_Brand_Category.Model.Services
{
    public interface IBrandService
    {
        void Add(Brand brand);
        void Update(Brand brand);   
        void Delete(int id);   
        Brand GetById(int id);  
        List<Brand> GetAll();
        bool Exists(int id);
    }
}
