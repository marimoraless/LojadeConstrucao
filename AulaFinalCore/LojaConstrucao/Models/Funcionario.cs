using LojaConstrucao.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LojaConstrucao.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string NomeFuncionario { get; set; } = string.Empty;


    };
}
