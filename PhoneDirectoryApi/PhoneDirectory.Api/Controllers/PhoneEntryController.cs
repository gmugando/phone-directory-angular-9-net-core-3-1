using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneDirectory.Api.DTOs;
using PhoneDirectory.Data.Domain.Models;
using PhoneDirectory.Data.Domain.Models.Queries;
using PhoneDirectory.Data.Domain.Services;
using System.Threading.Tasks;

namespace PhoneDirectory.Api.Controllers
{
    [Route("/api/entry")]
    [Produces("application/json")]
    [ApiController]
    public class PhoneEntryController : Controller
    {
        private readonly IEntryService _entryService;
        private readonly IMapper _mapper;
        public PhoneEntryController(IEntryService entryService , IMapper mapper)
        {
            _entryService = entryService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(QueryResultDTO<EntryDTO>), 200)]
        public async Task<QueryResultDTO<EntryDTO>> ListAsync([FromQuery] EntryQueryDTO query)
        {
            var entriesQuery = _mapper.Map<EntryQueryDTO, EntriesQuery>(query);
            var queryResult = await _entryService.ListAsync(entriesQuery);

            var entryResult = _mapper.Map<QueryResult<Entry>, QueryResultDTO<EntryDTO>>(queryResult);
            return entryResult;
        }

        [HttpPost]
        [ProducesResponseType(typeof(EntryDTO), 201)]
        [ProducesResponseType(typeof(ErrorDTO), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveEntryDTO entry)
        {
            var newEntry = _mapper.Map<SaveEntryDTO, Entry>(entry);
            var result = await _entryService.SaveAsync(newEntry);

            if (!result.Success)
            {
                return BadRequest(new ErrorDTO(result.Message));
            }

            var entryResult = _mapper.Map<Entry, EntryDTO>(result.Resource);
            return Ok(entryResult);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EntryDTO), 201)]
        [ProducesResponseType(typeof(ErrorDTO), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveEntryDTO entry)
        {
            var updatedEntry = _mapper.Map<SaveEntryDTO, Entry>(entry);
            var result = await _entryService.UpdateAsync(id, updatedEntry);

            if (!result.Success)
            {
                return BadRequest(new ErrorDTO(result.Message));
            }

            var entryResult = _mapper.Map<Entry, EntryDTO>(result.Resource);
            return Ok(entryResult);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EntryDTO), 200)]
        [ProducesResponseType(typeof(ErrorDTO), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _entryService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorDTO(result.Message));
            }

            var entryResult = _mapper.Map<Entry, EntryDTO>(result.Resource);
            return Ok(entryResult);
        }
    }
}