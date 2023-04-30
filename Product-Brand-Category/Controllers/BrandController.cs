using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Brand_Category.Model;
using Product_Brand_Category.Model.Services;

namespace Brand_Brand_Category.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _service;
        public BrandController(IBrandService service)
        {
            _service = service;
        }
        [HttpGet(Name = "Get All Brands")]
        public IActionResult GetBrands()
        {
            var Brands = _service.GetAll();

            if (Brands.Count() == 0)
            {
                return BadRequest("No Brands found");
            }

            return Ok(Brands);
            /* return Ok(_service.Brands.ToList());
           /*  if( Brand == null)
                 return BadRequest("No Brand found");
             return Ok(Brand);*/

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Brand = _service.GetById(id);
            if (Brand == null)
                return BadRequest("No Brand with id " + id + " is found");
            return Ok(Brand);
        }
        [HttpPost]
        public  IActionResult PostCreate(Brand Brand)
        {
            var exists = _service.Exists(Brand.BrandId);
            if (exists) 
            {
                return BadRequest("The Brand id " + Brand.BrandId + " already exists in the table");
            }
            Brand.BrandId = 0;
            _service.Add(Brand);
            return Ok(Brand);
            //return Ok(GetBrands());
        }
        [HttpPut]
        public  IActionResult PutUPdate(Brand Brand)
        {
            var upd = _service.GetById(Brand.BrandId);
            if (upd is null)
                return BadRequest("No Brand with id " + Brand.BrandId + " is found");
            _service.Update(Brand);
            return Ok("Brand has been updated");
            //return Ok(GetBrands());
        }
        [HttpDelete]
        public IActionResult DeleteBrand(int id)
        {
            var del = _service.GetById(id);
            if (del is null)
                return BadRequest("No Brand with id " + id + " is found");
            _service.Delete(id);
            return Ok("Brand has been deleted"); 
        }
    }
}
