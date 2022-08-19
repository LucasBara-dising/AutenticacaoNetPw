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
            return View();
        }
    }
}