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
using PRUEBA_CLIENTES1.Entidades;

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
        String empresa;
        int contador;
      
        public Clientes()
        {
            contador = 0;
            InitializeComponent();
            FechaActual();
            cveIniCliente = "";
            cveFinCliente = "";
            fechaInicial = "";
            fechaFinal = "";
            status = "";
           
            Inicio();
            
        }
        private void Inicio()
        {
            CboEmpresa.DataSource = LeerEmpresasCSV.GetInstance().GetEmpresas();
            CboEmpresa.SelectedIndex = int.Parse(RutaBD.Default.empresaEnUso) - 1;
            cmbEstatus.SelectedIndex = 1;
            cmbFecha.SelectedIndex = 1;
            toolStripStatusLabel1.Text = FechaActual().Date.ToLongDateString();

        }

        private void HolaMundo()
        {
            MessageBox.Show("Hola Mundo");
        }
        private DateTime FechaActual()
        {
            DateTime dateTime;
            dateTime = DateTime.Now;
            return dateTime;
            // toolStripStatusLabel1.Text =  dateTime.Date.ToLongDateString();
        }
        private void BuscarSaldos()
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            ClienteDetalleVO clienteDetalleVO = new ClienteDetalleVO();


            cveIniCliente = txtCveIniCliente.Text;
            cveFinCliente = txtCveFinCliente.Text;
            fechaInicial = dateTimePicker3.Text;
            fechaFinal = dateTimePicker2.Text;
            status = cmbEstatus.Text.Trim();

            cveIniCliente = Validaciones.GetInstance().ValidaCliente(cveIniCliente);
            cveFinCliente = Validaciones.GetInstance().ValidaCliente(cveFinCliente);


            clienteDetalleVO.ClaveInicial = cveIniCliente;
            clienteDetalleVO.ClaveFinal = cveFinCliente;
            clienteDetalleVO.FechaInicial = fechaInicial.Substring(3, 3) + fechaInicial.Substring(0, 3) + fechaInicial.Substring(6, 4);


            clienteDetalleVO.FechaFinal = fechaFinal.Substring(3, 3) + fechaFinal.Substring(0, 3) + fechaFinal.Substring(6, 4);

            clienteDetalleVO.Status = status.Substring(0, 1);

            //dgvSaldos.DataSource  = clienteDAO.GetClientesCargosAbonos(clienteDetalleVO);
            DataTable data = new DataTable();
            dgvSaldos.AutoGenerateColumns = false;

            //MessageBox.Show("cantidad: " + clienteDAO.GetClientesCargosAbonos(clienteDetalleVO).Count);
            dgvSaldos.DataSource = clienteDAO.GetClientesCargosAbonos(clienteDetalleVO);
            dgvSaldos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSaldos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            TestForm testForm = new TestForm();
            RutaBD.Default.empresaEnUso = (CboEmpresa.SelectedIndex + 1).ToString();
            MessageBox.Show(RutaBD.Default.empresaEnUso);
            testForm.Show();
        }

        private void Clientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = Form1.GetInstance();
            form1.Close();
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

        private void pbCveIniCliente_Click(object sender, EventArgs e)
        {
            txtCveIniCliente.Text = GetClaveCliente();
        }

        private void pbCveFinCliente_Click_1(object sender, EventArgs e)
        {
            txtCveFinCliente.Text = GetClaveCliente();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            BuscarSaldos();
            Cursor.Current = Cursors.Default;
        }


        private void cmbFecha_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cmbFecha.SelectedIndex)
            {
                case 0://NO SELECCIONAR FECHAS
                    dateTimePicker3.Enabled = false;
                    dateTimePicker2.Enabled = false;
                    break;

                case 1://FECHAS SELECCIONADAS
                    dateTimePicker3.Enabled = true;
                    dateTimePicker2.Enabled = true;
                    break;

                case 2://HOY

                    FechaActual();
                    DateTime hoy = FechaActual().Subtract(TimeSpan.FromDays(0));

                    dateTimePicker3.Text = hoy.ToShortDateString();
                    dateTimePicker2.Text = hoy.ToShortDateString();

                    break;

                case 3://AYER

                    FechaActual();
                    DateTime ayer = FechaActual().Subtract(TimeSpan.FromDays(1));

                    dateTimePicker3.Text = ayer.ToShortDateString();
                    dateTimePicker2.Text = ayer.ToShortDateString();

                    break;

                case 4:
                    FechaActual();
                    DateTime estasemana = FechaActual().Subtract(TimeSpan.FromDays(7));

                    dateTimePicker3.Text = estasemana.ToShortDateString();
                    dateTimePicker2.Text = FechaActual().ToShortDateString();

                    break;

                case 5://ESTE MES 


                    string fechames = FechaActual().ToShortDateString().Substring(4, 1);
                    string fechayear = FechaActual().ToShortDateString().Substring(6, 4);


                    int daym = System.DateTime.DaysInMonth(int.Parse(fechayear), int.Parse(fechames));
                    Console.WriteLine(daym);


                    string sini = "01" + FechaActual().ToShortDateString().Substring(2, 8);
                    string tfin = daym + FechaActual().ToShortDateString().Substring(2, 8);

                    dateTimePicker3.Text = sini;
                    dateTimePicker2.Text = tfin;

                    break;


                case 6://MES ANTERIOR
                    string fechames1 = FechaActual().ToShortDateString().Substring(4, 1);
                    string fechayear1 = FechaActual().ToShortDateString().Substring(6, 4);

                    int fechamesr = int.Parse(fechames1);
                    int yearant;
                    int mesant;
                    int dayma;
                    int mesant1;

                    if (fechamesr == 1)
                    {
                        mesant = 12;
                        yearant = int.Parse(fechayear1) - 1;

                        dayma = System.DateTime.DaysInMonth(yearant, mesant);
                        Console.WriteLine(dayma);

                        string sinic = "01" + "/" + mesant + "/" + yearant;
                        string tfinc = dayma + "/" + mesant + "/" + yearant;

                        dateTimePicker3.Text = sinic;
                        dateTimePicker2.Text = tfinc;
                    }
                    else
                    {
                        mesant1 = int.Parse(fechames1) - 1;
                        yearant = int.Parse(fechayear1);

                        dayma = System.DateTime.DaysInMonth(yearant, mesant1);
                        Console.WriteLine(dayma);

                        string sinic = "01" + "/" + mesant1 + "/" + yearant;
                        string tfinc = dayma + "/" + mesant1 + "/" + yearant;

                        dateTimePicker3.Text = sinic;
                        dateTimePicker2.Text = tfinc;
                    }

                    break;

                case 7://ESTE AÑO 

                    string yearactual = FechaActual().ToShortDateString().Substring(6, 4);

                    string sinict = "01" + "/" + "01" + "/" + yearactual;
                    string tyearfi = "31" + "/" + "12" + "/" + yearactual;

                    dateTimePicker3.Text = sinict;
                    dateTimePicker2.Text = tyearfi;

                    break;

                case 8://ENERO

                    yearactual = FechaActual().ToShortDateString().Substring(6, 4);
                    int mesene = 1;

                    dayma = System.DateTime.DaysInMonth(int.Parse(yearactual), mesene);
                    Console.WriteLine(dayma);

                    string eneini = "01" + "/" + "01" + "/" + yearactual;
                    string enefin = dayma + "/" + "01" + "/" + yearactual;

                    dateTimePicker3.Text = eneini;
                    dateTimePicker2.Text = enefin;


                    break;

                case 9://FEBRERO

                    yearactual = FechaActual().ToShortDateString().Substring(6, 4);
                    int mesfeb = 2;

                    dayma = System.DateTime.DaysInMonth(int.Parse(yearactual), mesfeb);
                    Console.WriteLine(dayma);

                    string febini = "01" + "/" + "02" + "/" + yearactual;
                    string febfin = dayma + "/" + "02" + "/" + yearactual;

                    dateTimePicker3.Text = febini;
                    dateTimePicker2.Text = febfin;


                    break;

                case 10://MARZO

                    yearactual = FechaActual().ToShortDateString().Substring(6, 4);
                    int mesmar = 3;

                    dayma = System.DateTime.DaysInMonth(int.Parse(yearactual), mesmar);
                    Console.WriteLine(dayma);

                    string marini = "01" + "/" + "03" + "/" + yearactual;
                    string marfin = dayma + "/" + "03" + "/" + yearactual;

                    dateTimePicker3.Text = marini;
                    dateTimePicker2.Text = marfin;


                    break;

                case 11://ABRIL

                    yearactual = FechaActual().ToShortDateString().Substring(6, 4);
                    int mesabr = 4;

                    dayma = System.DateTime.DaysInMonth(int.Parse(yearactual), mesabr);
                    Console.WriteLine(dayma);

                    string abrini = "01" + "/" + "04" + "/" + yearactual;
                    string abrfin = dayma + "/" + "04" + "/" + yearactual;

                    dateTimePicker3.Text = abrini;
                    dateTimePicker2.Text = abrfin;


                    break;

                case 12://MAYO

                    yearactual = FechaActual().ToShortDateString().Substring(6, 4);
                    int mesmay = 5;

                    dayma = System.DateTime.DaysInMonth(int.Parse(yearactual), mesmay);
                    Console.WriteLine(dayma);

                    string mayini = "01" + "/" + "05" + "/" + yearactual;
                    string mayfin = dayma + "/" + "05" + "/" + yearactual;

                    dateTimePicker3.Text = mayini;
                    dateTimePicker2.Text = mayfin;


                    break;

                case 13://JUNIO

                    yearactual = FechaActual().ToShortDateString().Substring(6, 4);
                    int mesjun = 6;

                    dayma = System.DateTime.DaysInMonth(int.Parse(yearactual), mesjun);
                    Console.WriteLine(dayma);

                    string junini = "01" + "/" + "06" + "/" + yearactual;
                    string junfin = dayma + "/" + "06" + "/" + yearactual;

                    dateTimePicker3.Text = junini;
                    dateTimePicker2.Text = junfin;


                    break;

                case 14://JULIO

                    yearactual = FechaActual().ToShortDateString().Substring(6, 4);
                    int mesjul = 7;

                    dayma = System.DateTime.DaysInMonth(int.Parse(yearactual), mesjul);
                    Console.WriteLine(dayma);

                    string julini = "01" + "/" + "07" + "/" + yearactual;
                    string julfin = dayma + "/" + "07" + "/" + yearactual;

                    dateTimePicker3.Text = julini;
                    dateTimePicker2.Text = julfin;


                    break;

                case 15://AGOSTO

                    yearactual = FechaActual().ToShortDateString().Substring(6, 4);
                    int mesago = 8;

                    dayma = System.DateTime.DaysInMonth(int.Parse(yearactual), mesago);
                    Console.WriteLine(dayma);

                    string agoini = "01" + "/" + "08" + "/" + yearactual;
                    string agofin = dayma + "/" + "08" + "/" + yearactual;

                    dateTimePicker3.Text = agoini;
                    dateTimePicker2.Text = agofin;


                    break;

                case 16://SEPTIEMBRE

                    yearactual = FechaActual().ToShortDateString().Substring(6, 4);
                    int messep = 9;

                    dayma = System.DateTime.DaysInMonth(int.Parse(yearactual), messep);
                    Console.WriteLine(dayma);

                    string sepini = "01" + "/" + "09" + "/" + yearactual;
                    string sepfin = dayma + "/" + "09" + "/" + yearactual;

                    dateTimePicker3.Text = sepini;
                    dateTimePicker2.Text = sepfin;


                    break;

                case 17://OCTUBRE

                    yearactual = FechaActual().ToShortDateString().Substring(6, 4);
                    int mesoct = 10;

                    dayma = System.DateTime.DaysInMonth(int.Parse(yearactual), mesoct);
                    Console.WriteLine(dayma);

                    string octini = "01" + "/" + "10" + "/" + yearactual;
                    string octfin = dayma + "/" + "10" + "/" + yearactual;

                    dateTimePicker3.Text = octini;
                    dateTimePicker2.Text = octfin;


                    break;

                case 18://NOVIEMBRE

                    yearactual = FechaActual().ToShortDateString().Substring(6, 4);
                    int mesnov = 11;

                    dayma = System.DateTime.DaysInMonth(int.Parse(yearactual), mesnov);
                    Console.WriteLine(dayma);

                    string novini = "01" + "/" + "11" + "/" + yearactual;
                    string novfin = dayma + "/" + "11" + "/" + yearactual;

                    dateTimePicker3.Text = novini;
                    dateTimePicker2.Text = novfin;


                    break;


                case 19://DICIEMBRE

                    yearactual = FechaActual().ToShortDateString().Substring(6, 4);
                    int mesdic = 12;

                    dayma = System.DateTime.DaysInMonth(int.Parse(yearactual), mesdic);
                    Console.WriteLine(dayma);

                    string dicini = "01" + "/" + "12" + "/" + yearactual;
                    string dicfin = dayma + "/" + "12" + "/" + yearactual;

                    dateTimePicker3.Text = dicini;
                    dateTimePicker2.Text = dicfin;


                    break;


                case 20://AÑO ANTERIOR
                    yearactual = FechaActual().ToShortDateString().Substring(6, 4);
                    yearant = int.Parse(yearactual) - 1;

                    sinict = "01" + "/" + "01" + "/" + yearant;
                    tyearfi = "31" + "/" + "12" + "/" + yearant;

                    dateTimePicker3.Text = sinict;
                    dateTimePicker2.Text = tyearfi;

                    break;

            }
        }

        private void LimpiarCampos()
        {
            txtCveIniCliente.Text = "";
            txtCveFinCliente.Text = "";
            cmbFecha.SelectedIndex = 1;
            cmbEstatus.SelectedIndex = 1;
            dgvSaldos.DataSource = null;

        }

        private void txtCveIniCliente_Leave(object sender, EventArgs e)
        {
            if (!Validaciones.GetInstance().ValidaClavesClientes(txtCveIniCliente.Text, txtCveFinCliente.Text))
            {
                MessageBox.Show(this, "La clave inicial no debe ser mayor que la final.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCveIniCliente.Focus();
                txtCveIniCliente.SelectAll();
            }

        }

        private void txtCveFinCliente_Leave(object sender, EventArgs e)
        {
            if (!Validaciones.GetInstance().ValidaClavesClientes(txtCveIniCliente.Text, txtCveFinCliente.Text))
            {
                MessageBox.Show(this, "La clave final no debe ser menor que la inicial.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCveFinCliente.Focus();
                txtCveFinCliente.SelectAll();
            }

        }

        private void cmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void CboEmpresa_SelectedIndexChanged_1(object sender, EventArgs e)

        {
            if (contador > 1)
            {
                empresa = CboEmpresa.SelectedValue.ToString();
                MessageBox.Show("HAS INGRESADO A  " + empresa);


                RutaBD.Default.empresaEnUso = (CboEmpresa.SelectedIndex + 1).ToString();
                RutaBD.Default.Save();
                LimpiarCampos();
            }

            else

                contador++;
        }

        private void txtCveFinCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvSaldos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Clientes_Load(object sender, EventArgs e)
        {

        }

        private void aRCHIVOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}