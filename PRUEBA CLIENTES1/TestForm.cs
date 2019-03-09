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
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }
        private void ObtenerClientes()
        {
            ClientesVO cliente = new ClientesVO("","","",' ',' ');
            ClienteDAO clienteDAO = new ClienteDAO();
            dgvClientes.DataSource = clienteDAO.GetClientes(cliente).Tables[0];

        }
        private void ObtenerHistorialSaldos()
        {
            ClienteDetalleVO clienteDetalle = new ClienteDetalleVO()
            {
                fechaInicial = "02/22/2018",
                fechaFinal = "02/22/2018",
                status = "A",
            };
            ClienteDAO cliente = new ClienteDAO();
            dgvClientes.DataSource = cliente.GetClientesCargosAbonos(clienteDetalle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ObtenerClientes();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void btnHistorialSaldos_Click(object sender, EventArgs e)
        {
            ObtenerHistorialSaldos();
        }
    }
}
