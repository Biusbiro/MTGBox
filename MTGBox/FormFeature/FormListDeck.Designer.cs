namespace MTGBox.FormFeature
{
    partial class FormListDeck
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splListDeck = new System.Windows.Forms.SplitContainer();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splListDeckContent = new System.Windows.Forms.SplitContainer();
            this.picAddDeck = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splListDeck)).BeginInit();
            this.splListDeck.Panel1.SuspendLayout();
            this.splListDeck.Panel2.SuspendLayout();
            this.splListDeck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splListDeckContent)).BeginInit();
            this.splListDeckContent.Panel1.SuspendLayout();
            this.splListDeckContent.Panel2.SuspendLayout();
            this.splListDeckContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAddDeck)).BeginInit();
            this.SuspendLayout();
            // 
            // splListDeck
            // 
            this.splListDeck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splListDeck.Location = new System.Drawing.Point(0, 0);
            this.splListDeck.Name = "splListDeck";
            this.splListDeck.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splListDeck.Panel1
            // 
            this.splListDeck.Panel1.Controls.Add(this.splListDeckContent);
            // 
            // splListDeck.Panel2
            // 
            this.splListDeck.Panel2.Controls.Add(this.btnCancel);
            this.splListDeck.Panel2.Controls.Add(this.btnSelect);
            this.splListDeck.Size = new System.Drawing.Size(800, 450);
            this.splListDeck.SplitterDistance = 402;
            this.splListDeck.TabIndex = 0;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(628, 9);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Selecionar";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(709, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 362);
            this.dataGridView1.TabIndex = 0;
            // 
            // splListDeckContent
            // 
            this.splListDeckContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splListDeckContent.Location = new System.Drawing.Point(0, 0);
            this.splListDeckContent.Name = "splListDeckContent";
            this.splListDeckContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splListDeckContent.Panel1
            // 
            this.splListDeckContent.Panel1.Controls.Add(this.picAddDeck);
            // 
            // splListDeckContent.Panel2
            // 
            this.splListDeckContent.Panel2.Controls.Add(this.dataGridView1);
            this.splListDeckContent.Size = new System.Drawing.Size(800, 402);
            this.splListDeckContent.SplitterDistance = 36;
            this.splListDeckContent.TabIndex = 1;
            // 
            // picAddDeck
            // 
            this.picAddDeck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picAddDeck.Image = global::MTGBox.Properties.Resources.add_20_20;
            this.picAddDeck.Location = new System.Drawing.Point(8, 8);
            this.picAddDeck.Name = "picAddDeck";
            this.picAddDeck.Size = new System.Drawing.Size(20, 20);
            this.picAddDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAddDeck.TabIndex = 69;
            this.picAddDeck.TabStop = false;
            this.picAddDeck.Click += new System.EventHandler(this.picAddDeck_Click);
            // 
            // FormListDeck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splListDeck);
            this.Name = "FormListDeck";
            this.Text = "FormListDeck";
            this.splListDeck.Panel1.ResumeLayout(false);
            this.splListDeck.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splListDeck)).EndInit();
            this.splListDeck.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splListDeckContent.Panel1.ResumeLayout(false);
            this.splListDeckContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splListDeckContent)).EndInit();
            this.splListDeckContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAddDeck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splListDeck;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splListDeckContent;
        private System.Windows.Forms.PictureBox picAddDeck;
    }
}