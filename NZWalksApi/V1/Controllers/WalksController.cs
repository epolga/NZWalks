using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksApi.CustomActionFilters;
using NZWalksApi.Models.Domain;
using NZWalksApi.Models.DTO;
using NZWalksApi.Repositories;

namespace NZWalksApi.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class WalksController : ControllerBase
    {
        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            Mapper = mapper;
            WalkRepository = walkRepository;
        }

        public IMapper Mapper { get; set; }
        public IWalkRepository WalkRepository { get; set; }

        // Create Walk
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {

            // Map DTO to Domain Model
            var walksDomainModel = Mapper.Map<Walk>(addWalkRequestDto);
            await WalkRepository.CreateAsync(walksDomainModel);
            // Map Domain Model to DTO and return it
            return Ok(Mapper.Map<WalkDto>(walksDomainModel));
        }
        //

        // GET Walks
        // GET: /api/walks?filterOn=Name&filterQuery=Track

        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<IActionResult> GetAll1([FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending,
            [FromQuery] int? pageNumber,
            [FromQuery] int? pageSize
         )
        {
            var walksDomainModel = await WalkRepository.GetAllAsync(filterOn, filterQuery,
                sortBy, isAscending, pageNumber ?? 1, pageSize ?? 10000);
            // Map Domain Model to DTO and return it
            return Ok(Mapper.Map<List<WalkDto>>(walksDomainModel));
        }

        // GET Walks
        // GET: /api/walks?filterOn=Name&filterQuery=Track

        [MapToApiVersion("2.0")]
        [HttpGet]
        public async Task<IActionResult> GetAll2([FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending,
            [FromQuery] int? pageNumber,
            [FromQuery] int? pageSize
         )
        {
            var walksDomainModel = await WalkRepository.GetAllAsync(filterOn, filterQuery,
                sortBy, isAscending, pageNumber ?? 1, pageSize ?? 10000);
            // Map Domain Model to DTO and return it
            return Ok(Mapper.Map<List<WalkDto>>(walksDomainModel));
        }


        // Get Walk by Id
        // Get: /api/walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await WalkRepository.GetByIdAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO

            return Ok(Mapper.Map<WalkDto>(walkDomainModel));
        }

        // Update Walk by Id
        // PUT: /api/Walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {

            // Map DTO to Domain Model
            var walkDomainModel = Mapper.Map<Walk>(updateWalkRequestDto);
            walkDomainModel = await WalkRepository.UpdateAsync(id, walkDomainModel);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            // Map Domain Model to DTO
            return Ok(Mapper.Map<WalkDto>(walkDomainModel));
        }

        // Delete a Walk By Id
        // DELETE: /api/Walks/{id}
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalkDomain = await WalkRepository.DeleteAsync(id);
            if (deletedWalkDomain == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<WalkDto>(deletedWalkDomain));
        }
    }
}
