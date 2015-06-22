using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace LojaFantasias.Data
{
    public class Exemplares
    {
        [Display (Name = "Código Exemplar")]
        public int id_exemplar { get; set; }
        
        [Display(Name = "Tamanho da Fantasia")]
        public string tamanho { get; set; }

        [Display(Name = "Dispinibilidade")]
        public string status_exemplar { get; set; }

        [Display(Name = "Fantasias")]
        public Fantasias fantasia { get; set; }

    }
}
