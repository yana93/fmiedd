using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
namespace CRUD
{
    class Program
    {
        static int id = 0;
        static OleDbDataReader dr = null;
        static OleDbCommand cmd = new OleDbCommand();
        static OleDbConnection cn = new OleDbConnection();
        public static void Reader(OleDbConnection cn, OleDbCommand cmd, OleDbDataReader dr)
        {
            try
            {
                string q = "select * from info";
                cmd.CommandText = q;
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        Console.WriteLine("ID: " + dr[0].ToString() + "; " + "Username: " + dr[1].ToString() + "; " + "Password: " + dr[2].ToString() + "; " + "email: " + dr[3].ToString());
                        id = Convert.ToInt32(dr[0]);
                    }

                }
                dr.Close();

                cn.Close();
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message.ToString());
            }
        }
        public static void Cud(String u, OleDbConnection cn, OleDbCommand cmd)
        {
            try
            {
                cn.Open();
                cmd.CommandText = u;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message.ToString());
            }
        }
        public static void Create(OleDbConnection cn, OleDbCommand cmd)
        {

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Create a record in database: ");
            Reader(cn, cmd, dr);
            Console.WriteLine();
            Console.WriteLine("Username: ");
            string username = (Console.ReadLine());
            Console.WriteLine("Password: ");
            string password2 = (Console.ReadLine());
            Console.WriteLine("E-mail: ");
            string email = (Console.ReadLine());
            id += 1;
            string s = @"INSERT INTO info ([id], [username], [password2], [email]) VALUES('" + id + "','" + username + "','" + password2 + "','" + email + "')";
            Cud(s, cn, cmd);
            Console.WriteLine();
            Reader(cn, cmd, dr);
        }
        public static void Update(OleDbConnection cn, OleDbCommand cmd)
        {

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Update a record in database: ");
            Reader(cn, cmd, dr);
            Console.WriteLine();
            Console.WriteLine("ID= ");
            string id = (Console.ReadLine());
            Console.WriteLine("Username: ");
            string username = (Console.ReadLine());
            Console.WriteLine("Password: ");
            string password2 = (Console.ReadLine());
            Console.WriteLine("E-mail: ");
            string email = (Console.ReadLine());

            string u = "update info set username ='" + username + "',password2 ='" + password2 + "',email ='" + email + "'where id=" + id;
            Cud(u, cn, cmd);
            Console.WriteLine();
            Reader(cn, cmd, dr);


        }
        public static void Delete(OleDbConnection cn, OleDbCommand cmd)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Delete a record in database: ");
            Reader(cn, cmd, dr);
            Console.WriteLine();
            Console.WriteLine("ID= ");
            string id_del = (Console.ReadLine());
            string p = "delete * from info where id=" + id_del;
            Cud(p, cn, cmd);
            Reader(cn, cmd, dr);

        }
        static void Main(string[] args)
        {
            cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\users\pavel\documents\visual studio 2012\Projects\Cruid\Cruid\Database1.accdb;Persist Security Info=True";
            cmd.Connection = cn;

            Create(cn, cmd);
            Update(cn, cmd);
            Delete(cn, cmd);

            Console.ReadKey();
        }
    }
}