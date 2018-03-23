using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Multas

    {
        public int ID { get; set; }

        public String LocalInf { get; set; }

        public DateTime DataInf { get; set; }

        public String Infracao { get; set; }

        public Decimal ValorMulta { get; set; }

        [ForeignKey("Agente")]
        public int AgenteFK { get; set; }
        public virtual Agentes Agente { get; set; }

        [ForeignKey("Viatura")]
        public int ViaturaFK { get; set; }
        public virtual Viaturas Viatura { get; set; }

        [ForeignKey("Condutor")]
        public int CondutorFK { get; set; }
        public virtual Condutores Condutor { get; set; }
    }
}