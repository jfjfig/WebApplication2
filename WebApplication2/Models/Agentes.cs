using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public class Agentes
    {
        public Agentes() => ListaMultasFK = new HashSet<Multas>();

        public int ID { get; set; }

        public String Nome { get; set; }

        public String Fotografia { get; set; }

        public String Esquadra{ get; set; }

        public virtual ICollection<Multas> ListaMultasFK { get; set; }
    }
}