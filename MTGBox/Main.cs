using MTGBox.Enum;
using MTGBox.FormFeature;
using MTGBox.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTGBox
{
    public partial class Main : Form
    {
        private Int32 ChildFormNumber = 0;
        public static Dictionary<ECatalogTypes, Catalog> Catalogs { get; set; }
        public Main()
        {
            InitializeComponent();
            Catalogs = new Dictionary<ECatalogTypes, Catalog>();
            LoadCatalogs();
            ShowFormSearch();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Janela " + ChildFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void ShowFormSearch()
        {
            FormCardList frm = new FormCardList();
            frm.MdiParent = this;
            frm.MaximizeBox = true;
            frm.FormBorderStyle = FormBorderStyle.Sizable;
            frm.WindowState = FormWindowState.Maximized;
            frm.ControlBox = false;
            frm.Show();
        }

        private void CloseAllChildForms()
        {

        }

        private void picFormSearch_Click(object sender, EventArgs e)
        {
            ShowFormSearch();
        }

        private Catalog GetCatalogDataFromAPI(ECatalogTypes type)
        {
            try
            {
                var catalog = new Catalog();
                var requisicaoWeb = WebRequest.CreateHttp("https://api.scryfall.com/catalog/" + new EnumReturns().ToString(type));
                requisicaoWeb.Method = "GET";
                requisicaoWeb.UserAgent = "RequisicaoWebDemo";
                using (var resposta = requisicaoWeb.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);
                    object objResponse = reader.ReadToEnd();
                    catalog = JsonConvert.DeserializeObject<Catalog>(objResponse.ToString());
                    streamDados.Close();
                    resposta.Close();
                }
                return catalog;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong request ! " + ex.Message, "Error");
                return new Catalog();
            }
        }

        public void LoadCatalogs()
        {
            Catalogs.Add(ECatalogTypes.CardNames, GetCatalogDataFromAPI(ECatalogTypes.CardNames));
            Catalogs.Add(ECatalogTypes.ArtistNames, GetCatalogDataFromAPI(ECatalogTypes.ArtistNames));
            Catalogs.Add(ECatalogTypes.WordBank, GetCatalogDataFromAPI(ECatalogTypes.WordBank));
            Catalogs.Add(ECatalogTypes.CreatureTypes, GetCatalogDataFromAPI(ECatalogTypes.CreatureTypes));
            Catalogs.Add(ECatalogTypes.PlaneswalkerTypes, GetCatalogDataFromAPI(ECatalogTypes.PlaneswalkerTypes));
            Catalogs.Add(ECatalogTypes.LandTypes, GetCatalogDataFromAPI(ECatalogTypes.LandTypes));
            Catalogs.Add(ECatalogTypes.ArtifactTypes, GetCatalogDataFromAPI(ECatalogTypes.ArtifactTypes));
            Catalogs.Add(ECatalogTypes.EnchantmentYypes, GetCatalogDataFromAPI(ECatalogTypes.EnchantmentYypes));
            Catalogs.Add(ECatalogTypes.SpellTypes, GetCatalogDataFromAPI(ECatalogTypes.SpellTypes));
            Catalogs.Add(ECatalogTypes.Powers, GetCatalogDataFromAPI(ECatalogTypes.Powers));
            Catalogs.Add(ECatalogTypes.Toughnesses, GetCatalogDataFromAPI(ECatalogTypes.Toughnesses));
            Catalogs.Add(ECatalogTypes.Loyalties, GetCatalogDataFromAPI(ECatalogTypes.Loyalties));
            Catalogs.Add(ECatalogTypes.Watermarks, GetCatalogDataFromAPI(ECatalogTypes.Watermarks));
            Catalogs.Add(ECatalogTypes.KeywordAbilities, GetCatalogDataFromAPI(ECatalogTypes.KeywordAbilities));
            Catalogs.Add(ECatalogTypes.KeywordActions, GetCatalogDataFromAPI(ECatalogTypes.KeywordActions));
            Catalogs.Add(ECatalogTypes.AbilityWords, GetCatalogDataFromAPI(ECatalogTypes.AbilityWords));
        }
    }
}
