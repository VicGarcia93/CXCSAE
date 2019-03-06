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

        public DataSet GetClientesCargosAbonos(ClienteDetalleVO clienteDetalle)
        {
            DataSet dataClientes = new DataSet();
            if (String.IsNullOrEmpty(clienteDetalle.claveInicial))
            {

            }
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
                foreach (FbParameter p in parametros)
                {
                    command.Parameters.Add(p);

                }
                return command;
            }catch(Exception ex)
            {
                throw (ex);
            }
            
        }
    }
}
