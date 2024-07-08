using Microsoft.AspNetCore.Mvc;

using Server.Interfaces;
using Server.Models;
using Server.Repository;

namespace Server.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ClassesController : Controller
    {
        private readonly IClassesRepository _classesRepository;

        public ClassesController(IClassesRepository classRepository)
        {
            _classesRepository = classRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ClassesRepository>))]
        public IActionResult GetClasses()
        {
            var classes = _classesRepository.Get();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(classes);
        }

        [HttpGet("{id}/people")]
        [ProducesResponseType(200)]
        public IActionResult GetClassPeople(int id)
        {
            var _class = _classesRepository.GetByPerson(id);

            if (_class == null)
            {
                return NotFound();
            }

            return Ok(_class);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ClassesRepository))]
        public IActionResult GetClass(int id)
        {
            var _class = _classesRepository.GetByID(id);

            if (_class == null)
            {
                return NotFound();
            }

            return Ok(_class);
        }
    }
}
