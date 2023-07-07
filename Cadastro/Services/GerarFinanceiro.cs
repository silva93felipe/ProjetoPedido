using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro.Utils;
using System.Text.Json;
using System.Text;

namespace Cadastro.Services
{
    public class GerarFinanceiro : IGerarFinanceiro
    {
        
        public async Task Gerar(string message)
        {

             using var client = new HttpClient();
            var json = JsonSerializer.Serialize(message);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var result = await client.PostAsync(UriInternas.SERVICO_FINANCERIO, data);            

        }

        public async Task StatusPagamento()
        {
             using var client = new HttpClient();
            var result = await client.GetAsync("http://localhost:5251/api/Financeiro/statuspagamento");

            Console.WriteLine(result.StatusCode);
        }
    }
}