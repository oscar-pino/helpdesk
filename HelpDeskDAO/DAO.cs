using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace HelpDeskDAO
{
    public sealed class DAO
    {
        private static object _sync = new Object();
        private static volatile SqlConnection _coneccion;
        private static string _stringConeccion = string.Empty;

        private DAO() { 
        
        }

        public static SqlConnection Instancia
        {
            get
            {
                if (_coneccion == null)
                {
                    lock (_sync)
                    {
                        if (_coneccion == null)
                        {
                            _stringConeccion = ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString;
                            _coneccion = new SqlConnection(_stringConeccion);
                        }
                    }
                }
                return _coneccion;
            }            
        }
    }
}
