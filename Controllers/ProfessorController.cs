using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSchool_API.Data;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Controllers {
    [Route ("[controller]")]
    [ApiController]
    public class ProfessorController : Controller {
        private readonly IRepository repository;

        public ProfessorController (IRepository repository) {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get () {
            try {
                var result = await repository.GetAllProfessoresAsync (true);
                return Ok (result);

            } catch (System.Exception) {
                return StatusCode (StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> Get (int id) {
            try {
                var results = await repository.GetProfessorByIdAsync (id, true);
                return Ok (results);

            } catch (System.Exception) {
                return StatusCode (StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post (Professor model) {
            try {
                repository.Add (model);

                if (await repository.SaveChangesAsync ()) {
                    return Created ($"/api/professor/{model.Id}", model);
                }

            } catch (System.Exception) {

                return StatusCode (StatusCodes.Status500InternalServerError);
            }
            return BadRequest ();
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> Put (int id, Professor model) {
            try {
                var professor = await repository.GetProfessorByIdAsync (id);

                if (professor == null) return NotFound ();

                repository.Updated (model);

                if (await repository.SaveChangesAsync ()) {
                    return Created ($"/api/professor/{model.Id}", model);
                }

            } catch (System.Exception) {

                return StatusCode (StatusCodes.Status500InternalServerError);
            }
            return BadRequest ();
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete (int id) {
            try {
                var professor = await repository.GetProfessorByIdAsync (id);

                if (professor == null) return NotFound ();

                repository.Delete (professor);

                if (await repository.SaveChangesAsync ()) {
                    return NoContent ();
                }

            } catch (System.Exception) {

                return StatusCode (StatusCodes.Status500InternalServerError);
            }
            return BadRequest ();
        }
    }
}