﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTGBox.FormFeature
{
    public partial class FormListDeck : Form
    {
        public FormListDeck()
        {
            InitializeComponent();
        }

        private void picAddDeck_Click(object sender, EventArgs e)
        {
            var frm = new FormDataDeck();
            frm.Show();
        }
    }
}
