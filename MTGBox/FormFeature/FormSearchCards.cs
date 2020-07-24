using MTGBox.Enum;
using MTGBox.Model;
using MTGBox.Requisitions;
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
        #region constructors
        public FormCardList()
        {
            InitializeComponent();
            AddColumns();
            AddColumnsCardData();
            Load();
        }
        #endregion

        #region events
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetCardsWithParameters("https://api.scryfall.com/cards/search?");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetNamedCards("https://api.scryfall.com/cards/search?order=name&q=" + txtSearch.Text);
        }

        private void btnSearchByExactName_Click(object sender, EventArgs e)
        {
            if (cboCardNames.Text != String.Empty)
                GetCardByName(cboCardNames.Text);
        }
        #endregion

        #region private methods
        private void GetCardByName(String name)
        {
            var card = new Card();
            try
            {
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
            SetCardValues(card);
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
                cell.Tag = card;
                PictureBox pic = new PictureBox();
                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(
                    card.ImageUris != null 
                        ? card.ImageUris.Small != null 
                            ? card.ImageUris.Small
                            : card.ImageUris.Normal != null 
                                ? card.ImageUris.Normal
                                : card.ImageUris.Large != null
                                    ? card.ImageUris.Large
                                    : card.ImageUris.Png != null
                                        ? card.ImageUris.Png
                                        : "https://gamepedia.cursecdn.com/mtgsalvation_gamepedia/thumb/f/f8/Magic_card_back.jpg/250px-Magic_card_back.jpg?version=56c40a91c76ffdbe89867f0bc5172888"
                        : "https://gamepedia.cursecdn.com/mtgsalvation_gamepedia/thumb/f/f8/Magic_card_back.jpg/250px-Magic_card_back.jpg?version=56c40a91c76ffdbe89867f0bc5172888");
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

        private void GetNamedCards(String text)
        {
            var cardPack = new CardPack();
            try
            {
                cardPack = (CardPack)new GetJson().GetCardPackObject(text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong request ! " + ex.Message, "Error");
            }
            PopulateCards(cardPack.Cards);
        }

        private void Load()
        {
            LoadComboboxWithCatalog(cboCardNames, ECatalogTypes.CardNames);
            LoadComboboxWithCatalog(cboArtistNames, ECatalogTypes.ArtistNames);
            LoadComboboxWithCatalog(cboWordBank, ECatalogTypes.WordBank);
            LoadComboboxWithCatalog(cboCreatureTypes, ECatalogTypes.CreatureTypes);
            LoadComboboxWithCatalog(cboPlaneswalkerTypes, ECatalogTypes.PlaneswalkerTypes);
            LoadComboboxWithCatalog(cboLandTypes, ECatalogTypes.LandTypes);
            LoadComboboxWithCatalog(cboArtifactTypes, ECatalogTypes.ArtifactTypes);
            LoadComboboxWithCatalog(cboEnchantmentYypes, ECatalogTypes.EnchantmentYypes);
            LoadComboboxWithCatalog(cboSpellTypes, ECatalogTypes.SpellTypes);
            LoadComboboxWithCatalog(cboPowers, ECatalogTypes.Powers);
            LoadComboboxWithCatalog(cboToughnesses, ECatalogTypes.Toughnesses);
            LoadComboboxWithCatalog(cboLoyalties, ECatalogTypes.Loyalties);
            LoadComboboxWithCatalog(cboWatermarks, ECatalogTypes.Watermarks);
            LoadComboboxWithCatalog(cboKeywordAbilities, ECatalogTypes.KeywordAbilities);
            LoadComboboxWithCatalog(cboKeywordActions, ECatalogTypes.KeywordActions);
            LoadComboboxWithCatalog(cboAbilityWords, ECatalogTypes.AbilityWords);
            LoadOrders();
        }

        private void LoadOrders()
        {
            foreach (var element in EOrderType.GetValues(typeof(EOrderType)))
            {
                cboOrder.Items.Add(element);
            }
        }

        private void LoadComboboxWithCatalog(ComboBox cbo, ECatalogTypes catalogType)
        {
            KeyValuePair <ECatalogTypes, Catalog> catalog = Main.Catalogs.Where(c => c.Key == catalogType).FirstOrDefault();
            foreach (String data in catalog.Value.Data)
            {
                cbo.Items.Add(data);
            }
        }

        private void AddColumnsCardData()
        {
            grdCardData.Columns.Add("Key", "");
            grdCardData.Columns.Add("Value", "");

            grdCardData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grdCardData.ColumnHeadersVisible = false;
            grdCardData.RowHeadersVisible = false;
            grdCardData.AllowUserToAddRows = false;
            grdCardData.AllowUserToResizeColumns = false; ;
            grdCardData.AllowUserToResizeRows = false;
            grdCardData.BorderStyle = BorderStyle.None;
            grdCardData.Margin = new Padding(30);
        }

        private void SetCardValues(Card card)
        {
            grdCardData.Rows.Add("Name", card.Name);
            grdCardData.Rows.Add("Set", card.Set);
            grdCardData.Rows.Add("SetName", card.SetName);
            grdCardData.Rows.Add("Artist", card.Artist);
            grdCardData.Rows.Add("Booster", card.Booster);
            grdCardData.Rows.Add("Cmc", card.Cmc);
            grdCardData.Rows.Add("CollectorNumber", card.CollectorNumber);
            grdCardData.Rows.Add("EdhrecRank", card.EdhrecRank);
            grdCardData.Rows.Add("EdhrecRank", card.FlavorText);
            grdCardData.Rows.Add("Foil", card.Foil);
            grdCardData.Rows.Add("Frame", card.Frame);
            grdCardData.Rows.Add("Games", card.Games);
            grdCardData.Rows.Add("Keywords", card.Keywords);
            grdCardData.Rows.Add("Layout", card.Layout);
            grdCardData.Rows.Add("Legalities", card.Legalities);
            grdCardData.Rows.Add("ManaCost", card.ManaCost);
            grdCardData.Rows.Add("Prices", card.Prices.Usd);
            grdCardData.Rows.Add("Rarity", card.Rarity);
            grdCardData.Rows.Add("Reprint", card.Reprint);
            grdCardData.Rows.Add("Reserved", card.Reserved);
            grdCardData.Rows.Add("SetName", card.SetName);
            grdCardData.Rows.Add("SetType", card.SetType);
            grdCardData.Rows.Add("StorySpotlight", card.StorySpotlight);
            grdCardData.Rows.Add("TypeLine", card.TypeLine);
            grdCardData.Rows.Add("Variation", card.Variation);
        }
        #endregion

        private void grd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            grdCardData.Rows.Clear();
            grdCardData.Refresh();
            var card = (grd.SelectedCells[0].Tag as Card);
            pic1.LoadAsync(@"" + card.ImageUris.Normal);
            SetCardValues(card);
        }

        private void GetCardsWithParameters(String search)
        {
            var requisition = "https://api.scryfall.com/cards/search?";
            var order = "order=" + cboOrder.SelectedItem  + "&";
            var queryInitialise = "q=";
            var name = (txtSearch.Text.Equals(String.Empty) ? String.Empty : txtSearch.Text + "+");
            var type = cboCreatureTypes.SelectedItem.Equals(String.Empty) ? String.Empty : "type%3a" + cboCreatureTypes.SelectedItem;

            var fullUrl = requisition + order + queryInitialise + name + type;

            var cardPack = new CardPack();
            try
            {
                cardPack = (CardPack)new GetJson().GetCardPackObject(fullUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong request ! " + ex.Message, "Error");
            }
            PopulateCards(cardPack.Cards);
        }
    }
}
