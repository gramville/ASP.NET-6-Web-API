using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Brand_Category.Model;
using Product_Brand_Category.Model.Services;

namespace Category_Category_Category.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet(Name = "Get All Categories")]
        public IActionResult GetCategorys()
        {
            var Categorys = _service.GetAll();

            if (Categorys.Count() == 0)
            {
                return BadRequest("No Categorys found");
            }

            return Ok(Categorys);
            /* return Ok(_service.Categorys.ToList());
           /*  if( Category == null)
                 return BadRequest("No Category found");
             return Ok(Category);*/

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Category = _service.GetById(id);
            if (Category == null)
                return BadRequest("No Category with id " + id + " is found");
            return Ok(Category);
        }
        [HttpPost]
        public IActionResult PostCreate(Category Category)
        {
            var exists = _service.Exists(Category.CategoryId);
            if (exists)
            {
                return BadRequest("The Category id " + Category.CategoryId + " already exists in the table");
            }
            Category.CategoryId = 0; 
            _service.Add(Category);
            return Ok(Category);
            //return Ok(GetCategorys());
        }
        [HttpPut]
        public IActionResult PutUPdate(Category Category)
        {
            var upd = _service.GetById(Category.CategoryId);
            if (upd is null)
                return BadRequest("No Category with id " + Category.CategoryId + " is found");
            _service.Update(Category);
            return Ok("Category has been updated");
            //return Ok(GetCategorys());
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var del = _service.GetById(id);
            if (del is null)
                return BadRequest("No Category with id " + id + " is found");
            _service.Delete(id);
            return Ok("Category has been deleted");
        }
    }
}
