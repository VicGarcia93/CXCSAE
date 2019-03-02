using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA_CLIENTES1.POJOS
{
    class ClientesVO
    {
        private string id;
        private string nombre;
        private string rfc;
        private char status;
        private char conCredito; 

        public ClientesVO(string id, string nombre, string rfc, char status, char conCredito)
        {
            this.id = id;
            this.nombre = nombre;
            this.rfc = rfc;
            this.status = status;
            this.conCredito = conCredito;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Rfc
        {
            get { return rfc; }
            set { rfc = value; }
        }

        public char Status
        {
            get { return status; }
            set { status = value; }
        }

        public char ConCredito
        {
            get { return conCredito; }
            set { conCredito = value; }
        }
    }
}
