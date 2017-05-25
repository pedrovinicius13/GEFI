using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

public class ContextoEF : DbContext
{
    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public ContextoEF() : base("name=ContextoEF")
    {
    }

    public System.Data.Entity.DbSet<projeto_FILA.Models.Cliente> Clientes { get; set; }

    public System.Data.Entity.DbSet<projeto_FILA.Models.Funcionario> Funcionarios { get; set; }

    public System.Data.Entity.DbSet<projeto_FILA.Models.Servico> Servicoes { get; set; }

    public System.Data.Entity.DbSet<projeto_FILA.Models.Fila> Filas { get; set; }
}
