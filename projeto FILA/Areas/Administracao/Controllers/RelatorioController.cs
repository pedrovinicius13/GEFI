using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projeto_FILA.Areas.Administracao.Controllers
{
    public class RelatorioController : Controller
    {
        ContextoEF contexto = new ContextoEF();
        
        public ActionResult TotalDeServicoPorTipo()
        {
            var total = contexto.Funcionarios.ToList();
            return View();
        }

        public ActionResult TotalDeAtendimentoPorFuncionario()
        {
            var total = contexto.Funcionarios.ToList();
            return View();
        }
    }
}