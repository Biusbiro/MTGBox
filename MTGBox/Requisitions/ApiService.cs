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
        public void GetCardsWithParameters(String name, Boolean includeExtras, Boolean includeMultilingual, String order, Int32 page, String unique)
        {
            String stringFormat = "format=json";
            String stringIncludeExtras = "include_extras=" + includeExtras;
            String stringIncludeMultilingual = "include_multilingual=" + includeMultilingual;
            String stringOrder = "order=" + order;
            String stringPage = "page=" + page;
            String stringQuery = "q=c%3Ablue+pow%3D3";
            String stringUnique = "unique=" + unique;

            var customUrl = "https://api.scryfall.com/cards/search?" +
                stringFormat + "&" +
                stringIncludeExtras + "&" +
                stringIncludeMultilingual + "&" +
                stringOrder + "&" +
                stringPage + "&" +
                stringQuery + "&" +
                stringUnique;

            var card = new Card();

            try
            {
                card = new GetJson().GetCardObject(customUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong request ! " + ex.Message, "Error");
            }

            var listCards = new List<Card>();
        }

        private List<Card> GetRandomCards(Int32 quant)
        {
            List<Card> cards = new List<Card>();

            var count = 0;
            while (count < 10) 
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
