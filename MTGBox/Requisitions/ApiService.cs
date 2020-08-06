using MTGBox.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTGBox.Requisitions
{
    public class ApiService
    {
        public List<Card> GetCardsWithParameters(String searchText, String artist, String type, String order, String oracle, String colors, String language)
        {
            var query = "q=";
            var requisition = "https://api.scryfall.com/cards/search?";

            var fullUrl =
                requisition +
                order +
                query +
                searchText +
                type +
                artist +
                oracle +
                colors +
                language;

            var cardPack = new CardPack();
            try
            {
                cardPack = (CardPack)new GetJson().GetCardPackObject(fullUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong request ! " + ex.Message, "Error");
            }
            return cardPack.Cards;
        }

        private List<Card> GetRandomCards(Int32 quantitie)
        {
            List<Card> cards = new List<Card>();

            var count = 0;
            while (count < quantitie) 
            {
                var card = new Card();
                try
                {
                    card = new GetJson().GetCardObject("https://api.scryfall.com/cards/random");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wrong request ! " + ex.Message, "Error");
                }
                cards.Add(card);
                count++;
            }
            return cards;
        }
    }
}
