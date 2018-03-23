using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{ 
    public class MultasDb:DbContext
    {
        public MultasDb():base("MultasDbConS")
        {

        }

        public virtual DbSet<Viaturas> Viaturas { get; set; }
        public virtual DbSet<Multas> Multas { get; set; }
        public virtual DbSet<Condutores> Condutores { get; set; }
        public virtual DbSet<Agentes> Agentes { get; set; }

    }
}