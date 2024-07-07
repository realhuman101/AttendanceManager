using Microsoft.AspNetCore.Mvc;

using Server.Interfaces;
using Server.Repository;

namespace Server.Controllers
{
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
        [ProducesResponseType(200, Type = typeof(List<People>))]
        public IActionResult GetPeople()
        {
            var people = _peopleRepository.GetPeople();

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
            var person = _peopleRepository.GetPerson(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }
    }
}
