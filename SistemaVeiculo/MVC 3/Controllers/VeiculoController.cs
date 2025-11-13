using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_3.Data;
using MVC_3.Models;

namespace MVC_3.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly AppDbContext _context;

        public VeiculoController(AppDbContext contextConstrutor)
        {
            _context = contextConstrutor;
        }

        // LISTAR
        // async / await -> executa a função de listar dentro do banco, mas permite que o sistema continue rodando enquanto isso acontece.

        public async Task<IActionResult> Index()
        {
            // ToList - lista as informações dentro da tabela funcionário.
            var lista = await _context.TabelaVeiculo.ToListAsync();

            // retorna a view com a lista de funcionários no index.
            return View(lista);
        }

        // Formulário de criação - retorna a lista de formulário vazia
        [HttpGet] // GET - Listar (Como se fosse um SELECT no banco)
        public IActionResult Criar() => View();

        // Cadastrar as informações do formulário no banco de dados.
        [HttpPost]
        public async Task<IActionResult> Criar(string CModelo, int CAno, string Tipo)
        {
            Veiculo? novoVeiculo = null;

            if (Tipo == "Carro")
            {
                novoVeiculo = new Carro(CModelo, CAno);
            }
            else if (Tipo == "Moto")
            {
                novoVeiculo = new Moto(CModelo, CAno);
            }
            else
            {
                return BadRequest("Cargo inválido.");
            }

            _context.TabelaVeiculo.Add(novoVeiculo);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // Excluir
        public async Task<IActionResult> Deletar(int id)
        {
            // variável que vai armazenar o registro de funcionário encontrado pelo id.
            // Find(id) -> busca o registro pelo id
            var Veiculo = await _context.TabelaVeiculo.FindAsync(id);

            if (Veiculo == null) return NotFound();

            // Remove() -> remove o registro do banco.
            _context.TabelaVeiculo.Remove(Veiculo);

            // Salva as alterações
            await _context.SaveChangesAsync();

            // Retorna para a Action: Index -> Mostra a lista atualizada de funcionários.
            return RedirectToAction("Index");
        }

    }
}