using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestoranAPiV2.Context;
using RestoranAPiV2.Entities;

namespace RestoranAPiV2.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApiContext _Context;

        public ServicesController(ApiContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {

            var values = _Context.Services.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _Context.Services.Add(service);
            _Context.SaveChanges();
            return Ok("Hizmet Ekleme Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var value = _Context.Services.Find(id);
            _Context.Services.Remove(value);
            _Context.SaveChanges();
            return Ok("Hizmet silme işlemi başarılı");
        }
        [HttpGet("GetService")]
        public IActionResult GetService(int id)
        {
            var value = _Context.Services.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _Context.Services.Update(service);
            _Context.SaveChanges();
            return Ok("Hizmet güncellendi");

        }
    }
}
