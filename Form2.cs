using System;
using Word = Microsoft.Office.Interop.Word;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Text.RegularExpressions;
using System.IO;

namespace ProyectoPae2
{
    public partial class Form2 : Form
    {
        private SpeechSynthesizer voz = new SpeechSynthesizer();

        public Form2()
        {
            InitializeComponent();
            voz.Rate = -2;
            voz.Volume = 100;
            webView21.Visible = false;
            txtRespuesta.Visible = false;
        }

        private void MostrarEnPantalla(string texto)
        {
            txtRespuesta.Text = texto;
        }

        private async void  EjecutarInvestigacionAsync(string pregunta)
        {
            string grado = texGrado.Text.Trim();
            try
            {
                ConexionPrimari con = new ConexionPrimari("8cc7a0887cbbad9442f11c749ce875398f1605e4e33eb34b83480475781d1c67");
                txtRespuesta.Visible = true;
                
                string prompt = $"Responde dependiendo el grado que te ingrese es de nivel primario  : { grado}: { pregunta}";
                string respuesta = await con.EnviarPreguntaALaIA(prompt);

                MostrarEnPantalla(respuesta);
                LeerTextoEnVoz(respuesta);
                


                if (!string.IsNullOrWhiteSpace(grado))
                {
                    SQLPrimaria db = new SQLPrimaria();
                    db.GuardarEnBaseDeDatos(pregunta, respuesta, grado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error durante la investigación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonBuscar_Click_1(object sender, EventArgs e)
        {
            string pregunta = textBoxPregunta.Text;
            if (string.IsNullOrWhiteSpace(pregunta))
            {
                MessageBox.Show("Por favor, escribe una pregunta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

             EjecutarInvestigacionAsync(pregunta);
            webView21.Visible = false;
        }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            string pregunta = "Explica cómo sumar a niños de primaria como un maestro amable pero para niños pequeños";
            texGrado.Text = "Primero";
            textBoxPregunta.Text = pregunta;
            await ExplicarTemaConVozYVideo(pregunta, "M3DTbZgqX_w", 13);
            txtRespuesta.Visible = true;
            webView21.Visible = true;
        }

        private async void pictureBoxPre_Click(object sender, EventArgs e)
        {
            string pregunta = "Explica cómo resta a niños de primaria como un maestro amable pero para niños pequeños";
            texGrado.Text = "Segundo";
            textBoxPregunta.Text = pregunta;
            await ExplicarTemaConVozYVideo(pregunta, "Acn7Tl4z7pU", 13);
            txtRespuesta.Visible = true;
            webView21.Visible = true;
        }

        private async void pictureBox3_Click(object sender, EventArgs e)
        {
            string pregunta = "Explica cómo Division a niños de primaria como un maestro amable pero para niños pequeños";
            texGrado.Text = "Tercero";
            textBoxPregunta.Text = pregunta;
            await ExplicarTemaConVozYVideo(pregunta, "iA0fP4tL67s", 13);
            txtRespuesta.Visible = true;
            webView21.Visible = true;
        }

        private async void pictureBox4_Click(object sender, EventArgs e)
        {
            string pregunta = "Explica cómo Multiplicacion a niños de primaria como un maestro amable pero para niños pequeños";
            texGrado.Text = "Segundo";
            textBoxPregunta.Text = pregunta;
            await ExplicarTemaConVozYVideo(pregunta, "YFtEaVw5k1A", 13);
            txtRespuesta.Visible = true;
            webView21.Visible = true;
        }

        private async void pictureBox5_Click(object sender, EventArgs e)
        {
            string pregunta = "Enséñale a un niño de primaria cómo aprender a leer desde cero. Primero, enséñale el abecedario con un tono amable como un maestro. Luego explica cómo suenan las letras cuando se juntan, como 'ma', 'me', 'mi', y Usa ejemplos fáciles al final, separados por líneas y comienza esa sección con la palabra 'Ejemplos:'";
            texGrado.Text = "Primero";
            textBoxPregunta.Text = pregunta;
            await ExplicarTemaConVozYVideo(pregunta, "d1U8Cke2oAE", 13);
            txtRespuesta.Visible = true;
            webView21.Visible = true;
        }

        private void buttonRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
            this.Close();
        }
        private void buttoLimpiar_Click(object sender, EventArgs e)
        {
            webView21.Visible = false;
            txtRespuesta.Text = " ";
            textBoxPregunta.Text = "";
            texGrado.Text = "";

        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            await webView21.EnsureCoreWebView2Async(null);
        }

        private async Task ExplicarTemaConVozYVideo(string pregunta, string videoId, int startSeconds)
        {
            ConexionPrimari con = new ConexionPrimari("8cc7a0887cbbad9442f11c749ce875398f1605e4e33eb34b83480475781d1c67");
            string respuesta = await con.EnviarPreguntaALaIA(pregunta);
            MostrarEnPantalla(respuesta);
            LeerTextoEnVoz(respuesta);

            string url = $"https://www.youtube.com/embed/{videoId}?start={startSeconds}&autoplay=1";
            webView21.CoreWebView2.Navigate(url);
        }
  
        private void LeerTextoEnVoz(string texto)
        {
            if (voz.State == SynthesizerState.Speaking)
            {
                voz.SpeakAsyncCancelAll();
            }

            string textoParaLeer = Regex.Replace(texto, @"[*_`#\\-]+", "");
            voz.SpeakAsync(textoParaLeer);
        }
        

        private void CrearWord(string contenido, string ruta, string pregunta)
        {
            try
            {
                // Crear instancia de Word
                var wordApp = new Word.Application();
                var doc = wordApp.Documents.Add();

                string grado = texGrado.Text.Trim();

                var rango = doc.Content;
                rango.Text = $"Grado Académico: {grado}\n\nPregunta: {pregunta}\n\n";
                rango.Font.Size = 18;
                rango.Font.Bold = 1;

                var rangoContenido = doc.Content;
                rangoContenido.Start = rango.End;
                rangoContenido.Text = contenido;
                rangoContenido.Font.Size = 12;
                rangoContenido.Font.Bold = 0;


                doc.SaveAs2(ruta);
                doc.Close();
                wordApp.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el documento Word: " + ex.Message, "Error de Word", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            string pregunta = textBoxPregunta.Text;
            string respuesta = txtRespuesta.Text;

            try
            {
                string carpeta = "C:\\Users\\VICTUS\\Music\\ProyectoPae2\\Investigacion de primaria_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                Directory.CreateDirectory(carpeta);

                string rutaWord = Path.Combine(carpeta, "Investigacion.docx");
                CrearWord(respuesta, rutaWord, pregunta);

                // Mostrar mensaje de éxito
                MessageBox.Show("El archivo se creó correctamente en:\n" + rutaWord, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar los documentos: " + ex.Message, "Error de Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
    }
}
