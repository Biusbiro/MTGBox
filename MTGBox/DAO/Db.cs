using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MTGBox.DAO
{
    public class Db
    {
        public static SqlConnection Connect()
        {
            String StringConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\github\\MTGBox\\MTGBox\\MTGBDB.mdf;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(StringConnection);
            sqlConnection.Open();
            return sqlConnection;
        }

        public static void Execute(SqlCommand sqlCommand)
        {
            SqlConnection sqlConnection = Connect();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static SqlDataReader Select(SqlCommand sqlCommand)
        {
            SqlConnection sqlConnection = Connect();
            sqlCommand.Connection = sqlConnection;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            return sqlDataReader;
        }

    }
}
