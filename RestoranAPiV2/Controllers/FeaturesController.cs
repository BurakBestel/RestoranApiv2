using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using RestoranAPiV2.Context;
using RestoranAPiV2.Dtos.FeatureDtos;
using RestoranAPiV2.Entities;

namespace RestoranAPiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public FeaturesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _context.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var result = _mapper.Map<Feature>(createFeatureDto);
            _context.Features.Add(result);
            _context.SaveChanges();
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var result = _context.Features.Find(id);
            _context.Features.Remove(result);
            _context.SaveChanges();
            return Ok("Silme işlemi yapıldi");
        }
        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var result = _context.Features.Find(id);

            return Ok(_mapper.Map<GetByIdFeatureDto>(result));
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var result = _mapper.Map<Feature>(updateFeatureDto);
            _context.Features.Update(result);
            _context.SaveChanges();
            return Ok("Güncelleme başarıyla yapıldı");

        }

    }
}
