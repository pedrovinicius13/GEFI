using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projeto_FILA.Models
{
    public class Fila
    {
        public int FilaID { get; set; }

        [Required(ErrorMessage = "Informe a situação do atendimento")]
        [Display(Name = "Situação de atendimento")]
        public Situacao Situacao { get; set; }

        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }
        public int FuncionarioID { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public int ServicoID { get; set; }
        public virtual Servico Servico { get; set; }

    }
}