using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using EDD_111_1082.Entity;

namespace EDD_111_1082.Repository
{
    class MailRepository
    {
        OleDbConnection conn;
        OleDbCommand cmd;

        private void ConnectTo()
        {
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database.accdb;Persist Security Info=False;");

            cmd = conn.CreateCommand();
        }
        public MailRepository()
        {
            ConnectTo();
        }
        public int InsertMail(Message message1)
        {
            int sent = 0;
            cmd.CommandText = @"INSERT INTO TMessages(Sender,Reciever,Message)
                                VALUES (@sender,@reciever,@message)";
            cmd.Parameters.AddRange(new OleDbParameter[] { 
            new OleDbParameter("@sender",(object)message1.Sender),
            new OleDbParameter("@reciever",(object)message1.Reciever),
            new OleDbParameter("@message",(object)message1.Messages)
            });
            try
            {
                conn.Open();
                sent=cmd.ExecuteNonQuery();
            }
            catch(OleDbException)
            {
                return sent = 0;
            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }
            return sent;
        }
        public List<Message> RetrieveMail(string reciever) //Gets user's messages from DB
        {
            List<Message> resultSet = new List<Message>();
            try
            {
                conn.Open();
                cmd.CommandText = @"SELECT * FROM TMessages WHERE Reciever=@reciever or Sender=@reciever";
                cmd.Parameters.AddWithValue("@reciever", (object)reciever);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultSet.Add(new Message()
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Sender = Convert.ToString(reader["Sender"]),
                        Reciever = Convert.ToString(reader["Reciever"]),
                        Messages = Convert.ToString(reader["Message"])
                    });
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return resultSet;
        }
                
    }
}
