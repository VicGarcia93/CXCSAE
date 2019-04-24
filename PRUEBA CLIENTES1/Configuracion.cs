using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using PRUEBA_CLIENTES1.Datos;

namespace PRUEBA_CLIENTES1
{
    public partial class Configuracion : Form
    {
        public Configuracion()
        {
            InitializeComponent();
            CargarConfiguracionActual();
        }
        private void CargarConfiguracionActual()
        {

            //  DataTable dataTable = (DataTable) dgvConfiguracionBD.DataSource;
            dgvConfiguracionBD.AutoGenerateColumns = false;
          dgvConfiguracionBD.DataSource = LeerEmpresasCSV.GetInstance().GetEmpresasAll();

        }
        
        
    }
}
