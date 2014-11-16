using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Data.Sql;
using System.Data;

namespace CRUD_EventRDY
{
    class ConnectDB
    {
        public static void RegisterME(string usr,string names, string pass, string email)
        {
            SqlCeConnection sqlConnection1 = new SqlCeConnection();
            sqlConnection1.ConnectionString = @"Data Source=..\..\UsersLOG.sdf";

            SqlCeCommand cmd = new SqlCeCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into UsersDBLOG (username,names,password,email) values('" + usr + "','" + names + "','" + pass + "','" + email + "');";
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            try
            {
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
                frmEdit.register = "User has been successfully registered!";
                frmCreate.register = "User has been successfully registered!";
            }
            catch (Exception)
            {
                frmEdit.register = "Username already exists!";
                frmCreate.register = "Username already exists!";
            }
        }
    }
}
