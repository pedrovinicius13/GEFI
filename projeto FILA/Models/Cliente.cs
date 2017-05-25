using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projeto_FILA.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "O campo e obrigatótio")]
        [StringLength(150, ErrorMessage = "Limite de 150 caracteres")]
        [Display(Name = "Cliente")]
        public string NomeCliente { get; set; }

        [Required(ErrorMessage = "O campo e obrigatótio")]
        [MinLength(11, ErrorMessage = "O tamanho mínimo são 11 caracteres.")]
        [StringLength(11, ErrorMessage = "Limite de 11 caracteres")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório [ formato: (00)00000-0000 ]")]
        [RegularExpression(@"^\(\d{2}\)\d{5}-\d{4}$", ErrorMessage = "Telefone inválido")]
        [Display(Name = "Telefone [ formato: (00)00000-0000 ]")]
        public string Celular { get; set; }

        public virtual ICollection<Fila> Filas { get; set; }

}
}