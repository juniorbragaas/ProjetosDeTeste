using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TGCTE.Entities
{
    public class Cte
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int codigo { get; set; }
        public string numeroCte { get; set; }
        public Decimal ICMS { get; set; }
        public DateTime DataEnvio { get; set; }
    }
}
