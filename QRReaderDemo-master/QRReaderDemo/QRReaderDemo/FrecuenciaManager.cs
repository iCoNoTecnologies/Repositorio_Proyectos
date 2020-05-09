using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace QRReaderDemo
{
    class FrecuenciaManager
    {
        const String URL = "172.27.103.104/prueba.php?dato=hola_mundo";

        private HttpClient getCliente()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");

            return client;
        }

        public async Task<IEnumerable<Frecuencia>> getFrecuencia()
        {
            HttpClient client = getCliente();

            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Frecuencia>>(content);
            }

            return Enumerable.Empty<Frecuencia>();

        }
    }
}
