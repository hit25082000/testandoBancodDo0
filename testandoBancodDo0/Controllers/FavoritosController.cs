using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using testandoBancodDo0.Context;
using testandoBancodDo0.Models;

namespace testandoBancodDo0.Controllers
{
    public class FavoritosController : Controller
    {
        private readonly AproveDbContext _dbContext;
        private string? _usuarioLogadoID;

        public FavoritosController(AproveDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            _usuarioLogadoID = HttpContext.Session.GetString("UserId");
            if (_usuarioLogadoID != null)
            {
                var receitas = _dbContext.Favoritos.First(favoritos => favoritos.UsuarioId == _usuarioLogadoID).Receitas.ToList();

                TempData["PreviouUrl"] = Request.Path.Value;
                return View(receitas);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FavoritarReceita(int receitaID, string userId)
        {
            Receita receita = _dbContext.Receitas.Find(receitaID);

            var receitaJaFavoritada = _dbContext.Favoritos.First(favoritos => favoritos.UsuarioId == userId)
                .Receitas.Any(x => x.Id == receitaID);

            if (receitaJaFavoritada)
            {
                _dbContext.Favoritos.First(favoritos => favoritos.UsuarioId == userId)
                    .Receitas.Remove(receita);
                _dbContext.SaveChanges();
                return NoContent();
            }
                _dbContext.Favoritos.First(favoritos => favoritos.UsuarioId == userId)
                    .Receitas.Add(receita);
                _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
