using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CurriculoFrancisco.Models;
using CurriculoFrancisco.Controllers;


namespace CurriculoFrancisco.Models
{
    public class DadosPessoais
       
    {
        public int Id { get; set; }
        public IList<InformacaoAdicional> informacaoAdicionals { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Instituição")]
        public string Instituicao { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        public string Curso { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        public DateTime Ano { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        public int Contado { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        public int Idade { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Estado Civil")]
        public string EstadoCivil { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        public string Cargo { get; set; }
        [DisplayName("Função")]
        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        public string Funcao { get; set; }
    }
}
