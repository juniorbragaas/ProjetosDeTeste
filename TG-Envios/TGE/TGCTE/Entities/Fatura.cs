using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TGCTE.Entities
{
    public class Fatura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int codigo { get; set; }
        public DateTime? dataImportacao { get; set; }
        public string chaveRegistro { get; set; }
        public string responseWS { get; set; }
        public int? numeroTentativasEnvio { get; set; }
        public DateTime? dataEnvio { get; set; }
        public string status { get; set; }
        public string numeroPreFatura { get; set; }
        public DateTime? dataPreFatura { get; set; }
        public string numeroFatura { get; set; }
        public DateTime? dataVencFatura { get; set; }
        public DateTime? dataFatura { get; set; }
        public string CodTranspMatriz { get; set; }
        public string codTranspEmit { get; set; }
        public int? numeroDocFiscal { get; set; }
        public int? serieDocFiscal { get; set; }
        public DateTime? dataDocFiscal { get; set; }
        public string chaveCTe { get; set; }
        public string docTransporte { get; set; }
        public decimal? valorFrete { get; set; }
        public decimal? difValorFrete { get; set; }
        public decimal? aliquotaICMS { get; set; }
        public decimal? baseICMS { get; set; }
        public decimal? valorICMS { get; set; }
        public decimal? aliquotaICMSST { get; set; }
        public decimal? baseICMSST { get; set; }
        public decimal? valorICMSST { get; set; }
        public decimal? aliquotaPIS { get; set; }
        public decimal? basePIS { get; set; }
        public decimal? valorPIS { get; set; }
        public decimal? aliquotaCOFINS { get; set; }
        public decimal? baseCOFINS { get; set; }
        public decimal? valorCOFINS { get; set; }
        public decimal? aliquotaISS { get; set; }
        public decimal? baseISS { get; set; }
        public decimal? valorISS { get; set; }
        public int? modelo { get; set; }
        public int? numero { get; set; }
        public int? serie { get; set; }
        public DateTime? dataEmissao { get; set; }
        public string chaveNFeCTe { get; set; }
    }

}
