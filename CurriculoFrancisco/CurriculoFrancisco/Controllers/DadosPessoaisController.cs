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
    public class DadosPessoaisController : Controller
    {
        private readonly CurriculoFranciscoContext _context;

        public DadosPessoaisController(CurriculoFranciscoContext context)
        {
            _context = context;
        }

        // GET: DadosPessoais
        public IActionResult Index()
        {
            return View( _context.DadosPessoais.ToListAsync());
        }

        // GET: DadosPessoais/Details/5
        public IActionResult Detalho(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosPessoais =  _context.DadosPessoais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dadosPessoais == null)
            {
                return NotFound();
            }

            return View(dadosPessoais);
        }

        // GET: DadosPessoais/Create
        public IActionResult Criar()
        {
            return View();
        }

        // POST: DadosPessoais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar([Bind("Id,Instituicao,Curso,Ano,Nome,Email,Contado,Idade,EstadoCivil,Cargo,Funcao")] DadosPessoais dadosPessoais)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dadosPessoais);
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dadosPessoais);
        }

        // GET: DadosPessoais/Edit/5
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosPessoais =  _context.DadosPessoais.FindAsync(id);
            if (dadosPessoais == null)
            {
                return NotFound();
            }
            return View(dadosPessoais);
        }

        // POST: DadosPessoais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Editar(int id, [Bind("Id,Instituicao,Curso,Ano,Nome,Email,Contado,Idade,EstadoCivil,Cargo,Funcao")] DadosPessoais dadosPessoais)
        {
            if (id != dadosPessoais.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dadosPessoais);
                    _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DadosPessoaisExists(dadosPessoais.Id))
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
            return View(dadosPessoais);
        }

        // GET: DadosPessoais/Delete/5
        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosPessoais = await _context.DadosPessoais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dadosPessoais == null)
            {
                return NotFound();
            }

            return View(dadosPessoais);
        }

        // POST: DadosPessoais/Delete/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExcluirConfirmed(int id)
        {
            var dadosPessoais = await _context.DadosPessoais.FindAsync(id);
            _context.DadosPessoais.Remove(dadosPessoais);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DadosPessoaisExists(int id)
        {
            return _context.DadosPessoais.Any(e => e.Id == id);
        }
    }
}
