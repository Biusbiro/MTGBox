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
    class KeywordDAO
    {
        public void Insert(Keyword keyword)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "insert into keywords (value, id_card) values (@value, @id_card)";

            sqlCommand.Parameters.AddWithValue("@value", keyword.Value);
            sqlCommand.Parameters.AddWithValue("@id_card", keyword.Card.Id);

            Db.Execute(sqlCommand);
        }

        public void Update(Keyword keyword)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "update keywords set value = @value, id_card = @id_card where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", keyword.Id);
            sqlCommand.Parameters.AddWithValue("@value", keyword.Value);
            sqlCommand.Parameters.AddWithValue("@id_card", keyword.Card.Id);

            Db.Execute(sqlCommand);
        }

        public void Delete(Keyword keyword)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "delete from keywords where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", keyword.Id);

            Db.Execute(sqlCommand);
        }

        public Keyword SelectById(Int32 id)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from keywords where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            Keyword keyword = new Keyword();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                keyword.Id = (Int32)sqlDataReader["id"];
                keyword.Value = (String)sqlDataReader["usd"];
                keyword.Card = new CardDAO().SelectById((Int32)sqlDataReader["id_card"]);

                return keyword;
            }
            else
            {
                return null;
            }
        }

        public List<Keyword> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from keywords";

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            List<Keyword> listKeyword = new List<Keyword>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Keyword keyword = new Keyword();
                    keyword.Id = (Int32)sqlDataReader["id"];
                    keyword.Value = (String)sqlDataReader["usd"];
                    keyword.Card = new CardDAO().SelectById((Int32)sqlDataReader["id_card"]);
                    listKeyword.Add(keyword);
                }
                sqlDataReader.Read();

                return listKeyword;
            }
            else
            {
                return null;
            }
        }

        public List<Keyword> SelectAllByIdCard(Int32 idCard)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from keywords where id_card = @id_card";

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            List<Keyword> listKeyword = new List<Keyword>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Keyword keyword = new Keyword();
                    keyword.Id = (Int32)sqlDataReader["id"];
                    keyword.Value = (String)sqlDataReader["usd"];
                    keyword.Card = new CardDAO().SelectById(idCard);
                    listKeyword.Add(keyword);
                }
                sqlDataReader.Read();

                return listKeyword;
            }
            else
            {
                return null;
            }
        }
    }
}
