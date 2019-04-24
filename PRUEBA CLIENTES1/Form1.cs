using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRUEBA_CLIENTES1.Datos;

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

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Configuracion configuracion = new Configuracion();
            configuracion.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboempresa.DataSource = LeerEmpresasCSV.GetInstance().GetEmpresas();
            GenerarTXT();
        }
        // para crear el archivo
        void GenerarTXT()
        {
            string rutaCompleta = @" //7.1.1.251//dacaspel//Sistemas Aspel//SAE7.00//BD//mi archivo.txt";
            string texto = "HOLA MUNDO ";

            using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
            {

                //se adiciona alguna información y la fecha


                DateTime dateTime = new DateTime();
                dateTime = DateTime.Now;
                string strDate = Convert.ToDateTime(dateTime).ToString("yyMMdd");

                mylogs.WriteLine(texto + strDate);

                mylogs.Close();


            }
        }
    }
}