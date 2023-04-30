namespace Product_Brand_Category.Model.Services
{
    public interface ICategoryService
    {
        void Add(Category category);
        void Update(Category category); 
        void Delete(int id);
        Category GetById(int id);
        List<Category> GetAll();
        bool Exists(int id);
    }
}
