using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LojaFantasias.Data
{
    public class Clientes
    {
        [Display(Name = "Código Cliente")]
        public int id_cliente { get; set; }


        [Display(Name = "Nome Cliente")]
        [Required(ErrorMessage = "O campo Nome deve ser preenchido.")]
        public string nome_cli { get; set; }


        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo Telefone deve ser preenchido.")]
        public string telefone { get; set; }



        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "O campo Endereço deve ser preenchido.")]
        public string endereco { get; set; }



        [Display(Name = "Quantidade já Alugada")]
        public int qtd_alugueis { get; set; }
    }
}
