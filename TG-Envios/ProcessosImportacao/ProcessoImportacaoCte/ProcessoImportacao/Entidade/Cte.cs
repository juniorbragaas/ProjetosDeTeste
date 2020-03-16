using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoImportacao
{
    public class Cte
    {
        public int codigo { get; set; }
        public string numeroCte { get; set; }
        public string dataEnvio { get; set; }
        public string status { get; set; }
        public string dataImportacao { get; set; }
        public int? numeroTentativasEnvio { get; set; }
        public string NumeroTransporte { get; set; }
        public string codTranspMatriz { get; set; }
        public string codTranspFilial { get; set; }
        public string cnpjEmitente { get; set; }
        public string cnpjTomador { get; set; }
        public int? serieCte { get; set; }
        public int? modeloCte { get; set; }
        public string dtEmissaoCte { get; set; }
        public int? cdIbgeOrigem { get; set; }
        public int? cdIbgeDestino { get; set; }
        public string tipoDoc { get; set; }
        public decimal? valorFrete { get; set; }
        public decimal? valorImposto { get; set; }
        public string chaveCTE { get; set; }
        public string xmlCte { get; set; }
        public string chaveNfe { get; set; }
        public string DtEmissaoNf { get; set; }
    }
}
