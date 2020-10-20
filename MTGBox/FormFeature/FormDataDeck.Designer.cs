namespace MTGBox.FormFeature
{
    partial class FormDataDeck
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCardNames = new System.Windows.Forms.Label();
            this.pnlCardNames = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlCardNames.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.pnlCardNames);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // lblCardNames
            // 
            this.lblCardNames.AutoSize = true;
            this.lblCardNames.Font = new System.Drawing.Font("Franklin Gothic Book", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardNames.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblCardNames.Location = new System.Drawing.Point(1, 3);
            this.lblCardNames.Name = "lblCardNames";
            this.lblCardNames.Size = new System.Drawing.Size(81, 14);
            this.lblCardNames.TabIndex = 2;
            this.lblCardNames.Text = "Nome do Deck";
            // 
            // pnlCardNames
            // 
            this.pnlCardNames.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlCardNames.Controls.Add(this.lblCardNames);
            this.pnlCardNames.Location = new System.Drawing.Point(12, 12);
            this.pnlCardNames.Name = "pnlCardNames";
            this.pnlCardNames.Size = new System.Drawing.Size(466, 21);
            this.pnlCardNames.TabIndex = 33;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(466, 20);
            this.textBox1.TabIndex = 31;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(466, 21);
            this.panel2.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Book", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(1, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Descrição do Deck";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 87);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(466, 311);
            this.textBox2.TabIndex = 34;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.Location = new System.Drawing.Point(502, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(286, 331);
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(502, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(286, 21);
            this.panel3.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Book", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(1, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Escolher Imagem";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(502, 32);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(286, 20);
            this.textBox3.TabIndex = 37;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(713, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 39;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(632, 415);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 40;
            this.btnOk.Text = "Gravar";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // FormDataDeck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "FormDataDeck";
            this.Text = "FormDataDeck";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlCardNames.ResumeLayout(false);
            this.pnlCardNames.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel pnlCardNames;
        private System.Windows.Forms.Label lblCardNames;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
    }
}