using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DAL.Persistence
{
    public class Connection
    {
        //atributes
        protected SqlConnection conn;
        protected SqlCommand com;
        protected SqlDataReader dreader;

        //methods
        protected void OpenConnection()
        {
            try
            {
                conn = new SqlConnection("Data Source=.\\SQLExpress;Initial Catalog=alexander;Integrated Security=True");  // connectionString
                conn.Open();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        protected void CloseConnection()
        {
            try
            {

                conn.Close();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}


