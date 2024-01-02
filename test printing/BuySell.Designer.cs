namespace test_printing
{
    partial class BuySell
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.Archive = new Guna.UI2.WinForms.Guna2Button();
            this.toggle = new Guna.UI2.WinForms.Guna2Panel();
            this.sell = new Guna.UI2.WinForms.Guna2Button();
            this.Buy = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.bill1 = new test_printing.bill();
            this.billBuy1 = new test_printing.BillBuy();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.Result = new Guna.UI2.WinForms.Guna2Button();
            this.Calculate_bill = new Guna.UI2.WinForms.Guna2Button();
            this.grams = new Guna.UI2.WinForms.Guna2TextBox();
            this.price = new Guna.UI2.WinForms.Guna2TextBox();
            this.bouns = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            this.toggle.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.guna2Panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.Controls.Add(this.Archive);
            this.guna2Panel1.Controls.Add(this.toggle);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1542, 100);
            this.guna2Panel1.TabIndex = 0;
            // 
            // Archive
            // 
            this.Archive.BackColor = System.Drawing.Color.Transparent;
            this.Archive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.Archive.BorderRadius = 5;
            this.Archive.BorderThickness = 2;
            this.Archive.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Archive.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Archive.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Archive.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Archive.FillColor = System.Drawing.Color.Transparent;
            this.Archive.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Archive.ForeColor = System.Drawing.Color.Black;
            this.Archive.Image = global::AbuFas.Properties.Resources.Vector1;
            this.Archive.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Archive.Location = new System.Drawing.Point(141, 26);
            this.Archive.Margin = new System.Windows.Forms.Padding(0);
            this.Archive.Name = "Archive";
            this.Archive.Size = new System.Drawing.Size(180, 45);
            this.Archive.TabIndex = 2;
            this.Archive.Text = "أرشفه";
            this.Archive.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // toggle
            // 
            this.toggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toggle.AutoRoundedCorners = true;
            this.toggle.BackColor = System.Drawing.Color.Transparent;
            this.toggle.BorderColor = System.Drawing.Color.Transparent;
            this.toggle.BorderRadius = 21;
            this.toggle.Controls.Add(this.sell);
            this.toggle.Controls.Add(this.Buy);
            this.toggle.FillColor = System.Drawing.Color.Black;
            this.toggle.Location = new System.Drawing.Point(1155, 26);
            this.toggle.Margin = new System.Windows.Forms.Padding(0);
            this.toggle.Name = "toggle";
            this.toggle.Size = new System.Drawing.Size(311, 45);
            this.toggle.TabIndex = 1;
            // 
            // sell
            // 
            this.sell.BackColor = System.Drawing.Color.Transparent;
            this.sell.BorderRadius = 20;
            this.sell.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.sell.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.sell.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.sell.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.sell.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.sell.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sell.ForeColor = System.Drawing.Color.White;
            this.sell.Location = new System.Drawing.Point(133, 0);
            this.sell.Name = "sell";
            this.sell.Size = new System.Drawing.Size(180, 45);
            this.sell.TabIndex = 0;
            this.sell.Text = "البيع";
            this.sell.Click += new System.EventHandler(this.sell_Click);
            // 
            // Buy
            // 
            this.Buy.BackColor = System.Drawing.Color.Transparent;
            this.Buy.BorderRadius = 20;
            this.Buy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Buy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Buy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Buy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Buy.FillColor = System.Drawing.Color.Black;
            this.Buy.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Buy.ForeColor = System.Drawing.Color.White;
            this.Buy.Location = new System.Drawing.Point(-2, 0);
            this.Buy.Name = "Buy";
            this.Buy.Size = new System.Drawing.Size(180, 45);
            this.Buy.TabIndex = 1;
            this.Buy.Text = "الشراء";
            this.Buy.Click += new System.EventHandler(this.Buy_Click);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.AutoScroll = true;
            this.guna2Panel2.Controls.Add(this.bill1);
            this.guna2Panel2.Controls.Add(this.billBuy1);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel2.Location = new System.Drawing.Point(612, 100);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 25);
            this.guna2Panel2.Size = new System.Drawing.Size(930, 813);
            this.guna2Panel2.TabIndex = 1;
            // 
            // bill1
            // 
            this.bill1.AutoScroll = true;
            this.bill1.AutoSize = true;
            this.bill1.BackColor = System.Drawing.Color.White;
            this.bill1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bill1.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bill1.Location = new System.Drawing.Point(22, 16);
            this.bill1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.bill1.Name = "bill1";
            this.bill1.Size = new System.Drawing.Size(882, 749);
            this.bill1.TabIndex = 0;
            // 
            // billBuy1
            // 
            this.billBuy1.AutoScroll = true;
            this.billBuy1.AutoSize = true;
            this.billBuy1.Location = new System.Drawing.Point(22, 16);
            this.billBuy1.Name = "billBuy1";
            this.billBuy1.Size = new System.Drawing.Size(882, 869);
            this.billBuy1.TabIndex = 1;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.guna2Button4);
            this.guna2Panel3.Controls.Add(this.guna2Panel4);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel3.Location = new System.Drawing.Point(0, 100);
            this.guna2Panel3.Margin = new System.Windows.Forms.Padding(0);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 25);
            this.guna2Panel3.ShadowDecoration.Color = System.Drawing.Color.LightGray;
            this.guna2Panel3.Size = new System.Drawing.Size(612, 813);
            this.guna2Panel3.TabIndex = 2;
            // 
            // guna2Button4
            // 
            this.guna2Button4.BorderRadius = 5;
            this.guna2Button4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.guna2Button4.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button4.ForeColor = System.Drawing.Color.Black;
            this.guna2Button4.Location = new System.Drawing.Point(249, 722);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.Size = new System.Drawing.Size(306, 63);
            this.guna2Button4.TabIndex = 13;
            this.guna2Button4.Text = "طبع الفاتورة";
            this.guna2Button4.Click += new System.EventHandler(this.guna2Button4_Click);
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel4.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel4.BorderRadius = 10;
            this.guna2Panel4.BorderThickness = 1;
            this.guna2Panel4.Controls.Add(this.label5);
            this.guna2Panel4.Controls.Add(this.Result);
            this.guna2Panel4.Controls.Add(this.Calculate_bill);
            this.guna2Panel4.Controls.Add(this.grams);
            this.guna2Panel4.Controls.Add(this.price);
            this.guna2Panel4.Controls.Add(this.bouns);
            this.guna2Panel4.Controls.Add(this.label6);
            this.guna2Panel4.Controls.Add(this.label4);
            this.guna2Panel4.Controls.Add(this.label3);
            this.guna2Panel4.Controls.Add(this.label2);
            this.guna2Panel4.Controls.Add(this.guna2Panel5);
            this.guna2Panel4.FillColor = System.Drawing.Color.White;
            this.guna2Panel4.Location = new System.Drawing.Point(249, 16);
            this.guna2Panel4.Margin = new System.Windows.Forms.Padding(0);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.ShadowDecoration.BorderRadius = 10;
            this.guna2Panel4.ShadowDecoration.Depth = 5;
            this.guna2Panel4.ShadowDecoration.Enabled = true;
            this.guna2Panel4.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(10);
            this.guna2Panel4.Size = new System.Drawing.Size(306, 694);
            this.guna2Panel4.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cairo Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(137, 350);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 43);
            this.label5.TabIndex = 12;
            this.label5.Text = "X";
            // 
            // Result
            // 
            this.Result.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Result.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Result.DisabledState.CustomBorderColor = System.Drawing.Color.Black;
            this.Result.DisabledState.FillColor = System.Drawing.Color.Black;
            this.Result.DisabledState.ForeColor = System.Drawing.Color.White;
            this.Result.Enabled = false;
            this.Result.FillColor = System.Drawing.Color.Black;
            this.Result.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result.ForeColor = System.Drawing.Color.White;
            this.Result.Location = new System.Drawing.Point(15, 573);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(277, 68);
            this.Result.TabIndex = 11;
            this.Result.Text = "0";
            // 
            // Calculate_bill
            // 
            this.Calculate_bill.BorderRadius = 5;
            this.Calculate_bill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Calculate_bill.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Calculate_bill.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Calculate_bill.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Calculate_bill.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Calculate_bill.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.Calculate_bill.Font = new System.Drawing.Font("Cairo", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Calculate_bill.ForeColor = System.Drawing.Color.Black;
            this.Calculate_bill.Location = new System.Drawing.Point(15, 500);
            this.Calculate_bill.Name = "Calculate_bill";
            this.Calculate_bill.Size = new System.Drawing.Size(277, 48);
            this.Calculate_bill.TabIndex = 10;
            this.Calculate_bill.Text = "=";
            this.Calculate_bill.Click += new System.EventHandler(this.Calculate_bill_Click);
            // 
            // grams
            // 
            this.grams.BorderColor = System.Drawing.Color.Black;
            this.grams.BorderRadius = 5;
            this.grams.BorderThickness = 2;
            this.grams.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.grams.DefaultText = "";
            this.grams.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.grams.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.grams.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.grams.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.grams.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.grams.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grams.ForeColor = System.Drawing.Color.Black;
            this.grams.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.grams.Location = new System.Drawing.Point(15, 159);
            this.grams.Margin = new System.Windows.Forms.Padding(0);
            this.grams.Name = "grams";
            this.grams.PasswordChar = '\0';
            this.grams.PlaceholderText = "";
            this.grams.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grams.SelectedText = "";
            this.grams.Size = new System.Drawing.Size(277, 48);
            this.grams.TabIndex = 9;
            this.grams.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.price_KeyPress);
            // 
            // price
            // 
            this.price.BorderColor = System.Drawing.Color.Black;
            this.price.BorderRadius = 5;
            this.price.BorderThickness = 2;
            this.price.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.price.DefaultText = "";
            this.price.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.price.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.price.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.price.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.price.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.price.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.ForeColor = System.Drawing.Color.Black;
            this.price.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.price.Location = new System.Drawing.Point(15, 292);
            this.price.Margin = new System.Windows.Forms.Padding(0);
            this.price.Name = "price";
            this.price.PasswordChar = '\0';
            this.price.PlaceholderText = "";
            this.price.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.price.SelectedText = "";
            this.price.Size = new System.Drawing.Size(277, 48);
            this.price.TabIndex = 8;
            this.price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.price_KeyPress);
            // 
            // bouns
            // 
            this.bouns.BorderColor = System.Drawing.Color.Black;
            this.bouns.BorderRadius = 5;
            this.bouns.BorderThickness = 2;
            this.bouns.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bouns.DefaultText = "";
            this.bouns.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.bouns.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.bouns.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.bouns.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.bouns.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.bouns.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bouns.ForeColor = System.Drawing.Color.Black;
            this.bouns.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.bouns.IconRight = global::AbuFas.Properties.Resources.percentage;
            this.bouns.IconRightOffset = new System.Drawing.Point(10, 0);
            this.bouns.Location = new System.Drawing.Point(15, 427);
            this.bouns.Margin = new System.Windows.Forms.Padding(0);
            this.bouns.Name = "bouns";
            this.bouns.PasswordChar = '\0';
            this.bouns.PlaceholderText = "";
            this.bouns.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bouns.SelectedText = "";
            this.bouns.Size = new System.Drawing.Size(277, 48);
            this.bouns.TabIndex = 7;
            this.bouns.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.price_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cairo Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(137, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 43);
            this.label6.TabIndex = 6;
            this.label6.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(193, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 43);
            this.label4.TabIndex = 4;
            this.label4.Text = "الجرامات";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(218, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 43);
            this.label3.TabIndex = 3;
            this.label3.Text = "السعر";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(182, 373);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 43);
            this.label2.TabIndex = 2;
            this.label2.Text = "المصنعية";
            // 
            // guna2Panel5
            // 
            this.guna2Panel5.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel5.Controls.Add(this.label1);
            this.guna2Panel5.CustomBorderColor = System.Drawing.Color.Black;
            this.guna2Panel5.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.guna2Panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel5.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel5.Name = "guna2Panel5";
            this.guna2Panel5.Size = new System.Drawing.Size(306, 100);
            this.guna2Panel5.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(107, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "الحاسبة";
            // 
            // BuySell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "BuySell";
            this.Size = new System.Drawing.Size(1542, 913);
            this.Load += new System.EventHandler(this.firstPage_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.toggle.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel4.PerformLayout();
            this.guna2Panel5.ResumeLayout(false);
            this.guna2Panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel toggle;
        private Guna.UI2.WinForms.Guna2Button sell;
        private Guna.UI2.WinForms.Guna2Button Buy;
        private Guna.UI2.WinForms.Guna2Button Archive;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private bill bill1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Guna.UI2.WinForms.Guna2Button Calculate_bill;
        private Guna.UI2.WinForms.Guna2TextBox grams;
        private Guna.UI2.WinForms.Guna2TextBox price;
        private Guna.UI2.WinForms.Guna2TextBox bouns;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button Result;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private BillBuy billBuy1;
    }
}
