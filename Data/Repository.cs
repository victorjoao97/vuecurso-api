using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data {
    public class Repository : IRepository {
        private readonly DataContext context;

        public Repository (DataContext context) {
            this.context = context;
        }
        public void Add<T> (T entity) where T : class {
            context.Add (entity);
        }
        public void Updated<T> (T entity) where T : class {
            context.Update (entity);
        }
        public void Delete<T> (T entity) where T : class {
            context.Remove (entity);
        }
        public async Task<bool> SaveChangesAsync () {
            return (await context.SaveChangesAsync () > 0);
        }

        public async Task<Aluno[]> GetAllAlunosAsync (bool includeProfessor = false) {
            IQueryable<Aluno> queryable = context.Alunos;
            if (includeProfessor) {
                queryable = queryable.Include (professor => professor.Professor);
            }
            queryable = queryable.AsNoTracking ().OrderBy (aluno => aluno.Id);
            return await queryable.ToArrayAsync ();
        }

        public async Task<Aluno> GetAlunoByIdAsync (int AlunoId, bool includeProfessor = false) {
            IQueryable<Aluno> queryable = context.Alunos;
            if (includeProfessor) {
                queryable = queryable.Include (professor => professor.Professor);
            }
            queryable = queryable.AsNoTracking ().OrderBy (aluno => aluno.Id).Where (aluno => aluno.Id == AlunoId);
            return await queryable.FirstOrDefaultAsync ();
        }

        public async Task<Aluno[]> GetAlunosByProfessorIdAsync (int ProfessorId, bool includeProfessor = false) {
            IQueryable<Aluno> queryable = context.Alunos;
            if (includeProfessor) {
                queryable = queryable.Include (professor => professor.Professor);
            }
            queryable = queryable.AsNoTracking ().OrderBy (aluno => aluno.Id).Where (aluno => aluno.ProfessorId == ProfessorId);
            return await queryable.ToArrayAsync ();
        }

        public async Task<Professor[]> GetAllProfessoresAsync (bool includeAluno = false) {
            IQueryable<Professor> queryable = context.Professores;
            if (includeAluno) {
                queryable = queryable.Include (professor => professor.Alunos);
            }
            queryable = queryable.AsNoTracking ().OrderBy (Professor => Professor.Id);
            return await queryable.ToArrayAsync ();
        }

        public async Task<Professor> GetProfessorByIdAsync (int ProfessorId, bool includeAluno = false) {
            IQueryable<Professor> queryable = context.Professores;
            if (includeAluno) {
                queryable = queryable.Include (professor => professor.Alunos);
            }
            queryable = queryable.AsNoTracking ().OrderBy (Professor => Professor.Id).Where (professor => professor.Id == ProfessorId);
            return await queryable.FirstOrDefaultAsync ();
        }
    }
}