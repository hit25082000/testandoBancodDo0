using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testandoBancodDo0.Context;
using testandoBancodDo0.Models;

namespace testandoBancodDo0.Controllers
{
    public class CadastroController : Controller
    {
        private readonly AproveDbContext _dbContext;

        public CadastroController(AproveDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Cadastrar([Bind("Name,Email,Senha")] UsuarioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Crie uma instância do seu modelo de dados e popule com os dados do formulário
                    var novoUsuario = new UsuarioModel
                    {
                        Name = model.Name,
                        Email = model.Email,
                        Senha = model.Senha
                        
                    };

                    // Adicione o novo usuário ao contexto do banco de dados
                    _dbContext.usuarios.Add(novoUsuario);

                    // Salve as alterações no banco de dados
                    _dbContext.SaveChanges();

                    // Redirecione para a página desejada após o cadastro
                    return RedirectToAction("Login", "Site");
                }

                // Se houver erros de validação, retorne à página de cadastro com os erros
                Console.WriteLine("Deu erro aqui camarada");
                return View("/Views/Site/Cadastro.cshtml", model);
            }
            catch (Exception ex)
            {
                // Registre a exceção para ajudar na depuração
                Console.WriteLine($"Erro ao cadastrar: {ex.Message}");
                return View();
            }
        }
    }
}



