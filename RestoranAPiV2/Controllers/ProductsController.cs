using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestoranAPiV2.Context;
using RestoranAPiV2.Dtos.ProductDtos;
using RestoranAPiV2.Entities;

namespace RestoranAPiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ProductsController(IValidator<Product> validator, ApiContext context, IMapper mapper)
        {
            _validator = validator;
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult productList()
        {
            var values = _context.Products.ToList();
            return Ok(values);
        }
        
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok("Ürün başarılıyla eklendi");
            }
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var result = _context.Products.Find(id);
            _context.Products.Remove(result);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var result = _context.Products.Find(id);
            return Ok(result);
        }
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return Ok("GÜncelleme işlemi yapıldı");
            }
        }
        [HttpPost("CreateProductCategory")]
        public IActionResult CreateProductCategory(CreateProtuctDto createProductDto)
        {
            var value= _mapper.Map<Product>(createProductDto);
            _context.Products.Add(value);
            _context.SaveChanges();
            return Ok("Ürün başarılıyla eklendi");

        }
        
    }
}
