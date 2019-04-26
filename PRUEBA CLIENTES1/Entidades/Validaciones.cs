using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA_CLIENTES1.Entidades
{
    class Validaciones
    {
        private static Validaciones validador = null;
        private Validaciones()
        {

        }

        public static Validaciones GetInstance()
        {
            if(validador == null)
            {
                validador = new Validaciones();
            }
            return validador;
        }

        public String ValidaCliente(string cveCliente)
        {

            if (!cveCliente.Equals("MOSTR"))
            {
                if (!String.IsNullOrEmpty(cveCliente))
                {
                    for (int i = cveCliente.Length; i < 10; i++)
                    {
                        cveCliente = " " + cveCliente;
                    }
                }


            }
            //Verificar si existe en la Base de datos

            return cveCliente;
        }

        public bool ValidaClavesClientes(string cveInicialCliente, string cveFinalCliente)
        {
            if (!String.IsNullOrEmpty(cveFinalCliente))
            {
                if (!String.IsNullOrEmpty(cveInicialCliente))
                {
                    if (int.Parse(cveInicialCliente) > int.Parse(cveFinalCliente))
                    {
                        return false;
                    }
                }

            }
            return true;
        }
    }
}
