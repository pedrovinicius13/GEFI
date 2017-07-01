using projeto_FILA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Areas.Administracao.Controllers
{
    public class RelatorioController : Controller
    {
        ContextoEF contexto = new ContextoEF();

        public ActionResult TotalDeServicoPorTipo()
        {
            var resultado = (from s in contexto.Servicoes
                             join f in contexto.Filas
             on s.ServicoID equals f.ServicoID
                             where f.Situacao == projeto_FILA.Models.Situacao.Atendido


                             group s.NomeServico by s.ServicoID into g

                             select new TotalDeServicoPorTipoViewModel
                             {

                                 ServicoID = g.Key,
                                 //Servico = s.NomeServico,
                                 Total = g.Count()

                             }).ToList();



            return View(resultado);
        }

        public ActionResult RelatorioDeFuncionarios()
        {
            
            return View();
        }
    }
}