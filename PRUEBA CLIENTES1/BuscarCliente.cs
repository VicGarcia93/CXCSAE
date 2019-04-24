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
    public partial class BuscarCliente : Form
    {
        private String cveCliente = "";
        public BuscarCliente()
        {
            InitializeComponent();
            cmbCategoria.SelectedIndex = 1;
            BuscarClientes();
        }

        private void BuscarClientes()
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            ClientesVO clientes;

            String id = "";
            String nombre = "";
            String rfc = "";



            if (cmbCategoria.Text.Equals("Clave"))
            {
                id = Validaciones.GetInstance().ValidaCliente(txtBuscar.Text);
            }
            else if (cmbCategoria.Text.Equals("Nombre"))
            {
                nombre = txtBuscar.Text;
            }
            else if (cmbCategoria.Text.Equals("RFC"))
                rfc = txtBuscar.Text;

            clientes = new ClientesVO(id, nombre, rfc, ' ', ' ');
            dgvClientes.DataSource = clienteDAO.GetClientes(clientes).Tables[0];
        }

        public String GetCveCliente()
        {
            return cveCliente;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarClientes();
        }

        private void dgvClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cveCliente = dgvClientes.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.Close();
        }
    }
}
