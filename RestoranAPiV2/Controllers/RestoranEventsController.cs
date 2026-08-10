using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestoranAPiV2.Context;
using RestoranAPiV2.Entities;
using RestoranAPiV2.WebApi.Entities;

namespace RestoranAPiV2.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestoranEventsController : ControllerBase
    {
        private readonly ApiContext _Context;

        public RestoranEventsController(ApiContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public IActionResult RestoranEventList()
        {

            var values = _Context.RestoranEvents.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateRestoranEvent(RestoranEvent RestoranEvent)
        {
            _Context.RestoranEvents.Add(RestoranEvent);
            _Context.SaveChanges();
            return Ok("Etkinlik Ekleme Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteRestoranEvent(int id)
        {
            var value = _Context.RestoranEvents.Find(id);
            _Context.RestoranEvents.Remove(value);
            _Context.SaveChanges();
            return Ok("Etkinlik silme işlemi başarılı");
        }
        [HttpGet("GetRestoranEvent")]
        public IActionResult GetRestoranEvent(int id)
        {
            var value = _Context.RestoranEvents.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateRestoranEvent(RestoranEvent RestoranEvent)
        {
            _Context.RestoranEvents.Update(RestoranEvent);
            _Context.SaveChanges();
            return Ok("Etkinlik güncellendi");

        }
    }
}
