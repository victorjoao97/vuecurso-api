using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSchool_API.Data;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Controllers {
    [Route ("[controller]")]
    [ApiController]
    public class AlunoController : Controller {
        private readonly IRepository repository;

        public AlunoController (IRepository repository) {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get () {
            try {
                var result = await repository.GetAllAlunosAsync (true);
                return Ok (result);

            } catch (System.Exception) {
                return StatusCode (StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> Get (int id) {
            try {
                var result = await repository.GetAlunoByIdAsync (id, true);
                return Ok (result);

            } catch (System.Exception) {
                return StatusCode (StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet ("byprofessor/{ProfessorId}")]
        public async Task<IActionResult> GetByProfessor (int ProfessorId) {
            try {
                var result = await repository.GetAlunosByProfessorIdAsync (ProfessorId, true);
                return Ok (result);

            } catch (System.Exception) {
                return StatusCode (StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post (Aluno model) {
            try {
                repository.Add (model);

                if (await repository.SaveChangesAsync ()) {
                    var result = await repository.GetAlunoByIdAsync (model.Id, true);
                    return Ok (result);
                }

            } catch (System.Exception) {

                return StatusCode (StatusCodes.Status500InternalServerError);
            }
            return BadRequest ();
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> Put (int id, Aluno model) {
            try {

                var aluno = await repository.GetAlunoByIdAsync (id);

                if (aluno == null) {
                    return NotFound ();
                }

                repository.Updated (model);

                if (await repository.SaveChangesAsync ()) {
                    aluno = await repository.GetAlunoByIdAsync (id, true);
                    return Ok (aluno);
                }

            } catch (System.Exception) {

                return StatusCode (StatusCodes.Status500InternalServerError);
            }
            return BadRequest ();
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete (int id) {
            try {
                var aluno = await repository.GetAlunoByIdAsync (id);
                if (aluno == null) return NotFound ();

                repository.Delete (aluno);
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