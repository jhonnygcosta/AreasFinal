using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Area.Models;

namespace Area.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _ResultadoPesquisa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Pesquisa pesquisa)
        {

            return View("_ResultadoPesquisa", pesquisa);
        }

        public ActionResult Empresas()
        {
            return View();
        }

        public ActionResult DetalheEmpresa()
        {
            return View();
        }
    }
}