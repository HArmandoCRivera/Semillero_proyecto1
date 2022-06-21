using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Estudiantes
{
    class Conexion
    {
        public static SqlConnection Conectar() {
            SqlConnection con = new SqlConnection("SERVER=DESKTOP-E8KBADI\\SQLEXPRESSHUGO;DATABASE=REGISTRO;integrated security=true");
            con.Open();
            return con; /*esta es la conexión con la BD del proyecto*/

        }

        public static SqlConnection Desconectar(){
            SqlConnection des = new SqlConnection("SERVER=DESKTOP-E8KBADI\\SQLEXPRESSHUGO;DATABASE=REGISTRO;integrated security=true");
            des.Close();
            return des;

        }

    }
}
