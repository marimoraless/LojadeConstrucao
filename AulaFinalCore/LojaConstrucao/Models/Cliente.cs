using LojaConstrucao.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LojaConstrucao.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string NomeCliente { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    };
}



        //public Cliente(int clienteid, string nomecliente, string email)
        // {

//ClienteId = clienteid;
//NomeCliente = nomecliente;
//Email = email;
//}
// }
