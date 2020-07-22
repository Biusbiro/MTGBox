using MTGBox.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTGBox.Requisitions
{
    public class GetJson
    {
        public Card GetCardObject(String cacheKey)
        {
            var requisicaoWeb = WebRequest.CreateHttp(cacheKey);
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";
            Card obj = new Card();
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                obj = JsonConvert.DeserializeObject<Card>(objResponse.ToString());
                streamDados.Close();
                resposta.Close();
            }
            return obj;
        }

        public CardPack GetCardPackObject(String cacheKey)
        {
            var requisicaoWeb = WebRequest.CreateHttp(cacheKey);
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";
            CardPack obj = new CardPack();
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                obj = JsonConvert.DeserializeObject<CardPack>(objResponse.ToString());
                streamDados.Close();
                resposta.Close();
            }
            return obj;
        }
    }
}
