using LojaConstrucao.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LojaConstrucao.Controllers
{
    public class FuncionarioController : Controller
    {
        private static List<Funcionario> _funcionario = new List<Funcionario>()
        {
            new Funcionario { FuncionarioId = 1, NomeFuncionario = "Mariana Morales" },
            new Funcionario { FuncionarioId = 2, NomeFuncionario = "Juan Pablo" },
            new Funcionario { FuncionarioId = 3, NomeFuncionario = "Maria Silva" },
            new Funcionario { FuncionarioId = 4, NomeFuncionario = "José Silva" }
        };

        public IActionResult Index()
        {
            return View(_funcionario);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                funcionario.FuncionarioId = _funcionario.Count > 0 ? _funcionario.Max(f => f.FuncionarioId) + 1 : 1;
                _funcionario.Add(funcionario);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var funcionario = _funcionario.FirstOrDefault(f => f.FuncionarioId == id);
            if (funcionario == null)
                return NotFound();

            _funcionario.Remove(funcionario);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var funcionario = _funcionario.FirstOrDefault(f => f.FuncionarioId == id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        [HttpPost]
        public IActionResult Edit(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                var existingFuncionario = _funcionario.FirstOrDefault(f => f.FuncionarioId == funcionario.FuncionarioId);
                if (existingFuncionario != null)
                {
                    existingFuncionario.NomeFuncionario = funcionario.NomeFuncionario;
                    
                }
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }


        public IActionResult Detalhes(int id)
        {

            var funcionario = _funcionario.FirstOrDefault(c => c.FuncionarioId == id);
            if (funcionario == null)
                return NotFound();
            return View(funcionario);


        }
    }
}
