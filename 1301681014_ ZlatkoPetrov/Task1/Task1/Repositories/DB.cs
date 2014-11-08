using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace Task1.Repositories
{
    public class DB
    {
        public static IDbConnection getDB()
        {
            ConnectionStringSettings cm = ConfigurationManager.ConnectionStrings["myConnection"];
            IDbConnection Conn = new OleDbConnection(cm.ConnectionString);
            return Conn;
        }
    }
}