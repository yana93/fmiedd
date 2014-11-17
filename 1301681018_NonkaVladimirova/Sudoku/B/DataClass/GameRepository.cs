using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace B.DataClass
{
    class GameRepository
    {
        static private IDbConnection conn = null;
        static private string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\Debug\\sudokuDB.mdb;";

        public Game Select(int user_ID)
        {
            Game oldGame=new Game();

            conn = new OleDbConnection();
            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            conn.ConnectionString = connString;
            cmd.CommandText = @"
SELECT
  user_ID,
  A, B, C, D, F, G, H, I, J
FROM
  Sudoku
WHERE
  user_ID = @user_ID
";
            IDbDataParameter param = cmd.CreateParameter();

            param = cmd.CreateParameter();
            param.ParameterName = "@user_ID";
            param.Value = user_ID;
            cmd.Parameters.Add(param);
            try
            {
                conn.Open();

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    {
                        oldGame.user_ID = Convert.ToInt32(reader["user_ID"]);
                        oldGame.A = Convert.ToString(reader["A"]);
                        oldGame.B = Convert.ToString(reader["B"]);
                        oldGame.C = Convert.ToString(reader["C"]);
                        oldGame.D = Convert.ToString(reader["D"]);
                        oldGame.F = Convert.ToString(reader["F"]);
                        oldGame.G = Convert.ToString(reader["G"]);
                        oldGame.H = Convert.ToString(reader["H"]);
                        oldGame.I = Convert.ToString(reader["I"]);
                        oldGame.J = Convert.ToString(reader["J"]);
                    };
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            if(oldGame.user_ID==0)
                return null;
            else return oldGame;
        }
        
        public void SaveGame(Game game)
        {
            conn = new OleDbConnection();
            IDbCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            conn.ConnectionString = connString;                      
            cmd.CommandText = @"
INSERT INTO Sudoku (
  user_ID,
  A, B, C, D, F, G, H, I, J
)
VALUES (
  @user_ID,
  @A, @B, @C, @D, @F, @G, @H, @I, @J
)
";
            IDbDataParameter param = cmd.CreateParameter();

            param.ParameterName = "@user_ID";
            param.Value = game.user_ID;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = "@A";
            param.Value =game.A;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = "@B";
            param.Value =game.B;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = "@C";
            param.Value =game.C;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = "@D";
            param.Value =game.D;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = "@F";
            param.Value =game.F;
            cmd.Parameters.Add(param);
                
            param = cmd.CreateParameter();
            param.ParameterName = "@G";
            param.Value =game.G;
            cmd.Parameters.Add(param);
                
            param = cmd.CreateParameter();
            param.ParameterName = "@H";
            param.Value =game.H;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = "@I";
            param.Value =game.I;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = "@J";
            param.Value =game.J;
            cmd.Parameters.Add(param);            
           
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error "+ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateGame(Game game)
        {

            conn = new OleDbConnection();
            conn.ConnectionString = connString;
            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"
UPDATE Sudoku SET
    A = @A,
    B = @B,
    C = @C,
    D = @D,
    F = @F,
    G = @G,
    H = @H,
    I = @I,
    J = @J
WHERE
  user_ID = @user_ID
";
            IDbDataParameter param = cmd.CreateParameter();

            param = cmd.CreateParameter();
            param.ParameterName = "@A";
            param.Value = game.A;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = "@B";
            param.Value = game.B;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = "@C";
            param.Value = game.C;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = "@D";
            param.Value = game.D;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = "@F";
            param.Value = game.F;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = "@G";
            param.Value = game.G;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = "@H";
            param.Value = game.H;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = "@I";
            param.Value = game.I;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = "@J";
            param.Value = game.J;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = "@user_ID";
            param.Value = game.user_ID;
            cmd.Parameters.Add(param);
           
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void Delete(int user_ID)
        {
            conn=new OleDbConnection();
            conn.ConnectionString = connString;
            IDbCommand cmd =conn.CreateCommand();
            cmd.CommandText = @"
DELETE FROM sudoku
WHERE
  user_Id = @user_ID
";
            IDbDataParameter param = cmd.CreateParameter();

            param = cmd.CreateParameter();
            param.ParameterName = "@user_ID";
            param.Value = user_ID;
            cmd.Parameters.Add(param);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
