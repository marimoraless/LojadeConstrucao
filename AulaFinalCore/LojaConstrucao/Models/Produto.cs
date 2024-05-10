using LojaConstrucao.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LojaConstrucao.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public string CaminhoImagem { get; set; }
        public string Preço { get; set; }

    };
}

