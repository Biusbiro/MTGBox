using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGBox.DAO
{
    class ArtistIdDAO
    {
        public void Insert(ArtistId artistId)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "insert into artist_ids (value, id_card) values (@value, @id_card)";

            sqlCommand.Parameters.AddWithValue("@value", artistId.Value);
            sqlCommand.Parameters.AddWithValue("@id_card", artistId.Card.Id);

            Db.Execute(sqlCommand);
        }

        public void Update(ArtistId artistId)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "update artist_ids set value = @value, id_card = @id_card where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", artistId.Id);
            sqlCommand.Parameters.AddWithValue("@value", artistId.Value);
            sqlCommand.Parameters.AddWithValue("@id_card", artistId.Card.Id);

            Db.Execute(sqlCommand);
        }

        public void Delete(ArtistId artistId)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "delete from artist_ids where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", artistId.Id);

            Db.Execute(sqlCommand);
        }

        public ArtistId SelectById(Int32 id)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from artist_ids where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            ArtistId artistId = new ArtistId();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                artistId.Id = (Int32)sqlDataReader["id"];
                artistId.Value = (String)sqlDataReader["usd"];
                artistId.Card = new CardDAO().SelectById((Int32)sqlDataReader["id_card"]);

                return artistId;
            }
            else
            {
                return null;
            }
        }

        public List<ArtistId> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from artist_ids";

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            List<ArtistId> listArtistIds = new List<ArtistId>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    ArtistId artistId = new ArtistId();
                    artistId.Id = (Int32)sqlDataReader["id"];
                    artistId.Value = (String)sqlDataReader["usd"];
                    artistId.Card = new CardDAO().SelectById((Int32)sqlDataReader["id_card"]);
                    listArtistIds.Add(artistId);
                }
                sqlDataReader.Read();

                return listArtistIds;
            }
            else
            {
                return null;
            }
        }

        public List<ArtistId> SelectAllByIdCard(Int32 idCard)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from artist_ids where id_card = @id_card";

            sqlCommand.Parameters.AddWithValue("@id_card", idCard);

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            List<ArtistId> listArtistIds = new List<ArtistId>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    ArtistId artistId = new ArtistId();
                    artistId.Id = (Int32)sqlDataReader["id"];
                    artistId.Value = (String)sqlDataReader["usd"];
                    artistId.Card = new CardDAO().SelectById(idCard);
                    listArtistIds.Add(artistId);
                }
                sqlDataReader.Read();

                return listArtistIds;
            }
            else
            {
                return null;
            }
        }
    }
}
