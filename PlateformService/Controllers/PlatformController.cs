using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlateformService.Data;
using PlateformService.Dtos;
using PlateformService.Models;

namespace PlateformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepository _repo;
        private readonly IMapper _mapper;

        public PlatformController(IPlatformRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetAll()
        {
            var platforms = _repo.GetAll();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
        }

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<PlatformReadDto> GetById(System.Guid id)
        {
            var platform = _repo.GetById(id);
            if(platform is null) return NotFound();
            return Ok(_mapper.Map<PlatformReadDto>(platform));

        }

        [HttpPost]
        public ActionResult<PlateformCreateDto> CreatePlatform(PlateformCreateDto plateformCreateDto)
        {
            var platform = _mapper.Map<Platform>(plateformCreateDto);
            platform.Id = System.Guid.NewGuid();
            _repo.Create(platform);
            _repo.SaveChanges();
            var createdPlatform =  _mapper.Map<PlatformReadDto>(platform);
            return CreatedAtRoute(nameof(GetById), new {id = createdPlatform.Id}, createdPlatform);
        }
    }
}