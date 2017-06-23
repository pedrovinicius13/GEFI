using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projeto_FILA.ViewModels
{
    public class TotalDeServicoPorTipoViewModel
    {
        public int ServicoID { get; set; }
        public string Servico { get; set; }
        public decimal Total { get; set; }

    }
}