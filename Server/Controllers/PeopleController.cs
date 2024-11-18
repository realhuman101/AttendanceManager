using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Caching.Memory;

using Server.Interfaces;
using Server.Models;
using Server.Repository;

namespace Server.Controllers
{
    [Authorize]
    [Route("/api/[controller]")]
    [ApiController]
    public class PeopleController : Controller
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly IMemoryCache _cache;

        public PeopleController(IPeopleRepository peopleRepository, IMemoryCache cache)
        {
            _peopleRepository = peopleRepository;
            _cache = cache;
        }

        [OutputCache(Duration = 60)]

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<PeopleRepository>))]
        public IActionResult GetPeople()
        {
            var people = _peopleRepository.Get();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(people);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(PeopleRepository))]
        public IActionResult GetPerson(string id)
        {
            var person = _peopleRepository.GetByID(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpGet("search/{name}")]
        [ProducesResponseType(200, Type = typeof(List<PeopleRepository>))]
        public IActionResult GetByName(string name)
        {
            List<Person>? people = _peopleRepository.GetByName(name);

            if (people == null)
                return NotFound();

            return Ok(people);
        }

        [HttpGet("{id}/classes")]
        [ProducesResponseType(200)]
        public IActionResult GetPersonClass(string id)
        {
            var person = _peopleRepository.GetClasses(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpGet("{id}/role")]
        [ProducesResponseType(200)]
        public IActionResult GetPersonRole(string id)
        {
            var person = _peopleRepository.GetByID(id);

            if (id != person.ID)
            {
                return BadRequest();
            }

            if (person == null)
                return NotFound();

            return Ok(person.Role);
        }

        [HttpPost("{id}&{state}")]
        [ProducesResponseType(200)]
        public IActionResult UpdatePerson(string id, bool state)
        {
            Person person = _peopleRepository.GetByID(id);

            if (id != person.ID)
            {
                return BadRequest();
            }

            if (person == null)
                return NotFound();

            person.Present = state;

            _peopleRepository.Save();

            return NoContent();
        }
    }
}
