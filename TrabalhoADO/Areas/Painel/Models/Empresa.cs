using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace TrabalhoADO.Areas.Painel.Models
{
    public class Empresa
    {
        public int EmpresaId { get; set; }

        [Required(ErrorMessage = "Preencha o nome")]
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string CatId { get; set; }
        public string nomeCat { get; set; }
    }
}