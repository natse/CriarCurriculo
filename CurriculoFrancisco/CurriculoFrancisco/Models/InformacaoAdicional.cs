using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculoFrancisco.Models
{
    public class InformacaoAdicional
    {
        public List<DadosPessoais> dadosPessoais { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        public string Empresa { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Função")]
        public string Funcao { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        public DateTime Ano { get; set; }

        [DisplayName("Instituição")]
        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        public string Instituicao { get; set; }
        [DisplayName("Tipo de Formação")]
        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        public string TipoFormacao { get; set; }
        [DisplayName("Ano Instituição")]
        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        public DateTime InstituicaoAno { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Descriação")]
        public string Descriacao { get; set; }
    }
}
