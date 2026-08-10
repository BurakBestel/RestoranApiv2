using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestoranAPiV2.Context;
using RestoranAPiV2.Dtos.FeatureDtos;
using RestoranAPiV2.Entities;
using RestoranAPiV2.WebApi.Dtos.CategoryDtos;

namespace RestoranAPiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _Context;

        public CategoriesController(ApiContext context, IMapper mapper)
        {
            _Context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {

            var values = _Context.Categories.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            

            var result = _mapper.Map<Category>(createCategoryDto);
            _Context.Categories.Add(result);
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
