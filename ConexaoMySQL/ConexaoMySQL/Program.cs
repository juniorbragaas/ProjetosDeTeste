using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Xml;
using System.Xml.Linq;

namespace ConexaoMySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            //Aqui você substitui pelos seus dados
            string servidor = "";
            string banco = "";
            string usuario = "";
            string senha = "";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("conexao.xml"); 
            XmlNodeList xnList = xmlDoc.GetElementsByTagName("conexao");

            for (int i = 0; i < xnList.Count; i++)
            {
                servidor= xnList[i]["servidor"].InnerText;
                banco = xnList[i]["banco"].InnerText;
                usuario = xnList[i]["usuario"].InnerText;
                senha= xnList[i]["senha"].InnerText;
            }

            var connString = "Server="+servidor+";Database="+banco+";Uid="+usuario+";Pwd="+senha;
            var connection = new MySqlConnection(connString);
            var command = connection.CreateCommand();

            try
            {
                connection.Open();
                command.CommandText = "SELECT * FROM pessoa";
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine( reader["Nome"].ToString());
                }

            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
