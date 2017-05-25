using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projeto_FILA.Models
{
    public class Funcionario
    {
        public int FuncionarioID { get; set; }

            [Required(ErrorMessage = "O campo e obrigatótio")]
            [StringLength(150, ErrorMessage = "Limite de 150 caracteres")]
            [Display(Name = "Especialista")]
            public string NomeFuncionario { get; set; }

        public virtual ICollection<Fila> Filas { get; set; }
}
}