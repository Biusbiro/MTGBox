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
    class RelatedUrisDAO
    {
        public void Insert(RelatedUris relatedUris)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "insert into related_uris (gatherer, tcgplayer_decks, edhrec, mtgtop8) values (@gatherer, @tcgplayer_decks, @edhrec, @mtgtop8)";

            sqlCommand.Parameters.AddWithValue("@gatherer", relatedUris.Gatherer);
            sqlCommand.Parameters.AddWithValue("@tcgplayer_decks", relatedUris.TcgplayerDecks);
            sqlCommand.Parameters.AddWithValue("@edhrec", relatedUris.Edhrec);
            sqlCommand.Parameters.AddWithValue("@mtgtop8", relatedUris.Mtgtop8);

            Db.Execute(sqlCommand);
        }

        public void Update(RelatedUris relatedUris)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "update related_uris set tcgplayer = @tcgplayer, cardmarket = @cardmarket, cardhoarder = @cardhoarder where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", relatedUris.Id);
            sqlCommand.Parameters.AddWithValue("@gatherer", relatedUris.Gatherer);
            sqlCommand.Parameters.AddWithValue("@tcgplayer_decks", relatedUris.TcgplayerDecks);
            sqlCommand.Parameters.AddWithValue("@edhrec", relatedUris.Edhrec);
            sqlCommand.Parameters.AddWithValue("@mtgtop8", relatedUris.Mtgtop8);

            Db.Execute(sqlCommand);
        }

        public void Delete(RelatedUris relatedUris)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "delete from related_uris where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", relatedUris.Id);

            Db.Execute(sqlCommand);
        }

        public RelatedUris SelectById(Int32 id)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from related_uris where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            RelatedUris relatedUris = new RelatedUris();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                relatedUris.Id = (Int32)sqlDataReader["id"];
                relatedUris.Gatherer = (String)sqlDataReader["gatherer"];
                relatedUris.TcgplayerDecks = (String)sqlDataReader["tcgplayer_decks"];
                relatedUris.Edhrec = (String)sqlDataReader["edhrec"];
                relatedUris.Mtgtop8 = (String)sqlDataReader["mtgtop8"];

                return relatedUris;
            }
            else
            {
                return null;
            }
        }

        public List<RelatedUris> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from related_uris";

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            List<RelatedUris> listRelatedUris = new List<RelatedUris>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    RelatedUris relatedUris = new RelatedUris();
                    relatedUris.Id = (Int32)sqlDataReader["id"];
                    relatedUris.Gatherer = (String)sqlDataReader["gatherer"];
                    relatedUris.TcgplayerDecks = (String)sqlDataReader["tcgplayer_decks"];
                    relatedUris.Edhrec = (String)sqlDataReader["edhrec"];
                    relatedUris.Mtgtop8 = (String)sqlDataReader["mtgtop8"];
                    listRelatedUris.Add(relatedUris);
                }
                sqlDataReader.Read();

                return listRelatedUris;
            }
            else
            {
                return null;
            }
        }
    }
}
