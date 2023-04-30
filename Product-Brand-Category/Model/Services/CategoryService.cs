namespace Product_Brand_Category.Model.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Category Category)
        {
            _context.Categories.Add(Category);
            _context.SaveChanges();
        }
        public void Update(Category Category)
        {
            var upd = GetById(Category.CategoryId);
            if (upd != null)
                return;
            else
            {
                upd.CategoryName = Category.CategoryName;
                _context.SaveChanges();

            }
        }
        public void Delete(int id)
        {
            var deletedCategory = GetById(id);
            _context.Remove(deletedCategory);
            _context.SaveChanges();
        }
        public Category GetById(int id)
        {
            var Category = _context.Categories.Find(id);
            return Category;
        }
        public List<Category> GetAll()
        {
            var Categories = _context.Categories.ToList();
            return Categories;
        }
        public bool Exists(int id)
        {
            var exist = _context.Categories.Any(t => t.CategoryId == id);
            return exist;
        }
    }
}
