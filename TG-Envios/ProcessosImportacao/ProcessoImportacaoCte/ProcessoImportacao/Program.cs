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
            List<Cte> Ctes = new List<Cte>();
            SqlDataReader reader;
            SqlCommand command;

            try
            {
               
                Console.WriteLine("Processo de Importação de Tabela Cte");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                /* Primeiro Passo Apagar  tabela temporaria*/
                Console.WriteLine("1-  Passo Apagar  tabela temporaria");
                Console.WriteLine("TRUNCATE TABLE temp_CTE");                
                
                connectionBanco.Open();
                sql = Querys.SqlDeleteTempCte;
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
                sql = Querys.SqlVCteAll;
                command = new SqlCommand(sql, connectionView);
                reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    Cte cte = new Cte { 
                                        numeroCte = reader["numeroCte"].ToString() ,
                                        NumeroTransporte = reader["NumeroTransporte"].ToString(),
                                        codTranspMatriz = reader["codTranspMatriz"].ToString(),
                                        codTranspFilial = reader["codTranspFilial"].ToString(),
                                        cnpjEmitente = reader["cnpjEmitente"].ToString(),
                                        cnpjTomador = reader["cnpjTomador"].ToString(),
                                        serieCte =  Convert.ToInt32(reader["SerieCte"]),
                                        modeloCte = Convert.ToInt32(reader["modeloCte"]),
                                        dtEmissaoCte = reader["dtEmissaoCte"].ToString(),
                                        cdIbgeOrigem = Convert.ToInt32(reader["cdIbgeOrigem"]),
                                        cdIbgeDestino = Convert.ToInt32(reader["cdIbgeDestino"]),
                                        tipoDoc = reader["tipoDoc"].ToString(),
                                        valorFrete = Convert.ToDecimal(reader["valorFrete"]),
                                        valorImposto = Convert.ToDecimal(reader["valorImposto"]),
                                        chaveCTE = reader["chaveCte"].ToString(),
                                        xmlCte = reader["xmlCte"].ToString(),
                                        chaveNfe = reader["chaveNfe"].ToString(),
                                        DtEmissaoNf = reader["DtEmissaoNf"].ToString()


                    };
                    Ctes.Add(cte);
                }
                reader.Close();
                command.Cancel();
                sb.Clear();
                connectionBanco.Close();
                Console.WriteLine("* OBJETO PREENCHIDO OK");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("2.2- Inserir ObjectView na Tabela Temporaria");
                connectionBanco.Open();
                foreach (var element in Ctes)
                {
                    sql = Querys.SqlInserirRegistroTempCte(element);
                    command = new SqlCommand(sql, connectionBanco);
                    reader = command.ExecuteReader();
                    reader.Close();
                    command.Cancel();
                    sb.Clear();
                }
                connectionBanco.Close();
                Console.WriteLine("* DADOS DO OBJETO INSERIDOS EM temp_Cte OK");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("--------------------------------------------------------------------------------------------------");

                /* Terceiro Passo Incluir Registros Novos e modificados na tabela de producao*/
                Console.WriteLine("3- Incluir Registros Novos e modificados da tabela temporaria para tabela de producao");
                Console.WriteLine("3.1- Update de registro que com status != OK (Sem sucesso de resposta do web service)");
                connectionBanco.Open();
                sql = Querys.SqlUpdateCteNaoProcessado;
                command = new SqlCommand(sql, connectionBanco);
                reader = command.ExecuteReader();
                reader.Close();
                command.Cancel();
                sb.Clear();
                connectionBanco.Close();
                Console.WriteLine("* ATUALIZANDO REGISTROS NÃO PROCESSADOS DA TABELA Cte OK");
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                Console.WriteLine("3.2- Incluir registros de novos-Keys da tabela temporaria que nao existem na tabela ");
                /* Considerando inicialmente chave = numeroCte + chaveCte */
                connectionBanco.Open();
                sql = Querys.SqlIncrementarCte;
                command = new SqlCommand(sql, connectionBanco);
                reader = command.ExecuteReader();
                reader.Close();
                command.Cancel();
                sb.Clear();
                connectionBanco.Close();
                Console.WriteLine("* NOVOS REGISTROS INCLUIDOS NA TABELA Cte OK");
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
