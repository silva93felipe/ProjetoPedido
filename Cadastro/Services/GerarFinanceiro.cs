using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro.Utils;
using System.Text.Json;
using System.Text;
using Cadastro.Model;

namespace Cadastro.Services
{
    public class GerarFinanceiro : IGerarFinanceiro
    {
        
        public async Task<bool> GerarPagamento(PedidoModel pedido)
        {

            using var client = new HttpClient();
            var json = JsonSerializer.Serialize(pedido);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

           var result = await client.PostAsync(UriInternas.SERVICO_FINANCERIO, data);            

            if(result.IsSuccessStatusCode)
            {
                var dado = result.Content.ReadAsStringAsync();

                return dado.Result == "PAGAMENTO_APROVADO";

            }

            return false;
        }

        public async Task<int> StatusPagamento(Guid pedidoId)
        {
            using var client = new HttpClient();
            var result = await client.GetAsync(UriInternas.SERVICO_FINANCERIO + "statuspagamento");


            //TODO 
            return 0;
        }
    }
}