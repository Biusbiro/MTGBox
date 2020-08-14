using MTGBox.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGBox.DAO
{
    class ColorIdentityDAO
    {
        public void Insert(ColorIdentity colorIdentity)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "insert into color_identity (value, id_card) values (@usd, @id_card)";

            sqlCommand.Parameters.AddWithValue("@value", colorIdentity.Value);
            sqlCommand.Parameters.AddWithValue("@id_card", colorIdentity.Card.Id);

            Db.Execute(sqlCommand);
        }

        public void Update(ColorIdentity colorIdentity)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "update color_identity set value = @value, id_card = @id_card where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", colorIdentity.Id);
            sqlCommand.Parameters.AddWithValue("@value", colorIdentity.Value);
            sqlCommand.Parameters.AddWithValue("@id_card", colorIdentity.Card.Id);

            Db.Execute(sqlCommand);
        }

        public void Delete(ColorIdentity colorIdentity)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "delete from color_identity where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", colorIdentity.Id);

            Db.Execute(sqlCommand);
        }

        public ColorIdentity SelectById(Int32 id)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from color_identity where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            ColorIdentity colorIdentity = new ColorIdentity();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                colorIdentity.Id = (Int32)sqlDataReader["id"];
                colorIdentity.Value = (String)sqlDataReader["value"];
                colorIdentity.Card = new CardDAO().SelectById((Int32)sqlDataReader["id_card"]);

                return colorIdentity;
            }
            else
            {
                return null;
            }
        }

        public List<ColorIdentity> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from color_identity";

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            List<ColorIdentity> listColorIdentity = new List<ColorIdentity>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    ColorIdentity colorIdentity = new ColorIdentity();
                    colorIdentity.Id = (Int32)sqlDataReader["id"];
                    colorIdentity.Value = (String)sqlDataReader["value"];
                    colorIdentity.Card = new CardDAO().SelectById((Int32)sqlDataReader["id_card"]);
                    listColorIdentity.Add(colorIdentity);
                }
                sqlDataReader.Read();

                return listColorIdentity;
            }
            else
            {
                return null;
            }
        }

        public List<ColorIdentity> SelectAllByIdCard(Int32 idCard)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from color_identity where id_card = @id_card";

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            List<ColorIdentity> listColorIdentity = new List<ColorIdentity>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    ColorIdentity colorIdentity = new ColorIdentity();
                    colorIdentity.Id = (Int32)sqlDataReader["id"];
                    colorIdentity.Value = (String)sqlDataReader["value"];
                    colorIdentity.Card = new CardDAO().SelectById(idCard);
                    listColorIdentity.Add(colorIdentity);
                }
                sqlDataReader.Read();

                return listColorIdentity;
            }
            else
            {
                return null;
            }
        }
    }
}
