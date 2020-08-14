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
    class MultiverseIdDAO
    {
        public void Insert(MultiverseId multiverseIds)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "insert into multiverse_ids (value, id_card) values (@id_card, @id_card)";

            sqlCommand.Parameters.AddWithValue("@value", multiverseIds.Value);
            sqlCommand.Parameters.AddWithValue("@id_card", multiverseIds.Card.Id);

            Db.Execute(sqlCommand);
        }

        public void Update(MultiverseId multiverseId)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "update multiverse_ids set value = @value, id_card = @id_card where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", multiverseId.Id);
            sqlCommand.Parameters.AddWithValue("@value", multiverseId.Value);
            sqlCommand.Parameters.AddWithValue("@id_card", multiverseId.Card.Id);

            Db.Execute(sqlCommand);
        }

        public void Delete(MultiverseId multiverseId)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "delete from multiverse_ids where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", multiverseId.Id);

            Db.Execute(sqlCommand);
        }

        public MultiverseId SelectById(Int32 id)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from multiverse_ids where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            MultiverseId multiverseId = new MultiverseId();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                multiverseId.Id = (Int32)sqlDataReader["id"];
                multiverseId.Value = (Int32)sqlDataReader["value"];
                multiverseId.Card = new CardDAO().SelectById((Int32)sqlDataReader["id_card"]);

                return multiverseId;
            }
            else
            {
                return null;
            }
        }

        public List<MultiverseId> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from prices";

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            List<MultiverseId> multiverseIds = new List<MultiverseId>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    MultiverseId multiverseId = new MultiverseId();
                    multiverseId.Id = (Int32)sqlDataReader["id"];
                    multiverseId.Value = (Int32)sqlDataReader["value"];
                    multiverseId.Card = new CardDAO().SelectById((Int32)sqlDataReader["id_card"]);
                    multiverseIds.Add(multiverseId);
                }
                sqlDataReader.Read();

                return multiverseIds;
            }
            else
            {
                return null;
            }
        }

        public List<MultiverseId> SelectAllByIdCard(Int32 idCard)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from prices where id_card = @id_card";

            sqlCommand.Parameters.AddWithValue("@id_card", idCard);

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            List<MultiverseId> multiverseIds = new List<MultiverseId>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    MultiverseId multiverseId = new MultiverseId();
                    multiverseId.Id = (Int32)sqlDataReader["id"];
                    multiverseId.Value = (Int32)sqlDataReader["value"];
                    multiverseId.Card = new CardDAO().SelectById(idCard);
                    multiverseIds.Add(multiverseId);
                }
                sqlDataReader.Read();

                return multiverseIds;
            }
            else
            {
                return null;
            }
        }
    }
}
