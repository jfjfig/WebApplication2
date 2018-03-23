using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public class Viaturas
    {
        public Viaturas() => ListaMultasFK = new HashSet<Multas>();

        public virtual ICollection<Multas> ListaMultasFK { get; set; }

        public int ID { get; set; }

        public String Matricula { get; set; }

        public String Marca { get; set; }

        public String Modelo { get; set; }

        public String Cor { get; set; }

        public String Dono { get; set; }

        public String MoradaDono { get; set; }

        public String CodigoPostalDono { get; set; }

    }
}