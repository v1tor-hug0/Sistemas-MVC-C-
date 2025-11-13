using System;
using Microsoft.AspNetCore.Mvc;
using SistemaFuncionario.Models;
using SistemaFuncionario.data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SistemaFuncionario.Controllers
{
    
    public class CursoController : Controller
    {
        private readonly AppDbContext _context;


        //Construtor
        public CursoController(AppDbContext contextConstructor)
        {
            _context = contextConstructor;
        }


        //listar
        public async Task<IActionResult> Index()
        {
            var cursos = await _context.TabelaCurso.ToListAsync();
            return View(cursos);
        }

        [HttpGet]

        //criar
        public IActionResult Criar() => View();
        [HttpPost]
        public async Task<IActionResult> Criar(string nomeC, int horasC, string tipoCurso)
        {
            Curso? novoCurso = null;
            if (tipoCurso == "Tecnico")
            {
                novoCurso = new Tecnico(nomeC, horasC);
            }
            else if (tipoCurso == "Superior")
            {
                novoCurso = new Superior(nomeC, horasC);
            }
            else
            {
                return BadRequest("Tipo de curso inválido.");
            }

            _context.TabelaCurso.Add(novoCurso);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        //deletar
        public async Task<IActionResult> Deletar(int id)
        {
            var curso = await _context.TabelaCurso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            _context.TabelaCurso.Remove(curso);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}