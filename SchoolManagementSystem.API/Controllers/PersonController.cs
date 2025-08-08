using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Interfaces;
using SchoolManagementSystem.API.Models;

namespace SchoolManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;

        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPeople()
        {
            var people = await personService.GetAllPeople();
            return Ok(people);
        }

        [HttpGet("{personId}")]
        public async Task<IActionResult> GetPersonById(Guid personId)
        {
            var person = await personService.GetPersonById(personId);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson(Person person)
        {
            await personService.AddPerson(person);
            return CreatedAtAction(nameof(GetPersonById), new { id = person.PersonId}, person);
            // CreatedAtAction = “I’ve created something, and here’s where you can find it.”
        }

        [HttpPut("{personId}")]
        public async Task<IActionResult> UpdatePerson(Guid personId, Person person)
        {
            if (personId != person.PersonId)
            {
                return BadRequest();
            }
            await personService.UpdatePerson(person);
            return NoContent();
        }   

        [HttpDelete("{personId}")]
        public async Task<IActionResult> DeletePerson(Guid personId)
        {
            await personService.DeletePerson(personId);
            return NoContent();
        }   
    }
}