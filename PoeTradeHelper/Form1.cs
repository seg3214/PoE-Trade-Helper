using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace PoeTradeHelper
{
    public partial class Form1 : Form
    {
        private readonly bool Debugbox_enable = false;
        private const string col_orbName = "Orb";
        private const string col_orbAmount = "Amount";
        private const string col_chaosAmount = "Chaos_orb";
        private const string col_orbRatio = "Ratio1";
        private const string col_chaosRatio = "Ratio2";

        private TradeStruct trade;
        private Debug debugBoxes;
        private string rootdir, datadir, assetdir;
        private int lastIndex = -1;
        private int loading_trade = 0;

        public Form1()
        {
            InitializeComponent();
            int x1 = 550;
            int x2 = 500;
            SetupTransparentLabel(buyStackLabel, BuyPictureBox, new Point(x1, 0));
            SetupTransparentLabel(sellStackLabel, SellPictureBox, new Point(x1, 0));
            SetupTransparentLabel(buyingLabel, BuyPictureBox, new Point(x2, 0));
            SetupTransparentLabel(sellingLabel, SellPictureBox, new Point(x2, 0));

        }
        private void SetupTransparentLabel(Label lb, PictureBox pb, Point loc)
        {
            lb.Parent = pb;
            lb.BackColor = Color.Transparent;
            lb.ForeColor = Color.White;
            lb.Font = new Font(lb.Font, FontStyle.Bold);
            lb.Location = loc;
        }
        private void Reset()
        {
            warningLabel.Text = "";
            ratioLabel.Text = "";
            sellStackLabel.Text = "";
            buyStackLabel.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //loading gridview1 and making some global variables

            bool isVs = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("VisualStudioEdition"));
            DirectoryInfo directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            rootdir = directory.ToString();

            if (isVs)
            {
                datadir = Path.GetFullPath(Path.Combine(rootdir, @"..\..\data"));
                assetdir = Path.GetFullPath(Path.Combine(rootdir, @"..\..\assets"));
                Directory.CreateDirectory(datadir);

                string source = datadir;
                string destination = Path.Combine(rootdir, @"data");

                Helpers.CopyDirectory(source, destination, true);
            }
            else
            {
                datadir = Path.GetFullPath(Path.Combine(rootdir, @"data"));
                assetdir = Path.GetFullPath(Path.Combine(rootdir, @"assets"));
                Directory.CreateDirectory(datadir);
            }

            Reset();

            BtnLoadCSV_Click();
            dataGridView1.Columns[col_orbName].FillWeight = 40;
            dataGridView1.Columns[col_orbAmount].FillWeight = 20;
            dataGridView1.Columns[col_chaosAmount].FillWeight = 20;
            dataGridView1.Columns[col_orbRatio].FillWeight = 10;
            dataGridView1.Columns[col_chaosRatio].FillWeight = 10;

            dataGridView1.Columns[col_orbRatio].ReadOnly = true;
            dataGridView1.Columns[col_chaosRatio].ReadOnly = true;
            dataGridView1.Columns[col_orbRatio].DefaultCellStyle.BackColor = Color.Gainsboro;
            dataGridView1.Columns[col_chaosRatio].DefaultCellStyle.BackColor = Color.Gainsboro;
            //////////////
            Currencies.Initialize(assetdir);

            buyCurrencyComboBox.Items.Clear();
            sellCurrencyComboBox.Items.Clear();

            foreach (Currencies.Curr c in Currencies.CurrencyList)
            {
                buyCurrencyComboBox.Items.Add(c.Name);
                sellCurrencyComboBox.Items.Add(c.Name);
            }

            string bckgrImage = Path.GetFullPath(Path.Combine(assetdir, @"images\tr.png"));
            SellPictureBox.Image = Image.FromFile(bckgrImage);
            BuyPictureBox.Image = Image.FromFile(bckgrImage);

            SavedTrades.Initialize(listBox1, datadir);
            SavedTrades.LoadFromAFile();

            trade.SellCurr.area.lb_info = sellStackLabel;
            trade.BuyCurr.area.lb_info = buyStackLabel;
#if DEBUG
            if (Debugbox_enable)
            {
                debugBoxes.maxboxes = PBoxArea.MAX_gridCells;
                debugBoxes.dboxes = new Debugbox[PBoxArea.MAX_gridCells];
            }
#endif
        }

        private void SearchOrbs(object sender, EventArgs e)
        {
            string s = default;
            ComboBox cb = default;
            if (sender == searchBuyTextBox)
            {
                s = searchBuyTextBox.Text;
                cb = buyCurrencyComboBox;
            }
            else if (sender == searchSellTextBox)
            {
                s = searchSellTextBox.Text;
                cb = sellCurrencyComboBox;
            }
            if (string.IsNullOrEmpty(s))
                return;

            for (int i = 0; i < cb.Items.Count; i++)
            {
                if (cb.Items[i].ToString().ToLower().Contains(s))
                {
                    cb.SelectedItem = cb.Items[i];
                    break;
                }
            }
        }
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem == null)
            {
                return;
            }
            if (listBox1.SelectedIndex == lastIndex)
            {
                return;
            }
            lastIndex = listBox1.SelectedIndex;

            loading_trade = 1;
            if (SavedTrades.GetTrade(listBox1.SelectedIndex, out SavedTrades.Trade t))
            {
                int index = buyCurrencyComboBox.FindString(t.BuyCurrency);
                if (index != -1)
                {
                    buyCurrencyComboBox.SelectedIndex = index;
                    buyAmountTextBox.Text = t.BuyCurrencyAmount.ToString();
                }
                else
                {
                    buyAmountTextBox.Text = "ERROR: cant find currency";
                }

                index = sellCurrencyComboBox.FindString(t.SellCurrency);
                if (index != -1)
                {
                    sellCurrencyComboBox.SelectedIndex = index;
                    sellAmountTextBox.Text = t.SellCurrencyAmount.ToString();
                }
                else
                {
                    sellAmountTextBox.Text = "ERROR: cant find currency";
                }

                tagBox.Text = t.tag;
            }
            ;
            loading_trade = 0;
        }
        private bool IsValidForCalc()
        {
            if (!IsValidForUpdate(ref trade.SellCurr) || !IsValidForUpdate(ref trade.BuyCurr))
            {
                return false;
            }

            if (!trade.SellCurr.chaos_standart.exists || !trade.BuyCurr.chaos_standart.exists)
            {
                return false;
            }

            return true;
        }
        private bool IsValidForUpdate(ref Currency c)
        {
            //if has something means it has been updated once
            if (string.IsNullOrEmpty(c.Name))
                return false;

            if (c.TradeAmount == 0)
                return false;
            return true;
        }
        private void ClearPboxArea(ref Currency c, ref PictureBox pbox)
        {
            if (!c.area.initialized)
            {
                InitPBoxArea(ref c, ref pbox);
            }

            c.area.lb_info.Text = "";
            int counter_gridCells = 0;
            for (int gridRow = 0; gridRow < PBoxArea.MAX_gridRow; gridRow++)
            {
                for (int gridCol = 0; gridCol < PBoxArea.MAX_gridCol; gridCol++)
                {
                    PictureBox pb = c.area.pbox_pboxes[counter_gridCells];
                    pb.Visible = false;

                    Label l = c.area.pbox_labels[counter_gridCells];
                    l.Visible = false;

                    counter_gridCells++;
                }
            }
        }
        private void UpdatePBoxArea(ref Currency c, ref PictureBox pbox)
        {
            if (!IsValidForUpdate(ref c))
            {
                return;
            }

            int full_stacks = c.TradeAmount / c.area.StackSize;
            int remainder = c.TradeAmount % c.area.StackSize;

            int remainder_stack = 0;
            if (remainder != 0)
                remainder_stack = 1;

            int stacks = full_stacks + remainder_stack;
            int maxcells = PBoxArea.MAX_gridCells;

            if (stacks > maxcells)
            {
                return;
            }

            //////
            if (!c.area.initialized)
            {
                InitPBoxArea(ref c, ref pbox);
            }

            ClearPboxArea(ref c, ref pbox);

            c.area.lb_info.Text = $"{full_stacks} stacks and {remainder}";

            for (int i = 0; i < stacks; i++)
            {
                Label l = c.area.pbox_labels[i];
                l.Visible = true;

                //go through stacks
                if (i < full_stacks)
                {
                    l.Text = $"{c.area.StackSize}";
                }
                //add the remainder
                else
                {
                    l.Text = $"{remainder}";
                }

                PictureBox pb = c.area.pbox_pboxes[i];
                pb.Visible = true;
                pb.Image = c.area.Image;

            }
        }
        private void InitPBoxArea(ref Currency c, ref PictureBox pbox)
        {
            c.area.pbox = pbox;
            c.area.pbox_labels = new Label[PBoxArea.MAX_gridCells];
            c.area.pbox_pboxes = new PictureBox[PBoxArea.MAX_gridCells];


            int counter_gridCells = 0;

            for (int gridRow = 0; gridRow < PBoxArea.MAX_gridRow; gridRow++)
            {
                int gridX = gridRow * PBoxArea.gridCellWidth + PBoxArea.gridOffsetX;
                for (int gridCol = 0; gridCol < PBoxArea.MAX_gridCol; gridCol++)
                {
                    int gridY = gridCol * PBoxArea.gridCellHeight + PBoxArea.gridOffsetY;
#if DEBUG
                    if (Debugbox_enable)
                    {
                        debugBoxes.dboxes[counter_gridCells].color = Color.White;
                        debugBoxes.dboxes[counter_gridCells].start = new Point(gridX, gridY);
                        debugBoxes.dboxes[counter_gridCells].width = PBoxArea.gridCellWidth;
                        debugBoxes.dboxes[counter_gridCells].height = PBoxArea.gridCellHeight;
                    }
#endif
                    c.area.pbox_pboxes[counter_gridCells] = new PictureBox();
                    PictureBox pb = c.area.pbox_pboxes[counter_gridCells];

                    pb.Location = new Point(gridX, gridY);
                    pb.Size = new Size(52, 52);
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb.BackColor = Color.Transparent;
                    pb.Visible = false;


                    c.area.pbox_labels[counter_gridCells] = new Label();
                    Label l = c.area.pbox_labels[counter_gridCells];

                    l.Location = new Point(gridX, gridY);
                    l.AutoSize = true;
                    l.BackColor = Color.Transparent;
                    l.ForeColor = Color.White;
                    l.Font = new Font(l.Font, FontStyle.Bold);
                    l.Visible = false;

                    counter_gridCells++;
                }
            }

            c.area.pbox.Controls.AddRange(c.area.pbox_labels);
            c.area.pbox.Controls.AddRange(c.area.pbox_pboxes);

            c.area.initialized = true;
#if DEBUG
            if (Debugbox_enable)
            {
                debugBoxes.shouldDrawBox = true;
                BuyPictureBox.Invalidate();
            }
#endif
        }
        private void BuyPictureBox_Paint(object sender, PaintEventArgs e)
        {
#if DEBUG
            if (Debugbox_enable)
            {
                if (!debugBoxes.shouldDrawBox)
                    return;

                for (int i = 0; i < debugBoxes.maxboxes; i++)
                {
                    Debugbox db = debugBoxes.dboxes[i];
                    using (SolidBrush brush = new SolidBrush(db.color))
                    {
                        Rectangle rect = new Rectangle(db.start.X, db.start.Y, db.width, db.height);
                        e.Graphics.FillRectangle(brush, rect);
                        using (Pen pen = new Pen(Color.Black, 1))
                        {
                            e.Graphics.DrawRectangle(pen, rect);
                        }
                    }
                }


                debugBoxes.shouldDrawBox = false;
            }
#endif
        }

        private void CalcRatios()
        {
            if (!IsValidForCalc())
            {
                return;
            }

            //standart ratio
            ref Ratio standart_Ratio = ref trade.calculated.standart_Ratio;
            CalcOrbToOrbRatio(trade.SellCurr.chaos_standart.orbAmount, trade.BuyCurr.chaos_standart.orbAmount, out standart_Ratio.ratio1, out standart_Ratio.ratio2);

            double standart_SellToBuy = (double)trade.calculated.standart_Ratio.ratio1 / trade.calculated.standart_Ratio.ratio2;
            double trade_SellToBuy = (double)trade.SellCurr.TradeAmount / trade.BuyCurr.TradeAmount;


            trade.calculated.paying_index = 1 * trade_SellToBuy / standart_SellToBuy;
            trade.calculated.sellAmountShouldBe = trade.SellCurr.TradeAmount / trade.calculated.paying_index;
            trade.calculated.sellAmountCorrection = trade.calculated.sellAmountShouldBe - trade.SellCurr.TradeAmount;


        }
        private void InputChanged(object sender, EventArgs e)
        {

            int Amount = 0;
            string name = default;
            Currency dummy = default;
            ref Currency c = ref dummy;
            PictureBox dummy1 = default;
            ref PictureBox pbox = ref dummy1;

            if (sender == sellCurrencyComboBox || sender == sellAmountTextBox)
            {
                c = ref trade.SellCurr;
                pbox = ref SellPictureBox;
            }
            else if (sender == buyCurrencyComboBox || sender == buyAmountTextBox)
            {
                c = ref trade.BuyCurr;
                pbox = ref BuyPictureBox;
            }

            bool exists = false;
            if (sender is ComboBox cb)
            {
                name = cb.Text;
                exists = Currencies.CurrencyList.Exists(x => x.Name == name);
                if (!exists)
                {
                    c.Name = default;
                }
                else
                {
                    CurrencyCBChanged(ref c, name);
                }
            }
            else if (sender is TextBox tb)
            {
                exists = (int.TryParse(tb.Text, out Amount) && Amount != 0);
                if (!exists)
                {
                    c.TradeAmount = 0;
                }
                else
                {
                    c.TradeAmount = Amount;
                }
            }

            if (!exists)
            {
                ClearPboxArea(ref c, ref pbox);
                return;
            }
            ////
            if (listBox1.SelectedIndex != -1 && loading_trade == 0)
            {
                UnselectListbox1();
            }

            CalcRatios();
            UpdatePBoxArea(ref c, ref pbox);
            MakeWarning();
        }

        private bool ParseGrid1Row(int row_index, out Grid1Row r)
        {
            r = default;
            r.orbName = dataGridView1.Rows[row_index].Cells[col_orbName].Value?.ToString();
            if (string.IsNullOrEmpty(r.orbName))
            {
                return false;
            }

            if (!int.TryParse(dataGridView1.Rows[row_index].Cells[col_orbAmount].Value?.ToString(), out r.orbAmount))
                return false;
            if (!int.TryParse(dataGridView1.Rows[row_index].Cells[col_chaosAmount].Value?.ToString(), out r.chaosAmount))
                return false;
            if (!int.TryParse(dataGridView1.Rows[row_index].Cells[col_orbRatio].Value?.ToString(), out r.orbToChaos_Ratio.ratio1))
                return false;
            if (!int.TryParse(dataGridView1.Rows[row_index].Cells[col_chaosRatio].Value?.ToString(), out r.orbToChaos_Ratio.ratio2))
                return false;


            r.exists = true;
            r.index = row_index;
            return true;
        }

        private void CalcOrbToOrbRatio(int orb1Amount, int orb2Amount, out int rat1, out int rat2)
        {
            Grid1Row r1 = trade.SellCurr.chaos_standart;
            Grid1Row r2 = trade.BuyCurr.chaos_standart;

            int lcm = Helpers.FindLCM_fromINTS(r1.chaosAmount, r2.chaosAmount);

            int m1 = lcm / r1.chaosAmount;
            int m2 = lcm / r2.chaosAmount;

            int o1 = m1 * orb1Amount;
            int o2 = m2 * orb2Amount;

            int gcf2 = Helpers.FindGCF_fromINTS(o1, o2);

            rat1 = o1 / gcf2;
            rat2 = o2 / gcf2;
        }

        private void MakeWarning()
        {
            string snf1 = default;
            string snf2 = default;
            if (!trade.SellCurr.chaos_standart.exists)
            {
                if (!string.IsNullOrEmpty(trade.SellCurr.Name))
                    snf1 = $"No standart for: {trade.SellCurr.Name}";
            }
            if (!trade.BuyCurr.chaos_standart.exists)
            {
                if (!string.IsNullOrEmpty(trade.BuyCurr.Name))
                    snf2 = $"No standart for: {trade.BuyCurr.Name}";
            }
            //if (!string.IsNullOrEmpty(snf))
            {
                warningLabel.ForeColor = Color.Red;
                warningLabel.Text = $"{snf1}" + Environment.NewLine +
                    $"{snf2}";
                ratioLabel.Text = default;
            }

            if (!IsValidForCalc())
            {
                return;
            }


            string s = "OK";
            warningLabel.Text = s;
            Color c = Color.Blue;
            string orbname = trade.SellCurr.Name;
            if (trade.calculated.paying_index < 1)
            {
                s = $"SAVING {trade.calculated.sellAmountCorrection:0.##} {orbname}";
                c = Color.Green;
            }
            else if (trade.calculated.paying_index > 1)
            {
                s = $"LOSING {trade.calculated.sellAmountCorrection:0.##} {orbname} " + Environment.NewLine +
                    $"(should be selling: {trade.calculated.sellAmountShouldBe:0.#})";
                c = Color.Red;
            }

            warningLabel.ForeColor = c;
            warningLabel.Text = $"{s}";
            ratioLabel.Text = $"Standart ratio {trade.calculated.standart_Ratio.ratio1}:{trade.calculated.standart_Ratio.ratio2}" +
                $" ({trade.SellCurr.Name}:{trade.BuyCurr.Name})";
        }

        private void CurrencyCBChanged(ref Currency c, string name)
        {
            c.Name = name;
            c.area.StackSize = Currencies.CurrencyList.Find(x => x.Name == name).stacksize;
            c.area.Image = Currencies.CurrencyList.Find(x => x.Name == name).Image;

            int cur1Index = -1;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells[col_orbName].Value?.ToString() == name)
                {
                    cur1Index = row.Index;
                    break;
                }
            }
            ///
            Grid1Row r1 = default;
            int fail = 0;
            if (cur1Index == -1)
            {
                fail = 1;
            }
            else
            {
                if (!ParseGrid1Row(cur1Index, out r1))
                {
                    fail = 1;
                }
            }

            if (fail == 1)
            {
                c.chaos_standart.exists = false;
                c.chaos_standart.index = -1;
            }
            else
            {
                c.chaos_standart.exists = true;
                c.chaos_standart.index = cur1Index;
                c.chaos_standart.orbName = name;
                c.chaos_standart.orbAmount = r1.orbAmount;
                c.chaos_standart.chaosAmount = r1.chaosAmount;
                c.chaos_standart.orbToChaos_Ratio = r1.orbToChaos_Ratio;
            }
        }
        private void Save_to_list_Click(object sender, EventArgs e)
        {
            if (!IsValidForUpdate(ref trade.SellCurr) || !IsValidForUpdate(ref trade.BuyCurr))
                return;
            if (!string.IsNullOrEmpty(tagBox.Text))
            {
                trade.tag = tagBox.Text;
            }
            SavedTrades.Add(ref trade);

            UnselectListbox1();
            SavedTrades.SaveToAFile();
        }
        private void Delete_from_list_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem == null)
            {
                return;
            }

            SavedTrades.Delete(listBox1.SelectedIndex);
            UnselectListbox1();
        }

        private void CalcOrbRatios(int orb1, int orb2, out int rat1, out int rat2)
        {
            rat1 = 0;
            rat2 = 0;
            if (orb1 == 0 || orb2 == 0) return;

            //int gcf1 = Helpers.FindGCF_fromINTS(orb1, orb2);
            int lcd = Helpers.FindLCM_fromINTS(orb1, orb2);
            int a1 = orb1 * lcd;
            int a2 = orb2 * lcd;
            int gcf2 = Helpers.FindGCF_fromINTS(a1, a2);
            rat1 = a1 / gcf2;
            rat2 = a2 / gcf2;

            // Debug.WriteLine($"orbs={orb1},{orb2};rats={rat1},{rat2}");
        }
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the change happened in a specific column by index or name
            if (e.ColumnIndex == dataGridView1.Columns[col_orbAmount].Index || e.ColumnIndex == dataGridView1.Columns[col_chaosAmount].Index)
            {
                var orb_amount1 = dataGridView1.Rows[e.RowIndex].Cells[col_orbAmount].Value;
                var chaos_amount1 = dataGridView1.Rows[e.RowIndex].Cells[col_chaosAmount].Value;
                if (int.TryParse(orb_amount1?.ToString(), out int orb_amount) &&
                int.TryParse(chaos_amount1?.ToString(), out int chaos_amount))
                {
                    CalcOrbRatios(orb_amount, chaos_amount, out int rat1, out int rat2);

                    dataGridView1.Rows[e.RowIndex].Cells[col_orbRatio].Value = rat1;
                    dataGridView1.Rows[e.RowIndex].Cells[col_chaosRatio].Value = rat2;

                    InputChanged(sellCurrencyComboBox, EventArgs.Empty);
                    InputChanged(buyCurrencyComboBox, EventArgs.Empty);

                }
            }
        }

        private void UnselectListbox1()
        {
            lastIndex = -1;
            listBox1.SelectedItem = null;
            listBox1.ClearSelected();
        }
        private void ResetButton_Click(object sender, EventArgs e)
        {
            buyAmountTextBox.Clear();
            sellAmountTextBox.Clear();
            buyCurrencyComboBox.SelectedIndex = -1;
            sellCurrencyComboBox.SelectedIndex = -1;
            searchBuyTextBox.Clear();
            searchSellTextBox.Clear();
            warningLabel.Text = "";
            ratioLabel.Text = "";
            UnselectListbox1();
        }

        private void BtnSaveCSV_Click(object sender, EventArgs e)
        {

            string path = Path.Combine(datadir, @"grid1.csv");
            {
                StringBuilder sb = new StringBuilder();

                string[] columnNames = dataGridView1.Columns.Cast<DataGridViewColumn>()
                                        .Select(column => column.HeaderText).ToArray();
                sb.AppendLine(string.Join(",", columnNames));

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow) // Skip the empty "new row" at the bottom
                    {
                        string[] cells = row.Cells.Cast<DataGridViewCell>()
                                         .Select(cell => cell.Value?.ToString() ?? "").ToArray();
                        sb.AppendLine(string.Join(",", cells));
                    }
                }

                File.WriteAllText(path, sb.ToString(), Encoding.UTF8);

            }
        }
        private void BtnLoadCSV_Click()
        {
            string path = Path.Combine(datadir, @"grid1.csv");
            if (!File.Exists(path))
            {
                return;

            }
            dataGridView1.Columns.Clear();

            DataTable dt = new DataTable();
            string[] lines = File.ReadAllLines(path);

            if (lines.Length > 0)
            {

                // first line -headers
                string[] headers = lines[0].Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header.Trim());
                }

                // other lines
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] data = lines[i].Split(',');
                    dt.Rows.Add(data);
                }
            }
            dataGridView1.DataSource = dt;
        }
        public struct PBoxArea
        {
            public bool initialized;
            public Image Image;
            public int StackSize;
            public PictureBox pbox;
            public Label[] pbox_labels;
            public PictureBox[] pbox_pboxes;
            public Label lb_info;

            public const int MAX_gridRow = 12;
            public const int MAX_gridCol = 5;
            public const int MAX_gridCells = MAX_gridRow * MAX_gridCol;

            public const int gridCellWidth = 53;
            public const int gridCellHeight = 53;
            public const int gridOffsetX = 14;
            public const int gridOffsetY = 14;
        }
        public struct Ratio
        {
            public int ratio1;
            public int ratio2;
        }
        public struct Grid1Row
        {
            public bool exists;
            public int index;
            public string orbName;
            public int orbAmount;
            public int chaosAmount;
            public Ratio orbToChaos_Ratio;
        }
        public struct Calculated
        {
            public Ratio standart_Ratio;
            public double paying_index;
            public double sellAmountShouldBe;
            public double sellAmountCorrection;
        }
        public struct Currency
        {
            public string Name;
            public int TradeAmount;
            public Grid1Row chaos_standart;
            public PBoxArea area;
        }
        public struct TradeStruct
        {
            public Currency BuyCurr;
            public Currency SellCurr;
            public string tag;
            public Calculated calculated;
        }
        public struct Debugbox
        {
            public Point start;
            public int width;
            public int height;
            public Color color;
        }

        public struct Debug
        {
            public Debugbox[] dboxes;
            public int maxboxes;
            public bool shouldDrawBox;
        }
        internal static class SavedTrades
        {
            public struct Trade
            {
                public string BuyCurrency;
                public int BuyCurrencyAmount;
                public string SellCurrency;
                public int SellCurrencyAmount;
                public string tag;
            };

            private const string filename = "trades.xml";
            private static readonly List<Trade> saved_trades_list = new List<Trade>();
            private static ListBox lb;
            private static string filepath;

            public static void Initialize(ListBox lbox, string datadir)
            {
                lb = lbox;
                filepath = Path.GetFullPath(Path.Combine(datadir, filename));
            }

            public static bool GetTrade(int index, out Trade t)
            {
                if (index >= 0 && index < saved_trades_list.Count)
                {
                    t = saved_trades_list[index];
                    return true;
                }
                t = default;
                return false;
            }
            private static int FileExists()
            {
                if (File.Exists(filepath))
                {
                    return 1;
                }
                else return 0;
            }

            private static void ListBoxRefresh()
            {
                lb.Items.Clear();
                foreach (Trade s in saved_trades_list)
                {
                    lb.Items.Add("(" + s.tag + ") " + "Buy " + s.BuyCurrency + " " + s.BuyCurrencyAmount + "" +
                        " ; " +
                        "Sell " + s.SellCurrency + " " + s.SellCurrencyAmount + "" +
                        "; "
                        ); ;
                }
            }

            public static void Add(ref TradeStruct t)
            {
                saved_trades_list.Add(new Trade
                {
                    BuyCurrency = t.BuyCurr.Name,
                    BuyCurrencyAmount = t.BuyCurr.TradeAmount,
                    SellCurrency = t.SellCurr.Name,
                    SellCurrencyAmount = t.SellCurr.TradeAmount,
                    tag = t.tag
                });
                ListBoxRefresh();
            }
            public static void Delete(int index)
            {
                saved_trades_list.RemoveAt(index);
                ListBoxRefresh();
            }
            public static void SaveToAFile()
            {
                XmlWriter xmlWriter = XmlWriter.Create(filepath);
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement(nameof(saved_trades_list));
                foreach (Trade s in saved_trades_list)
                {
                    xmlWriter.WriteStartElement("Trade");
                    xmlWriter.WriteAttributeString(nameof(Trade.BuyCurrency), s.BuyCurrency);
                    xmlWriter.WriteAttributeString(nameof(Trade.BuyCurrencyAmount), s.BuyCurrencyAmount.ToString());
                    xmlWriter.WriteAttributeString(nameof(Trade.SellCurrencyAmount), s.SellCurrencyAmount.ToString());
                    xmlWriter.WriteAttributeString(nameof(Trade.SellCurrency), s.SellCurrency);
                    xmlWriter.WriteAttributeString(nameof(Trade.tag), s.tag);
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }
            public static void LoadFromAFile()
            {
                if (FileExists() == 0)
                    return;

                saved_trades_list.Clear();
                XmlReader xmlReader = XmlReader.Create(filepath);

                while (xmlReader.Read())
                {
                    if (xmlReader.Name.Equals("Trade") && (xmlReader.NodeType == XmlNodeType.Element))
                    {
                        if (xmlReader.HasAttributes)
                            saved_trades_list.Add(new Trade
                            {
                                BuyCurrency = xmlReader.GetAttribute(nameof(Trade.BuyCurrency)),
                                BuyCurrencyAmount = Int32.Parse(xmlReader.GetAttribute(nameof(Trade.BuyCurrencyAmount))),
                                SellCurrency = xmlReader.GetAttribute(nameof(Trade.SellCurrency)),
                                SellCurrencyAmount = Int32.Parse(xmlReader.GetAttribute(nameof(Trade.SellCurrencyAmount))),
                                tag = xmlReader.GetAttribute(nameof(Trade.tag)),
                            });
                    }
                }
                xmlReader.Close();
                ListBoxRefresh();
            }

        }
    }
}


