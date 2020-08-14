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

        public void Delete(Card card)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "delete from decks where id = @id";

            sqlCommand.Parameters.AddWithValue("@id", card.Id);

            Db.Execute(sqlCommand);
        }

        public Card SelectById(Int32 id)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from cards where id = @id";
            sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            Card selectedCard = new Card();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                selectedCard.Id = (String)sqlDataReader["id"];

                selectedCard.Name = (String)sqlDataReader["name"];
                selectedCard.OracleId = (String)sqlDataReader["oracle_id"];
                selectedCard.MtgoId = (int)sqlDataReader["mtgo_id"];
                selectedCard.MtgoFoilId = (int)sqlDataReader["mtgo_foil_id"];
                selectedCard.TcgplayerId = (int)sqlDataReader["tcgplayer_id"];
                selectedCard.Lang = (String)sqlDataReader["lang"];
                selectedCard.ReleasedAt = (String)sqlDataReader["released_at"];
                selectedCard.Uri = (String)sqlDataReader["uri"];
                selectedCard.ScryfallSetUri = (String)sqlDataReader["scryfall_uri"];
                selectedCard.Layout = (String)sqlDataReader["layout"];
                selectedCard.HighresImage = (Boolean)sqlDataReader["highres_image"];
                selectedCard.ManaCost = (String)sqlDataReader["mana_cost"];
                selectedCard.Cmc = (String)sqlDataReader["cmc"];
                selectedCard.TypeLine = (String)sqlDataReader["type_line"];
                selectedCard.Reserved = (Boolean)sqlDataReader["reserved"];
                selectedCard.Foil = (Boolean)sqlDataReader["foil"];
                selectedCard.Nonfoil = (Boolean)sqlDataReader["nonfoil"];
                selectedCard.Oversized = (Boolean)sqlDataReader["oversized"];
                selectedCard.Promo = (Boolean)sqlDataReader["promo"];
                selectedCard.Reprint = (Boolean)sqlDataReader["reprint"];
                selectedCard.Variation = (Boolean)sqlDataReader["variation"];
                selectedCard.Set = (String)sqlDataReader["set"];
                selectedCard.SetName = (String)sqlDataReader["set_name"];
                selectedCard.SetType = (String)sqlDataReader["set_type"];
                selectedCard.SetUri = (String)sqlDataReader["set_uri"];
                selectedCard.SetSearchUri = (String)sqlDataReader["set_search_uri"];
                selectedCard.ScryfallSetUri = (String)sqlDataReader["scryfall_set_uri"];
                selectedCard.RulingsUri = (String)sqlDataReader["rulings_uri"];
                selectedCard.OracleText = (String)sqlDataReader["oracle_text"];
                selectedCard.PrintsSearchUri = (String)sqlDataReader["prints_search_uri"];
                selectedCard.CollectorNumber = (String)sqlDataReader["collector_number"];
                selectedCard.Digital = (Boolean)sqlDataReader["digital"];
                selectedCard.Rarity = (String)sqlDataReader["rarity"];
                selectedCard.FlavorText = (String)sqlDataReader["flavor_text"];
                selectedCard.CardBackId = (String)sqlDataReader["card_back_id"];
                selectedCard.Artist = (String)sqlDataReader["artist"];
                selectedCard.IllustrationId = (String)sqlDataReader["illustration_id"];
                selectedCard.BorderColor = (String)sqlDataReader["border_color"];
                selectedCard.Frame = (String)sqlDataReader["frame"];
                selectedCard.FullArt = (Boolean)sqlDataReader["full_art"];
                selectedCard.Textless = (Boolean)sqlDataReader["textless"];
                selectedCard.Booster = (Boolean)sqlDataReader["booster"];
                selectedCard.StorySpotlight = (Boolean)sqlDataReader["story_spotlight"];
                selectedCard.EdhrecRank = (Int32)sqlDataReader["edhrec_rank"];

                selectedCard.MultiverseIds = new MultiverseIdDAO().SelectAllByIdCard(id).Select(obj => obj.Value).ToList();
                selectedCard.Colors = new ColorDAO().SelectAllByIdCard(id).Select(obj => obj.Value).ToList();
                selectedCard.ColorIdentity = new ColorIdentityDAO().SelectAllByIdCard(id).Select(obj => obj.Value).ToList();
                selectedCard.Keywords = new KeywordDAO().SelectAllByIdCard(id).Select(obj => obj.Value).ToList();
                selectedCard.Games = new GameDAO().SelectAllByIdCard(id).Select(obj => obj.Value).ToList();
                selectedCard.ArtistIds = new ArtistIdDAO().SelectAllByIdCard(id).Select(obj => obj.Value).ToList();

                selectedCard.PurchaseUris = new PurchaseUrisDAO().SelectById((Int32)sqlDataReader["id_purchase_uris"]);
                selectedCard.RelatedUris = new RelatedUrisDAO().SelectById((Int32)sqlDataReader["id_related_uris"]);
                selectedCard.Prices = new PricesDAO().SelectById((Int32)sqlDataReader["id_prices"]);
                selectedCard.Legalities = new LegalitiesDAO().SelectById((Int32)sqlDataReader["id_legalities"]);
                selectedCard.ImageUris = new ImageUrisDAO().SelectById((Int32)sqlDataReader["image_uris"]);

                return selectedCard;
            }
            else
            {
                return null;
            }
        }

        public List<Card> SelectAll()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "select * from cards";

            SqlDataReader sqlDataReader = Db.Select(sqlCommand);

            List<Card> listCards = new List<Card>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    var dbId = (Int32)sqlDataReader["dbid"];

                    Card card = new Card();
                    card.DbId = dbId;
                    card.Id = (String)sqlDataReader["id"];
                    card.Name = (String)sqlDataReader["name"];
                    card.OracleId = (String)sqlDataReader["oracle_id"];
                    card.MtgoId = (Int32)sqlDataReader["mtgo_id"];
                    card.MtgoFoilId = (Int32)sqlDataReader["mtgo_foil_id"];
                    card.TcgplayerId = (Int32)sqlDataReader["tcgplayer_id"];
                    card.Lang = (String)sqlDataReader["lang"];
                    card.ReleasedAt = (String)sqlDataReader["released_at"];
                    card.Uri = (String)sqlDataReader["uri"];
                    card.ScryfallSetUri = (String)sqlDataReader["scryfall_uri"];
                    card.Layout = (String)sqlDataReader["layout"];
                    card.HighresImage = (Boolean)sqlDataReader["highres_image"];
                    card.ManaCost = (String)sqlDataReader["mana_cost"];
                    card.Cmc = (String)sqlDataReader["cmc"];
                    card.TypeLine = (String)sqlDataReader["type_line"];
                    card.Reserved = (Boolean)sqlDataReader["reserved"];
                    card.Foil = (Boolean)sqlDataReader["foil"];
                    card.Nonfoil = (Boolean)sqlDataReader["nonfoil"];
                    card.Oversized = (Boolean)sqlDataReader["oversized"];
                    card.Promo = (Boolean)sqlDataReader["promo"];
                    card.Reprint = (Boolean)sqlDataReader["reprint"];
                    card.Variation = (Boolean)sqlDataReader["variation"];
                    card.Set = (String)sqlDataReader["set"];
                    card.SetName = (String)sqlDataReader["set_name"];
                    card.SetType = (String)sqlDataReader["set_type"];
                    card.SetUri = (String)sqlDataReader["set_uri"];
                    card.SetSearchUri = (String)sqlDataReader["set_search_uri"];
                    card.ScryfallSetUri = (String)sqlDataReader["scryfall_set_uri"];
                    card.RulingsUri = (String)sqlDataReader["rulings_uri"];
                    card.OracleText = (String)sqlDataReader["oracle_text"];
                    card.PrintsSearchUri = (String)sqlDataReader["prints_search_uri"];
                    card.CollectorNumber = (String)sqlDataReader["collector_number"];
                    card.Digital = (Boolean)sqlDataReader["digital"];
                    card.Rarity = (String)sqlDataReader["rarity"];
                    card.FlavorText = (String)sqlDataReader["flavor_text"];
                    card.CardBackId = (String)sqlDataReader["card_back_id"];
                    card.Artist = (String)sqlDataReader["artist"];
                    card.IllustrationId = (String)sqlDataReader["illustration_id"];
                    card.BorderColor = (String)sqlDataReader["border_color"];
                    card.Frame = (String)sqlDataReader["frame"];
                    card.FullArt = (Boolean)sqlDataReader["full_art"];
                    card.Textless = (Boolean)sqlDataReader["textless"];
                    card.Booster = (Boolean)sqlDataReader["booster"];
                    card.StorySpotlight = (Boolean)sqlDataReader["story_spotlight"];
                    card.EdhrecRank = (Int32)sqlDataReader["edhrec_rank"];

                    card.MultiverseIds = new MultiverseIdDAO().SelectAllByIdCard(dbId).Select(obj => obj.Value).ToList();
                    card.Colors = new ColorDAO().SelectAllByIdCard(dbId).Select(obj => obj.Value).ToList();
                    card.ColorIdentity = new ColorIdentityDAO().SelectAllByIdCard(dbId).Select(obj => obj.Value).ToList();
                    card.Keywords = new KeywordDAO().SelectAllByIdCard(dbId).Select(obj => obj.Value).ToList();
                    card.Games = new GameDAO().SelectAllByIdCard(dbId).Select(obj => obj.Value).ToList();
                    card.ArtistIds = new ArtistIdDAO().SelectAllByIdCard(dbId).Select(obj => obj.Value).ToList();
                    
                    card.PurchaseUris = new PurchaseUrisDAO().SelectById((Int32)sqlDataReader["id_purchase_uris"]);
                    card.RelatedUris = new RelatedUrisDAO().SelectById((Int32)sqlDataReader["id_related_uris"]);
                    card.Prices = new PricesDAO().SelectById((Int32)sqlDataReader["id_prices"]);
                    card.Legalities = new LegalitiesDAO().SelectById((Int32)sqlDataReader["id_legalities"]);
                    card.ImageUris = new ImageUrisDAO().SelectById((Int32)sqlDataReader["image_uris"]);

                    listCards.Add(card);
                }
                sqlDataReader.Read();

                return listCards;
            }
            else
            {
                return null;
            }
        }
    }
}
