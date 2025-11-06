using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroDeEstudantes.Data;
using CadastroDeEstudantes.Models;
using System.Linq.Expressions;

namespace CadastroDeEstudantes.Controllers
{
    public class EstudantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstudantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Estudantes
        public async Task<IActionResult> Index(string termoBusca)
        {
            var estudantes = from e in _context.Estudantes
                             select e;

            if (!String.IsNullOrEmpty(termoBusca))
            {
                estudantes = estudantes.Where(s => s.Nome.Contains(termoBusca)
                                                || s.CPF.Contains(termoBusca)
                                                || s.Endereco.Contains(termoBusca));
            }

            return View(await estudantes.OrderBy(e => e.Nome).ToListAsync());
        }

        // GET: Estudantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudante = await _context.Estudantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudante == null)
            {
                return NotFound();
            }

            return View(estudante);
        }

        // GET: Estudantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudantes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CPF,Endereco,DataConclusao")] Estudante estudante)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(estudante);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Estudante cadastrado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    // Verifica a exceção interna para o erro de chave única do SQL Server (números 2601 ou 2627)
                    if (ex.InnerException is Microsoft.Data.SqlClient.SqlException sqlEx &&
                       (sqlEx.Number == 2601 || sqlEx.Number == 2627))
                    {
                        ModelState.AddModelError("CPF", "Este CPF já está cadastrado em nosso sistema.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Ocorreu um erro ao salvar os dados.");
                    }
                }
            }
            return View(estudante);
        }

        // GET: Estudantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudante = await _context.Estudantes.FindAsync(id);
            if (estudante == null)
            {
                return NotFound();
            }
            return View(estudante);
        }

        // POST: Estudantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,CPF,Endereco,DataConclusao")] Estudante estudante)
        {
            if (id != estudante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudante);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Estudante atualizado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    // Verifica a exceção interna para o erro de chave única do SQL Server (números 2601 ou 2627)
                    if (ex.InnerException is Microsoft.Data.SqlClient.SqlException sqlEx &&
                       (sqlEx.Number == 2601 || sqlEx.Number == 2627))
                    {
                        ModelState.AddModelError("CPF", "Este CPF já está cadastrado em nosso sistema.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Ocorreu um erro ao salvar as alterações.");
                    }
                }
            }
            return View(estudante);
        }

        // GET: Estudantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudante = await _context.Estudantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudante == null)
            {
                return NotFound();
            }

            return View(estudante);
        }

        // POST: Estudantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudante = await _context.Estudantes.FindAsync(id);
            if (estudante != null)
            {
                _context.Estudantes.Remove(estudante);
            }

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Estudante excluído com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        private bool EstudanteExists(int id)
        {
            return _context.Estudantes.Any(e => e.Id == id);
        }
    }
}