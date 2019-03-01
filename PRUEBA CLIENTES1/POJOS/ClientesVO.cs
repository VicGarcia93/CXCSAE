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

        public ClientesVO(string id, string nombre, string rfc)
        {
            this.id = id;
            this.nombre = nombre;
            this.rfc = rfc;
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
    }
}
