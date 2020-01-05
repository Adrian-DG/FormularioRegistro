using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FormularioRegistro.Models
{
    public class ClienteContext: DbContext
    {
        public ClienteContext(): base("ClienteDB")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}