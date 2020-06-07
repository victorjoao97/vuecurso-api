using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectSchool_API.Models {
    public class Professor {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        public List<Aluno> Alunos { get; set; }
    }
}