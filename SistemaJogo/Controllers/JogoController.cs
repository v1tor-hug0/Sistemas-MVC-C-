using System;
using System.Linq;
using System.Threading.Tasks;
using SistemaJogo.Models;
using SistemaJogo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


namespace SistemaJogo.Controllers
{
    public class JogoController : Controller
    {
        private readonly AppDbContext _context;

        public JogoController(AppDbContext contextConstrutor)
        {
            _context = contextConstrutor;
        }
        

        public async Task<IActionResult> Index()
        {
            var personagens = await _context.TabelaPersonagen.ToListAsync();
            return View(personagens);
        }

        [HttpGet]

        public IActionResult Criar() => View();

        [HttpPost]
        public async Task<IActionResult> Criar(string nomeC, int nivelC, string Classe)
        {
            Personagem? personagem = null;
            if (Classe == "Guerreiro")
            {
                personagem = new Guerreiro(nomeC, nivelC);
            }
            else if (Classe == "Mago")
            {
                personagem = new Mago(nomeC, nivelC);
            }
            else
            {
                return BadRequest("Tipo de personagem inválido.");
            }

            _context.TabelaPersonagen.Add(personagem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Deletar(int id)
        {
            var personagem = await _context.TabelaPersonagen.FindAsync(id);
            if (personagem == null)
            {
                return NotFound();
            }

            _context.TabelaPersonagen.Remove(personagem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
            
        }

    }
}