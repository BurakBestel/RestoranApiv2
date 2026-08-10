using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestoranAPiV2.Context;
using RestoranAPiV2.Dtos.MessageDtos;
using RestoranAPiV2.Entities;

namespace RestoranAPiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;
        public MessagesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var result = _context.Messages.ToList();
            return Ok(_mapper.Map<List<ResultMessageDto>>(result));
        }

        [HttpPost]
        public IActionResult CreateMessage([FromBody]CreateMessageDto createMessageDto)
        {
            var result = _mapper.Map<Message>(createMessageDto);
            _context.Messages.Add(result);
            _context.SaveChanges();
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var result= _context.Messages.Find(id);
            _context.Messages.Remove(result);
            _context.SaveChanges();
            return Ok("Mesaj Silindi");
        }
        [HttpGet("GetMessage")]
        public IActionResult GetMessage(int id)
        {
            var value= _context.Messages.Find(id);
            return Ok(_mapper.Map<GetByIdMessageDto>(value)); 
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var value = _mapper.Map<Message>(updateMessageDto);
            _context.Messages.Add(value);
            _context.SaveChanges();
            return Ok("Mesaj güncelleme başarılı");
        }

        [HttpGet("MessageListbyIsReadFalse")]
        public IActionResult MessageListbyIsReadFalse()
        {
            var value = _context.Messages.Where(x => x.IsRead==false).ToList();
            return Ok(value);
        }
    }
}
