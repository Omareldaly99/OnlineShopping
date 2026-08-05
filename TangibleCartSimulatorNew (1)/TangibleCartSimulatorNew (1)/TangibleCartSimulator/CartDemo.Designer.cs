
namespace TangibleCartSimulator
{

    partial class CartDemo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.userProfilePanel = new System.Windows.Forms.Panel();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.userIconPictureBox = new System.Windows.Forms.PictureBox();
            this.userProfleLabel = new System.Windows.Forms.Label();
            this.activeSelectionPanel = new System.Windows.Forms.Panel();
            this.activeSelectionLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.nextItemButton = new System.Windows.Forms.Button();
            this.prevItemButton = new System.Windows.Forms.Button();
            this.activeItemPictureBox = new System.Windows.Forms.PictureBox();
            this.activeSelectionLbl = new System.Windows.Forms.Label();
            this.shoppingCartPanel = new System.Windows.Forms.Panel();
            this.shoppingCartGrid = new System.Windows.Forms.DataGridView();
            this.ShoppingCartLabel = new System.Windows.Forms.Label();
            this.cartSummaryPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.SubtotalLbl = new System.Windows.Forms.Label();
            this.subtotalLabelval = new System.Windows.Forms.Label();
            this.taxLabel = new System.Windows.Forms.Label();
            this.taxLabelval = new System.Windows.Forms.Label();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.totalLabelval = new System.Windows.Forms.Label();
            this.cartSummaryLabel = new System.Windows.Forms.Label();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.checkoutButton = new System.Windows.Forms.Button();
            this.clearCartButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.itemColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTotalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simulationPanel = new TangibleCartSimulator.DoubleBufferedPanel();
            this.tableLayoutPanel2.SuspendLayout();
            this.userProfilePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userIconPictureBox)).BeginInit();
            this.activeSelectionPanel.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activeItemPictureBox)).BeginInit();
            this.shoppingCartPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shoppingCartGrid)).BeginInit();
            this.cartSummaryPanel.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.userProfilePanel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.activeSelectionPanel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.shoppingCartPanel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cartSummaryPanel, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.buttonPanel, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(891, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 143F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(483, 686);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // userProfilePanel
            // 
            this.userProfilePanel.BackColor = System.Drawing.Color.DarkSlateGray;
            this.userProfilePanel.Controls.Add(this.userNameLabel);
            this.userProfilePanel.Controls.Add(this.userIconPictureBox);
            this.userProfilePanel.Controls.Add(this.userProfleLabel);
            this.userProfilePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userProfilePanel.Location = new System.Drawing.Point(3, 3);
            this.userProfilePanel.Name = "userProfilePanel";
            this.userProfilePanel.Size = new System.Drawing.Size(477, 137);
            this.userProfilePanel.TabIndex = 0;
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLabel.ForeColor = System.Drawing.Color.White;
            this.userNameLabel.Location = new System.Drawing.Point(129, 65);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(41, 13);
            this.userNameLabel.TabIndex = 2;
            this.userNameLabel.Text = "User: ";
            this.userNameLabel.Click += new System.EventHandler(this.userNameLabel_Click);
            // 
            // userIconPictureBox
            // 
            this.userIconPictureBox.Location = new System.Drawing.Point(26, 36);
            this.userIconPictureBox.Name = "userIconPictureBox";
            this.userIconPictureBox.Size = new System.Drawing.Size(80, 80);
            this.userIconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userIconPictureBox.TabIndex = 1;
            this.userIconPictureBox.TabStop = false;
            this.userIconPictureBox.Click += new System.EventHandler(this.userIconPictureBox_Click);
            // 
            // userProfleLabel
            // 
            this.userProfleLabel.AutoSize = true;
            this.userProfleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.userProfleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userProfleLabel.ForeColor = System.Drawing.Color.White;
            this.userProfleLabel.Location = new System.Drawing.Point(0, 0);
            this.userProfleLabel.Name = "userProfleLabel";
            this.userProfleLabel.Size = new System.Drawing.Size(94, 17);
            this.userProfleLabel.TabIndex = 0;
            this.userProfleLabel.Text = "User Profile";
            // 
            // activeSelectionPanel
            // 
            this.activeSelectionPanel.BackColor = System.Drawing.Color.DarkSlateGray;
            this.activeSelectionPanel.Controls.Add(this.activeSelectionLabel);
            this.activeSelectionPanel.Controls.Add(this.tableLayoutPanel3);
            this.activeSelectionPanel.Controls.Add(this.activeSelectionLbl);
            this.activeSelectionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activeSelectionPanel.Location = new System.Drawing.Point(3, 146);
            this.activeSelectionPanel.Name = "activeSelectionPanel";
            this.activeSelectionPanel.Size = new System.Drawing.Size(477, 130);
            this.activeSelectionPanel.TabIndex = 1;
            // 
            // activeSelectionLabel
            // 
            this.activeSelectionLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.activeSelectionLabel.AutoSize = true;
            this.activeSelectionLabel.ForeColor = System.Drawing.Color.White;
            this.activeSelectionLabel.Location = new System.Drawing.Point(148, 95);
            this.activeSelectionLabel.Name = "activeSelectionLabel";
            this.activeSelectionLabel.Size = new System.Drawing.Size(180, 13);
            this.activeSelectionLabel.TabIndex = 2;
            this.activeSelectionLabel.Text = "ACTIVE OBJECT SELECTOR: MILK";
            this.activeSelectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel3.Controls.Add(this.nextItemButton, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.prevItemButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.activeItemPictureBox, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 17);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(477, 78);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // nextItemButton
            // 
            this.nextItemButton.AutoSize = true;
            this.nextItemButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nextItemButton.BackColor = System.Drawing.Color.DarkSlateGray;
            this.nextItemButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nextItemButton.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.nextItemButton.FlatAppearance.BorderSize = 0;
            this.nextItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextItemButton.ForeColor = System.Drawing.Color.White;
            this.nextItemButton.Location = new System.Drawing.Point(346, 3);
            this.nextItemButton.Name = "nextItemButton";
            this.nextItemButton.Size = new System.Drawing.Size(147, 72);
            this.nextItemButton.TabIndex = 2;
            this.nextItemButton.Text = ">";
            this.nextItemButton.UseVisualStyleBackColor = false;
            this.nextItemButton.Click += new System.EventHandler(this.nextItemButton_Click);
            // 
            // prevItemButton
            // 
            this.prevItemButton.AutoSize = true;
            this.prevItemButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.prevItemButton.BackColor = System.Drawing.Color.DarkSlateGray;
            this.prevItemButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prevItemButton.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.prevItemButton.FlatAppearance.BorderSize = 0;
            this.prevItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevItemButton.ForeColor = System.Drawing.Color.White;
            this.prevItemButton.Location = new System.Drawing.Point(3, 3);
            this.prevItemButton.Name = "prevItemButton";
            this.prevItemButton.Size = new System.Drawing.Size(137, 72);
            this.prevItemButton.TabIndex = 0;
            this.prevItemButton.Text = "<";
            this.prevItemButton.UseVisualStyleBackColor = false;
            this.prevItemButton.Click += new System.EventHandler(this.prevItemButton_Click);
            // 
            // activeItemPictureBox
            // 
            this.activeItemPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activeItemPictureBox.Location = new System.Drawing.Point(146, 3);
            this.activeItemPictureBox.Name = "activeItemPictureBox";
            this.activeItemPictureBox.Size = new System.Drawing.Size(194, 72);
            this.activeItemPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.activeItemPictureBox.TabIndex = 1;
            this.activeItemPictureBox.TabStop = false;
            this.activeItemPictureBox.Click += new System.EventHandler(this.activeItemPictureBox_Click);
            // 
            // activeSelectionLbl
            // 
            this.activeSelectionLbl.AutoSize = true;
            this.activeSelectionLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.activeSelectionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeSelectionLbl.ForeColor = System.Drawing.Color.White;
            this.activeSelectionLbl.Location = new System.Drawing.Point(0, 0);
            this.activeSelectionLbl.Name = "activeSelectionLbl";
            this.activeSelectionLbl.Size = new System.Drawing.Size(124, 17);
            this.activeSelectionLbl.TabIndex = 0;
            this.activeSelectionLbl.Text = "Active Selection";
            this.activeSelectionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // shoppingCartPanel
            // 
            this.shoppingCartPanel.BackColor = System.Drawing.Color.DarkSlateGray;
            this.shoppingCartPanel.Controls.Add(this.shoppingCartGrid);
            this.shoppingCartPanel.Controls.Add(this.ShoppingCartLabel);
            this.shoppingCartPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shoppingCartPanel.Location = new System.Drawing.Point(3, 282);
            this.shoppingCartPanel.Name = "shoppingCartPanel";
            this.shoppingCartPanel.Size = new System.Drawing.Size(477, 184);
            this.shoppingCartPanel.TabIndex = 2;
            // 
            // shoppingCartGrid
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray;
            this.shoppingCartGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.shoppingCartGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shoppingCartGrid.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.shoppingCartGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.shoppingCartGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.shoppingCartGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.OliveDrab;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.shoppingCartGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.shoppingCartGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shoppingCartGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemColumn,
            this.quantityColumn,
            this.unitPriceColumn,
            this.subTotalColumn,
            this.actionColumn});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.OliveDrab;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.shoppingCartGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.shoppingCartGrid.GridColor = System.Drawing.Color.DarkSlateGray;
            this.shoppingCartGrid.Location = new System.Drawing.Point(0, 17);
            this.shoppingCartGrid.Name = "shoppingCartGrid";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.shoppingCartGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.shoppingCartGrid.RowHeadersVisible = false;
            this.shoppingCartGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.DarkSlateGray;
            this.shoppingCartGrid.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.shoppingCartGrid.RowTemplate.Height = 30;
            this.shoppingCartGrid.Size = new System.Drawing.Size(477, 167);
            this.shoppingCartGrid.TabIndex = 1;
            this.shoppingCartGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.shoppingCartGrid_CellContentClick);
            // 
            // ShoppingCartLabel
            // 
            this.ShoppingCartLabel.AutoSize = true;
            this.ShoppingCartLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ShoppingCartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShoppingCartLabel.ForeColor = System.Drawing.Color.White;
            this.ShoppingCartLabel.Location = new System.Drawing.Point(0, 0);
            this.ShoppingCartLabel.Name = "ShoppingCartLabel";
            this.ShoppingCartLabel.Size = new System.Drawing.Size(183, 17);
            this.ShoppingCartLabel.TabIndex = 0;
            this.ShoppingCartLabel.Text = "YOUR SHOPPING CART";
            this.ShoppingCartLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cartSummaryPanel
            // 
            this.cartSummaryPanel.BackColor = System.Drawing.Color.DarkSlateGray;
            this.cartSummaryPanel.Controls.Add(this.tableLayoutPanel4);
            this.cartSummaryPanel.Controls.Add(this.cartSummaryLabel);
            this.cartSummaryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartSummaryPanel.Location = new System.Drawing.Point(3, 472);
            this.cartSummaryPanel.Name = "cartSummaryPanel";
            this.cartSummaryPanel.Size = new System.Drawing.Size(477, 134);
            this.cartSummaryPanel.TabIndex = 3;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.SubtotalLbl, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.subtotalLabelval, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.taxLabel, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.taxLabelval, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.TotalLabel, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.totalLabelval, 1, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 17);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(477, 117);
            this.tableLayoutPanel4.TabIndex = 1;
            this.tableLayoutPanel4.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel4_Paint);
            // 
            // SubtotalLbl
            // 
            this.SubtotalLbl.AutoSize = true;
            this.SubtotalLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubtotalLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubtotalLbl.ForeColor = System.Drawing.Color.White;
            this.SubtotalLbl.Location = new System.Drawing.Point(3, 0);
            this.SubtotalLbl.Name = "SubtotalLbl";
            this.SubtotalLbl.Size = new System.Drawing.Size(232, 39);
            this.SubtotalLbl.TabIndex = 0;
            this.SubtotalLbl.Text = "Subtotal:";
            this.SubtotalLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // subtotalLabelval
            // 
            this.subtotalLabelval.AutoSize = true;
            this.subtotalLabelval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subtotalLabelval.ForeColor = System.Drawing.Color.White;
            this.subtotalLabelval.Location = new System.Drawing.Point(241, 0);
            this.subtotalLabelval.Name = "subtotalLabelval";
            this.subtotalLabelval.Size = new System.Drawing.Size(233, 39);
            this.subtotalLabelval.TabIndex = 1;
            this.subtotalLabelval.Text = "$0.00";
            this.subtotalLabelval.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.subtotalLabelval.Click += new System.EventHandler(this.subtotalLabelval_Click);
            // 
            // taxLabel
            // 
            this.taxLabel.AutoSize = true;
            this.taxLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taxLabel.ForeColor = System.Drawing.Color.White;
            this.taxLabel.Location = new System.Drawing.Point(3, 39);
            this.taxLabel.Name = "taxLabel";
            this.taxLabel.Size = new System.Drawing.Size(232, 39);
            this.taxLabel.TabIndex = 2;
            this.taxLabel.Text = "Tax (13%):";
            this.taxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // taxLabelval
            // 
            this.taxLabelval.AutoSize = true;
            this.taxLabelval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taxLabelval.ForeColor = System.Drawing.Color.White;
            this.taxLabelval.Location = new System.Drawing.Point(241, 39);
            this.taxLabelval.Name = "taxLabelval";
            this.taxLabelval.Size = new System.Drawing.Size(233, 39);
            this.taxLabelval.TabIndex = 3;
            this.taxLabelval.Text = "$0.00";
            this.taxLabelval.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.taxLabelval.Click += new System.EventHandler(this.taxLabelval_Click);
            // 
            // TotalLabel
            // 
            this.TotalLabel.AutoSize = true;
            this.TotalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalLabel.ForeColor = System.Drawing.Color.White;
            this.TotalLabel.Location = new System.Drawing.Point(3, 78);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(232, 39);
            this.TotalLabel.TabIndex = 4;
            this.TotalLabel.Text = "Total:";
            this.TotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalLabelval
            // 
            this.totalLabelval.AutoSize = true;
            this.totalLabelval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalLabelval.ForeColor = System.Drawing.Color.White;
            this.totalLabelval.Location = new System.Drawing.Point(241, 78);
            this.totalLabelval.Name = "totalLabelval";
            this.totalLabelval.Size = new System.Drawing.Size(233, 39);
            this.totalLabelval.TabIndex = 5;
            this.totalLabelval.Text = "$0.00";
            this.totalLabelval.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.totalLabelval.Click += new System.EventHandler(this.totalLabelval_Click);
            // 
            // cartSummaryLabel
            // 
            this.cartSummaryLabel.AutoSize = true;
            this.cartSummaryLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.cartSummaryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.cartSummaryLabel.ForeColor = System.Drawing.Color.White;
            this.cartSummaryLabel.Location = new System.Drawing.Point(0, 0);
            this.cartSummaryLabel.Name = "cartSummaryLabel";
            this.cartSummaryLabel.Size = new System.Drawing.Size(109, 17);
            this.cartSummaryLabel.TabIndex = 0;
            this.cartSummaryLabel.Text = "Cart Summary";
            // 
            // buttonPanel
            // 
            this.buttonPanel.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonPanel.Controls.Add(this.tableLayoutPanel5);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPanel.Location = new System.Drawing.Point(3, 612);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(477, 71);
            this.buttonPanel.TabIndex = 4;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.DarkSlateGray;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.checkoutButton, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.clearCartButton, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(477, 71);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // checkoutButton
            // 
            this.checkoutButton.BackColor = System.Drawing.Color.Silver;
            this.checkoutButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkoutButton.FlatAppearance.BorderSize = 0;
            this.checkoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkoutButton.Location = new System.Drawing.Point(241, 3);
            this.checkoutButton.Name = "checkoutButton";
            this.checkoutButton.Size = new System.Drawing.Size(233, 65);
            this.checkoutButton.TabIndex = 1;
            this.checkoutButton.Text = "Checkout";
            this.checkoutButton.UseVisualStyleBackColor = false;
            this.checkoutButton.Click += new System.EventHandler(this.checkoutButton_Click);
            // 
            // clearCartButton
            // 
            this.clearCartButton.BackColor = System.Drawing.Color.Silver;
            this.clearCartButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearCartButton.FlatAppearance.BorderSize = 0;
            this.clearCartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearCartButton.Location = new System.Drawing.Point(3, 3);
            this.clearCartButton.Name = "clearCartButton";
            this.clearCartButton.Size = new System.Drawing.Size(232, 65);
            this.clearCartButton.TabIndex = 0;
            this.clearCartButton.Text = "Clear Cart";
            this.clearCartButton.UseVisualStyleBackColor = false;
            this.clearCartButton.Click += new System.EventHandler(this.clearCartButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.51104F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.48896F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.simulationPanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 98.85877F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.141227F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1377, 701);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // itemColumn
            // 
            this.itemColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.itemColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.itemColumn.HeaderText = "Item";
            this.itemColumn.Name = "itemColumn";
            // 
            // quantityColumn
            // 
            this.quantityColumn.HeaderText = "Quantity";
            this.quantityColumn.Name = "quantityColumn";
            // 
            // unitPriceColumn
            // 
            this.unitPriceColumn.HeaderText = "Unit Price";
            this.unitPriceColumn.Name = "unitPriceColumn";
            // 
            // subTotalColumn
            // 
            this.subTotalColumn.HeaderText = "Sub Total";
            this.subTotalColumn.Name = "subTotalColumn";
            // 
            // actionColumn
            // 
            this.actionColumn.HeaderText = "Action";
            this.actionColumn.Name = "actionColumn";
            // 
            // simulationPanel
            // 
            this.simulationPanel.BackColor = System.Drawing.Color.DarkSlateGray;
            this.simulationPanel.Location = new System.Drawing.Point(3, 3);
            this.simulationPanel.Name = "simulationPanel";
            this.simulationPanel.Size = new System.Drawing.Size(882, 680);
            this.simulationPanel.TabIndex = 1;
            this.simulationPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.simulationPanel_Paint);
            // 
            // CartDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 701);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CartDemo";
            this.Text = "Tangible Grocery Cart Simulator";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.userProfilePanel.ResumeLayout(false);
            this.userProfilePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userIconPictureBox)).EndInit();
            this.activeSelectionPanel.ResumeLayout(false);
            this.activeSelectionPanel.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activeItemPictureBox)).EndInit();
            this.shoppingCartPanel.ResumeLayout(false);
            this.shoppingCartPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shoppingCartGrid)).EndInit();
            this.cartSummaryPanel.ResumeLayout(false);
            this.cartSummaryPanel.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.buttonPanel.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel userProfilePanel;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.PictureBox userIconPictureBox;
        private System.Windows.Forms.Label userProfleLabel;
        private System.Windows.Forms.Panel activeSelectionPanel;
        private System.Windows.Forms.Label activeSelectionLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button nextItemButton;
        private System.Windows.Forms.Button prevItemButton;
        private System.Windows.Forms.PictureBox activeItemPictureBox;
        private System.Windows.Forms.Label activeSelectionLbl;
        private System.Windows.Forms.Panel shoppingCartPanel;
        private System.Windows.Forms.Label ShoppingCartLabel;
        private System.Windows.Forms.Panel cartSummaryPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label SubtotalLbl;
        private System.Windows.Forms.Label subtotalLabelval;
        private System.Windows.Forms.Label taxLabel;
        private System.Windows.Forms.Label taxLabelval;
        private System.Windows.Forms.Label TotalLabel;
        private System.Windows.Forms.Label totalLabelval;
        private System.Windows.Forms.Label cartSummaryLabel;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button checkoutButton;
        private System.Windows.Forms.Button clearCartButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private TangibleCartSimulator.DoubleBufferedPanel simulationPanel;
        private System.Windows.Forms.DataGridView shoppingCartGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTotalColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionColumn;
    }
}