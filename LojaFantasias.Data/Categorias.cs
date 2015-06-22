using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaFantasias.Data
{
    public class Categorias
    {
        [Display(Name = "Código Categoria")]
        public int id_categoria { get; set; }


        [Display(Name = "Nome Categoria")]
        [Required(ErrorMessage = "O campo Nome deve ser preenchido.")]
        public string nome_cat { get; set; }
    }
}
