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
    class LegalitiesDAO
    {
        public void Insert(Legalities legalities)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "insert into legalities (standard, future, historic, pioneer, modern, legacy, pauper, vintage, penny, commander, brawl, duel, oldschool) " +
                "values (@standard, @future, @historic, @pioneer, @modern, @legacy, @pauper, @vintage, @penny, @commander, @brawl, @duel, @oldschool)";

            sqlCommand.Parameters.AddWithValue("@standard", legalities.Standard);
            sqlCommand.Parameters.AddWithValue("@future", legalities.Future);
            sqlCommand.Parameters.AddWithValue("@historic", legalities.Historic);
            sqlCommand.Parameters.AddWithValue("@pioneer", legalities.Pioneer);
            sqlCommand.Parameters.AddWithValue("@modern", legalities.Modern);
            sqlCommand.Parameters.AddWithValue("@legacy", legalities.Legacy);
            sqlCommand.Parameters.AddWithValue("@pauper", legalities.Pauper);
            sqlCommand.Parameters.AddWithValue("@vintage", legalities.Vintage);
            sqlCommand.Parameters.AddWithValue("@penny", legalities.Penny);
            sqlCommand.Parameters.AddWithValue("@commander", legalities.Commander);
            sqlCommand.Parameters.AddWithValue("@brawl", legalities.Brawl);
            sqlCommand.Parameters.AddWithValue("@duel", legalities.Duel);
            sqlCommand.Parameters.AddWithValue("@oldschool", legalities.Oldschool);

            Db.Execute(sqlCommand);
        }

        public void Update(Legalities legalities)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText =
                "update legalities set " +
                    "standard = @standard, " +
                    "future = @future, " +
                    "historic = @historic, " +
                    "pioneer = @pioneer, " +
                    "modern = @modern, " +
                    "legacy = @legacy, " +
                    "pauper = @pauper, " +
                    "vintage = @vintage, " +
                    "penny = @penny, " +
                    "commander = @commander, " +
                    "brawl = @brawl, " +
                    "duel = @duel, " +
                    "oldschool = @oldschool " +
                "where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", legalities.Id);
            sqlCommand.Parameters.AddWithValue("@standard", legalities.Standard);
            sqlCommand.Parameters.AddWithValue("@future", legalities.Future);
            sqlCommand.Parameters.AddWithValue("@historic", legalities.Historic);
            sqlCommand.Parameters.AddWithValue("@pioneer", legalities.Pioneer);
            sqlCommand.Parameters.AddWithValue("@modern", legalities.Modern);
            sqlCommand.Parameters.AddWithValue("@legacy", legalities.Legacy);
            sqlCommand.Parameters.AddWithValue("@pauper", legalities.Pauper);
            sqlCommand.Parameters.AddWithValue("@vintage", legalities.Vintage);
            sqlCommand.Parameters.AddWithValue("@penny", legalities.Penny);
            sqlCommand.Parameters.AddWithValue("@commander", legalities.Commander);
            sqlCommand.Parameters.AddWithValue("@brawl", legalities.Brawl);
            sqlCommand.Parameters.AddWithValue("@duel", legalities.Duel);
            sqlCommand.Parameters.AddWithValue("@oldschool", legalities.Oldschool);

            Db.Execute(sqlCommand);
        }

        public void Delete(Legalities legalities)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "delete from legalities where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", legalities.Id);

            Db.Execute(sqlCommand);
        }

        public Legalities SelectById(Int32 id)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from legalities where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            Legalities legalities = new Legalities();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                legalities.Id = (Int32)sqlDataReader["id"];
                legalities.Standard = (String)sqlDataReader["standard"];
                legalities.Future = (String)sqlDataReader["future"];
                legalities.Historic = (String)sqlDataReader["historic"];
                legalities.Pioneer = (String)sqlDataReader["pioneer"];
                legalities.Modern = (String)sqlDataReader["modern"];
                legalities.Legacy = (String)sqlDataReader["legacy"];
                legalities.Pauper = (String)sqlDataReader["pauper"];
                legalities.Vintage = (String)sqlDataReader["vintage"];
                legalities.Penny = (String)sqlDataReader["penny"];
                legalities.Commander = (String)sqlDataReader["commander"];
                legalities.Brawl = (String)sqlDataReader["brawl"];
                legalities.Duel = (String)sqlDataReader["duel"];
                legalities.Oldschool = (String)sqlDataReader["oldschool"];

                return legalities;
            }
            else
            {
                return null;
            }
        }

        public List<Legalities> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from legalities";

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            List<Legalities> listLegalities = new List<Legalities>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Legalities legalities = new Legalities();
                    legalities.Id = (Int32)sqlDataReader["id"];
                    legalities.Standard = (String)sqlDataReader["standard"];
                    legalities.Future = (String)sqlDataReader["future"];
                    legalities.Historic = (String)sqlDataReader["historic"];
                    legalities.Pioneer = (String)sqlDataReader["pioneer"];
                    legalities.Modern = (String)sqlDataReader["modern"];
                    legalities.Legacy = (String)sqlDataReader["legacy"];
                    legalities.Pauper = (String)sqlDataReader["pauper"];
                    legalities.Vintage = (String)sqlDataReader["vintage"];
                    legalities.Penny = (String)sqlDataReader["penny"];
                    legalities.Commander = (String)sqlDataReader["commander"];
                    legalities.Brawl = (String)sqlDataReader["brawl"];
                    legalities.Duel = (String)sqlDataReader["duel"];
                    legalities.Oldschool = (String)sqlDataReader["oldschool"];
                    listLegalities.Add(legalities);
                }
                sqlDataReader.Read();

                return listLegalities;
            }
            else
            {
                return null;
            }
        }

    }
}
