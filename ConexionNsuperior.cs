using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPae2
{

    internal class ConexionNsuperior
    {
        private string apiKey = "8cc7a0887cbbad9442f11c749ce875398f1605e4e33eb34b83480475781d1c67";

        public ConexionNsuperior(string apikey)
        {
            this.apiKey = apikey;
        }
        public async Task<string> ObtenerRespuestaAsync(string prompt)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
                

                var datos = new
                {
                    model = "meta-llama/Llama-4-Scout-17B-16E-Instruct",
                    messages = new[] { new { role = "user", content ="contesta dependiedno que grado te ingrese :"  + prompt } },
                    temperature = 0.2
                };

                var contenido = new StringContent(System.Text.Json.JsonSerializer.Serialize(datos), Encoding.UTF8, "application/json");
                var respuesta = await cliente.PostAsync("https://api.together.xyz/v1/chat/completions", contenido);

                if (!respuesta.IsSuccessStatusCode)
                    throw new Exception("La solicitud a la IA falló con el código: " + respuesta.StatusCode);

                var texto = await respuesta.Content.ReadAsStringAsync();
                var docJson = System.Text.Json.JsonDocument.Parse(texto);
                return docJson.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").ToString();
            }
        }

    }
}
