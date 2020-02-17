using System;

namespace ConsumnindoAPIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("Digite o CEP: ");
            var valor = System.Console.ReadLine();
            try
            {
                var ws = new WSCorreios.AtendeClienteClient();
                var resposta = ws.consultaCEPAsync(valor);
                System.Console.WriteLine();
                System.Console.WriteLine("Endereço: {0}", resposta.Result.@return.end);
                System.Console.WriteLine("Complemento: {0}", resposta.Result.@return.complemento2);
                System.Console.WriteLine("Bairro: {0}", resposta.Result.@return.bairro);
                System.Console.WriteLine("Cidade: {0}", resposta.Result.@return.cidade);
                System.Console.WriteLine("Estado: {0}", resposta.Result.@return.uf);
                System.Console.WriteLine("Unidades de Postagem: {0}", resposta.Result.@return.unidadesPostagem);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Erro ao efetuar busca do CEP: {0}", ex.Message);
            }
            System.Console.ReadLine();
        }
    }
}
