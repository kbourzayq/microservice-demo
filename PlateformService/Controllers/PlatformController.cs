using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlateformService.Data;
using PlateformService.Dtos;
using PlateformService.Models;
using PlateformService.SyncDataServices.Http;

namespace PlateformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepository _repo;
        private readonly IMapper _mapper;
        private readonly ICommandDataService _commandDataService;

        public PlatformController(IPlatformRepository repository, IMapper mapper, ICommandDataService commandDataService)
        {
            _repo = repository;
            _mapper = mapper;
            _commandDataService =  commandDataService;
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
        public async Task<ActionResult<PlateformCreateDto>> CreatePlatform(PlateformCreateDto plateformCreateDto)
        {
            var platform = _mapper.Map<Platform>(plateformCreateDto);
            platform.Id = System.Guid.NewGuid();
            _repo.Create(platform);
            _repo.SaveChanges();
            var createdPlatform =  _mapper.Map<PlatformReadDto>(platform);
            try
            {
                await _commandDataService.SendPlatformToCommand(createdPlatform);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"---> an exception has occurred while calling CommandService : {ex.ToString()}");
            }
            return CreatedAtRoute(nameof(GetById), new {id = createdPlatform.Id}, createdPlatform);
        }
    }
}