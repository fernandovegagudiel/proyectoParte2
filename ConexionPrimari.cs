using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPae2
{
    internal class ConexionPrimari
    {
        private string apiKey = "8cc7a0887cbbad9442f11c749ce875398f1605e4e33eb34b83480475781d1c67";

        public ConexionPrimari(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public async Task<string> EnviarPreguntaALaIA(string prompt)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                var datos = new
                {
                    model = "deepseek-ai/DeepSeek-V3",
                    messages = new[] { new { role = "user", content = "Explica como si fuera para un niño de primaria, usando español latinoamericano, y separa el contenido en secciones como: definición, ejemplo, importancia y resumen final. Tema: " + prompt } },
                    max_tokens = 200,
                    temperature = 0.7
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
