using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPae2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void picturePrimaria_Click(object sender, EventArgs e)
        {
            this.Hide();             // Oculta Form1
            Form2 form = new Form2();
            form.ShowDialog();       // Muestra Form2 de forma modal
            this.Close();             // Vuelve a mostrar Form1 después de cerrar Form2
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 fom = new Form3();
            fom.ShowDialog();
            this.Close();
        }
    }
}
