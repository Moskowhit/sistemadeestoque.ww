using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clnConexao
    {
        //Atributo
        private static SqlConnection con;

        /*  private static string caminho =
            "Data source = L1M27; initial catalog=BD_POOII;Integrated Security = True";*/
        /* private static string caminho =
             @"Server=DESKTOP-IG4G7V8;
 Database=BD_POOII;User Id= sa; Password=12345678";*/

        private static string caminho =
             @"Server=WESLEY\SQLEXPRESS;
 Database=BD_Floricultura;Integrated Security = True";
        //veja no site https://www.connectionstrings.com
        /* connectionString="Data Source=NOMESERVIDOR;
        initial catalog = Agenda; Integrated Security = True"*/
        //veja no site https://www.connectionstrings.com
        /* connectionString="Data Source=DESKTOP-IG4G7V8;
        initial catalog = Agenda; Integrated Security = True"*/
        public static SqlConnection getConexao()
    {
            try
            {
                con = new SqlConnection(caminho);
                return con;
            }
            catch(Exception)
            {
                throw;
            }


    }



    }
}
