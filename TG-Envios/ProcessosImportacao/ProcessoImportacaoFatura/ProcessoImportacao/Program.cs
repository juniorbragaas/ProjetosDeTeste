using ProcessoImportacao.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ProcessoImportacao
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
           string opcao =    args[0].ToString().ToUpper();
           switch (opcao)
           {
           case "CTE":
           // Importar Ct-e para o Banco
           break;
           case "FATURA":
           // Importar Faturas para o Banco
           break;
           case "OCORRENCIA":
           // Importar Ocorrencia para o Banco
           break;
           default:
           // Caso usuario execute alguma opção que não existe
           break;
           } */


            string ConnectionBanco = "Data Source=DESKTOP-72FLPN6\\SQLEXPRESS;Initial Catalog=TG;Persist Security Info=True;User ID=sa;Password=admin123";
            string ConnectionView = "Data Source=DESKTOP-72FLPN6\\SQLEXPRESS;Initial Catalog=TGView;Persist Security Info=True;User ID=sa;Password=admin123";
            SqlConnection connectionBanco = new SqlConnection(ConnectionBanco);
            SqlConnection connectionView = new SqlConnection(ConnectionView);
            StringBuilder sb = new StringBuilder();
            string sql;
            List<Fatura> faturas = new List<Fatura>();
            SqlDataReader reader;
            SqlCommand command;

            try
            {
               
                Console.WriteLine("Processo de Importação de Tabela Cte");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                /* Primeiro Passo Apagar  tabela temporaria*/
                Console.WriteLine("1-  Passo Apagar  tabela temporaria");
                Console.WriteLine("TRUNCATE TABLE temp_Fatura");                
                
                connectionBanco.Open();
                sql = Querys.SqlDeleteTempFatura;
                command = new SqlCommand(sql, connectionBanco);
                reader = command.ExecuteReader();
                reader.Close();
                sb.Clear();
                command.Cancel();
                connectionBanco.Close();
                Console.WriteLine("* DADOS APAGADOS OK");
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                Console.WriteLine("--------------------------------------------------------------------------------------------------");

                /* Segundo Passo Armazenar View numa tabela temporaria*/
                Console.WriteLine("2- Passo Armazenar View na tabela temporaria");
                Console.WriteLine("2.1- Armazenar View em Object View (Conexao View) ");
                connectionView.Open();
                sql = Querys.SqlVFaturaAll;
                command = new SqlCommand(sql, connectionView);
                reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    Fatura fatura = new Fatura {
                        chaveRegistro = reader["numeroFatura"].ToString() + "-" + reader["numeroDocFiscal"].ToString() + "-"  + reader["serieDocFiscal"].ToString(),
                        numeroPreFatura = reader["numeroPreFatura"].ToString(),
                        dataPreFatura = reader["dataPreFatura"].ToString(),
                        numeroFatura = reader["numeroFatura"].ToString(),
                                        dataVencFatura = reader["dataVencFatura"].ToString(),
                                        dataFatura = reader["dataFatura"].ToString(),
                                        CodTranspMatriz = reader["CodTranspMatriz"].ToString(),
                                        codTranspEmit = reader["codTranspEmit"].ToString(),
                                        numeroDocFiscal = Convert.ToInt32(reader["numeroDocFiscal"].ToString()),
                                        serieDocFiscal = Convert.ToInt32(reader["serieDocFiscal"].ToString()),
                                        dataDocFiscal = reader["dataDocFiscal"].ToString(),
                                        chaveCTe = reader["chaveCTe"].ToString(),
                                        docTransporte = reader["docTransporte"].ToString(),
                                        valorFrete = Convert.ToDecimal(reader["valorFrete"].ToString()),
                                        difValorFrete = Convert.ToDecimal(reader["difValorFrete"].ToString()),
                                        aliquotaICMS = Convert.ToDecimal(reader["aliquotaICMS"].ToString()),
                                        baseICMS = Convert.ToDecimal(reader["baseICMS"].ToString()),
                                        valorICMS = Convert.ToDecimal(reader["valorICMS"].ToString()),
                                        aliquotaICMSST = Convert.ToDecimal(reader["aliquotaICMSST"].ToString()),
                                        baseICMSST = Convert.ToDecimal(reader["baseICMSST"].ToString()),
                                        valorICMSST = Convert.ToDecimal(reader["valorICMSST"].ToString()),
                                        aliquotaPIS = Convert.ToDecimal(reader["aliquotaPIS"].ToString()),
                                        basePIS = Convert.ToDecimal(reader["basePIS"].ToString()),
                                        valorPIS = Convert.ToDecimal(reader["valorPIS"].ToString()),
                                        aliquotaCOFINS = Convert.ToDecimal(reader["aliquotaCOFINS"].ToString()),
                                        baseCOFINS = Convert.ToDecimal(reader["baseCOFINS"].ToString()),
                                        valorCOFINS = Convert.ToDecimal(reader["valorCOFINS"].ToString()),
                                        aliquotaISS = Convert.ToDecimal(reader["aliquotaISS"].ToString()),
                                        baseISS = Convert.ToDecimal(reader["baseISS"].ToString()),
                                        valorISS = Convert.ToDecimal(reader["valorISS"].ToString()),
                                        modelo = Convert.ToInt32(reader["modelo"].ToString()),
                                        numero = Convert.ToInt32(reader["numero"].ToString()),
                                        serie = Convert.ToInt32(reader["serie"].ToString()),
                                        dataEmissao = reader["dataEmissao"].ToString(),
                                        chaveNFeCTe = reader["chaveNFeCTe"].ToString()


    };
                    faturas.Add(fatura);
                }
                reader.Close();
                command.Cancel();
                sb.Clear();
                connectionBanco.Close();
                Console.WriteLine("* OBJETO PREENCHIDO OK");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("2.2- Inserir ObjectView na Tabela Temporaria");
                connectionBanco.Open();
                foreach (var element in faturas)
                {
                    sql = Querys.SqlInserirRegistroTempFatura(element);
                    command = new SqlCommand(sql, connectionBanco);
                    reader = command.ExecuteReader();
                    reader.Close();
                    command.Cancel();
                    sb.Clear();
                }
                connectionBanco.Close();
                Console.WriteLine("* DADOS DO OBJETO INSERIDOS EM temp_Fatura OK");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("--------------------------------------------------------------------------------------------------");

                /* Terceiro Passo Incluir Registros Novos e modificados na tabela de producao*/
                Console.WriteLine("3- Incluir Registros Novos e modificados da tabela temporaria para tabela de producao");
                Console.WriteLine("3.1- Update de registro que com status != OK (Sem sucesso de resposta do web service)");
                connectionBanco.Open();
                sql = Querys.SqlUpdateFaturaNaoProcessado;
                command = new SqlCommand(sql, connectionBanco);
                reader = command.ExecuteReader();
                reader.Close();
                command.Cancel();
                sb.Clear();
                connectionBanco.Close();
                Console.WriteLine("* ATUALIZANDO REGISTROS NÃO PROCESSADOS DA TABELA Fatura OK");
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                Console.WriteLine("3.2- Incluir registros de novos-Keys da tabela temporaria que nao existem na tabela ");
                /* Considerando inicialmente chave = numeroCte + chaveCte */
                connectionBanco.Open();
                sql = Querys.SqlIncrementarFatura;
                command = new SqlCommand(sql, connectionBanco);
                reader = command.ExecuteReader();
                reader.Close();
                command.Cancel();
                sb.Clear();
                connectionBanco.Close();
                Console.WriteLine("* NOVOS REGISTROS INCLUIDOS NA TABELA Fatura OK");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("--------------------------------------------------------------------------------------------------");

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            
            Console.WriteLine("\nPressione Enter para sair.");
            Console.ReadLine();
        }
    }
}
