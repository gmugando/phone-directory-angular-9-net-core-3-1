using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneDirectory.Api.DTOs;
using PhoneDirectory.Data.Domain.Models;
using PhoneDirectory.Data.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneDirectory.Api.Controllers
{
    [Route("/api/phonebook")]
    [Produces("application/json")]
    [ApiController]
    public class PhoneBookController : Controller
    {
        private readonly IPhoneBookService _phonebookService;
        private readonly IMapper _mapper;

        public PhoneBookController(IPhoneBookService phonebookService, IMapper mapper)
        {
            _phonebookService = phonebookService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PhoneBookDTO>), 200)]
        public async Task<IEnumerable<PhoneBookDTO>> ListAsync()
        {
            var phoneBooks = await _phonebookService.ListAsync();
            var results = _mapper.Map<IEnumerable<PhoneBook>, IEnumerable<PhoneBookDTO>>(phoneBooks);

            return results;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PhoneBookDTO), 201)]
        [ProducesResponseType(typeof(ErrorDTO), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SavePhoneBookDTO phonebook)
        {
            var phone = _mapper.Map<SavePhoneBookDTO, PhoneBook>(phonebook);
            var result = await _phonebookService.SaveAsync(phone);

            if (!result.Success)
            {
                return BadRequest(new ErrorDTO(result.Message));
            }

            var phoneBookDTO = _mapper.Map<PhoneBook, PhoneBookDTO>(result.Resource);
            return Ok(phoneBookDTO);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PhoneBookDTO), 200)]
        [ProducesResponseType(typeof(ErrorDTO), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePhoneBookDTO phonebook)
        {
            var phone = _mapper.Map<SavePhoneBookDTO, PhoneBook>(phonebook);
            var result = await _phonebookService.UpdateAsync(id, phone);

            if (!result.Success)
            {
                return BadRequest(new ErrorDTO(result.Message));
            }

            var phoneBookDTO = _mapper.Map<PhoneBook, PhoneBookDTO>(result.Resource);
            return Ok(phoneBookDTO);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PhoneBookDTO), 200)]
        [ProducesResponseType(typeof(ErrorDTO), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _phonebookService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorDTO(result.Message));
            }

            var phoneBookDTO = _mapper.Map<PhoneBook, PhoneBookDTO>(result.Resource);
            return Ok(phoneBookDTO);
        }
    }
}