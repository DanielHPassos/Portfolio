using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class Mensagem
    {
        [Required]
        [MaxLength(250, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(3, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }
        [EmailAddress, Required]
        public string Email { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(10, ErrorMessage = "Mínimo {0} caracteres")]
        public string Texto { get; set; }
    }
}
