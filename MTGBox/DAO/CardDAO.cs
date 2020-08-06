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
    class CardDAO
    {
        public void Insert(Card card)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText =
                "insert into cards " +
                "(" +
                    "name, " +
                    "id_user" +
                    "oracle_id" +
                    "mtgo_id" +
                    "mtgo_foil_id" +
                    "tcgplayer_id" +
                    "lang" +
                    "released_at" +
                    "uri" +
                    "scryfall_uri" +
                    "layout" +
                    "highres_image" +
                    "mana_cost" +
                    "cmc" +
                    "type_line" +
                    "reserved" +
                    "foil" +
                    "nonfoil" +
                    "oversized" +
                    "promo" +
                    "reprint" +
                    "variation" +
                    "set" +
                    "set_name" +
                    "set_type" +
                    "set_uri" +
                    "set_search_uri" +
                    "scryfall_set_uri" +
                    "rulings_uri" +
                    "oracle_text" +
                    "prints_search_uri" +
                    "collector_number" +
                    "digital" +
                    "rarity" +
                    "flavor_text" +
                    "card_back_id" +
                    "artist" +
                    "illustration_id" +
                    "border_color" +
                    "frame" +
                    "full_art" +
                    "textless" +
                    "booster" +
                    "story_spotlight" +
                    "edhrec_rank" +
                    "multiverse_ids" +
                    "image_uris" +
                    "colors" +
                    "color_identity" +
                    "keywords" +
                    "legalities" +
                    "games" +
                    "artist_ids" +
                    "prices" +
                    "related_uris" +
                    "purchase_uris" +
                ") " +
                "values (" +
                    "@name, " +
                    "@id_user" +
                    "@oracle_id" +
                    "@mtgo_id" +
                    "@mtgo_foil_id" +
                    "@tcgplayer_id" +
                    "@lang" +
                    "@released_at" +
                    "@uri" +
                    "@scryfall_uri" +
                    "@layout" +
                    "@highres_image" +
                    "@mana_cost" +
                    "@cmc" +
                    "@type_line" +
                    "@reserved" +
                    "@foil" +
                    "@nonfoil" +
                    "@oversized" +
                    "@promo" +
                    "@reprint" +
                    "@variation" +
                    "@set" +
                    "@set_name" +
                    "@set_type" +
                    "@set_uri" +
                    "@set_search_uri" +
                    "@scryfall_set_uri" +
                    "@rulings_uri" +
                    "@oracle_text" +
                    "@prints_search_uri" +
                    "@collector_number" +
                    "@digital" +
                    "@rarity" +
                    "@flavor_text" +
                    "@card_back_id" +
                    "@artist" +
                    "@illustration_id" +
                    "@border_color" +
                    "@frame" +
                    "@full_art" +
                    "@textless" +
                    "@booster" +
                    "@story_spotlight" +
                    "@edhrec_rank" +
                    "@multiverse_ids" +
                    "@image_uris" +
                    "@colors" +
                    "@color_identity" +
                    "@keywords" +
                    "@legalities" +
                    "@games" +
                    "@artist_ids" +
                    "@prices" +
                    "@related_uris" +
                    "@purchase_uris" +
                ")";

            sqlCommand.Parameters.AddWithValue("@name", card.Name);
            sqlCommand.Parameters.AddWithValue("@id_user", card.User);
            sqlCommand.Parameters.AddWithValue("@oracle_id", card.OracleId);
            sqlCommand.Parameters.AddWithValue("@mtgo_id", card.MtgoId);
            sqlCommand.Parameters.AddWithValue("@mtgo_foil_id", card.MtgoFoilId);
            sqlCommand.Parameters.AddWithValue("@tcgplayer_id", card.TcgplayerId);
            sqlCommand.Parameters.AddWithValue("@lang", card.Lang);
            sqlCommand.Parameters.AddWithValue("@released_at", card.ReleasedAt);
            sqlCommand.Parameters.AddWithValue("@uri", card.Uri);
            sqlCommand.Parameters.AddWithValue("@scryfall_uri", card.ScryfallUri);
            sqlCommand.Parameters.AddWithValue("@layout", card.Layout);
            sqlCommand.Parameters.AddWithValue("@highres_image", card.HighresImage);
            sqlCommand.Parameters.AddWithValue("@mana_cost", card.ManaCost);
            sqlCommand.Parameters.AddWithValue("@cmc", card.Cmc);
            sqlCommand.Parameters.AddWithValue("@type_line", card.TypeLine);
            sqlCommand.Parameters.AddWithValue("@reserved", card.Reserved);
            sqlCommand.Parameters.AddWithValue("@foil", card.Foil);
            sqlCommand.Parameters.AddWithValue("@nonfoil", card.Nonfoil);
            sqlCommand.Parameters.AddWithValue("@oversized", card.Oversized);
            sqlCommand.Parameters.AddWithValue("@promo", card.Promo);
            sqlCommand.Parameters.AddWithValue("@reprint", card.Reprint);
            sqlCommand.Parameters.AddWithValue("@variation", card.Variation);
            sqlCommand.Parameters.AddWithValue("@set", card.Set);
            sqlCommand.Parameters.AddWithValue("@set_name", card.SetName);
            sqlCommand.Parameters.AddWithValue("@set_type", card.SetType);
            sqlCommand.Parameters.AddWithValue("@set_uri", card.SetUri);
            sqlCommand.Parameters.AddWithValue("@set_search_uri", card.SetSearchUri);
            sqlCommand.Parameters.AddWithValue("@scryfall_set_uri", card.ScryfallSetUri);
            sqlCommand.Parameters.AddWithValue("@rulings_uri", card.RulingsUri);
            sqlCommand.Parameters.AddWithValue("@oracle_text", card.OracleText);
            sqlCommand.Parameters.AddWithValue("@prints_search_uri", card.PrintsSearchUri);
            sqlCommand.Parameters.AddWithValue("@collector_number", card.CollectorNumber);
            sqlCommand.Parameters.AddWithValue("@digital", card.Digital);
            sqlCommand.Parameters.AddWithValue("@rarity", card.Rarity);
            sqlCommand.Parameters.AddWithValue("@flavor_text", card.FlavorText);
            sqlCommand.Parameters.AddWithValue("@card_back_id", card.CardBackId);
            sqlCommand.Parameters.AddWithValue("@artist", card.Artist);
            sqlCommand.Parameters.AddWithValue("@illustration_id", card.IllustrationId);
            sqlCommand.Parameters.AddWithValue("@border_color", card.BorderColor);
            sqlCommand.Parameters.AddWithValue("@frame", card.Frame);
            sqlCommand.Parameters.AddWithValue("@full_art", card.FullArt);
            sqlCommand.Parameters.AddWithValue("@textless", card.Textless);
            sqlCommand.Parameters.AddWithValue("@booster", card.Booster);
            sqlCommand.Parameters.AddWithValue("@story_spotlight", card.StorySpotlight);
            sqlCommand.Parameters.AddWithValue("@edhrec_rank", card.EdhrecRank);
            sqlCommand.Parameters.AddWithValue("@multiverse_ids", card.MultiverseIds);
            sqlCommand.Parameters.AddWithValue("@image_uris", card.ImageUris);
            sqlCommand.Parameters.AddWithValue("@colors", card.Colors);
            sqlCommand.Parameters.AddWithValue("@color_identity", card.ColorIdentity);
            sqlCommand.Parameters.AddWithValue("@keywords", card.Keywords);
            sqlCommand.Parameters.AddWithValue("@legalities", card.Legalities);
            sqlCommand.Parameters.AddWithValue("@games", card.Games);
            sqlCommand.Parameters.AddWithValue("@artist_ids", card.ArtistIds);
            sqlCommand.Parameters.AddWithValue("@prices", card.Prices);
            sqlCommand.Parameters.AddWithValue("@related_uris", card.RelatedUris);
            sqlCommand.Parameters.AddWithValue("@purchase_uris", card.PurchaseUris);

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
