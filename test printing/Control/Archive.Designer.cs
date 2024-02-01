namespace test_printing
{
    partial class Archive
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
            this.Header = new Guna.UI2.WinForms.Guna2Panel();
            this.back = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.Multi = new Guna.UI2.WinForms.Guna2Panel();
            this.Single = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.previous = new Guna.UI2.WinForms.Guna2ImageButton();
            this.next = new Guna.UI2.WinForms.Guna2ImageButton();
            this.ArchiveTable = new System.Windows.Forms.TableLayoutPanel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.bill1 = new test_printing.bill();
            this.billBuy1 = new test_printing.BillBuy();
            this.Header.SuspendLayout();
            this.Multi.SuspendLayout();
            this.Single.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.White;
            this.Header.Controls.Add(this.back);
            this.Header.Controls.Add(this.guna2Button1);
            this.Header.CustomBorderColor = System.Drawing.Color.Black;
            this.Header.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(1279, 100);
            this.Header.TabIndex = 0;
            // 
            // back
            // 
            this.back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.back.BorderRadius = 10;
            this.back.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.back.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.back.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.back.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.back.FillColor = System.Drawing.Color.Black;
            this.back.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold);
            this.back.ForeColor = System.Drawing.Color.White;
            this.back.Image = global::AbuFas.Properties.Resources.right;
            this.back.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.back.ImageOffset = new System.Drawing.Point(5, 3);
            this.back.ImageSize = new System.Drawing.Size(11, 20);
            this.back.Location = new System.Drawing.Point(1093, 26);
            this.back.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(135, 46);
            this.back.TabIndex = 4;
            this.back.Text = "عودة";
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.guna2Button1.BorderRadius = 5;
            this.guna2Button1.BorderThickness = 2;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.Image = global::AbuFas.Properties.Resources.Vector1;
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2Button1.Location = new System.Drawing.Point(141, 26);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(180, 46);
            this.guna2Button1.TabIndex = 3;
            this.guna2Button1.Text = "أرشفه";
            // 
            // Multi
            // 
            this.Multi.BackColor = System.Drawing.Color.White;
            this.Multi.Controls.Add(this.Single);
            this.Multi.Controls.Add(this.ArchiveTable);
            this.Multi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Multi.Location = new System.Drawing.Point(0, 100);
            this.Multi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Multi.Name = "Multi";
            this.Multi.Padding = new System.Windows.Forms.Padding(0, 0, 0, 39);
            this.Multi.Size = new System.Drawing.Size(1279, 813);
            this.Multi.TabIndex = 1;
            // 
            // Single
            // 
            this.Single.AutoScroll = true;
            this.Single.BackColor = System.Drawing.Color.Transparent;
            this.Single.Controls.Add(this.guna2Button4);
            this.Single.Controls.Add(this.guna2Button3);
            this.Single.Controls.Add(this.guna2Panel1);
            this.Single.Controls.Add(this.guna2Button2);
            this.Single.Controls.Add(this.previous);
            this.Single.Controls.Add(this.next);
            this.Single.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Single.FillColor = System.Drawing.Color.Transparent;
            this.Single.Location = new System.Drawing.Point(0, 0);
            this.Single.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Single.Name = "Single";
            this.Single.ShadowDecoration.Depth = 3;
            this.Single.Size = new System.Drawing.Size(1279, 774);
            this.Single.TabIndex = 1;
            // 
            // guna2Button4
            // 
            this.guna2Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.guna2Button4.BorderRadius = 10;
            this.guna2Button4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button4.FillColor = System.Drawing.Color.Black;
            this.guna2Button4.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button4.ForeColor = System.Drawing.Color.White;
            this.guna2Button4.Location = new System.Drawing.Point(25, 576);
            this.guna2Button4.Margin = new System.Windows.Forms.Padding(0);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.Size = new System.Drawing.Size(180, 46);
            this.guna2Button4.TabIndex = 6;
            this.guna2Button4.Text = "حذف";
            this.guna2Button4.UseTransparentBackground = true;
            this.guna2Button4.Click += new System.EventHandler(this.guna2Button4_Click);
            // 
            // guna2Button3
            // 
            this.guna2Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.guna2Button3.BorderRadius = 10;
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.guna2Button3.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.Location = new System.Drawing.Point(25, 510);
            this.guna2Button3.Margin = new System.Windows.Forms.Padding(0);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(180, 46);
            this.guna2Button3.TabIndex = 5;
            this.guna2Button3.Text = "طباعة";
            this.guna2Button3.UseTransparentBackground = true;
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.guna2Button2.BorderRadius = 10;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.Black;
            this.guna2Button2.Font = new System.Drawing.Font("Cairo SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(25, 32);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(0);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(180, 46);
            this.guna2Button2.TabIndex = 3;
            this.guna2Button2.Text = "اغلاق";
            this.guna2Button2.UseTransparentBackground = true;
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // previous
            // 
            this.previous.BackColor = System.Drawing.Color.Black;
            this.previous.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.previous.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.previous.Image = global::AbuFas.Properties.Resources.left;
            this.previous.ImageOffset = new System.Drawing.Point(0, 0);
            this.previous.ImageRotate = 0F;
            this.previous.ImageSize = new System.Drawing.Size(11, 20);
            this.previous.Location = new System.Drawing.Point(25, 359);
            this.previous.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.previous.Name = "previous";
            this.previous.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.previous.ShadowDecoration.BorderRadius = 5;
            this.previous.Size = new System.Drawing.Size(36, 54);
            this.previous.TabIndex = 2;
            this.previous.Click += new System.EventHandler(this.previous_Click);
            // 
            // next
            // 
            this.next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.next.BackColor = System.Drawing.Color.Black;
            this.next.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.next.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.next.Image = global::AbuFas.Properties.Resources.right;
            this.next.ImageOffset = new System.Drawing.Point(0, 0);
            this.next.ImageRotate = 0F;
            this.next.ImageSize = new System.Drawing.Size(11, 20);
            this.next.Location = new System.Drawing.Point(1191, 359);
            this.next.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.next.Name = "next";
            this.next.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.next.ShadowDecoration.BorderRadius = 5;
            this.next.Size = new System.Drawing.Size(36, 54);
            this.next.TabIndex = 1;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // ArchiveTable
            // 
            this.ArchiveTable.AutoScroll = true;
            this.ArchiveTable.ColumnCount = 4;
            this.ArchiveTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 337F));
            this.ArchiveTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 337F));
            this.ArchiveTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 337F));
            this.ArchiveTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 337F));
            this.ArchiveTable.Location = new System.Drawing.Point(0, 17);
            this.ArchiveTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ArchiveTable.Name = "ArchiveTable";
            this.ArchiveTable.Padding = new System.Windows.Forms.Padding(15, 15, 25, 15);
            this.ArchiveTable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ArchiveTable.RowCount = 3;
            this.ArchiveTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.ArchiveTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.ArchiveTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.ArchiveTable.Size = new System.Drawing.Size(1276, 609);
            this.ArchiveTable.TabIndex = 0;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.AutoScroll = true;
            this.guna2Panel1.AutoSize = true;
            this.guna2Panel1.Controls.Add(this.bill1);
            this.guna2Panel1.Controls.Add(this.billBuy1);
            this.guna2Panel1.Location = new System.Drawing.Point(233, 6);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(986, 1046);
            this.guna2Panel1.TabIndex = 4;
            // 
            // bill1
            // 
            this.bill1.AutoScroll = true;
            this.bill1.AutoSize = true;
            this.bill1.BackColor = System.Drawing.Color.White;
            this.bill1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bill1.Font = new System.Drawing.Font("Cairo", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bill1.Location = new System.Drawing.Point(3, 3);
            this.bill1.Name = "bill1";
            this.bill1.Size = new System.Drawing.Size(707, 749);
            this.bill1.TabIndex = 2;
            // 
            // billBuy1
            // 
            this.billBuy1.AutoScroll = true;
            this.billBuy1.AutoSize = true;
            this.billBuy1.Enabled = false;
            this.billBuy1.Location = new System.Drawing.Point(0, 0);
            this.billBuy1.Margin = new System.Windows.Forms.Padding(0);
            this.billBuy1.Name = "billBuy1";
            this.billBuy1.Size = new System.Drawing.Size(686, 1046);
            this.billBuy1.TabIndex = 1;
            // 
            // Archive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Multi);
            this.Controls.Add(this.Header);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Archive";
            this.Size = new System.Drawing.Size(1279, 913);
            this.Load += new System.EventHandler(this.Archive_Load);
            this.Header.ResumeLayout(false);
            this.Multi.ResumeLayout(false);
            this.Single.ResumeLayout(false);
            this.Single.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel Header;
        private Guna.UI2.WinForms.Guna2Panel Multi;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.TableLayoutPanel ArchiveTable;
        private Guna.UI2.WinForms.Guna2Panel Single;
        private Guna.UI2.WinForms.Guna2ImageButton next;
        private Guna.UI2.WinForms.Guna2ImageButton previous;
        private Guna.UI2.WinForms.Guna2Button back;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private bill bill1;
        private BillBuy billBuy1;
    }
}
