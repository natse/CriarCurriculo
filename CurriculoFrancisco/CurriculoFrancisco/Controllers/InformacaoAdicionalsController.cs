using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CurriculoFrancisco.Models;

namespace CurriculoFrancisco.Controllers
{
    public class InformacaoAdicionalsController : Controller
    {
        private readonly CurriculoFranciscoContext _context;

        public InformacaoAdicionalsController(CurriculoFranciscoContext context)
        {
            _context = context;
        }

        // GET: InformacaoAdicionals
        public IActionResult Index()
        {
            return View(_context.InformacaoAdicional.ToListAsync());
        }

        // GET: InformacaoAdicionals/Details/5
        public IActionResult Detalho(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var informacaoAdicional = _context.InformacaoAdicional
                .FirstOrDefaultAsync(m => m.Id == id);
            if (informacaoAdicional == null)
            {
                return NotFound();
            }

            return View(informacaoAdicional);
        }

        // GET: InformacaoAdicionals/Create
        public IActionResult Criar()
        {
            return View();
        }

        // POST: InformacaoAdicionals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar([Bind("Id,Empresa,Funcao,Ano,Instituicao,TipoFormacao,InstituicaoAno,Descriacao")] InformacaoAdicional informacaoAdicional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(informacaoAdicional);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(informacaoAdicional);
        }

        // GET: InformacaoAdicionals/Edit/5
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var informacaoAdicional = _context.InformacaoAdicional.FindAsync(id);
            if (informacaoAdicional == null)
            {
                return NotFound();
            }
            return View(informacaoAdicional);
        }

        // POST: InformacaoAdicionals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, [Bind("Id,Empresa,Funcao,Ano,Instituicao,TipoFormacao,InstituicaoAno,Descriacao")] InformacaoAdicional informacaoAdicional)
        {
            if (id != informacaoAdicional.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(informacaoAdicional);
                    _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InformacaoAdicionalExists(informacaoAdicional.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(informacaoAdicional);
        }

        // GET: InformacaoAdicionals/Delete/5
        public IActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var informacaoAdicional = _context.InformacaoAdicional
                .FirstOrDefaultAsync(m => m.Id == id);
            if (informacaoAdicional == null)
            {
                return NotFound();
            }

            return View(informacaoAdicional);
        }

        // POST: InformacaoAdicionals/Delete/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExcluirConfirmed(int id)
        {
            var informacaoAdicional = await _context.InformacaoAdicional.FindAsync(id);
            _context.InformacaoAdicional.Remove(informacaoAdicional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InformacaoAdicionalExists(int id)
        {
            return _context.InformacaoAdicional.Any(e => e.Id == id);
        }
    }
}
