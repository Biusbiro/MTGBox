using MTGBox.Enum;
using MTGBox.FormFeature;
using MTGBox.Model;
using MTGBox.Properties;
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
            GetCardsWithParameters();
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

        private void radCreature_CheckedChanged(object sender, EventArgs e)
        {
            RefreshComboboxTypes();
        }

        private void radPlaneswalker_CheckedChanged(object sender, EventArgs e)
        {
            RefreshComboboxTypes();
        }

        private void radLand_CheckedChanged(object sender, EventArgs e)
        {
            RefreshComboboxTypes();
        }

        private void radArtifact_CheckedChanged(object sender, EventArgs e)
        {
            RefreshComboboxTypes();
        }

        private void radEnchantment_CheckedChanged(object sender, EventArgs e)
        {
            RefreshComboboxTypes();
        }

        private void radSpell_CheckedChanged(object sender, EventArgs e)
        {
            RefreshComboboxTypes();
        }

        private void grd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowDataCard();
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
            if (cards == null)
                return;

            grd.Rows.Clear();
            grd.Refresh();
            int columnNumber = 1;
            var row = new DataGridViewRow();
            foreach(Card card in cards)
            {
                if (columnNumber == 1)
                {
                    row = new DataGridViewRow();
                }
                var cell = new DataGridViewImageCell();
                cell.ImageLayout = DataGridViewImageCellLayout.Zoom;
                cell.Tag = card;
                cell.Value = LoadCardPic(card, cell);
                row.Cells.Add(cell);
                if (columnNumber == grd.Columns.Count || card == cards.Last())
                {
                    grd.Rows.Add(row);
                    columnNumber = 0;
                }
                columnNumber++;
            }
        }

        private Bitmap LoadCardPic(Card card, DataGridViewImageCell cell)
        {
            PictureBox pic = new PictureBox();
            pic.ErrorImage = Resources.MagicLogoDefaultBlock_100x100;
            pic.InitialImage = Resources.MagicLogoDefaultBlock_100x100;
            pic.BackgroundImageLayout = ImageLayout.Center;
            pic.LoadAsync(
                    card.ImageUris != null
                        ? card.ImageUris.Small != null
                            ? card.ImageUris.Small.ToString()
                            : card.ImageUris.Normal != null
                                ? card.ImageUris.Normal.ToString()
                                : card.ImageUris.Large != null
                                    ? card.ImageUris.Large.ToString()
                                    : card.ImageUris.Png != null
                                        ? card.ImageUris.Png.ToString()
                                        : "https://gamepedia.cursecdn.com/mtgsalvation_gamepedia/thumb/f/f8/Magic_card_back.jpg/250px-Magic_card_back.jpg?version=56c40a91c76ffdbe89867f0bc5172888"
                        : "https://gamepedia.cursecdn.com/mtgsalvation_gamepedia/thumb/f/f8/Magic_card_back.jpg/250px-Magic_card_back.jpg?version=56c40a91c76ffdbe89867f0bc5172888"); ;
            pic.Tag = cell;
            pic.LoadCompleted += Pic_LoadCompleted;
            return pic.Image as Bitmap;
        }

        private void Pic_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var cell = ((sender as PictureBox).Tag as DataGridViewImageCell);
            cell.Value = (sender as PictureBox).Image;
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
            LoadComboboxWithCatalog(cboEnchantmentTypes, ECatalogTypes.EnchantmentYypes);
            LoadComboboxWithCatalog(cboSpellTypes, ECatalogTypes.SpellTypes);
            LoadComboboxWithCatalog(cboPowers, ECatalogTypes.Powers);
            LoadComboboxWithCatalog(cboToughnesses, ECatalogTypes.Toughnesses);
            LoadComboboxWithCatalog(cboLoyalties, ECatalogTypes.Loyalties);
            LoadComboboxWithCatalog(cboWatermarks, ECatalogTypes.Watermarks);
            LoadComboboxWithCatalog(cboKeywordAbilities, ECatalogTypes.KeywordAbilities);
            LoadComboboxWithCatalog(cboKeywordActions, ECatalogTypes.KeywordActions);
            LoadComboboxWithCatalog(cboAbilityWords, ECatalogTypes.AbilityWords);
            LoadOrders();
            RefreshComboboxTypes();
        }

        private void LoadOrders()
        {
            foreach (var element in EOrderType.GetValues(typeof(EOrderType)))
            {
                cboOrder.Items.Add(element);
            }
            cboOrder.SelectedIndex = 0;
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
            grdCardData.Rows.Add("Games", String.Join(", ", card.Games));
            grdCardData.Rows.Add("Keywords", String.Join(", ", card.Keywords));
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

        private void RefreshComboboxTypes()
        {
            cboCreatureTypes.Enabled = radCreature.Checked;
            cboArtifactTypes.Enabled = radArtifact.Checked;
            cboLandTypes.Enabled = radLand.Checked;
            cboEnchantmentTypes.Enabled = radEnchantment.Checked;
            cboPlaneswalkerTypes.Enabled = radPlaneswalker.Checked;
            cboSpellTypes.Enabled = radSpell.Checked;
            cboCreatureTypes.SelectedItem = cboCreatureTypes.Enabled ? cboCreatureTypes.SelectedItem : null;
            cboArtifactTypes.SelectedItem = cboArtifactTypes.Enabled ? cboArtifactTypes.SelectedItem : null;
            cboLandTypes.SelectedItem = cboLandTypes.Enabled ? cboLandTypes.SelectedItem : null;
            cboEnchantmentTypes.SelectedItem = cboEnchantmentTypes.Enabled ? cboEnchantmentTypes.SelectedItem : null;
            cboPlaneswalkerTypes.SelectedItem = cboPlaneswalkerTypes.Enabled ? cboPlaneswalkerTypes.SelectedItem : null;
            cboSpellTypes.SelectedItem = cboSpellTypes.Enabled ? cboSpellTypes.SelectedItem = cboSpellTypes.Enabled : null;
        }

        private void ShowDataCard()
        {
            grdCardData.Rows.Clear();
            grdCardData.Refresh();
            var card = (grd.SelectedCells[0].Tag as Card);
            if (card == null)
                return;
            pic1.LoadAsync(@"" + card.ImageUris != null
                ? card.ImageUris.Normal
                : card.ImageUris.Normal != null
                    ? card.ImageUris.Normal
                    : "https://gamepedia.cursecdn.com/mtgsalvation_gamepedia/thumb/f/f8/Magic_card_back.jpg/250px-Magic_card_back.jpg?version=56c40a91c76ffdbe89867f0bc5172888");

            SetCardValues(card);
        }

        private void GetCardsWithParameters()
        {
            var are = "%3A";
            var and = "+";
            var order = "order=" + cboOrder.SelectedItem + "&";
            var searchText = (txtSearch.Text.Equals(String.Empty) ? String.Empty : txtSearch.Text + and);
            var type = GetCardType();
            var artist = cboArtistNames.SelectedItem == null ? String.Empty : GetArtist(cboArtistNames.SelectedItem.ToString()) + and;
            var oracle = cboKeywordAbilities.SelectedItem == null ? String.Empty : "oracle" + are + cboKeywordAbilities.SelectedItem + and;
            var colors = GetColor();
            var language = "lang" + are + "pt";
            var cardPack = new ApiService().GetCardsWithParameters(searchText, artist, type, order, oracle, colors, language);
            PopulateCards(cardPack);
        }

        private String GetArtist(String artist)
        {
            if (artist == null)
                return String.Empty;

            if (artist.Contains(" "))
                return "%28artist%3A" + artist.Replace(" ", "+artist%3A") + "%29";

            return artist;
        }

        private String GetColor()
        {
            var colors = String.Empty;
            colors += chkColorB.Checked ? "B" : String.Empty;
            colors += chkColorU.Checked ? "U" : String.Empty;
            colors += chkColorW.Checked ? "W" : String.Empty;
            colors += chkColorR.Checked ? "R" : String.Empty;
            colors += chkColorG.Checked ? "G" : String.Empty;
            return colors.Equals(String.Empty) ? String.Empty : "color%3D" + colors + "+";
        }

        private String GetCardType()
        {
            String type = String.Empty;
            type += cboCreatureTypes.Enabled ? cboCreatureTypes.SelectedItem : String.Empty;
            type += cboArtifactTypes.Enabled ? cboArtifactTypes.SelectedItem : String.Empty;
            type += cboPlaneswalkerTypes.Enabled ? cboPlaneswalkerTypes.SelectedItem : String.Empty;
            type += cboSpellTypes.Enabled ? cboSpellTypes.SelectedItem : String.Empty;
            type += cboEnchantmentTypes.Enabled ? cboEnchantmentTypes.SelectedItem : String.Empty;
            type += cboLandTypes.Enabled ? cboLandTypes.SelectedItem : String.Empty;
            return type.Equals(String.Empty) ? String.Empty : "type%3A" + type + "+";
        }
        #endregion

        private void picAddCard_Click(object sender, EventArgs e)
        {
            var card = (grd.SelectedCells[0].Tag as Card);
            if (card == null)
                return;

            AddCardToDeck(card);
        }

        private void AddCardToDeck(Card card)
        {
            var frm = new FormListDeck();
            frm.Show();
        }
    }
}
