using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaFantasias.Data
{
    public class Alugueis
    {
        [Display(Name = "Código Aluguel")]
        public int id_aluguel { get; set; }


        [Display(Name = "Data Retirada")]
        [Required(ErrorMessage = "O campo Data Retirada deve ser preenchida.")]
        public DateTime data_retirada { get; set; }


        [Display(Name = "Data Entrega")]
        public DateTime data_entrega { get; set; }


        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "O campo Cliente deve ser preenchido.")]
        public Clientes cliente { get; set; }


        [Display(Name = "Exemplar Alugado")]
        [Required(ErrorMessage = "O campo Exemplar deve ser preenchido.")]
        public Exemplares exemplar { get; set; }
    }
}
