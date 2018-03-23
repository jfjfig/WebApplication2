using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public class Condutores
    {
        public Condutores() => ListaMultasFK = new HashSet<Multas>();

        public virtual ICollection<Multas> ListaMultasFK { get; set; }

        public int ID { get; set; }

        public String Nome { get; set; }

        public String BI { get; set; }

        public String Telemovel { get; set; }

        public DateTime DataNasc { get; set; }

        public String CCond { get; set; }

        public String LocalEmicao { get; set; }

        public DateTime DataValidade { get; set; }
    }
}