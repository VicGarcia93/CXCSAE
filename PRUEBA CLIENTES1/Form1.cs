using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRUEBA_CLIENTES1
{
    public partial class Form1 : Form
    {
        static Form1 form;
        private Form1()
        {
            InitializeComponent();
        }
        public static Form1 GetInstance()
        {
            if (form == null)
            {
                form = new Form1();
            }
            return form;
        }

        private void LblEmpresa_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Crear objeto de la clase Clientes
            //Creación del objeto
            Clientes clientes;

            
            
            //Mostrar Formulario
            PRUEBA_CLIENTES1.Properties.Settings.Default.empresaEnUso = (cboempresa.SelectedIndex + 1).ToString();
            PRUEBA_CLIENTES1.Properties.Settings.Default.Save();
            //Instanciar el objeto
            clientes = new Clientes();
            clientes.Show();
            //Ocultar el Formulario actual
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Cerrar el Formulario actual
            this.Close();
        }

        
    }
}