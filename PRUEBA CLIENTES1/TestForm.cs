using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PRUEBA_CLIENTES1.Datos;
using PRUEBA_CLIENTES1.POJOS;
using Microsoft.Office;

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
                FechaInicial = "12/22/2018",
                FechaFinal = "12/22/2018",
                Status = "A",
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

        private void button2_Click(object sender, EventArgs e)
        {
            // Creamos un objeto Excel.
            Microsoft.Office.Interop.Excel.Application Mi_Excel = default(Microsoft.Office.Interop.Excel.Application);
            // Creamos un objeto WorkBook. Para crear el documento Excel.           
            Microsoft.Office.Interop.Excel.Workbook LibroExcel = default(Microsoft.Office.Interop.Excel.Workbook);
            // Creamos un objeto WorkSheet. Para crear la hoja del documento.
            Microsoft.Office.Interop.Excel.Worksheet HojaExcel = default(Microsoft.Office.Interop.Excel.Worksheet);

            // Iniciamos una instancia a Excel, y Hacemos visibles para ver como se va creando el reporte, 
            // podemos hacerlo visible al final si se desea.
            Mi_Excel = new Microsoft.Office.Interop.Excel.Application();
            Mi_Excel.Visible = true;

            /* Ahora creamos un nuevo documento y seleccionamos la primera hoja del 
             * documento en la cual crearemos nuestro informe. 
             */
            // Creamos una instancia del Workbooks de excel.            
            LibroExcel = Mi_Excel.Workbooks.Add();
            // Creamos una instancia de la primera hoja de trabajo de excel            
            HojaExcel = LibroExcel.Worksheets[1];
            HojaExcel.Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible;

            // Hacemos esta hoja la visible en pantalla 
            // (como seleccionamos la primera esto no es necesario
            // si seleccionamos una diferente a la primera si lo
            // necesitariamos).
            HojaExcel.Activate();

            // Crear el encabezado de nuestro informe.
            // La primera línea une las celdas y las convierte un en una sola.            
            HojaExcel.Range["A1:K1"].Merge();
            // La segunda línea Asigna el nombre del encabezado.
            HojaExcel.Range["A1:K1"].Value = " ";
            // La tercera línea asigna negrita al titulo.
            HojaExcel.Range["A1:K1"].Font.Bold = true;
            // La cuarta línea signa un Size a titulo de 15.
            HojaExcel.Range["A1:K1"].Font.Size = 15;
            HojaExcel.Range["A1:k1"].Interior.Color = Color.FromArgb(31, 78, 120);

            // Crear el subencabezado de nuestro informe
            HojaExcel.Range["A2:K2"].Merge();
            HojaExcel.Range["A2:K2"].Value = "ANTIGÜEDAD DE SALDOS DE CLIENTES";
            HojaExcel.Range["A2:K2"].Font.Italic = true;
            HojaExcel.Range["A2:K2"].Font.Size = 15;
            HojaExcel.Range["A2:K2"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            HojaExcel.Range["A2:K2"].Interior.Color = Color.FromArgb(31, 78, 120);
            HojaExcel.Range["A2:K2"].Font.Color = Color.White;

            HojaExcel.Range["A3:K4"].Interior.Color = Color.FromArgb(31, 78, 120);
            Microsoft.Office.Interop.Excel.Range encabezado = HojaExcel.Range["A4:K4"];
            encabezado.Interior.Color = Color.FromArgb(221, 235, 247);

            Microsoft.Office.Interop.Excel.Range objCelda = HojaExcel.Range["A4", Type.Missing];
            objCelda.Value = "Clave inicial";

            objCelda = HojaExcel.Range["B4", Type.Missing];
            objCelda.Value = "Clave final";

            objCelda = HojaExcel.Range["C4", Type.Missing];
            objCelda.Value = "Fecha inicial";

            objCelda = HojaExcel.Range["D4", Type.Missing];
            objCelda.Value = "Fecha final";

            objCelda = HojaExcel.Range["E4", Type.Missing];
            objCelda.Value = "Nombre";

            objCelda = HojaExcel.Range["F4", Type.Missing];
            objCelda.Value = "Cargos";

            objCelda = HojaExcel.Range["G4", Type.Missing];
            objCelda.Value = "Abonos 1-30";

            objCelda = HojaExcel.Range["H4", Type.Missing];
            objCelda.Value = "Abonos 31-60";

            objCelda = HojaExcel.Range["I4", Type.Missing];
            objCelda.Value = "Abono 61-90";

            objCelda = HojaExcel.Range["J4", Type.Missing];
            objCelda.Value = "Abono >90";

            objCelda = HojaExcel.Range["K4", Type.Missing];
            objCelda.Value = "Status";

            //objCelda.EntireColumn.NumberFormat = "###,###,###.00";
            
            int i = 5;
            //List<ClienteDetalleVO> ds =  (List<ClienteDetalleVO>) dgvClientes.DataSource;
            foreach (DataGridViewRow Row in dgvClientes.Rows)
            {
                // Asignar los valores de los registros a las celdas
                HojaExcel.Cells[i, "A"] = Row.Cells[0].Value.ToString();
                // Clave inicial
                HojaExcel.Cells[i, "B"] = Row.Cells[1].Value.ToString();
                // Clave final
                HojaExcel.Cells[i, "C"] = Row.Cells[2].Value.ToString();
                // Fecha inicial
                HojaExcel.Cells[i, "D"] = Row.Cells[3].Value.ToString();
                // Fecha final
                HojaExcel.Cells[i, "E"] = Row.Cells[4].Value.ToString();
                // Nombre
                HojaExcel.Cells[i, "F"] = Row.Cells[5].Value.ToString();
                //Cargos
                HojaExcel.Cells[i, "G"] = Row.Cells[6].Value.ToString();
                //Abonos 1-30
                HojaExcel.Cells[i, "H"] = Row.Cells[7].Value.ToString();
                //Abonos 31-60
                HojaExcel.Cells[i, "I"] = Row.Cells[8].Value.ToString();
                //Abonos 61-90
                HojaExcel.Cells[i, "J"] = Row.Cells[9].Value.ToString();
                //Abonos 90 o más
                HojaExcel.Cells[i, "K"] = Row.Cells[10].Value.ToString();
                //Status
                
                // Avanzamos una fila
                i++;
            }

            // Seleccionar todo el bloque desde A1 hasta D #de filas.
            Microsoft.Office.Interop.Excel.Range Rango = HojaExcel.Range["A4:K" + (i - 1).ToString()];

            // Selecionado todo el rango especificado
            Rango.Select();

            // Ajustamos el ancho de las columnas al ancho máximo del
            // contenido de sus celdas
            Rango.Columns.AutoFit();

            // Asignar filtro por columna
            Rango.AutoFilter(1);

            // Crear un total general
            //LibroExcel.PrintPreview();
        }
    }
}
