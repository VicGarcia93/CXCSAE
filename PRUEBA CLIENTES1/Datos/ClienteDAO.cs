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
    class ClienteDAO
    {
        List<ClientesVO> listClientes; 

        public ClienteDAO()
        {

        }

        public List<ClientesVO> GetClientes(ClientesVO clientes)
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
                                    FROM clie01 cli");

                if(clientes == null)
                {
                    throw new NullReferenceException("GetClientes()");
                }

                if (!String.IsNullOrEmpty(clientes.Id))
                {
                    campos.Append("cli.clave = @Id AND");
                    parametros.Add(new FbParameter("@Id", clientes.Id));
                }
                if (!String.IsNullOrEmpty(clientes.Nombre))
                {
                    campos.Append("cli.nombre = @Nombre AND");
                    parametros.Add(new FbParameter("@Nombre", clientes.Nombre)); 
                }
                if (!String.IsNullOrEmpty(clientes.Rfc))
                {
                    campos.Append("cli.rfc = @Rfc AND");
                    parametros.Add(new FbParameter("@Rfc", clientes.Rfc));
                }
                if (!String.IsNullOrEmpty(clientes.Status.ToString()))
                {
                    campos.Append("cli.status = @Status AND");
                    parametros.Add(new FbParameter("@Status", clientes.Status));
                }
                if (!String.IsNullOrEmpty(clientes.ConCredito.ToString()))
                {
                    campos.Append("cli.con_credito = @Con_Credito AND");
                    parametros.Add(new FbParameter("@Con_Credito", clientes.ConCredito));
                }


            }catch(Exception e)
            {

            }

        }
    }
}
