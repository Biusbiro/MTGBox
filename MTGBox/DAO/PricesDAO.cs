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
    class PricesDAO
    {
        public void Insert(Prices prices)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "insert into prices (usd, usd_foil, eur, tix) values (@usd, @usd_foil, @eur, @tix)";

            sqlCommand.Parameters.AddWithValue("@usd", prices.Usd);
            sqlCommand.Parameters.AddWithValue("@usd_foil", prices.UsdFoil);
            sqlCommand.Parameters.AddWithValue("@eur", prices.Eur);
            sqlCommand.Parameters.AddWithValue("@tix", prices.Tix);

            Db.Execute(sqlCommand);
        }

        public void Update(Prices prices)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "update prices set usd = @usd, usd_foil = @usd_foil, eur = @eur, tix = @tix where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", prices.Id);
            sqlCommand.Parameters.AddWithValue("@usd", prices.Usd);
            sqlCommand.Parameters.AddWithValue("@usd_foil", prices.UsdFoil);
            sqlCommand.Parameters.AddWithValue("@eur", prices.Eur);
            sqlCommand.Parameters.AddWithValue("@tix", prices.Tix);

            Db.Execute(sqlCommand);
        }

        public void Delete(Prices prices)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "delete from prices where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", prices.Id);

            Db.Execute(sqlCommand);
        }

        public Prices SelectById(Int32 id)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from prices where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            Prices prices = new Prices();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                prices.Id = (Int32)sqlDataReader["id"];
                prices.Usd = (String)sqlDataReader["usd"];
                prices.UsdFoil = (String)sqlDataReader["usd_foil"];
                prices.Eur = (String)sqlDataReader["eur"];
                prices.Tix = (String)sqlDataReader["tix"];

                return prices;
            }
            else
            {
                return null;
            }
        }

        public List<Prices> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from prices";

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            List<Prices> listPrices = new List<Prices>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Prices prices = new Prices();
                    prices.Id = (Int32)sqlDataReader["id"];
                    prices.Usd = (String)sqlDataReader["usd"];
                    prices.UsdFoil = (String)sqlDataReader["usd_foil"];
                    prices.Eur = (String)sqlDataReader["eur"];
                    prices.Tix = (String)sqlDataReader["tix"];
                    listPrices.Add(prices);
                }
                sqlDataReader.Read();

                return listPrices;
            }
            else
            {
                return null;
            }
        }
    }
}
