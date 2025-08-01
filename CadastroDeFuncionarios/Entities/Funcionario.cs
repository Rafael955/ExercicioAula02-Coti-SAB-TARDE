using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeFuncionarios.Entities
{
    public class Funcionario
    {
        public Guid? Id { get; set; }

        [MinLength(10, ErrorMessage = "O nome deve ter pelo menos 10 caracteres.")]
        [MaxLength(150, ErrorMessage = "O nome deve ter no máximo 150 caracteres.")]
        [Required(ErrorMessage = "O nome do funcionário é obrigatório.")]
        public string? Nome { get; set; }

        [Length(6, 6, ErrorMessage = "A matrícula deve ter exatamente 6 digitos.")]
        [Required(ErrorMessage = "A matrícula do funcionário é obrigatória.")]
        public string? Matricula { get; set; }

        [Length(11, 11, ErrorMessage = "O CPF deve ter exatamente 11 digitos.")]
        [Required(ErrorMessage = "O CPF do funcionário é obrigatório.")]
        public string? Cpf { get; set; }
    }
}
