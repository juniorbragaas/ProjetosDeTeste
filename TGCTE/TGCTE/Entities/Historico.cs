using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TGCTE.Entities
{
    public class Historico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int codigo { get; set; }
        public string tipoEnvio { get; set; }
        public int codigoRegistro { get; set; }
        public string usuario { get; set; }
        public DateTime dataTarefa { get; set; }
        public string status { get; set; }
    }
}
