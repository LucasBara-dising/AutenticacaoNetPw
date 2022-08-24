using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutenticacaoNetPw.Models;

namespace AutenticacaoNetPw.Controllers
{
    public class AutenticacaoController : Controller
    {
        // GET: Autenticacao
        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(CadastroUsuarioViewModel viewmodel)
        {
            if (!ModelState.IsValid)
                return View(viewmodel);
            Usuario novousuario = new Usuario
            {
                UsuNome = viewmodel.UsuNome,
                Login = viewmodel.Login,
                Senha = viewmodel.Senha,
            };
            novousuario.InsertUsuario(novousuario);

            return RedirectToAction("Index", "Home");
        }
        public ActionResult SelectLogin(string Login)
        {
            bool LoginExists;
            string login = new Usuario().SelectLogin(Login);
            if (login.Length == 0)
                LoginExists = false;
            else
                LoginExists = true;
            return Json(!LoginExists, JsonRequestBehavior.AllowGet);
        }
    }
}