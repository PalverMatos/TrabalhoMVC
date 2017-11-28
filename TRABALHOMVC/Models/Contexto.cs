using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace TRABALHOMVC.Models
{
    public class Contexto: DbContext
    {
        /* Define o nome do Banco que será Criado */
        public Contexto() : base("TRABALHOMVC") { }

        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Item> itens { get; set; }
        public DbSet<Venda> vendas { get; set; }

    }
}