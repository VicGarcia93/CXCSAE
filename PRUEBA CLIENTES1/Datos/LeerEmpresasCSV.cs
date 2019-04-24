using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA_CLIENTES1.Datos
{
    class LeerEmpresasCSV
    {
        private static LeerEmpresasCSV empresasCSV = null;
        private LeerEmpresasCSV()
        {

        }

        public static LeerEmpresasCSV GetInstance()
        {
            if (empresasCSV == null)
            {
                empresasCSV = new LeerEmpresasCSV();
            }

            return empresasCSV;
        }

        public List<DatosEmpresasCSV> GetEmpresasAll()
        {
            using (var reader = new StreamReader("C:\\CLIENTES_SAE\\Empresas.csv"))
            using (var csv = new CsvReader(reader))
            {
                List<DatosEmpresasCSV> datosEmpresasRutas = new List<DatosEmpresasCSV>();
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    datosEmpresasRutas.Add(new DatosEmpresasCSV
                    {
                        Empresa = csv[0],
                        Ruta = csv[1]
                    });
                }

                return datosEmpresasRutas;
            }
        }

        public List<string> GetEmpresas()
        {
            using (var reader = new StreamReader("C:\\CLIENTES_SAE\\Empresas.csv"))
            using (var csv = new CsvReader(reader))
            {
                List<string> datosEmpresas = new List<string>();
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    datosEmpresas.Add(csv[0]);

                }
                return datosEmpresas;
            }
        }

        public string GetRutaPorEmpresa(int posicion)
        {
            using (var reader = new StreamReader("C:\\CLIENTES_SAE\\Empresas.csv"))
            using (var csv = new CsvReader(reader))
            {
                csv.Read();
                csv.ReadHeader();


                for (int i = 0; i < posicion + 1; i++)
                {
                    csv.Read();
                }

                return csv[1];
            }
        }
    }
}
