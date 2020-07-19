using MTGBox.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MTGBox
{
    public partial class FormCardList : Form
    {

        public FormCardList()
        {
            InitializeComponent();
            AddColumns();
            GetRandomCards();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadCardByName();
        }

        private void LoadCardByName()
        {
            var card = new Card();
            try
            {
                var name = txtSearch.Text;
                var requisicaoWeb = WebRequest.CreateHttp("https://api.scryfall.com/cards/named?fuzzy=" + name);
                requisicaoWeb.Method = "GET";
                requisicaoWeb.UserAgent = "RequisicaoWebDemo";
                using (var resposta = requisicaoWeb.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);
                    object objResponse = reader.ReadToEnd();
                    card = JsonConvert.DeserializeObject<Card>(objResponse.ToString());
                    streamDados.Close();
                    resposta.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong request ! " + ex.Message, "Error");
            }

            pic1.LoadAsync(@"" + card.ImageUris.Normal);
        }

        private void AddColumns()
        {
            grd.Columns.Add(new DataGridViewImageColumn());
            grd.Columns.Add(new DataGridViewImageColumn());
            grd.Columns.Add(new DataGridViewImageColumn());
            grd.Columns.Add(new DataGridViewImageColumn());
            grd.Columns.Add(new DataGridViewImageColumn());

            grd.RowTemplate.Height = 150;
            grd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grd.ColumnHeadersVisible = false;
            grd.RowHeadersVisible = false;
            grd.AllowUserToAddRows = false;
            grd.AllowUserToResizeColumns = false; ;
            grd.AllowUserToResizeRows = false;
            grd.BorderStyle = BorderStyle.None;
            grd.Margin = new Padding(30);
        }

        private void PopulateCards(List<Card> cards)
        {
            grd.Rows.Clear();
            int columnNumber = 1;
            var row = new DataGridViewRow();
            foreach(Card card in cards)
            {
                if (columnNumber == 1)
                {
                    row = new DataGridViewRow();
                    row.MinimumHeight = 200;
                }
                var cell = new DataGridViewImageCell();
                cell.ImageLayout = DataGridViewImageCellLayout.Stretch;
                PictureBox pic = new PictureBox();
                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(card.ImageUris.Normal);
                using (HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    using (Stream stream = httpWebReponse.GetResponseStream())
                    {
                        cell.Value = Image.FromStream(stream);
                    }
                }
                row.Cells.Add(cell);
                if (columnNumber == grd.Columns.Count)
                {
                    grd.Rows.Add(row);
                    columnNumber = 0;
                }
                columnNumber++;
            }
        }

        private void GetRandomCards()
        {
            List<Card> cards = new List<Card>();

            var count = 0;
            while(count < 10)
            {
                var card = new Card();
                try
                {
                    var name = txtSearch.Text;
                    var requisicaoWeb = WebRequest.CreateHttp("https://api.scryfall.com/cards/random");
                    requisicaoWeb.Method = "GET";
                    requisicaoWeb.UserAgent = "RequisicaoWebDemo";
                    using (var resposta = requisicaoWeb.GetResponse())
                    {
                        var streamDados = resposta.GetResponseStream();
                        StreamReader reader = new StreamReader(streamDados);
                        object objResponse = reader.ReadToEnd();
                        card = JsonConvert.DeserializeObject<Card>(objResponse.ToString());
                        streamDados.Close();
                        resposta.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wrong request ! " + ex.Message, "Error");
                }
                cards.Add(card);
                count ++;
            }
            PopulateCards(cards);
        }
    }
}
