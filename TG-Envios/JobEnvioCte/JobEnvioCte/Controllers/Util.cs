using JobEnvioCte.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WSCteNfe;

namespace JobEnvioCte.Controllers
{
    public class Util
    {
        public static string ConnectionBanco = "Data Source=SMBH-020815\\SQLEXPRESS;Initial Catalog=TG;Persist Security Info=True;User ID=sa;Password=Sysmap*2020";
        public static string ConnectionView = "Data Source=SMBH-020815\\SQLEXPRESS;Initial Catalog=TGView;Persist Security Info=True;User ID=sa;Password=Sysmap*2020";
        public static SqlConnection connectionBanco = new SqlConnection(ConnectionBanco);
        public static SqlConnection connectionView = new SqlConnection(ConnectionView);
        public static SqlCommand command;
        public static SqlDataReader reader;

        public static List<Cte> PrencherListaCteNaoProcessados()
        {
            List<Cte> dados = new List<Cte>();
            
            try
            {
                connectionBanco.Open();
                string sql = @"SELECT * FROM Cte where status not Like 'OK' ;";
                command = new SqlCommand(sql, connectionBanco);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Cte cte = new Cte
                    {
                        numeroCte = reader["numeroCte"].ToString(),
                        chaveRegistro = reader["chaveRegistro"].ToString(),
                        NumeroTransporte = reader["NumeroTransporte"].ToString(),
                        codTranspMatriz = reader["codTranspMatriz"].ToString(),
                        codTranspFilial = reader["codTranspFilial"].ToString(),
                        cnpjEmitente = reader["cnpjEmitente"].ToString(),
                        cnpjTomador = reader["cnpjTomador"].ToString(),
                        serieCte = Convert.ToInt32(reader["SerieCte"]),
                        modeloCte = Convert.ToInt32(reader["modeloCte"]),
                        dtEmissaoCte = Convert.ToDateTime(reader["dtEmissaoCte"].ToString()),
                        cdIbgeOrigem = Convert.ToInt32(reader["cdIbgeOrigem"]),
                        cdIbgeDestino = Convert.ToInt32(reader["cdIbgeDestino"]),
                        tipoDoc = reader["tipoDoc"].ToString(),
                        valorFrete = Convert.ToDecimal(reader["valorFrete"]),
                        valorImposto = Convert.ToDecimal(reader["valorImposto"]),
                        chaveCTE = reader["chaveCte"].ToString(),
                        xmlCte = reader["xmlCte"].ToString(),
                        chaveNfe = reader["chaveNfe"].ToString(),
                        DtEmissaoNf = Convert.ToDateTime(reader["DtEmissaoNf"].ToString()),
                        status = reader["status"].ToString(),
                        numeroTentativasEnvio = Convert.ToInt32(reader["numeroTentativasEnvio"])
                    };
                    dados.Add(cte);
                }
                reader.Close();
                command.Cancel();
                connectionBanco.Close();
                return dados;
            }
            catch (SqlException)
            {
                return null;
            }
        }
        public static DT_EletronicDocumentRequestDados PrencherRequisicao(Cte dado)
        {

            DT_EletronicDocumentRequestDadosDocumentoFiscalNotasTransportadas DocumentoFiscalNotasTransportadas = new DT_EletronicDocumentRequestDadosDocumentoFiscalNotasTransportadas
            {
                chaveNFe = dado.chaveCTE,
                dataEmissao = dado.DtEmissaoNf,
                dataEmissaoSpecified = true

            };
            DT_EletronicDocumentRequestDadosDocumentoFiscalCte DadosDocumentoFiscalCte = new DT_EletronicDocumentRequestDadosDocumentoFiscalCte
            {
                chaveCTe = dado.chaveCTE,
                xmlCTe = dado.xmlCte
            };
            DT_EletronicDocumentRequestDadosDocumentoFiscal DadoDocumentoFiscal = new DT_EletronicDocumentRequestDadosDocumentoFiscal
            {
                numero = dado.numeroCte,
                serie = dado.serieCte.ToString(),
                modelo = dado.modeloCte.ToString(),
                origem = dado.cdIbgeOrigem.ToString(),
                destino = dado.cdIbgeDestino.ToString(),
                tipoDoc = dado.tipoDoc,
                valorFrete = dado.valorFrete.ToString(),
                valorImpostos = dado.valorImposto.ToString(),
                dataEmissao = dado.DtEmissaoNf,
                cte = DadosDocumentoFiscalCte
            };
            List<DT_EletronicDocumentRequestDadosDocumentoFiscal> DadosDocumentoFiscal = new List<DT_EletronicDocumentRequestDadosDocumentoFiscal>();
            DadosDocumentoFiscal.Add(DadoDocumentoFiscal);

            var DocumentRequestDados = new DT_EletronicDocumentRequestDados
            {
                cnpjEmitente = dado.cnpjEmitente,
                codTranspEmit = dado.codTranspFilial,
                cnpjTomador = dado.cnpjTomador,
                codTranspMatriz = dado.codTranspMatriz,
                numeroTransporte = dado.NumeroTransporte,
                documentoFiscal = DadosDocumentoFiscal.ToArray()

            };

            return DocumentRequestDados;
        }

        public static string  AtualizarDadosBanco(Cte dado)
        {
            try
            {
                connectionBanco.Open();
                string sql = @"Update Cte SET dataEnvio = '" + dado.dataEnvio + "',numeroTentativasEnvio = " + dado.numeroTentativasEnvio + ",responseWS = '" + dado.responseWS + "',status = '" + dado.status + "' Where chaveRegistro = '" + dado.chaveRegistro + "';";
                command = new SqlCommand(sql, connectionBanco);
                reader = command.ExecuteReader();
                reader.Close();
                command.Cancel();
                connectionBanco.Close();
                return "OK";

            }
            catch (Exception e)
            {

                return e.Message.ToString();
            }
           
        }
    }
}
