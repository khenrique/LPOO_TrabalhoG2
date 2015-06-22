using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using LojaFantasias.Data;

namespace LojaFantasias.Data
{
    public class Fantasias
    {
        [Display(Name = "Código Fantasia")]
        public int id_fantasia { get; set; }


        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo Descrição deve ser preenchido.")]
        public string descricao { get; set; }


        [Display(Name = "Quantidade Exemplares")]
        public int qtd_exemplares { get; set; }


        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "O campo Categoria deve ser preenchido.")]
        public Categorias categoria { get; set; }
    }
}

