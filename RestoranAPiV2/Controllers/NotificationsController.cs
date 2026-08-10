using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestoranAPiV2.Context;

using RestoranAPiV2.Entities;
using RestoranAPiV2.WebApi.Dtos.NotificationDtos;
using RestoranAPiV2.WebApi.Entities;

namespace RestoranAPiV2.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public NotificationsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _context.Notifications.ToList();
            return Ok(_mapper.Map<List<ResultNotificationDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var result = _mapper.Map<Notification>(createNotificationDto);
            _context.Notifications.Add(result);
            _context.SaveChanges();
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult DeleteNotification(int id)
        {
            var result = _context.Notifications.Find(id);
            _context.Notifications.Remove(result);
            _context.SaveChanges();
            return Ok("Silme işlemi yapıldi");
        }
        [HttpGet("GetNotification")]
        public IActionResult GetNotification(int id)
        {
            var result = _context.Notifications.Find(id);

            return Ok(_mapper.Map<GetNotificationByIdDto>(result));
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var result = _mapper.Map<Notification>(updateNotificationDto);
            _context.Notifications.Update(result);
            _context.SaveChanges();
            return Ok("Güncelleme başarıyla yapıldı");

        }
    }
}
