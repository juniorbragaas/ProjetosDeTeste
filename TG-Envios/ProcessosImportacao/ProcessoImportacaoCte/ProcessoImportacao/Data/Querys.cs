using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoImportacao.Data
{
    public class Querys
    {
        public static string SqlDeleteTempCte = @"TRUNCATE TABLE temp_CTE";

        public static string SqlVCteAll = @"SELECT * FROM V_Cte";

        public static string SqlUpdateCteNaoProcessado = @"UPDATE Cte SET 
Cte.NumeroTransporte = t.NumeroTransporte,
      Cte.codTranspMatriz=t.codTranspMatriz,
      Cte.codTranspFilial=t.codTranspFilial,
      Cte.cnpjEmitente=t.cnpjEmitente,
      Cte.cnpjTomador=t.cnpjTomador,
     Cte.serieCte=t.serieCte,
      Cte.modeloCte=t.modeloCte,
      Cte.dtEmissaoCte=t.dtEmissaoCte,
      Cte.cdIbgeOrigem=t.cdIbgeOrigem,
      Cte.cdIbgeDestino=t.cdIbgeDestino,
      Cte.tipoDoc=t.tipoDoc,
      Cte.valorFrete=t.valorFrete,
      Cte.valorImposto=t.valorImposto,
      Cte.chaveCTE=t.chaveCTE,
      Cte.xmlCte=t.xmlCte,
      Cte.chaveNfe=t.chaveNfe,
      Cte.DtEmissaoNf=t.DtEmissaoNf,
      Cte.dataImportacao = CURRENT_TIMESTAMP
from Cte 
Inner JOIN temp_Cte t On t.chaveRegistro = Cte.chaveRegistro  
where Cte.status NOT Like 'OK';";

        public static string SqlInserirRegistroTempCte(Cte dado) 
        {
            StringBuilder sb = new StringBuilder();
            sb = sb.Append("INSERT INTO temp_Cte" +
                        "(chaveRegistro, numeroCte, NumeroTransporte, codTranspMatriz,codTranspFilial,cnpjEmitente,cnpjTomador,serieCte,modeloCte,dtEmissaoCte,cdIbgeOrigem,cdIbgeDestino,tipoDoc,valorFrete,valorImposto,chaveCTE,xmlCte,chaveNfe,DtEmissaoNf) VALUES (" +
                        "'" + dado.numeroCte + "-" + dado.chaveCTE + "','"+
                        dado.numeroCte + "','" +
                        dado.NumeroTransporte + "','" +
                        dado.codTranspMatriz + "','" +
                        dado.codTranspFilial + "','" +
                        dado.cnpjEmitente + "','" +
                        dado.cnpjTomador + "'," +
                        dado.serieCte + "," +
                        dado.modeloCte + "," +
                        (dado.dtEmissaoCte.Length > 0 ? ("'" + dado.dtEmissaoCte.ToString() + "',") : "null,") +
                        dado.cdIbgeOrigem + "," +
                        dado.cdIbgeDestino + ",'" +
                        dado.tipoDoc + "'," +
                        dado.valorFrete.ToString().Replace(",", ".") + "," +
                        dado.valorImposto.ToString().Replace(",", ".") + ",'" +
                        dado.chaveCTE + "','" +
                        dado.xmlCte + "','" +
                        dado.chaveNfe + "'," +
                       (dado.DtEmissaoNf.Length > 0 ? ("'" + dado.DtEmissaoNf.ToString() + "'") : "null")+");");

            string SqlInserirRegistroTempCte = sb.ToString();
            sb.Clear();
            return SqlInserirRegistroTempCte;
        }
        
       



        public static string SqlIncrementarCte = @"INSERT INTO Cte 
(
   chaveRegistro,
   numeroCte,
   NumeroTransporte,
   codTranspMatriz,
   codTranspFilial,
   cnpjEmitente,
   cnpjTomador,
   serieCte,
   modeloCte,
   dtEmissaoCte,
   cdIbgeOrigem,
   cdIbgeDestino,
   tipoDoc,
   valorFrete,
   valorImposto,
   chaveCTE,
   xmlCte,
   chaveNfe,
   DtEmissaoNf,
   dataImportacao,
   status
)
SELECT 
   chaveRegistro,
   numeroCte,
   NumeroTransporte,
   codTranspMatriz,
   codTranspFilial,
   cnpjEmitente,
   cnpjTomador,
   serieCte,
   modeloCte,
   dtEmissaoCte,
   cdIbgeOrigem,
   cdIbgeDestino,
   tipoDoc,
   valorFrete,
   valorImposto,
   chaveCTE,
   xmlCte,
   chaveNfe,
   DtEmissaoNf,
   CURRENT_TIMESTAMP AS dataImportacao,
   'Não Pocessado!'
FROM 
	TEMP_Cte
wHERE chaveRegistro NOT IN (select chaveRegistro FROM Cte)";


    }
}
