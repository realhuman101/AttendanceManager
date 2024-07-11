using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Server.Interfaces;
using Server.Models;
using Server.Repository;

namespace Server.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    [Route("/api/[controller]")]
    [ApiController]
    public class PeopleController : Controller
    {
        private readonly IPeopleRepository _peopleRepository;

        public PeopleController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

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
        public IActionResult GetPerson(int id)
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
        public IActionResult GetPersonClass(int id)
        {
            var person = _peopleRepository.GetClasses(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [Authorize]
        [HttpPost("{id}&{state}")]
        [ProducesResponseType(200)]
        public IActionResult UpdatePerson(int id, bool state, string sessionID)
        {
            Person person = _peopleRepository.GetByID(id);

            if (id != person.ID)
            {
                return BadRequest();
            }

            person.Present = state;

            _peopleRepository.Save();

            return NoContent();
        }
    }
}
