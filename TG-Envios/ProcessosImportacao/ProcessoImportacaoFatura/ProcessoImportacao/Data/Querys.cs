using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoImportacao.Data
{
    public class Querys
    {
        public static string SqlDeleteTempFatura = @"TRUNCATE TABLE temp_Fatura";

        public static string SqlVFaturaAll= @"SELECT * FROM V_Fatura";

        public static string SqlUpdateFaturaNaoProcessado = @"UPDATE Fatura SET 
Fatura.numeroPreFatura = t.numeroPreFatura,
Fatura.dataPreFatura = t.dataPreFatura,
Fatura.numeroFatura = t.numeroFatura,
Fatura.dataVencFatura = t.dataVencFatura,
Fatura.dataFatura = t.dataFatura,
Fatura.CodTranspMatriz = t.CodTranspMatriz,
Fatura.codTranspEmit = t.codTranspEmit,
Fatura.numeroDocFiscal = t.numeroDocFiscal,
Fatura.serieDocFiscal = t.serieDocFiscal,
Fatura.dataDocFiscal = t.dataDocFiscal,
Fatura.chaveCTe = t.chaveCTe,
Fatura.docTransporte = t.docTransporte,
Fatura.valorFrete = t.valorFrete,
Fatura.difValorFrete = t.difValorFrete,
Fatura.aliquotaICMS = t.aliquotaICMS,
Fatura.baseICMS = t.baseICMS,
Fatura.valorICMS = t.valorICMS,
Fatura.aliquotaICMSST = t.aliquotaICMSST,
Fatura.baseICMSST = t.baseICMSST,
Fatura.valorICMSST = t.valorICMSST,
Fatura.aliquotaPIS = t.aliquotaPIS,
Fatura.basePIS = t.basePIS,
Fatura.valorPIS = t.valorPIS,
Fatura.aliquotaCOFINS = t.aliquotaCOFINS,
Fatura.baseCOFINS = t.baseCOFINS,
Fatura.valorCOFINS = t.valorCOFINS,
Fatura.aliquotaISS = t.aliquotaISS,
Fatura.baseISS = t.baseISS,
Fatura.valorISS = t.valorISS,
Fatura.modelo = t.modelo,
Fatura.numero = t.numero,
Fatura.serie = t.serie,
Fatura.dataEmissao = t.dataEmissao,
Fatura.chaveNFeCTe = t.chaveNFeCTe,
Fatura.dataImportacao = CURRENT_TIMESTAMP
from Fatura 
Inner JOIN temp_Fatura t On t.chaveRegistro = Fatura.chaveRegistro  
where Fatura.status NOT Like 'OK';";

        public static string SqlInserirRegistroTempFatura(Fatura dado) 
        {
            StringBuilder sb = new StringBuilder();
            sb = sb.Append("INSERT INTO temp_Fatura( " +
                "chaveRegistro," +
                "numeroPreFatura," +
                "dataPreFatura," +
                "numeroFatura," +
                "dataVencFatura," +
                "dataFatura," +
                "CodTranspMatriz," +
                "codTranspEmit," +
                "numeroDocFiscal," +
                "serieDocFiscal," +
                "dataDocFiscal," +
                "chaveCTe," +
                "docTransporte," +
                "valorFrete," +
                "difValorFrete," +
                "aliquotaICMS," +
                "baseICMS," +
                "valorICMS," +
                "aliquotaICMSST," +
                "baseICMSST," +
                "valorICMSST," +
                "aliquotaPIS," +
                "basePIS," +
                "valorPIS," +
                "aliquotaCOFINS," +
                "baseCOFINS," +
                "valorCOFINS," +
                "aliquotaISS," +
                "baseISS," +
                "valorISS," +
                "modelo," +
                "numero," +
                "serie," +
                "dataEmissao," +
                "chaveNFeCTe" +
                " ) VALUES (" +
"'" + dado.chaveRegistro + "'," +
"'" + dado.numeroPreFatura + "'," +
(dado.dataPreFatura.Length > 0 ? ("'" + dado.dataPreFatura.ToString() + "',") : "null,") +
"'" + dado.numeroFatura + "'," +
(dado.dataVencFatura.Length > 0 ? ("'" + dado.dataVencFatura.ToString() + "',") : "null,") +
(dado.dataFatura.Length > 0 ? ("'" + dado.dataFatura.ToString() + "',") : "null,") +
"'" + dado.CodTranspMatriz + "'," +
"'" + dado.codTranspEmit + "'," +
"'" + dado.numeroDocFiscal + "'," +
"'" + dado.serieDocFiscal + "'," +
"'" + dado.dataDocFiscal + "'," +
"'" + dado.chaveCTe + "'," +
"'" + dado.docTransporte + "'," +
"" + dado.valorFrete.ToString().ToString().Replace(",", ".") + "," +
"" + dado.difValorFrete.ToString().ToString().Replace(",", ".") + "," +
"" + dado.aliquotaICMS.ToString().ToString().Replace(",", ".") + "," +
"" + dado.baseICMS.ToString().ToString().Replace(",", ".") + "," +
"" + dado.valorICMS.ToString().ToString().Replace(",", ".") + "," +
"" + dado.aliquotaICMSST.ToString().ToString().Replace(",", ".") + "," +
"" + dado.baseICMSST.ToString().ToString().Replace(",", ".") + "," +
"" + dado.valorICMSST.ToString().ToString().Replace(",", ".") + "," +
"" + dado.aliquotaPIS.ToString().ToString().Replace(",", ".") + "," +
"" + dado.basePIS.ToString().ToString().Replace(",", ".") + "," +
"" + dado.valorPIS.ToString().ToString().Replace(",", ".") + "," +
"" + dado.aliquotaCOFINS.ToString().ToString().Replace(",", ".") + "," +
"" + dado.baseCOFINS.ToString().ToString().Replace(",", ".") + "," +
"" + dado.valorCOFINS.ToString().ToString().Replace(",", ".") + "," +
"" + dado.aliquotaISS.ToString().ToString().Replace(",", ".") + "," +
"" + dado.baseISS.ToString().ToString().Replace(",", ".") + "," +
"" + dado.valorISS.ToString().ToString().Replace(",", ".") + "," +
"'" + dado.modelo + "'," +
"'" + dado.numero + "'," +
"'" + dado.serie + "'," +
(dado.dataEmissao.Length > 0 ? ("'" + dado.dataEmissao.ToString() + "',") : "null,") +
"'" + dado.chaveNFeCTe + "'" +
                ");");

            string SqlInserirRegistroTempCte = sb.ToString();
            sb.Clear();
            return SqlInserirRegistroTempCte;
        }
        
       



        public static string SqlIncrementarFatura = @"INSERT INTO Fatura (
chaveRegistro,
numeroPreFatura,
dataPreFatura,
numeroFatura,
dataVencFatura,
dataFatura,
CodTranspMatriz,
codTranspEmit,
numeroDocFiscal,
serieDocFiscal,
dataDocFiscal,
chaveCTe,
docTransporte,
valorFrete,
difValorFrete,
aliquotaICMS,
baseICMS,
valorICMS,
aliquotaICMSST,
baseICMSST,
valorICMSST,
aliquotaPIS,
basePIS,
valorPIS,
aliquotaCOFINS,
baseCOFINS,
valorCOFINS,
aliquotaISS,
baseISS,
valorISS,
modelo,
numero,
serie,
dataEmissao,
chaveNFeCTe,
dataImportacao,
status
)
SELECT
chaveRegistro,
numeroPreFatura,
dataPreFatura,
numeroFatura,
dataVencFatura,
dataFatura,
CodTranspMatriz,
codTranspEmit,
numeroDocFiscal,
serieDocFiscal,
dataDocFiscal,
chaveCTe,
docTransporte,
valorFrete,
difValorFrete,
aliquotaICMS,
baseICMS,
valorICMS,
aliquotaICMSST,
baseICMSST,
valorICMSST,
aliquotaPIS,
basePIS,
valorPIS,
aliquotaCOFINS,
baseCOFINS,
valorCOFINS,
aliquotaISS,
baseISS,
valorISS,
modelo,
numero,
serie,
dataEmissao,
chaveNFeCTe,
CURRENT_TIMESTAMP AS dataImportacao,
'Não Pocessado!'
FROM temp_Fatura
wHERE chaveRegistro NOT IN (select chaveRegistro FROM Fatura);";


    }
}
