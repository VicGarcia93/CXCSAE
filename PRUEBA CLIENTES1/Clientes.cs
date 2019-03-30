using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRUEBA_CLIENTES1.Datos;
using PRUEBA_CLIENTES1.POJOS;

namespace PRUEBA_CLIENTES1
{
    using RutaBD = PRUEBA_CLIENTES1.Properties.Settings;
    public partial class Clientes : Form
    {
        String cveIniCliente;
        String cveFinCliente;
        String fechaInicial;
        String fechaFinal;
        String status;

        public Clientes()
        {
            InitializeComponent();
            CboEmpresa.SelectedIndex = int.Parse(RutaBD.Default.empresaEnUso) - 1;
            FechaActual();
            cveIniCliente = "";
            cveFinCliente = "";
            fechaInicial = "";
            fechaFinal = "";
            status = "";
        }
        private void HolaMundo()
        {
            MessageBox.Show("Hola Mundo");
        }
        private void FechaActual()
        {
            DateTime dateTime;
            dateTime = DateTime.Now;
            toolStripStatusLabel1.Text =  dateTime.Date.ToLongDateString();
        }
        private void BuscarSaldos()
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            ClienteDetalleVO clienteDetalleVO = new ClienteDetalleVO();
            

            cveIniCliente = txtCveIniCliente.Text;
            cveFinCliente = txtCveFinCliente.Text;
            fechaInicial = dateTimePicker2.Text;
            fechaFinal = dateTimePicker3.Text;
            status = cmbEstatus.Text.Trim();

            cveIniCliente = ValidaCliente(cveIniCliente);
            cveFinCliente = ValidaCliente(cveFinCliente);


            clienteDetalleVO.ClaveInicial = cveIniCliente;
            clienteDetalleVO.ClaveFinal = cveFinCliente;
            clienteDetalleVO.FechaInicial = fechaInicial.Substring(3,3) + fechaInicial.Substring(0,3) + fechaInicial.Substring(6,4);

            
            clienteDetalleVO.FechaFinal = fechaFinal.Substring(3, 3) + fechaFinal.Substring(0, 3) + fechaFinal.Substring(6, 4);

            clienteDetalleVO.Status = status.Substring(0, 1);


            //dgvSaldos.DataSource  = clienteDAO.GetClientesCargosAbonos(clienteDetalleVO);
            DataTable data = new DataTable();
            dgvSaldos.AutoGenerateColumns = false;
            
            MessageBox.Show("cantidad: " + clienteDAO.GetClientesCargosAbonos(clienteDetalleVO).Count);
            dgvSaldos.DataSource = clienteDAO.GetClientesCargosAbonos(clienteDetalleVO);
        }
        private String ValidaCliente(string cveCliente)
        {
        
            if (!cveCliente.Equals("MOSTR"))
            {
                for (int i = cveCliente.Length; i < 10; i++)
                {
                    cveCliente = " " + cveCliente; 
                }

            }
            //Verificar si existe en la Base de datos

            return cveCliente;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarSaldos();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Clientes_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestForm testForm = new TestForm();
            RutaBD.Default.empresaEnUso = (CboEmpresa.SelectedIndex + 1).ToString();
            MessageBox.Show(RutaBD.Default.empresaEnUso);
            testForm.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Clientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = Form1.GetInstance();
            form1.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            txtCveIniCliente.Text = GetClaveCliente();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void pbCveFinCliente_Click(object sender, EventArgs e)
        {
            txtCveFinCliente.Text = GetClaveCliente();
            
        }
        private String GetClaveCliente()
        {
            BuscarCliente buscarCliente = new BuscarCliente();
            buscarCliente.ShowDialog();
            return buscarCliente.GetCveCliente();
        }
    }
}
