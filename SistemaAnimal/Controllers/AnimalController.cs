using System;
using System.Linq;
using System.Threading.Tasks;
using SistemaAnimal.Models;
using Microsoft.AspNetCore.Mvc;
using SistemaAnimal.Data;
using Microsoft.EntityFrameworkCore;

namespace SistemaAnimal.Controllers
{
    public class AnimalController : Controller
    {
        private readonly AppDbContext _context;

        //Construtor
        public AnimalController(AppDbContext contextConstrutor)
        {
            _context = contextConstrutor;
        }

        //Listar
        public async Task<IActionResult> Index()
        {
            var Animais = await _context.TabelaAnimal.ToListAsync();
            return View(Animais);
        }
        [HttpGet]

        //Criar
        public IActionResult Criar() => View();
        [HttpPost]

        public async Task<IActionResult> Criar(string nomeC, string tipoAnimal)
        {
            Animal? novoAnimal = null;

            if (tipoAnimal == "Leao")
            {
                novoAnimal = new Leao(nomeC);
            }
            else if (tipoAnimal == "Elefante")
            {
                novoAnimal = new Elefante(nomeC);
            }
            else
            {
                return BadRequest("Tipo de animal inválido.");
            }

            _context.TabelaAnimal.Add(novoAnimal);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //Deletar

        public async Task<IActionResult> Deletar(int id)
        {
            var animalT = await _context.TabelaAnimal.FindAsync(id);
            if (animalT == null)
            {
                return NotFound();
            }

            _context.TabelaAnimal.Remove(animalT);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
    }
}