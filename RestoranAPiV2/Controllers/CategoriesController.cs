using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestoranAPiV2.Context;
using RestoranAPiV2.Entities;

namespace RestoranAPiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _Context;

        public CategoriesController(ApiContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {

            var values = _Context.Categories.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _Context.Categories.Add(category);
            _Context.SaveChanges();
            return Ok("Kategori Ekleme Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _Context.Categories.Find(id);
            _Context.Categories.Remove(value);
            _Context.SaveChanges();
            return Ok("Kategori silme işlemi başarılı");
        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var value= _Context.Categories.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            _Context.Categories.Update(category);
            _Context.SaveChanges();
            return Ok("Kategori güncellendi");
            
        }

    }

}
