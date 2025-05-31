using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPae2
{
    internal class SQLPrimaria
    {
        private string cadenaConexion = "Data Source=LAPTOP-O90PA1AO\\SQLEXPRESS;Initial Catalog=BD_InvestigacionesAsistenteE;Integrated Security=True;TrustServerCertificate=True";


        public void GuardarEnBaseDeDatos(string pregunta, string respuesta, string grado)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = "INSERT INTO InvestigacionesPrimaria (Preguntas, Respuesta, Grado, Fecha) VALUES (@Pregunta, @Respuesta, @Grado ,@f)";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Pregunta", pregunta);
                    comando.Parameters.AddWithValue("@Respuesta", respuesta);
                    comando.Parameters.AddWithValue("@Grado", grado);
                    comando.Parameters.AddWithValue("@f", DateTime.Now);

                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar en la base de datos: " + ex.Message);
                    }
                }
            }
        }
        public bool ExistePregunta(string pregunta, string grado)
        {
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM InvestigacionesPrimaria WHERE Preguntas = @pregunta AND Grado = @grado";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@pregunta", pregunta);
                    cmd.Parameters.AddWithValue("@grado", grado);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
