using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projWeek7.Repository
{



    public class TableRepository
    {
        static OleDbConnection aConnection;
        public static void Table()
        {
            aConnection = new OleDbConnection("Provider=SQLNCLI11;Data Source=VELKO-PC\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=users");


            OleDbCommand aCommand = new OleDbCommand("SELECT * from users", aConnection);
            try
            {
                aConnection.Open();

                OleDbDataReader aReader = aCommand.ExecuteReader();
                Console.WriteLine("This is the returned data from test table");
                while (aReader.Read())
                {
                    Console.WriteLine("{0} \t {1} \t {2} \t {3}", aReader.GetInt32(0).ToString(), aReader.GetString(1), aReader.GetString(2), aReader.GetString(3));
                }

                aReader.Close();
                aConnection.Close();
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);
                aConnection.Close();
            }

            Console.WriteLine("###############################################################");
        }

        public static void Add()
        {


            Console.Clear();

            Repository.TableRepository.Table();


            Console.WriteLine("ДОБАВЯВНЕ НА ЗАПИС ");
            Console.WriteLine("МОЛЯ първо проверете дали ID - то съществува !!!");

            Console.Write("id : ");
            int ID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Име : ");
            string name = Convert.ToString(Console.ReadLine());

            Console.Write("Парола : ");
            string password = Convert.ToString(Console.ReadLine());

            Console.Write("Email : ");
            string email = Convert.ToString(Console.ReadLine());



            try
            {
                aConnection.Open();

                OleDbCommand aCommand = new OleDbCommand("INSERT INTO [users] ([id], [username], [password], [email]) VALUES('" + ID + "','" + name + "','" + password + "','" + email + "')", aConnection);
                aCommand.ExecuteNonQuery();

                if ("[id]" == ID.ToString())
                {
                    Console.WriteLine("It`s working , but i`dont know how ... BUT STILL WORKING !!! xD");
                }

                aConnection.Close();
            }
            catch (OleDbException e)
            {
                Console.WriteLine("ВЕЧЕ ИМА ТАКОВА ID !!!", e);
                Console.ReadKey(true);
                Console.Clear();
                aConnection.Close();
                return;

            }




            Console.WriteLine("Добавихте запис с номер  {0} успешно", ID);
            Console.ReadKey(true);
            Console.Clear();
            return;

        }

        public static void Delete()
        {
            Console.Clear();
            Repository.TableRepository.Table();

            Console.WriteLine("ИЗТРИВАНЕ НА ЗАПИС");
            Console.WriteLine("МОЛЯ първо проверете дали ID - то съществува !!!");


            Console.Write("Номер на запис ID : ");
            int ID = Convert.ToInt32(Console.ReadLine());


            try
            {

                aConnection.Open();
                OleDbCommand aCommand = new OleDbCommand("DELETE FROM users WHERE id = " + ID, aConnection);


                aCommand.ExecuteNonQuery();

                aConnection.Close();

            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);
                Console.ReadKey(true);
                Console.Clear();
                aConnection.Close();
                return;
            }


            Console.WriteLine("Изтрихте запис с номер {0} успешно  !!!", ID);
            Console.ReadKey(true);
            Console.Clear();
            aConnection.Close();
            return;
        }


        public static void Update()
        {
            Console.Clear();

            Repository.TableRepository.Table();

            Console.WriteLine("ОБНОВЯВАНЕ НА ЗАПИС");
            Console.WriteLine("МОЛЯ първо проверете дали ID - то съществува !!!");

            Console.Write("Номер на запис ID : ");
            int ID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Име : ");
            string username = Convert.ToString(Console.ReadLine());

            Console.Write("Парола : ");
            string password = Convert.ToString(Console.ReadLine());

            Console.Write("Email : ");
            string email = Convert.ToString(Console.ReadLine());



            try
            {
                aConnection.Open();
                OleDbCommand aCommand = new OleDbCommand("UPDATE [users] SET [username]='" + username + "',[password]='" + password + "',[email]='" + email + "'where [id]=" + ID, aConnection);
                aCommand.ExecuteNonQuery();
                aConnection.Close();
            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);
                aConnection.Close();
            }

            Console.WriteLine("Променихте запис с номер {0}  успешно", ID);
            Console.ReadKey(true);
            Console.Clear();

            return;
        }

    }  
}

