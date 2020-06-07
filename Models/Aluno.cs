using System.ComponentModel.DataAnnotations;

namespace ProjectSchool_API.Models {
    public class Aluno {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Required]
        public string DataNasc { get; set; }
        public int ProfessorId { get; set; }

        public Professor Professor { get; set; }
    }
}