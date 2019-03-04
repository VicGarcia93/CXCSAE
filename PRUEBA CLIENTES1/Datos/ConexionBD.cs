using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;

namespace PRUEBA_CLIENTES1.Datos
{
    using RutaBD = PRUEBA_CLIENTES1.Properties.Settings;
    class ConexionBD
    {
        private static ConexionBD conexion;
        private FbConnection connection;
        private string bd;
        

        private ConexionBD()
        {
            
        }
       public static ConexionBD GetInstance()
        {
            if(conexion == null)
            {
                conexion = new ConexionBD();
            }
            return conexion;
            
        }

        private void ConectarConBD()
        {
            switch (RutaBD.Default.empresaEnUso)
            {
                case "1":
                    bd = RutaBD.Default.bDLan1;
                    break;
                case "2":
                    bd = RutaBD.Default.bDFerre;
                    break;
                case "3":
                    bd = RutaBD.Default.bDLlantasM;
                    break;
                case "4":
                    bd = RutaBD.Default.bDLlantasE;
                    break;
                case "5":
                    bd = RutaBD.Default.bDLlantasP;
                    break;
                default:
                    
                    break;
            }

            FbConnectionStringBuilder conStrBuil = new FbConnectionStringBuilder();
            conStrBuil.ServerType = FbServerType.Default;
            conStrBuil.Database = bd;
            conStrBuil.UserID = "SYSDBA";
            conStrBuil.Password = "masterkey";
            connection = new FbConnection(conStrBuil.ToString());
        }

      
        public FbConnection GetConnection()
        {
            ConectarConBD();
            return connection;
        }
        public void SetBD(string bd)
        {
            this.bd = bd;
        }
        
       
    }
}
