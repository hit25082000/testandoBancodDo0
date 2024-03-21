using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testandoBancodDo0.Context;
using testandoBancodDo0.Models;

namespace testandoBancodDo0.Controllers
{
    public class ReceitasController : Controller
    {
        private readonly AproveDbContext _dbContext;

        public ReceitasController(AproveDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            if (_dbContext.Receitas == null)
            {
                return Problem("Entity set 'AproveDbContext.Receitas'  is null.");
            }

            var receitas = from m in _dbContext.Receitas
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                receitas = receitas.Where(s => s.Titulo!.Contains(searchString));
            }

            TempData["PreviouUrl"] = Request.Path.Value;
            return View(await receitas.ToListAsync());
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["idIngredientes"] = new SelectList(_dbContext.tab_ingredientes, "Id", "Nome");
            ViewData["idSugestao"] = new SelectList(_dbContext.tab_sugestaoRec, "Id", "Titulo");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Receita receita)
        {
            bool receitaJaCadastrada = _dbContext.Receitas.Any(x => x.Titulo == receita.Titulo);

            if (!receitaJaCadastrada)
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Receitas.Add(receita);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            ViewData["IdIngredientes"] = new SelectList(_dbContext.tab_ingredientes, "Id", "Nome", receita.IdIngredientes);
            ViewData["IdSugestao"] = new SelectList(_dbContext.tab_sugestaoRec, "Id", "Titulo", receita.IdSugestao);
            return View(receita);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var receita = await _dbContext.Receitas.FindAsync(id);
            if (receita == null)
            {
                return NotFound();
            }

            ViewData["IdIngredientes"] = new SelectList(_dbContext.tab_ingredientes, "Id", "Nome", receita.IdIngredientes);
            ViewData["IdSugestao"] = new SelectList(_dbContext.tab_sugestaoRec, "Id", "Titulo", receita.IdSugestao);
            return View(receita);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Receita receita)
        {          

            if (id != receita.Id)
            {
                return NotFound();
            }
                if (ModelState.IsValid)
                {
                    try
                    {
                        _dbContext.Update(receita);
                        await _dbContext.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        
                            throw;
                    }

                    string[] redirect = TempData["PreviouUrl"].ToString().Split('/');

                    return RedirectToAction(redirect[2], redirect[1]);                
                }

            ViewData["IdIngredientes"] = new SelectList(_dbContext.tab_ingredientes, "Id", "Nome", receita.IdIngredientes);
            ViewData["IdSugestao"] = new SelectList(_dbContext.tab_sugestaoRec, "Id", "Titulo", receita.IdSugestao);
            return View(receita);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var receita = await _dbContext.Receitas
                .Include(e => e.Favoritos)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (receita == null)
            {
                return NotFound();
            }

            return View(receita);
        }

        // POST: Estoque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estoque = await _dbContext.Receitas.FindAsync(id);
            _dbContext.Receitas.Remove(estoque);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ReceitaAbobora()
        {
            return View();
        }

        public IActionResult ReceitaFrango()
        {
            return View();
        }

        public IActionResult ReceitaGaspacho()
        {
            return View();
        }                
    }
}
