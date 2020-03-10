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
            string ConnectionBanco = "Data Source=SMBH-020815\\SQLEXPRESS;Initial Catalog=TG;Persist Security Info=True;User ID=sa;Password=Sysmap*2020";
            string ConnectionView = "Data Source=SMBH-020815\\SQLEXPRESS;Initial Catalog=TGView;Persist Security Info=True;User ID=sa;Password=Sysmap*2020";
            SqlConnection connectionBanco = new SqlConnection(ConnectionBanco);
            SqlConnection connectionView = new SqlConnection(ConnectionView);
            StringBuilder sb = new StringBuilder();
            string sql;
            List<Cte> Ctes = new List<Cte>();

            try
            {
               
                Console.WriteLine("Processo de Importação de Tabela");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                /* Primeiro Passo Apagar  tabela temporaria*/
                Console.WriteLine("1-  Passo Apagar  tabela temporaria");
                Console.WriteLine("TRUNCATE TABLE temp_CTE");                
                
                connectionBanco.Open();
                sb.Append("TRUNCATE TABLE temp_CTE");
                sql = sb.ToString();
                SqlCommand command = new SqlCommand(sql, connectionBanco);
                SqlDataReader reader = command.ExecuteReader();
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
                sb.Append("SELECT * FROM V_Cte");
                sql = sb.ToString();
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
                                        dtEmissaoCte = Convert.ToDateTime(reader["dtEmissaoCte"].ToString()),
                                        cdIbgeOrigem = Convert.ToInt32(reader["cdIbgeOrigem"]),
                                        cdIbgeDestino = Convert.ToInt32(reader["cdIbgeDestino"]),
                                        tipoDoc = reader["tipoDoc"].ToString(),
                                        valorFrete = Convert.ToDecimal(reader["valorFrete"]),
                                        valorImposto = Convert.ToDecimal(reader["valorImposto"]),
                                        chaveCTE = reader["chaveCte"].ToString(),
                                        xmlCte = reader["xmlCte"].ToString(),
                                        chaveNfe = reader["chaveNfe"].ToString(),
                                        DtEmissaoNf = Convert.ToDateTime(reader["DtEmissaoNf"].ToString())


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
                    sb = sb.Append("INSERT INTO temp_Cte" +
                        "(" +
                            "numeroCte, " +
                            "NumeroTransporte, " +
                            "codTranspMatriz," +
                            "codTranspFilial, " +
                            "cnpjEmitente," +
                            "cnpjTomador," +
                            "serieCte, " +
                            "modeloCte, " +
                            "dtEmissaoCte," +
                            "cdIbgeOrigem," +
                            "cdIbgeDestino," +
                            "tipoDoc," +
                            "valorFrete," +
                            "valorImposto, " +
                            "chaveCTE, " +
                            "xmlCte, " +
                            "chaveNfe, " +
                            "DtEmissaoNf" +
                         ") VALUES ('" + 
                        element.numeroCte+"','" + 
                        element.NumeroTransporte +"','"+
                        element.codTranspMatriz + "','" +
                        element.codTranspFilial + "','" +
                        element.cnpjEmitente + "','" +
                        element.cnpjTomador + "'," +
                        element.serieCte + "," +
                        element.modeloCte + ",'" +
                        Convert.ToDateTime(element.dtEmissaoCte.ToString()) + "', " +
                        element.cdIbgeOrigem + "," +
                        element.cdIbgeDestino + ",'" +
                        element.tipoDoc+ "'," +
                        element.valorFrete.ToString().Replace(",",".") + "," +
                        element.valorImposto.ToString().Replace(",", ".") + ",'" +
                        element.chaveCTE + "','" +
                        element.xmlCte + "','" +
                        element.chaveNfe + "','" +
                        Convert.ToDateTime(element.DtEmissaoNf.ToString()) + "'" +
                         ");");
                  
                    sql = sb.ToString();
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
                Console.WriteLine("3.1- Incluir registros de novos-Keys da tabela temporaria que nao existem na tabela ");
                Console.WriteLine("3.2- Update de registro que com status != OK (Sem sucesso de resposta do web service)");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("--------------------------------------------------------------------------------------------------");

                //SqlConnection connection = new SqlConnection(ConnectionBanco);

                //Console.WriteLine("\nQuery data example:");
                //Console.WriteLine("=========================================\n");

                //connection.Open();
                //StringBuilder sb = new StringBuilder();
                //sb.Append("SELECT codigo,numeroCte FROM Cte ");
                //String sql = sb.ToString();
                //SqlCommand command = new SqlCommand(sql, connection);
                //SqlDataReader reader = command.ExecuteReader();


                //while (reader.Read())
                //{
                //    Console.WriteLine(reader["codigo"].ToString());
                //}


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
