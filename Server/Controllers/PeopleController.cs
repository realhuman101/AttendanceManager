using Microsoft.AspNetCore.Mvc;

using Server.Interfaces;
using Server.Models;
using Server.Repository;

namespace Server.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class PeopleController : Controller
    {
        private readonly IRepository<Person> _peopleRepository;

        public PeopleController(IRepository<Person> peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<People>))]
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
        [ProducesResponseType(200, Type = typeof(People))]
        public IActionResult GetPerson(int id)
        {
            var person = _peopleRepository.GetByID(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost("{id}&{state}")]
        [ProducesResponseType(200)]
        public IActionResult UpdatePerson(int id, bool state)
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
