using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRUEBA_CLIENTES1.POJOS;

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
                StringBuilder SQLString = new StringBuilder();
                StringBuilder Campos = new StringBuilder();
                ArrayList Parametros = new ArrayList();

                SQLString.Append(@"SELECT cli.clave,cli.nombre, cli.rfc, cli.status, cli.con_credito
                                    FROM clie01 cli");

                if(clientes == null)
                {
                    throw new NullReferenceException("GetClientes()");
                }


            }catch(Exception e)
            {

            }

        }
    }
}
