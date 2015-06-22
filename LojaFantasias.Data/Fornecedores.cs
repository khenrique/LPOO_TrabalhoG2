using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaFantasias.Data
{
    public class Fornecedores
    {
        [Display(Name = "Código Fornecedor")]
        public int id_fornecedor { get; set; }


        [Display(Name = "Nome Fornecedor")]
        [Required(ErrorMessage = "O campo Nome deve ser preenchido.")]
        public string nome_fornecedor { get; set; }


        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo Telefone deve ser preenchido.")]
        public string telefone { get; set; }


        [Display(Name = "Quantidade De Fantasias Fornecidas")]
        public int qtd_fantasias { get; set; }
    }
}
