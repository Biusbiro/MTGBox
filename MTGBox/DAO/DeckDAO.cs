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
    class DeckDAO
    {
        public void Insert(Deck deck)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "insert into decks (name, description, id_user) values (@name, @description, @id_user)";

            sqlCommand.Parameters.AddWithValue("@name", deck.Name);
            sqlCommand.Parameters.AddWithValue("@description", deck.Description);
            sqlCommand.Parameters.AddWithValue("@id_user", deck.User.Id);

            Db.Execute(sqlCommand);
        }

        public void Update(Deck deck)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "update deks set name = @name, description = @description, id_user = @id_user where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", deck.Id);
            sqlCommand.Parameters.AddWithValue("@name", deck.Name);
            sqlCommand.Parameters.AddWithValue("@description", deck.Description);
            sqlCommand.Parameters.AddWithValue("@id_user", deck.User.Id);

            Db.Execute(sqlCommand);
        }

        public void Delete(Deck deck)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "delete from decks where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", deck.Id);

            Db.Execute(sqlCommand);
        }

        public Deck SelectById(Deck deck)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from decks where id = @id";

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            Deck selectedUser = new Deck();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                deck.Id = (Int32)sqlDataReader["id"];
                deck.Name = (String)sqlDataReader["name"];
                deck.Description = (String)sqlDataReader["description"];
                deck.User = new UserDAO().SelectById((Int32)sqlDataReader["id_user"]);

                return deck;
            }
            else
            {
                return null;
            }
        }

        public List<Deck> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from deks";

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            List<Deck> listDeck = new List<Deck>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Deck deck = new Deck();
                    deck.Id = (Int32)sqlDataReader["id"];
                    deck.Name = (String)sqlDataReader["name"];
                    deck.Description = (String)sqlDataReader["description"];
                    deck.User = new UserDAO().SelectById((Int32)sqlDataReader["id_user"]);
                    listDeck.Add(deck);
                }
                sqlDataReader.Read();

                return listDeck;
            }
            else
            {
                return null;
            }
        }
    }
}
