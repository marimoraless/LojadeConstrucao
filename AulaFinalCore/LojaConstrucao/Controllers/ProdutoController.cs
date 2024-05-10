using Microsoft.AspNetCore.Mvc;
using LojaConstrucao.Models;
using System.Collections.Generic;
using System.Linq;

namespace LojaConstrucao.Controllers
{
    public class ProdutoController : Controller
    {
        private static List<Produto> _produtos = new List<Produto>()
        {
            new Produto {CaminhoImagem = "IMG/IMG5.jpg", ProdutoId = 1, NomeProduto = "Ração Hills para Cães Filhotes de Mini e Pequeno Porte - Sabor: Frango" , Preço = "R$ 169,99" },
            new Produto {CaminhoImagem = "IMG/IMG7.jpg" , ProdutoId = 2, NomeProduto = "Ração Hills Science Diet para Cães Adultos de Grande Porte Sabor: Frango", Preço = "R$ 479,99"},
            new Produto { CaminhoImagem = "IMG/IMG8.jpg", ProdutoId = 3, NomeProduto = "Ração Golden Fórmula Mini Bits Para Cães Adultos de Porte Pequeno Sabor: Carne e Arroz", Preço = "R$ 166,90"},

        };

        public IActionResult Index()
        {
            return View(_produtos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.ProdutoId = _produtos.Count > 0 ? _produtos.Max(c => c.ProdutoId) + 1 : 1;
                _produtos.Add(produto);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var produto = _produtos.FirstOrDefault(c => c.ProdutoId == id);
            if (produto == null)
                return NotFound();

            _produtos.Remove(produto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var produto = _produtos.FirstOrDefault(c => c.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        [HttpPost]
        public IActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                var existingProduto = _produtos.FirstOrDefault(c => c.ProdutoId == produto.ProdutoId);
                if (existingProduto != null)
                {
                    existingProduto.NomeProduto = produto.NomeProduto;

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            return View(produto);
        }
    }
}
