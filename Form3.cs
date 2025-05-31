using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Word = Microsoft.Office.Interop.Word;

namespace ProyectoPae2
{
    public partial class Form3 : Form
    {
       

        public Form3()
        {
            InitializeComponent();
        }

      
        private void buttonRegresar_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form1 from = new Form1();
            from.ShowDialog();
            this.Close();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            string pregunta = textBoxPregunta.Text;
            if (string.IsNullOrWhiteSpace(pregunta))
            {
                MessageBox.Show("Por favor, escribe una pregunta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EjecutarInvestigacion(pregunta);
        }
        private async void EjecutarInvestigacion(string pregunta)
        {
            string grado = texGrado.Text.Trim();
            try
            {
                ConexionNsuperior Conex = new ConexionNsuperior("8cc7a0887cbbad9442f11c749ce875398f1605e4e33eb34b83480475781d1c67");
                string prompt = $"Responde de forma adecuada al  nivel academico:  {grado}: {pregunta}";
                string respuesta = await Conex.ObtenerRespuestaAsync(prompt);
                MostrarEnPantalla(respuesta);

              
                if (!string.IsNullOrWhiteSpace(grado))
                {
                    SQLnivelesSu db = new SQLnivelesSu();
                    db.GuardarEnBaseDeDatos(pregunta, respuesta, grado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error durante la investigación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void MostrarEnPantalla(string texto)
        {
            textBoxRespuesta.Text = texto;
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
            string respuesta = textBoxRespuesta.Text;

            try
            {
                string carpeta = "C:\\Users\\VICTUS\\Music\\ProyectoPae2\\Investigacion de niveles superiores" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                Directory.CreateDirectory(carpeta);

                string rutaWord = Path.Combine(carpeta, "Informacion.docx");
                CrearWord(respuesta, rutaWord, pregunta);

               
                MessageBox.Show("El archivo se creó correctamente en:\n" + rutaWord, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar los documentos: " + ex.Message, "Error de Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
