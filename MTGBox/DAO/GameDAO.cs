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
    class GameDAO
    {
        public void Insert(Game game)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "insert into games (value, id_card) values (@value, @id_card)";

            sqlCommand.Parameters.AddWithValue("@value", game.Value);
            sqlCommand.Parameters.AddWithValue("@id_card", game.Card.Id);

            Db.Execute(sqlCommand);
        }

        public void Update(Game game)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "update games set value = @value, id_card = @id_card where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", game.Id);
            sqlCommand.Parameters.AddWithValue("@value", game.Value);
            sqlCommand.Parameters.AddWithValue("@id_card", game.Card.Id);

            Db.Execute(sqlCommand);
        }

        public void Delete(Game game)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "delete from games where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", game.Id);

            Db.Execute(sqlCommand);
        }

        public Game SelectById(Int32 id)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from games where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            Game game = new Game();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                game.Id = (Int32)sqlDataReader["id"];
                game.Value = (String)sqlDataReader["usd"];
                game.Card = new CardDAO().SelectById((Int32)sqlDataReader["id_card"]);

                return game;
            }
            else
            {
                return null;
            }
        }

        public List<Game> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from games";

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            List<Game> listGames = new List<Game>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Game game = new Game();
                    game.Id = (Int32)sqlDataReader["id"];
                    game.Value = (String)sqlDataReader["usd"];
                    game.Card = new CardDAO().SelectById((Int32)sqlDataReader["id_card"]);
                    listGames.Add(game);
                }
                sqlDataReader.Read();

                return listGames;
            }
            else
            {
                return null;
            }
        }

        public List<Game> SelectAllByIdCard(Int32 idCard)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from games where id_card = @id_card";

            sqlCommand.Parameters.AddWithValue("@id_card", idCard);

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            List<Game> listGames = new List<Game>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Game game = new Game();
                    game.Id = (Int32)sqlDataReader["id"];
                    game.Value = (String)sqlDataReader["usd"];
                    game.Card = new CardDAO().SelectById(idCard);
                    listGames.Add(game);
                }
                sqlDataReader.Read();

                return listGames;
            }
            else
            {
                return null;
            }
        }
    }
}
