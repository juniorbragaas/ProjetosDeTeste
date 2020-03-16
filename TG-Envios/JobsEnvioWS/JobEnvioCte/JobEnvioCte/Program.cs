
using JobEnvioCte.Controllers;
using JobEnvioCte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Xml.Serialization;
using WSCteNfe;
using static WSCteNfe.SI_ProcessaCteNfse_SyncClient;

namespace JobEnvioCte
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
            // Executar envio de Ct-e para o WS
            break;
            case "FATURA":
            // Executar envio de Faturas para o WS
            break;
            case "OCORRENCIA":
            // Executar Ocorrencia de Faturas para o WS
            break;
            default:
            // Caso usuario execute alguma opção que não existe
            break;
            } */

            Console.WriteLine("--Job Envio Cte--");

            /*Pegar registro que nao foram processados da tabela Cte*/
            var lista = Util.PrencherListaCteNaoProcessados();
            DT_EletronicDocumentRequestDados DocumentRequestDados;
            SI_ProcessaCteNfse_SyncRequest request;
            DT_EletronicDocumentRequest DocumentRequest;
            
            var processo = new SI_ProcessaCteNfse_SyncClient(EndpointConfiguration.HTTP_Port);
            for (int x = 0; x < lista.Count(); x++)
            {
                /*Limpando dados*/
                DocumentRequestDados = null;
                request = null;
                DocumentRequest = null;

                DocumentRequestDados = Util.PrencherRequisicao(lista[x]);
                request = new SI_ProcessaCteNfse_SyncRequest(new DT_EletronicDocumentRequest { dados = DocumentRequestDados });
                DocumentRequest = new DT_EletronicDocumentRequest();
                DocumentRequest.dados = DocumentRequestDados;
                var resposta = processo.SI_ProcessaCteNfse_SyncAsync(DocumentRequest);


                /* Atualizar campos do Objeto */
                lista[x].dataEnvio = DateTime.Now;
                lista[x].numeroTentativasEnvio = lista[x].numeroTentativasEnvio + 1;
                lista[x].responseWS = JsonSerializer.Serialize(resposta.Result.MT_EletronicDocumentResponse);
                lista[x].status = (resposta.Result.MT_EletronicDocumentResponse.First().message.Equals("Documento enviado com sucesso!") && resposta.Result != null) ? "OK" : "Falha : " + resposta.Result.MT_EletronicDocumentResponse.First().message;
            }
            for (int x = 0; x < lista.Count(); x++)
            {
                Util.AtualizarDadosBanco(lista[x]);
            }


            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Sair");
            Console.ReadLine();
        }
    }
}
