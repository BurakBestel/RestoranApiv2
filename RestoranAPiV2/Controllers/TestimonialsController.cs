using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestoranAPiV2.Context;
using RestoranAPiV2.Entities;

namespace RestoranAPiV2.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ApiContext _Context;

        public TestimonialsController(ApiContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {

            var values = _Context.Testimonials.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial Testimonial)
        {
            _Context.Testimonials.Add(Testimonial);
            _Context.SaveChanges();
            return Ok("Referans Ekleme Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _Context.Testimonials.Find(id);
            _Context.Testimonials.Remove(value);
            _Context.SaveChanges();
            return Ok("Referans silme işlemi başarılı");
        }
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _Context.Testimonials.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial Testimonial)
        {
            _Context.Testimonials.Update(Testimonial);
            _Context.SaveChanges();
            return Ok("Referans güncellendi");

        }
    }
}
