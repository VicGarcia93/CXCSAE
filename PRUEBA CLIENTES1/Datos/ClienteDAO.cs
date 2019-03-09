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


            sqlStringCargosGeneral.Append(@"SELECT mov.cve_clie,cli.nombre, SUM(mov.importe) as cargos
                                            FROM cuen_m0" + RutaBD.Default.empresaEnUso + @" mov, clie0" + RutaBD.Default.empresaEnUso + @" cli
                                            WHERE mov.tipo_mov = 'C'
                                            AND mov.cve_clie = cli.clave
                                            AND mov.fecha_apli BETWEEN '" + clienteDetalle.fechaInicial + "' AND '" + clienteDetalle.fechaFinal + @"'
                                            AND mov.cve_clie in (SELECT clie0" + RutaBD.Default.empresaEnUso + @".clave FROM clie0" + RutaBD.Default.empresaEnUso + @" WHERE clie0" + RutaBD.Default.empresaEnUso + @".status = '" + clienteDetalle.status + @"')
                                            ");

            sqlStringCargosDetalle.Append(@"SELECT det.cve_clie, cli.nombre, SUM(det.importe) AS cargos
                                            FROM cuen_det0" + RutaBD.Default.empresaEnUso + @" det, clie0" + RutaBD.Default.empresaEnUso + @" cli
                                            WHERE det.tipo_mov = 'C'                                            
                                            AND det.cve_clie = cli.clave
                                            AND det.fecha_apli BETWEEN '" + clienteDetalle.fechaInicial + "' AND '" + clienteDetalle.fechaFinal + @"'
                                            AND det.cve_clie IN(SELECT clie0" + RutaBD.Default.empresaEnUso + @".clave FROM clie0" + RutaBD.Default.empresaEnUso + @" WHERE clie0" + RutaBD.Default.empresaEnUso + @".status = '" + clienteDetalle.status + @"')
                                            ");

            sqlStringAbonosDetalle.Append(@"SELECT det.cve_clie, cli.nombre, det.importe, det.no_factura, fac.contado, det.fecha_apli, fac.fecha_doc
                                            FROM cuen_det0" + RutaBD.Default.empresaEnUso + @" det, clie0" + RutaBD.Default.empresaEnUso + @" cli, factf0" + RutaBD.Default.empresaEnUso + @" fac
                                            WHERE det.tipo_mov = 'A'
                                            AND det.cve_clie = cli.clave
                                            AND det.fecha_apli BETWEEN '" + clienteDetalle.fechaInicial + "' AND '" + clienteDetalle.fechaFinal + @"'
                                            AND det.cve_clie IN(SELECT clie0" + RutaBD.Default.empresaEnUso + @".clave FROM clie0" + RutaBD.Default.empresaEnUso + @" WHERE clie0" + RutaBD.Default.empresaEnUso + @".status = 'A')
                                            AND det.no_factura = fac.cve_doc");

            if (String.IsNullOrEmpty(clienteDetalle.claveInicial))
            { //Clave inicial null
                if (!String.IsNullOrEmpty(clienteDetalle.claveFinal))
                { //Clave final no es null
                    sqlStringCargosGeneral.Append(@" AND mov.cve_clie BETWEEN (SELECT clie0" + RutaBD.Default.empresaEnUso + @".clave FROM clie0" + RutaBD.Default.empresaEnUso + @" ORDER BY clie0" + RutaBD.Default.empresaEnUso + @".clave ASC ROWS 1)
                                             AND '" + clienteDetalle.claveFinal + "'");
                    sqlStringCargosDetalle.Append(@" AND mov.cve_clie BETWEEN (SELECT clie0" + RutaBD.Default.empresaEnUso + @".clave FROM clie0" + RutaBD.Default.empresaEnUso + @" ORDER BY clie0" + RutaBD.Default.empresaEnUso + @".clave ASC ROWS 1)
                                             AND '" + clienteDetalle.claveFinal + "'");
                    sqlStringAbonosDetalle.Append(@" AND det.cve_clie BETWEEN (SELECT clie0" + RutaBD.Default.empresaEnUso + @".clave FROM clie0" + RutaBD.Default.empresaEnUso + @" ORDER BY clie0" + RutaBD.Default.empresaEnUso + @".clave ASC ROWS 1)
                                             AND '" + clienteDetalle.claveFinal + "'");

                }
                else
                { //Clave final es null
                    
                }
            }
            else
            { //Clave inicial no null
                if (!String.IsNullOrEmpty(clienteDetalle.claveFinal))
                { //Clave final no es null
                    sqlStringCargosGeneral.Append(@" AND mov.cve_clie BETWEEN '" + clienteDetalle.claveInicial + 
                                            "' AND '" + clienteDetalle.claveFinal + "'");
                    sqlStringCargosDetalle.Append(@" AND mov.cve_clie BETWEEN '" + clienteDetalle.claveInicial + 
                                            "' AND '" + clienteDetalle.claveFinal + "'");
                    sqlStringAbonosDetalle.Append(@" AND det.cve_clie BETWEEN '" + clienteDetalle.claveInicial +
                                            "' AND '" + clienteDetalle.claveFinal + "'");
                }
                else
                { //Clave final es null
                    sqlStringCargosGeneral.Append(@" AND mov.cve_clie BETWEEN '" + clienteDetalle.claveInicial 
                                                    + "' AND (SELECT clie0" + RutaBD.Default.empresaEnUso + @".clave FROM clie0" + RutaBD.Default.empresaEnUso + @" ORDER BY clie0" + RutaBD.Default.empresaEnUso + @".clave DESC ROWS 1)");
                    sqlStringCargosDetalle.Append(@" AND mov.cve_clie BETWEEN '" + clienteDetalle.claveInicial
                                                    + "' AND (SELECT clie0" + RutaBD.Default.empresaEnUso + @".clave FROM clie0" + RutaBD.Default.empresaEnUso + @" ORDER BY clie0" + RutaBD.Default.empresaEnUso + @".clave DESC ROWS 1)");
                    sqlStringAbonosDetalle.Append(@" AND det.cve_clie BETWEEN '" + clienteDetalle.claveInicial
                                                    + "' AND (SELECT clie0" + RutaBD.Default.empresaEnUso + @".clave FROM clie0" + RutaBD.Default.empresaEnUso + @" ORDER BY clie0" + RutaBD.Default.empresaEnUso + @".clave DESC ROWS 1)");
                }
            }

            sqlStringCargosGeneral.Append(" GROUP BY mov.cve_clie, cli.nombre");
            sqlStringCargosDetalle.Append(" GROUP BY det.cve_clie, cli.nombre");

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
                ClienteDetalleVO cliente = clientesCargosAbonos.Find(x => x.claveInicial == filasCargos[i][0].ToString());
                if(cliente != null)
                {
                    cliente.cargos = (float.Parse(cliente.cargos) + float.Parse(filasCargos[i][2].ToString())).ToString();
                }
                else
                {
                    nuevoCliente = new ClienteDetalleVO
                    {
                        claveInicial = filasCargos[i][0].ToString(),
                        claveFinal = filasCargos[i][0].ToString(),
                        nombre = filasCargos[i][1].ToString(),
                        cargos = filasCargos[i][2].ToString(),
                        abono30 = "0",
                        abono60 = "0",
                        abono90 = "0",
                        abonoPlus90 = "0",
                        fechaFinal = "0",
                        fechaInicial = "0"
                    };
                    clientesCargosAbonos.Add(nuevoCliente);
                }
            }

            for (int i = 0; i < filasCargosDetalle.Count; i++)
            {
                ClienteDetalleVO cliente = clientesCargosAbonos.Find(x => x.claveInicial == filasCargosDetalle[i][0].ToString());
                if (cliente != null)
                {
                    cliente.cargos = (float.Parse(cliente.cargos) + float.Parse(filasCargosDetalle[i][2].ToString())).ToString();
                }
                else
                {
                    nuevoCliente = new ClienteDetalleVO
                    {
                        claveInicial = filasCargosDetalle[i][0].ToString(),
                        claveFinal = filasCargosDetalle[i][0].ToString(),
                        nombre = filasCargosDetalle[i][1].ToString(),
                        cargos = filasCargosDetalle[i][2].ToString(),
                        abono30 = "0",
                        abono60 = "0",
                        abono90 = "0",
                        abonoPlus90 = "0",
                        fechaFinal = "0",
                        fechaInicial = "0"
                    };
                    clientesCargosAbonos.Add(nuevoCliente);
                }
            }
            for (int i = 0; i < filasAbonos.Count; i++)
            {
                string esContado = filasAbonos[i][4].ToString();
                System.Windows.Forms.MessageBox.Show("Restan: " + (filasAbonos.Count - (i+1)).ToString());
                if (esContado.Equals("N"))
                {
                    System.Windows.Forms.MessageBox.Show(filasAbonos[i][5].ToString());
                    int resultado = DiferenciaFechasAbono(filasAbonos[i][5].ToString(),filasAbonos[i][6].ToString());
                   
                    ClienteDetalleVO cliente = clientesCargosAbonos.Find(x => x.claveInicial == filasAbonos[i][0].ToString());
                    if (cliente != null)
                    {
                        if(resultado < 31)
                            cliente.abono30 = (float.Parse(cliente.abono30) + float.Parse(filasAbonos[i][2].ToString())).ToString();
                        else if(resultado > 30 && resultado < 61)
                            cliente.abono60 = (float.Parse(cliente.abono60) + float.Parse(filasAbonos[i][2].ToString())).ToString();
                        else if(resultado > 60 && resultado < 91)
                            cliente.abono90 = (float.Parse(cliente.abono90) + float.Parse(filasAbonos[i][2].ToString())).ToString();
                        else if(resultado > 90)
                            cliente.abonoPlus90 = (float.Parse(cliente.abonoPlus90) + float.Parse(filasAbonos[i][2].ToString())).ToString();
                    }
                    else
                    {
                        nuevoCliente = new ClienteDetalleVO
                        {
                            claveInicial = filasAbonos[i][0].ToString(),
                            claveFinal = filasAbonos[i][0].ToString(),
                            nombre = filasAbonos[i][1].ToString(),
                            abono30 = "0",
                            abono60 = "0",
                            abono90 = "0",
                            abonoPlus90 = "0",
                            cargos = "0",
                            fechaFinal = "0",
                            fechaInicial = "0"
                            
                        };
                        if (resultado < 31)
                            nuevoCliente.abono30 = filasAbonos[i][2].ToString();
                        else if(resultado > 30 && resultado <61)
                            nuevoCliente.abono60 = filasAbonos[i][2].ToString();
                        else if(resultado > 60 && resultado < 91)
                            nuevoCliente.abono90 = filasAbonos[i][2].ToString();
                        else if(resultado > 90)
                            nuevoCliente.abonoPlus90 = filasAbonos[i][2].ToString();

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
