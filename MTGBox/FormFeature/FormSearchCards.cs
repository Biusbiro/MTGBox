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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadCardByName();
        }

        private void LoadCardByName()
        {
            try
            {
                var name = txtSearch.Text;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.scryfall.com/cards/named?fuzzy=" + name);
                request.ContentType = "application/json; charset=utf-8";
                request.Accept = "application/json";
                request.Method = WebRequestMethods.Http.Get;

                WebResponse response = request.GetResponse();

                StreamReader sr = new StreamReader(response.GetResponseStream());

                String json_text = sr.ReadToEnd();
                dynamic stuff = JsonConvert.DeserializeObject(json_text);
                if (stuff.error != null)
                {
                    MessageBox.Show("problem with getting data", "Error");
                }
                else
                {
                    dynamic data = JObject.Parse(json_text);
                }
                sr.Close();


            }
            catch (Exception ex)

            {
                MessageBox.Show("Wrong request ! " + ex.Message, "Error");
            }
        }

        public void SetImageIntoPicBox(String url)
        {
            var request = WebRequest.Create(url);
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                pic1.Image = Bitmap.FromStream(stream);
            }
        }
    }
}
