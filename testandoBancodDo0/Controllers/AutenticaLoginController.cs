using Microsoft.AspNetCore.Mvc;
using testandoBancodDo0.Models;
using testandoBancodDo0;
using System;
using System.Linq;
using testandoBancodDo0.Context;

//adicionado recentemente (validação para login no banco)

namespace testandoBancodDo0.Controllers
{
    public class AutenticaLoginController : Controller
    {
        private readonly AproveDbContext _dbContext;

        public AutenticaLoginController(AproveDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = _dbContext.usuarios.FirstOrDefault(u => u.Email == model.Email && u.Senha == model.Senha);

                    if (usuario != null)
                    {
                        // Armazenar informações do usuário na sessão
                        HttpContext.Session.SetString("UserId", usuario.Id.ToString());
                        HttpContext.Session.SetString("UserName", usuario.Name);

                        string UsuarioLogado = HttpContext.Session.GetString("UserName");
                        ViewBag.UserName = UsuarioLogado;

                        return RedirectToAction("Home", "Site");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Credenciais inválidas. Tente novamente.");
                        ModelState.AddModelError(string.Empty, "Verifique as informações digitadas.");
                        return View("~/Views/Site/Login.cshtml", model);
                    }
                }

                return View("~/Views/Site/Login.cshtml", model);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao fazer login: {ex.Message}");
                return View();
            }
        }

    }
}




