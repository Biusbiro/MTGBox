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
    class PurchaseUrisDAO
    {
        public void Insert(PurchaseUris pourchaseUris)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "insert into purchase_uris (tcgplayer, cardmarket, cardhoarder) values (@tcgplayer, @cardmarket, @cardhoarder)";

            sqlCommand.Parameters.AddWithValue("@tcgplayer", pourchaseUris.Tcgplayer);
            sqlCommand.Parameters.AddWithValue("@cardmarket", pourchaseUris.Cardmarket);
            sqlCommand.Parameters.AddWithValue("@cardhoarder", pourchaseUris.Cardhoarder);

            Db.Execute(sqlCommand);
        }

        public void Update(PurchaseUris pourchaseUris)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "update purchase_uris set tcgplayer = @tcgplayer, cardmarket = @cardmarket, cardhoarder = @cardhoarder where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", pourchaseUris.Id);
            sqlCommand.Parameters.AddWithValue("@tcgplayer", pourchaseUris.Tcgplayer);
            sqlCommand.Parameters.AddWithValue("@cardmarket", pourchaseUris.Cardmarket);
            sqlCommand.Parameters.AddWithValue("@cardhoarder", pourchaseUris.Cardhoarder);

            Db.Execute(sqlCommand);
        }

        public void Delete(PurchaseUris pourchaseUris)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "delete from purchase_uris where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", pourchaseUris.Id);

            Db.Execute(sqlCommand);
        }

        public PurchaseUris SelectById(Int32 id)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from purchase_uris where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            PurchaseUris purchaseUris = new PurchaseUris();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                purchaseUris.Id = (Int32)sqlDataReader["id"];
                purchaseUris.Tcgplayer = (String)sqlDataReader["tcgplayer"];
                purchaseUris.Cardmarket = (String)sqlDataReader["cardmarket"];
                purchaseUris.Cardhoarder = (String)sqlDataReader["cardhoarder"];

                return purchaseUris;
            }
            else
            {
                return null;
            }
        }

        public List<PurchaseUris> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from purchase_uris";

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            List<PurchaseUris> listPurchaseUris = new List<PurchaseUris>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    PurchaseUris purchaseUris = new PurchaseUris();
                    purchaseUris.Id = (Int32)sqlDataReader["id"];
                    purchaseUris.Tcgplayer = (String)sqlDataReader["tcgplayer"];
                    purchaseUris.Cardmarket = (String)sqlDataReader["cardmarket"];
                    purchaseUris.Cardhoarder = (String)sqlDataReader["cardhoarder"];
                    listPurchaseUris.Add(purchaseUris);
                }
                sqlDataReader.Read();

                return listPurchaseUris;
            }
            else
            {
                return null;
            }
        }
    }
}
