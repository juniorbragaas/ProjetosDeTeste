using System;
using System.Data.SqlClient;
using System.Text;

namespace ProcessoImportacao
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string ConnectionBanco = "Data Source=SMBH-020815\\SQLEXPRESS;Initial Catalog=TG;Persist Security Info=True;User ID=sa;Password=Sysmap*2020";
                string ConnectionView = "Data Source=SMBH-020815\\SQLEXPRESS;Initial Catalog=TG;Persist Security Info=True;User ID=sa;Password=Sysmap*2020";

                Console.WriteLine("Processo de Importação de Tabela");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                /* Primeiro Passo Apagar  tabela temporaria*/
                Console.WriteLine("Primeiro Passo Apagar  tabela temporaria");
                Console.WriteLine("DELETE FROM temp_CTE");
                Console.WriteLine("--------------------------------------------------------------------------------------------------");

                /* Segundo Passo Armazenar View numa tabela temporaria*/
                Console.WriteLine("Segundo Passo Armazenar View na tabela temporaria");
                Console.WriteLine("--Armazenar View em Object View (Conexao View) Obs:Impossivel Query de dois bancos diferentes em C#");
                Console.WriteLine("--Inserir ObjectView na Tabela Temporaria");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");

                /* Terceiro Passo Incluir Registros Novos e modificados na tabela de producao*/
                Console.WriteLine("Terceiro Passo Incluir Registros Novos e modificados da tabela temporaria para tabela de producao");
                Console.WriteLine("--Incluir registros de novos-Keys da tabela temporaria que nao existem na tabela ");
                Console.WriteLine("--Update de registro que com status != OK (Sem sucesso de resposta do web service)");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");

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
