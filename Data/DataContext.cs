using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data {
    public class DataContext : DbContext {
        public DataContext (DbContextOptions<DataContext> options) : base (options) { }
        public DbSet<Aluno> Alunos {
            get;
            set;
        }
        public DbSet<Professor> Professores {
            get;
            set;
        }

        protected override void OnModelCreating (ModelBuilder builder) {
            builder.Entity<Professor> ().HasData (
                new List<Professor> () {
                    new Professor () {
                            Id = 1,
                                Nome = "Valéria",
                        },
                        new Professor () {
                            Id = 2,
                                Nome = "Célia",
                        },
                        new Professor () {
                            Id = 3,
                                Nome = "Viana",
                        },
                }
            );

            builder.Entity<Aluno> ().HasData (
                new List<Aluno> () {
                    new Aluno () {
                            Id = 1,
                                Nome = "João Victor",
                                Sobrenome = "Nascimento",
                                DataNasc = "04/03/1997",
                                ProfessorId = 1
                        },
                        new Aluno () {
                            Id = 2,
                                Nome = "Marcos",
                                Sobrenome = "Paulo",
                                DataNasc = "06/12/1992",
                                ProfessorId = 1
                        },
                        new Aluno () {
                            Id = 3,
                                Nome = "Mairon",
                                Sobrenome = "Henrique",
                                DataNasc = "01/08/2018",
                                ProfessorId = 2
                        }
                }
            );
        }
    }
}