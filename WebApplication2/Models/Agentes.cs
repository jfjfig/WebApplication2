using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Agentes
    {
        public Agentes() => ListaMultasFK = new HashSet<Multas>();

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required(ErrorMessage="O campo {0} é de preenchimento obrigatorio.")]
    [RegularExpression("[A-ZÂÓÍÉ][a-záéíóúãõâêôûñäëïöü]+(( | e | de | do | das | d'|-)[A-ZÂÓÍ][a-záéíóúãõâêôûñäëïöü]+){1,3}", ErrorMessage = "Deve pelo menos o primeiro e ultimo nome, ambos com a primeira letra maiuscula e as outras minusculas")]
        [StringLength(70,ErrorMessage ="O {0} só aceita {1} caracteres")]
        public String Nome { get; set; }

        public String Fotografia { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatorio.")]
     [RegularExpression("([A-ZÂÓÍÉ][0-9a-záéíóúãõâêôûñäëïöü ]+)+", ErrorMessage = "Campo não valido")]
        public String Esquadra{ get; set; }

        public virtual ICollection<Multas> ListaMultasFK { get; set; }
    }
}