using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Area.Areas.Painel.Models;

namespace Area.Areas.Painel.Controllers
{
    public class HomePainelController : Controller
    {
        //
        // GET: /Painel/HomePainel/
        public ActionResult _Painel()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            if (usuario.User.Equals("Jhonny") && usuario.Senha.Equals("123"))
            {
                return View("_Painel", usuario);
            }
            ViewBag.erro = "Usuário/Senha inválidos";
            return View();
        }

        public ActionResult CadastrarEmpresa()
        {
            return View();
        }
        public ActionResult EditarEmpresa()
        {
            return View();
        }
        public ActionResult CancelarEmpresa()
        {
            return View();
        }
        public ActionResult DetalheEmpresa()
        {
            return View();
        }
        public ActionResult _PainelSucesso()
        {
            return View();
        }
        public ActionResult _PainelExcluirSucesso()
        {
            return View();
        }

	}
}