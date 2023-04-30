namespace Product_Brand_Category.Model.Services
{
    public class BrandService : IBrandService
    {
        private readonly AppDbContext _context;
        public BrandService(AppDbContext context) 
        {
            _context = context;
        }

        public void Add(Brand brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();
        }
        public void Update(Brand brand) 
        {
            var upd= GetById(brand.BrandId);
            if (upd == null)
                return;
            else
            {
                upd.BrandName = brand.BrandName;
                _context.SaveChanges();

            }
           
        }
        public void Delete(int id) 
        {
            var deletedBrand = GetById(id);
            _context.Remove(deletedBrand);
            _context.SaveChanges();
        }
        public Brand GetById(int id) 
        {
            var brand = _context.Brands.Find(id);
            if( brand == null)
                return null;
            return brand;
        }
        public List<Brand> GetAll() 
        {
            var brands = _context.Brands.ToList();
            return brands;
        }
        public bool Exists(int id)
        {
            var exist = _context.Brands.Any(t => t.BrandId == id);
            return exist;
        }
    }
}
