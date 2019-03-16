using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRUEBA_CLIENTES1.POJOS;
using FirebirdSql.Data.FirebirdClient;

namespace PRUEBA_CLIENTES1.Datos
{
    using RutaBD = PRUEBA_CLIENTES1.Properties.Settings;
    class ClienteDAO
    {
        List<ClienteDetalleVO> clientesCargosAbonos;
        List<ClienteDetalleVO> clientesCargosDetallado;
        List<ClienteDetalleVO> clientesAbonosDetallado;

        public ClienteDAO()
        {

        }

        public DataSet GetClientes(ClientesVO clientes)
        {

            try
            {


                // Instanciamos un DataSet, que albergará el contenido de la consulta
                DataSet ds = new DataSet();

                // Declaramos dos StringBuilders: uno para la sentencia y otra para los campos
                // A su vez, declaramos un ArrayList para almacenar los parámetros.
                StringBuilder sQLString = new StringBuilder();
                StringBuilder campos = new StringBuilder();
                ArrayList parametros = new ArrayList();

                sQLString.Append(@"SELECT cli.clave,cli.nombre, cli.rfc, cli.status, cli.con_credito
                                    FROM clie0" + RutaBD.Default.empresaEnUso  + " cli");
                

                if(clientes == null)
                {
                    throw new NullReferenceException("GetClientes()");
                }

                if (!String.IsNullOrEmpty(clientes.Id))
                {
                    campos.Append("cli.clave = @Id AND ");
                    parametros.Add(new FbParameter("@Id", clientes.Id.Trim()));
                }
                if (!String.IsNullOrEmpty(clientes.Nombre.Trim()))
                {
                    campos.Append("cli.nombre = @Nombre AND ");
                    parametros.Add(new FbParameter("@Nombre", clientes.Nombre)); 
                }
                if (!String.IsNullOrEmpty(clientes.Rfc.Trim()))
                {
                    campos.Append("cli.rfc = @Rfc AND ");
                    parametros.Add(new FbParameter("@Rfc", clientes.Rfc));
                }
                if (!String.IsNullOrEmpty(clientes.Status.ToString().Trim()))
                {
                    campos.Append("cli.status = @Status AND ");
                    parametros.Add(new FbParameter("@Status", clientes.Status));
                }
                if (!String.IsNullOrEmpty(clientes.ConCredito.ToString().Trim()))
                {
                    campos.Append("cli.con_credito = @Con_Credito AND ");
                    parametros.Add(new FbParameter("@Con_Credito", clientes.ConCredito));
                }
                if(campos.Length > 0)
                {
                    sQLString.Append(" WHERE ");
                    sQLString.Append(campos.ToString().Substring(0, campos.ToString().Length - 4));
                }


                FbDataAdapter dataAdapter = new FbDataAdapter(ObtenerOrdenSQL(sQLString.ToString(),parametros));
                dataAdapter.Fill(ds);
                System.Windows.Forms.MessageBox.Show(ds.Tables[0].Rows.Count.ToString()); 
                return ds;
            }catch(Exception e)
            {
                throw (e); 
            }

        }

        public List<ClienteDetalleVO> GetClientesCargosAbonos(ClienteDetalleVO clienteDetalle)
        {
            StringBuilder sqlStringCargosGeneral = new StringBuilder();
            StringBuilder sqlStringCargosDetalle = new StringBuilder();
            StringBuilder sqlStringAbonosDetalle = new StringBuilder();
            DataSet dataClientes = new DataSet();
            DataTable dtCargosGenerales = new DataTable();
            DataTable dtCargosDetalle = new DataTable();
            DataTable dtAbonosDetalle = new DataTable();


            sqlStringCargosGeneral.Append(@"SELECT mov.cve_clie,cli.nombre, SUM(mov.importe) as cargos, cli.status
                                            FROM cuen_m0" + RutaBD.Default.empresaEnUso + @" mov, clie0" + RutaBD.Default.empresaEnUso + @" cli
                                            WHERE mov.tipo_mov = 'C'
                                            AND mov.cve_clie = cli.clave
                                            AND mov.fecha_apli BETWEEN '" + clienteDetalle.FechaInicial + "' AND '" + clienteDetalle.FechaFinal + @"'
                                            AND mov.cve_clie in (SELECT clie0" + RutaBD.Default.empresaEnUso + @".clave FROM clie0" + RutaBD.Default.empresaEnUso + @" WHERE clie0" + RutaBD.Default.empresaEnUso + @".status = '" + clienteDetalle.Status + @"')
                                            ");

            sqlStringCargosDetalle.Append(@"SELECT det.cve_clie, cli.nombre, SUM(det.importe) AS cargos, cli.status
                                            FROM cuen_det0" + RutaBD.Default.empresaEnUso + @" det, clie0" + RutaBD.Default.empresaEnUso + @" cli
                                            WHERE det.tipo_mov = 'C'                                            
                                            AND det.cve_clie = cli.clave
                                            AND det.fecha_apli BETWEEN '" + clienteDetalle.FechaInicial + "' AND '" + clienteDetalle.FechaFinal + @"'
                                            AND det.cve_clie IN(SELECT clie0" + RutaBD.Default.empresaEnUso + @".clave FROM clie0" + RutaBD.Default.empresaEnUso + @" WHERE clie0" + RutaBD.Default.empresaEnUso + @".status = '" + clienteDetalle.Status + @"')
                                            ");

            sqlStringAbonosDetalle.Append(@"SELECT det.cve_clie, cli.nombre, det.importe, det.no_factura, fac.contado, det.fecha_apli, fac.fecha_doc, cli.status
                                            FROM cuen_det0" + RutaBD.Default.empresaEnUso + @" det, clie0" + RutaBD.Default.empresaEnUso + @" cli, factf0" + RutaBD.Default.empresaEnUso + @" fac
                                            WHERE det.tipo_mov = 'A'
                                            AND det.cve_clie = cli.clave
                                            AND det.fecha_apli BETWEEN '" + clienteDetalle.FechaInicial + "' AND '" + clienteDetalle.FechaFinal + @"'
                                            AND det.cve_clie IN(SELECT clie0" + RutaBD.Default.empresaEnUso + @".clave FROM clie0" + RutaBD.Default.empresaEnUso + @" WHERE clie0" + RutaBD.Default.empresaEnUso + @".status = 'A')
                                            AND det.no_factura = fac.cve_doc");

            if (String.IsNullOrEmpty(clienteDetalle.ClaveInicial))
            { //Clave inicial null
                if (!String.IsNullOrEmpty(clienteDetalle.ClaveFinal))
                { //Clave final no es null
                    sqlStringCargosGeneral.Append(@" AND mov.cve_clie BETWEEN (SELECT clie0" + RutaBD.Default.empresaEnUso + @".clave FROM clie0" + RutaBD.Default.empresaEnUso + @" ORDER BY clie0" + RutaBD.Default.empresaEnUso + @".clave ASC ROWS 1)
                                             AND '" + clienteDetalle.ClaveFinal + "'");
                    sqlStringCargosDetalle.Append(@" AND mov.cve_clie BETWEEN (SELECT clie0" + RutaBD.Default.empresaEnUso + @".clave FROM clie0" + RutaBD.Default.empresaEnUso + @" ORDER BY clie0" + RutaBD.Default.empresaEnUso + @".clave ASC ROWS 1)
                                             AND '" + clienteDetalle.ClaveFinal + "'");
                    sqlStringAbonosDetalle.Append(@" AND det.cve_clie BETWEEN (SELECT clie0" + RutaBD.Default.empresaEnUso + @".clave FROM clie0" + RutaBD.Default.empresaEnUso + @" ORDER BY clie0" + RutaBD.Default.empresaEnUso + @".clave ASC ROWS 1)
                                             AND '" + clienteDetalle.ClaveFinal + "'");

                }
                else
                { //Clave final es null
                    
                }
            }
            else
            { //Clave inicial no null
                if (!String.IsNullOrEmpty(clienteDetalle.ClaveFinal))
                { //Clave final no es null
                    sqlStringCargosGeneral.Append(@" AND mov.cve_clie BETWEEN '" + clienteDetalle.ClaveInicial + 
                                            "' AND '" + clienteDetalle.ClaveFinal + "'");
                    sqlStringCargosDetalle.Append(@" AND mov.cve_clie BETWEEN '" + clienteDetalle.ClaveInicial + 
                                            "' AND '" + clienteDetalle.ClaveFinal + "'");
                    sqlStringAbonosDetalle.Append(@" AND det.cve_clie BETWEEN '" + clienteDetalle.ClaveInicial +
                                            "' AND '" + clienteDetalle.ClaveFinal + "'");
                }
                else
                { //Clave final es null
                    sqlStringCargosGeneral.Append(@" AND mov.cve_clie BETWEEN '" + clienteDetalle.ClaveInicial 
                                                    + "' AND (SELECT clie0" + RutaBD.Default.empresaEnUso + @".clave FROM clie0" + RutaBD.Default.empresaEnUso + @" ORDER BY clie0" + RutaBD.Default.empresaEnUso + @".clave DESC ROWS 1)");
                    sqlStringCargosDetalle.Append(@" AND mov.cve_clie BETWEEN '" + clienteDetalle.ClaveInicial
                                                    + "' AND (SELECT clie0" + RutaBD.Default.empresaEnUso + @".clave FROM clie0" + RutaBD.Default.empresaEnUso + @" ORDER BY clie0" + RutaBD.Default.empresaEnUso + @".clave DESC ROWS 1)");
                    sqlStringAbonosDetalle.Append(@" AND det.cve_clie BETWEEN '" + clienteDetalle.ClaveInicial
                                                    + "' AND (SELECT clie0" + RutaBD.Default.empresaEnUso + @".clave FROM clie0" + RutaBD.Default.empresaEnUso + @" ORDER BY clie0" + RutaBD.Default.empresaEnUso + @".clave DESC ROWS 1)");
                }
            }

            sqlStringCargosGeneral.Append(" GROUP BY mov.cve_clie, cli.nombre,cli.status");
            sqlStringCargosDetalle.Append(" GROUP BY det.cve_clie, cli.nombre,cli.status");

            FbDataAdapter adapterCargosGenerales = new FbDataAdapter(ObtenerOrdenSQL(sqlStringCargosGeneral.ToString(), null));
            FbDataAdapter adapterCargosDetalle = new FbDataAdapter(ObtenerOrdenSQL(sqlStringCargosDetalle.ToString(), null));
            FbDataAdapter adapterAbonosDetalle = new FbDataAdapter(ObtenerOrdenSQL(sqlStringAbonosDetalle.ToString(), null));

            adapterCargosGenerales.Fill(dtCargosGenerales);
            adapterCargosDetalle.Fill(dtCargosDetalle);
            adapterAbonosDetalle.Fill(dtAbonosDetalle);

            DataTable dataTable = new DataTable();
            
            return ObtenerClientesCargosAbonos(dtCargosGenerales.Rows, dtCargosDetalle.Rows, dtAbonosDetalle.Rows);
        }
        private List<ClienteDetalleVO> ObtenerClientesCargosAbonos(DataRowCollection filasCargos, DataRowCollection filasCargosDetalle, DataRowCollection filasAbonos)
        {
            clientesCargosAbonos = new List<ClienteDetalleVO>();
            ClienteDetalleVO nuevoCliente;
            for (int i = 0; i < filasCargos.Count; i++)
            {
                ClienteDetalleVO cliente = clientesCargosAbonos.Find(x => x.ClaveInicial == filasCargos[i][0].ToString());
                if(cliente != null)
                {
                    cliente.Cargos = (float.Parse(cliente.Cargos) + float.Parse(filasCargos[i][2].ToString())).ToString();
                }
                else
                {
                    nuevoCliente = new ClienteDetalleVO
                    {
                        ClaveInicial = filasCargos[i][0].ToString(),
                        ClaveFinal = filasCargos[i][0].ToString(),
                        Nombre = filasCargos[i][1].ToString(),
                        Cargos = filasCargos[i][2].ToString(),
                        Abono30 = "0",
                        Abono60 = "0",
                        Abono90 = "0",
                        AbonoPlus90 = "0",
                        FechaFinal = "0",
                        FechaInicial = "0",
                        Status = filasCargos[i][3].ToString()
                    };
                    clientesCargosAbonos.Add(nuevoCliente);
                }
            }

            for (int i = 0; i < filasCargosDetalle.Count; i++)
            {
                ClienteDetalleVO cliente = clientesCargosAbonos.Find(x => x.ClaveInicial == filasCargosDetalle[i][0].ToString());
                if (cliente != null)
                {
                    cliente.Cargos = (float.Parse(cliente.Cargos) + float.Parse(filasCargosDetalle[i][2].ToString())).ToString();
                }
                else
                {
                    nuevoCliente = new ClienteDetalleVO
                    {
                        ClaveInicial = filasCargosDetalle[i][0].ToString(),
                        ClaveFinal = filasCargosDetalle[i][0].ToString(),
                        Nombre = filasCargosDetalle[i][1].ToString(),
                        Cargos = filasCargosDetalle[i][2].ToString(),
                        Abono30 = "0",
                        Abono60 = "0",
                        Abono90 = "0",
                        AbonoPlus90 = "0",
                        FechaFinal = "0",
                        FechaInicial = "0",
                        Status = filasCargosDetalle[i][3].ToString()
                    };
                    clientesCargosAbonos.Add(nuevoCliente);
                }
            }
            for (int i = 0; i < filasAbonos.Count; i++)
            {
                string esContado = filasAbonos[i][4].ToString();
                
                if (esContado.Equals("N"))
                {
                    
                    int resultado = DiferenciaFechasAbono(filasAbonos[i][5].ToString(),filasAbonos[i][6].ToString());
                   
                    ClienteDetalleVO cliente = clientesCargosAbonos.Find(x => x.ClaveInicial == filasAbonos[i][0].ToString());
                    if (cliente != null)
                    {
                        if(resultado < 31)
                            cliente.Abono30 = (float.Parse(cliente.Abono30) + float.Parse(filasAbonos[i][2].ToString())).ToString();
                        else if(resultado > 30 && resultado < 61)
                            cliente.Abono60 = (float.Parse(cliente.Abono60) + float.Parse(filasAbonos[i][2].ToString())).ToString();
                        else if(resultado > 60 && resultado < 91)
                            cliente.Abono90 = (float.Parse(cliente.Abono90) + float.Parse(filasAbonos[i][2].ToString())).ToString();
                        else if(resultado > 90)
                            cliente.AbonoPlus90 = (float.Parse(cliente.AbonoPlus90) + float.Parse(filasAbonos[i][2].ToString())).ToString();
                    }
                    else
                    {
                        nuevoCliente = new ClienteDetalleVO
                        {
                            ClaveInicial = filasAbonos[i][0].ToString(),
                            ClaveFinal = filasAbonos[i][0].ToString(),
                            Nombre = filasAbonos[i][1].ToString(),
                            Abono30 = "0",
                            Abono60 = "0",
                            Abono90 = "0",
                            AbonoPlus90 = "0",
                            Cargos = "0",
                            FechaFinal = "0",
                            FechaInicial = "0",
                            Status = filasAbonos[i][7].ToString()
                            
                        };
                        if (resultado < 31)
                            nuevoCliente.Abono30 = filasAbonos[i][2].ToString();
                        else if(resultado > 30 && resultado <61)
                            nuevoCliente.Abono60 = filasAbonos[i][2].ToString();
                        else if(resultado > 60 && resultado < 91)
                            nuevoCliente.Abono90 = filasAbonos[i][2].ToString();
                        else if(resultado > 90)
                            nuevoCliente.AbonoPlus90 = filasAbonos[i][2].ToString();

                        clientesCargosAbonos.Add(nuevoCliente);
                    }
                }
                
            }

            return clientesCargosAbonos;
        }

        private int DiferenciaFechasAbono(string fecha_apli,string fecha_doc)
        {
            string[] fecha1 = fecha_apli.Substring(0, 10).Split('/');
            string[] fecha2 = fecha_doc.Substring(0,10).Split('/');
            DateTime fechaApli = new DateTime(int.Parse(fecha1[2]), int.Parse(fecha1[1]), int.Parse(fecha1[0]));
            DateTime fechaDoc = new DateTime(int.Parse(fecha2[2]), int.Parse(fecha2[1]), int.Parse(fecha2[0]));

            TimeSpan difDias = fechaApli - fechaDoc;
            int numDias = difDias.Days;
            
            return numDias;
        }

        
        private FbCommand ObtenerOrdenSQL(string sentenciaSQL, ArrayList parametros)
        {
            try
            {
                
                FbCommand command = new FbCommand(sentenciaSQL, ConexionBD.GetInstance().GetConnection())
                {
                    CommandType = CommandType.Text
                };

                //command.CommandType = CommandType.Text;
                if(parametros != null)
                {
                    foreach (FbParameter p in parametros)
                    {
                        command.Parameters.Add(p);

                    }
                }
                
                return command;
            }catch(Exception ex)
            {
                throw (ex);
            }
            
        }
    }
}
