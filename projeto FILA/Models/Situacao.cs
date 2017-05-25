using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projeto_FILA.Models
{
    public enum Situacao
    
        
        {
            [Display(Name = @"Em Atendimento")]
            EmAtendimento = 1,
            [Display(Name = @"Em Espera")]
            EmEspera = 2,
            [Display(Name = @"Atendido")]
            Atendido = 3
        }
    }
