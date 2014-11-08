using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace B.DataClass
{
    class UserRepository
    {
        static private readonly string dataString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=sudokuDB.mdb;";
        
        static private IDbConnection conn = null;
        static public void AddUser(string username,string password)
        {
            conn = new OleDbConnection();
            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            conn.ConnectionString =dataString;
            cmd.CommandText = @"
INSERT INTO users (
  username,
  pass
)
VALUES (
  @username,
  @pass
)
";
            IDbDataParameter param = cmd.CreateParameter();

            param = cmd.CreateParameter();
            param.ParameterName = "@username";
            param.Value = username;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = "@pass";
            param.Value = password;
            cmd.Parameters.Add(param);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Contact was NOT persisted correctly.   Error " + ex.Message);
            }
            finally
            {
               conn.Close();
            }
        }

        static public User GetByUsernameAndPassword(string username, string password)
        {
            User loguser=new User();

            conn = new OleDbConnection();
            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            conn.ConnectionString =dataString;
            cmd.CommandText = @"
SELECT
  user_ID,
  username,
  pass
FROM
  users
WHERE
  username = @username
AND
  pass=@pass
";
            IDbDataParameter param = cmd.CreateParameter();

            param = cmd.CreateParameter();
            param.ParameterName = "@username";
            param.Value =username;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = "@pass";
            param.Value =password;
            cmd.Parameters.Add(param);

            try
            {
                conn.Open();
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        {
                            loguser.user_ID = Convert.ToInt32(reader["user_ID"]);
                            loguser.username=Convert.ToString(reader["username"]);
                            loguser.password=Convert.ToString(reader["pass"]);
                        };

                    reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
            finally
            {
                conn.Close();
            }
            if (loguser.username == null)
            {
                return null;
            }
            else return loguser;
     }
    }
}
