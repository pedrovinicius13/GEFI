using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Areas.Administracao.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class HomeController : Controller
    {
        // GET: Administracao/Home
        //Nesee controler apenas o ADM tem acesso
        //[Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View();
        }
       // [AllowAnonymous]
        public ActionResult Detalhes()
        {
          return View();
        }
        //[Authorize(Roles = "Usuario")]
        public ActionResult Usuario()
        {
            return View();
        }
    }
}