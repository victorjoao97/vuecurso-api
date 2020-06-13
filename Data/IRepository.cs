using System.Threading.Tasks;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data {
    public interface IRepository {
        void Add<T> (T entity) where T : class;
        void Updated<T> (T entity) where T : class;
        void Delete<T> (T entity) where T : class;
        Task<bool> SaveChangesAsync ();

        Task<Aluno[]> GetAllAlunosAsync (bool includeProfessor = false);
        Task<Aluno> GetAlunoByIdAsync (int AlunoId, bool includeProfessor = false);
        Task<Aluno[]> GetAlunosByProfessorIdAsync (int AlunoId, bool includeProfessor = false);
        Task<Professor[]> GetAllProfessoresAsync (bool includeAluno = false);
        Task<Professor> GetProfessorByIdAsync (int ProfessorId, bool includeAluno = false);
    }
}