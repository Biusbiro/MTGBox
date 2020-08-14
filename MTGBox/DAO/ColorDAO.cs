using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGBox.DAO
{
    class ColorDAO
    {
        public void Insert(Color color)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "insert into colors (value, id_card) values (@value, @id_card)";

            sqlCommand.Parameters.AddWithValue("@value", color.Value);
            sqlCommand.Parameters.AddWithValue("@id_card", color.Card.Id);

            Db.Execute(sqlCommand);
        }

        public void Update(Color color)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "update colors set value = @value, id_card = @id_card where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", color.Id);
            sqlCommand.Parameters.AddWithValue("@value", color.Value);
            sqlCommand.Parameters.AddWithValue("@id_card", color.Card.Id);

            Db.Execute(sqlCommand);
        }

        public void Delete(Color color)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "delete from colors where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", color.Id);

            Db.Execute(sqlCommand);
        }

        public Color SelectById(Int32 id)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from colors where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            Color color = new Color();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                color.Id = (Int32)sqlDataReader["id"];
                color.Value = (String)sqlDataReader["value"];
                color.Card = new CardDAO().SelectById((Int32)sqlDataReader["id_card"]);

                return color;
            }
            else
            {
                return null;
            }
        }

        public List<Color> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from colors";

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            List<Color> listColors = new List<Color>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Color color = new Color();
                    color.Id = (Int32)sqlDataReader["id"];
                    color.Value = (String)sqlDataReader["value"];
                    color.Card = new CardDAO().SelectById((Int32)sqlDataReader["id_card"]);
                    listColors.Add(color);
                }
                sqlDataReader.Read();

                return listColors;
            }
            else
            {
                return null;
            }
        }

        public List<Color> SelectAllByIdCard(Int32 idCard)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from colors where id_card = @id_card";

            sqlCommand.Parameters.AddWithValue("@id_card", idCard);

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            List<Color> listColors = new List<Color>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Color color = new Color();
                    color.Id = (Int32)sqlDataReader["id"];
                    color.Value = (String)sqlDataReader["value"];
                    color.Card = new CardDAO().SelectById(idCard);
                    listColors.Add(color);
                }
                sqlDataReader.Read();

                return listColors;
            }
            else
            {
                return null;
            }
        }
    }
}
