namespace PoeTradeHelper
{
    partial class Form1
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
            this.buyingLabel = new System.Windows.Forms.Label();
            this.sellingLabel = new System.Windows.Forms.Label();
            this.sellStackLabel = new System.Windows.Forms.Label();
            this.buyStackLabel = new System.Windows.Forms.Label();
            this.BuyPictureBox = new System.Windows.Forms.PictureBox();
            this.SellPictureBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.resetButton = new System.Windows.Forms.Button();
            this.ratioLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tagBox = new System.Windows.Forms.TextBox();
            this.delete_from_list = new System.Windows.Forms.Button();
            this.save_to_list = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveCSV = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Orb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chaos_orb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ratio1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ratio2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warningLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.searchSellTextBox = new System.Windows.Forms.TextBox();
            this.sellCurrencyComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.searchBuyTextBox = new System.Windows.Forms.TextBox();
            this.buyCurrencyComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sellAmountTextBox = new System.Windows.Forms.TextBox();
            this.buyAmountTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BuyPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SellPictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buyingLabel);
            this.panel1.Controls.Add(this.sellingLabel);
            this.panel1.Controls.Add(this.sellStackLabel);
            this.panel1.Controls.Add(this.buyStackLabel);
            this.panel1.Controls.Add(this.BuyPictureBox);
            this.panel1.Controls.Add(this.SellPictureBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 581);
            this.panel1.TabIndex = 96;
            // 
            // buyingLabel
            // 
            this.buyingLabel.AutoSize = true;
            this.buyingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buyingLabel.Location = new System.Drawing.Point(35, 0);
            this.buyingLabel.Name = "buyingLabel";
            this.buyingLabel.Size = new System.Drawing.Size(47, 15);
            this.buyingLabel.TabIndex = 111;
            this.buyingLabel.Text = "Buying:";
            // 
            // sellingLabel
            // 
            this.sellingLabel.AutoSize = true;
            this.sellingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sellingLabel.Location = new System.Drawing.Point(35, 296);
            this.sellingLabel.Name = "sellingLabel";
            this.sellingLabel.Size = new System.Drawing.Size(48, 15);
            this.sellingLabel.TabIndex = 113;
            this.sellingLabel.Text = "Selling:";
            // 
            // sellStackLabel
            // 
            this.sellStackLabel.AutoSize = true;
            this.sellStackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sellStackLabel.Location = new System.Drawing.Point(425, 296);
            this.sellStackLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sellStackLabel.Name = "sellStackLabel";
            this.sellStackLabel.Size = new System.Drawing.Size(26, 15);
            this.sellStackLabel.TabIndex = 110;
            this.sellStackLabel.Text = "N/A";
            // 
            // buyStackLabel
            // 
            this.buyStackLabel.AutoSize = true;
            this.buyStackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buyStackLabel.Location = new System.Drawing.Point(425, 0);
            this.buyStackLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.buyStackLabel.Name = "buyStackLabel";
            this.buyStackLabel.Size = new System.Drawing.Size(26, 15);
            this.buyStackLabel.TabIndex = 99;
            this.buyStackLabel.Text = "N/A";
            // 
            // BuyPictureBox
            // 
            this.BuyPictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.BuyPictureBox.Image = global::PoeTradeHelper.Properties.Resources.tr;
            this.BuyPictureBox.InitialImage = global::PoeTradeHelper.Properties.Resources.tr;
            this.BuyPictureBox.Location = new System.Drawing.Point(0, 0);
            this.BuyPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.BuyPictureBox.Name = "BuyPictureBox";
            this.BuyPictureBox.Size = new System.Drawing.Size(659, 290);
            this.BuyPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.BuyPictureBox.TabIndex = 97;
            this.BuyPictureBox.TabStop = false;
            this.BuyPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.BuyPictureBox_Paint);
            // 
            // SellPictureBox
            // 
            this.SellPictureBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SellPictureBox.Image = global::PoeTradeHelper.Properties.Resources.tr;
            this.SellPictureBox.Location = new System.Drawing.Point(0, 291);
            this.SellPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.SellPictureBox.Name = "SellPictureBox";
            this.SellPictureBox.Size = new System.Drawing.Size(659, 290);
            this.SellPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.SellPictureBox.TabIndex = 96;
            this.SellPictureBox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.resetButton);
            this.panel2.Controls.Add(this.ratioLabel);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.warningLabel);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.searchSellTextBox);
            this.panel2.Controls.Add(this.sellCurrencyComboBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.searchBuyTextBox);
            this.panel2.Controls.Add(this.buyCurrencyComboBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.sellAmountTextBox);
            this.panel2.Controls.Add(this.buyAmountTextBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(666, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(490, 581);
            this.panel2.TabIndex = 99;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(352, 51);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 136;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // ratioLabel
            // 
            this.ratioLabel.AutoSize = true;
            this.ratioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ratioLabel.Location = new System.Drawing.Point(11, 212);
            this.ratioLabel.Name = "ratioLabel";
            this.ratioLabel.Size = new System.Drawing.Size(30, 16);
            this.ratioLabel.TabIndex = 135;
            this.ratioLabel.Text = "N/A";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tagBox);
            this.groupBox2.Controls.Add(this.delete_from_list);
            this.groupBox2.Controls.Add(this.save_to_list);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 249);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(490, 159);
            this.groupBox2.TabIndex = 134;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Saved Trades:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 135;
            this.label1.Text = "Tag:";
            // 
            // tagBox
            // 
            this.tagBox.Location = new System.Drawing.Point(40, 133);
            this.tagBox.Name = "tagBox";
            this.tagBox.Size = new System.Drawing.Size(98, 20);
            this.tagBox.TabIndex = 134;
            // 
            // delete_from_list
            // 
            this.delete_from_list.Location = new System.Drawing.Point(276, 133);
            this.delete_from_list.Margin = new System.Windows.Forms.Padding(2);
            this.delete_from_list.Name = "delete_from_list";
            this.delete_from_list.Size = new System.Drawing.Size(129, 21);
            this.delete_from_list.TabIndex = 133;
            this.delete_from_list.Text = "Delete trade";
            this.delete_from_list.UseVisualStyleBackColor = true;
            this.delete_from_list.Click += new System.EventHandler(this.Delete_from_list_Click);
            // 
            // save_to_list
            // 
            this.save_to_list.Location = new System.Drawing.Point(143, 133);
            this.save_to_list.Margin = new System.Windows.Forms.Padding(2);
            this.save_to_list.Name = "save_to_list";
            this.save_to_list.Size = new System.Drawing.Size(129, 21);
            this.save_to_list.TabIndex = 132;
            this.save_to_list.Text = "Save trade";
            this.save_to_list.UseVisualStyleBackColor = true;
            this.save_to_list.Click += new System.EventHandler(this.Save_to_list_Click);
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 16);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(484, 108);
            this.listBox1.TabIndex = 131;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaveCSV);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 408);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 173);
            this.groupBox1.TabIndex = 133;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Standarts:";
            // 
            // btnSaveCSV
            // 
            this.btnSaveCSV.Location = new System.Drawing.Point(12, 143);
            this.btnSaveCSV.Name = "btnSaveCSV";
            this.btnSaveCSV.Size = new System.Drawing.Size(466, 24);
            this.btnSaveCSV.TabIndex = 125;
            this.btnSaveCSV.Text = "Save grid";
            this.btnSaveCSV.UseVisualStyleBackColor = true;
            this.btnSaveCSV.Click += new System.EventHandler(this.BtnSaveCSV_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Orb,
            this.Amount,
            this.Chaos_orb,
            this.Ratio1,
            this.Ratio2});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(484, 121);
            this.dataGridView1.TabIndex = 124;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellEndEdit);
            // 
            // Orb
            // 
            this.Orb.FillWeight = 40F;
            this.Orb.HeaderText = "Orb";
            this.Orb.MinimumWidth = 4;
            this.Orb.Name = "Orb";
            // 
            // Amount
            // 
            this.Amount.FillWeight = 20F;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // Chaos_orb
            // 
            this.Chaos_orb.FillWeight = 20F;
            this.Chaos_orb.HeaderText = "Chaos_orb";
            this.Chaos_orb.Name = "Chaos_orb";
            // 
            // Ratio1
            // 
            this.Ratio1.FillWeight = 10F;
            this.Ratio1.HeaderText = "Ratio1";
            this.Ratio1.Name = "Ratio1";
            this.Ratio1.ReadOnly = true;
            // 
            // Ratio2
            // 
            this.Ratio2.FillWeight = 10F;
            this.Ratio2.HeaderText = "Ratio2";
            this.Ratio2.Name = "Ratio2";
            this.Ratio2.ReadOnly = true;
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warningLabel.Location = new System.Drawing.Point(11, 136);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(42, 24);
            this.warningLabel.TabIndex = 125;
            this.warningLabel.Text = "N/A";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(228, 56);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 122;
            this.label5.Text = "Search orbs:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(228, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 121;
            this.label4.Text = "Search orbs:";
            // 
            // searchSellTextBox
            // 
            this.searchSellTextBox.Location = new System.Drawing.Point(231, 70);
            this.searchSellTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.searchSellTextBox.Name = "searchSellTextBox";
            this.searchSellTextBox.Size = new System.Drawing.Size(116, 20);
            this.searchSellTextBox.TabIndex = 109;
            this.searchSellTextBox.TextChanged += new System.EventHandler(this.SearchOrbs);
            // 
            // sellCurrencyComboBox
            // 
            this.sellCurrencyComboBox.AllowDrop = true;
            this.sellCurrencyComboBox.FormattingEnabled = true;
            this.sellCurrencyComboBox.IntegralHeight = false;
            this.sellCurrencyComboBox.Location = new System.Drawing.Point(100, 70);
            this.sellCurrencyComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.sellCurrencyComboBox.MaxDropDownItems = 10;
            this.sellCurrencyComboBox.Name = "sellCurrencyComboBox";
            this.sellCurrencyComboBox.Size = new System.Drawing.Size(127, 21);
            this.sellCurrencyComboBox.TabIndex = 108;
            this.sellCurrencyComboBox.SelectedIndexChanged += new System.EventHandler(this.InputChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 107;
            this.label3.Text = "Selling amount:";
            // 
            // searchBuyTextBox
            // 
            this.searchBuyTextBox.Location = new System.Drawing.Point(231, 33);
            this.searchBuyTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.searchBuyTextBox.Name = "searchBuyTextBox";
            this.searchBuyTextBox.Size = new System.Drawing.Size(116, 20);
            this.searchBuyTextBox.TabIndex = 104;
            this.searchBuyTextBox.TextChanged += new System.EventHandler(this.SearchOrbs);
            // 
            // buyCurrencyComboBox
            // 
            this.buyCurrencyComboBox.AllowDrop = true;
            this.buyCurrencyComboBox.FormattingEnabled = true;
            this.buyCurrencyComboBox.IntegralHeight = false;
            this.buyCurrencyComboBox.Items.AddRange(new object[] {
            "[20]Orb of Alteration",
            "[20]Orb of Fusing",
            "[10]Orb of Alchemy",
            "[10]Chaos Orb",
            "[20]Gemcutters Prism",
            "[10]Exalted Orb",
            "[20]Chromatic Orb",
            "[20]Jewellers Orb",
            "[20]Orb of Chance",
            "[20]Cartographers Chisel",
            "[30]Orb of Scouring",
            "[20]Blessed Orb",
            "[40]Orb of Regret",
            "[10]Regal Orb",
            "[10]Divine Orb",
            "[10]Vaal Orb",
            "[40]Scroll of Wisdom",
            "[40]Portal Scroll",
            "[40]Armourers Scrap",
            "[20]Blacksmiths Whetstone",
            "[20]Glassblowers Bauble",
            "[40]Orb of Transmutation",
            "[30]Orb of Augmentation",
            "[10]Mirror of Kalandra",
            "[10]Eternal Orb",
            "[1000]Perandus Coin",
            "[30]Silver Coin",
            "[1]Sacrifice at Dusk",
            "[1]Sacrifice at Midnight",
            "[1]Sacrifice at Dawn",
            "[1]Sacrifice at Noon",
            "[1]Mortal Grief",
            "[1]Mortal Rage",
            "[1]Mortal Hope",
            "[1]Mortal Ignorance",
            "[1]Ebers Key",
            "[1]Yriels Key",
            "[1]Inyas Key",
            "[1]Volkuurs Key",
            "[1]Offering to the Goddess",
            "[1]Fragment of the Hydra",
            "[1]Fragment of the Phoenix",
            "[1]Fragment of the Minotaur",
            "[1]Fragment of the Chimera"});
            this.buyCurrencyComboBox.Location = new System.Drawing.Point(100, 33);
            this.buyCurrencyComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.buyCurrencyComboBox.MaxDropDownItems = 10;
            this.buyCurrencyComboBox.Name = "buyCurrencyComboBox";
            this.buyCurrencyComboBox.Size = new System.Drawing.Size(127, 21);
            this.buyCurrencyComboBox.TabIndex = 103;
            this.buyCurrencyComboBox.SelectedIndexChanged += new System.EventHandler(this.InputChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 102;
            this.label2.Text = "Buying amount:";
            // 
            // sellAmountTextBox
            // 
            this.sellAmountTextBox.Location = new System.Drawing.Point(21, 71);
            this.sellAmountTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.sellAmountTextBox.Name = "sellAmountTextBox";
            this.sellAmountTextBox.Size = new System.Drawing.Size(75, 20);
            this.sellAmountTextBox.TabIndex = 101;
            this.sellAmountTextBox.TextChanged += new System.EventHandler(this.InputChanged);
            // 
            // buyAmountTextBox
            // 
            this.buyAmountTextBox.Location = new System.Drawing.Point(21, 33);
            this.buyAmountTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.buyAmountTextBox.Name = "buyAmountTextBox";
            this.buyAmountTextBox.Size = new System.Drawing.Size(75, 20);
            this.buyAmountTextBox.TabIndex = 100;
            this.buyAmountTextBox.TextChanged += new System.EventHandler(this.InputChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 581);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "PoeTradeHelper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BuyPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SellPictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox BuyPictureBox;
        private System.Windows.Forms.PictureBox SellPictureBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label sellStackLabel;
        private System.Windows.Forms.TextBox searchSellTextBox;
        private System.Windows.Forms.ComboBox sellCurrencyComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox searchBuyTextBox;
        private System.Windows.Forms.ComboBox buyCurrencyComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sellAmountTextBox;
        private System.Windows.Forms.TextBox buyAmountTextBox;
        private System.Windows.Forms.Label buyStackLabel;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Label buyingLabel;
        private System.Windows.Forms.Label sellingLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tagBox;
        private System.Windows.Forms.Button delete_from_list;
        private System.Windows.Forms.Button save_to_list;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveCSV;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Orb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chaos_orb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ratio1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ratio2;
        private System.Windows.Forms.Label ratioLabel;
        private System.Windows.Forms.Button resetButton;
    }
}

