using Microsoft.AspNetCore.Mvc;

namespace ProjectSchool_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfessorController:Controller
    {
        public ProfessorController(){
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}