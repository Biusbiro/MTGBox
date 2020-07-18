using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MTGBox
{
    public partial class FormCardList : Form
    {
        List<Card> Cards { get; set; }
        List<String> AllcardTypes = new List<String>();
        List<String> AllcardSuperTypes = new List<String>();
        List<String> AllcardSubTypes = new List<String>();
        List<Set> AllSets = new List<Set>();


        public FormCardList()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
