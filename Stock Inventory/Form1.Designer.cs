namespace Stock_Inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridViewProducts = new Krypton.Toolkit.KryptonDataGridView();
            this.btnAddNewStock = new Krypton.Toolkit.KryptonButton();
            this.btnAddStockOutForm = new Krypton.Toolkit.KryptonButton();
            this.btnViewInwardsData = new Krypton.Toolkit.KryptonButton();
            this.btnViewOutwardsData = new Krypton.Toolkit.KryptonButton();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.kryptonGroupBox2 = new Krypton.Toolkit.KryptonGroupBox();
            this.btnGetReport = new Krypton.Toolkit.KryptonButton();
            this.btnViewDataGrid = new Krypton.Toolkit.KryptonButton();
            this.kryptonGroupBox3 = new Krypton.Toolkit.KryptonGroupBox();
            this.btnSearchProduct = new Krypton.Toolkit.KryptonButton();
            this.txtProductItem = new Krypton.Toolkit.KryptonTextBox();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.btnEditEntries = new Krypton.Toolkit.KryptonButton();
            this.kryptonGroupBox4 = new Krypton.Toolkit.KryptonGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3.Panel)).BeginInit();
            this.kryptonGroupBox3.Panel.SuspendLayout();
            this.kryptonGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox4.Panel)).BeginInit();
            this.kryptonGroupBox4.Panel.SuspendLayout();
            this.kryptonGroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProducts.ColumnHeadersHeight = 35;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewProducts.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewProducts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewProducts.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProducts.Size = new System.Drawing.Size(698, 939);
            this.dataGridViewProducts.TabIndex = 0;
            // 
            // btnAddNewStock
            // 
            this.btnAddNewStock.CornerRoundingRadius = -1F;
            this.btnAddNewStock.Location = new System.Drawing.Point(101, 26);
            this.btnAddNewStock.Name = "btnAddNewStock";
            this.btnAddNewStock.Size = new System.Drawing.Size(326, 25);
            this.btnAddNewStock.TabIndex = 8;
            this.btnAddNewStock.Values.Text = "STOCK IN NEW PRODUCT";
            this.btnAddNewStock.Click += new System.EventHandler(this.btnAddNewStock_Click);
            // 
            // btnAddStockOutForm
            // 
            this.btnAddStockOutForm.CornerRoundingRadius = -1F;
            this.btnAddStockOutForm.Location = new System.Drawing.Point(101, 70);
            this.btnAddStockOutForm.Name = "btnAddStockOutForm";
            this.btnAddStockOutForm.Size = new System.Drawing.Size(326, 25);
            this.btnAddStockOutForm.TabIndex = 9;
            this.btnAddStockOutForm.Values.Text = "OUT PRODUCT FROM STOCK";
            this.btnAddStockOutForm.Click += new System.EventHandler(this.btnAddStockOutForm_Click);
            // 
            // btnViewInwardsData
            // 
            this.btnViewInwardsData.CornerRoundingRadius = -1F;
            this.btnViewInwardsData.Location = new System.Drawing.Point(101, 26);
            this.btnViewInwardsData.Name = "btnViewInwardsData";
            this.btnViewInwardsData.Size = new System.Drawing.Size(326, 25);
            this.btnViewInwardsData.TabIndex = 10;
            this.btnViewInwardsData.Values.Text = "VIEW INWARDS DATA";
            this.btnViewInwardsData.Click += new System.EventHandler(this.btnViewInwardsData_Click);
            // 
            // btnViewOutwardsData
            // 
            this.btnViewOutwardsData.CornerRoundingRadius = -1F;
            this.btnViewOutwardsData.Location = new System.Drawing.Point(101, 70);
            this.btnViewOutwardsData.Name = "btnViewOutwardsData";
            this.btnViewOutwardsData.Size = new System.Drawing.Size(326, 25);
            this.btnViewOutwardsData.TabIndex = 11;
            this.btnViewOutwardsData.Values.Text = "VIEW OUTWARDS DATA";
            this.btnViewOutwardsData.Click += new System.EventHandler(this.btnViewOutwardsData_Click);
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.CaptionStyle = Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonGroupBox1.GroupBackStyle = Krypton.Toolkit.PaletteBackStyle.ButtonForm;
            this.kryptonGroupBox1.GroupBorderStyle = Krypton.Toolkit.PaletteBorderStyle.ControlRibbonAppMenu;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(716, 182);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            this.kryptonGroupBox1.PaletteMode = Krypton.Toolkit.PaletteMode.Office365White;
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.btnAddNewStock);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btnAddStockOutForm);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(535, 147);
            this.kryptonGroupBox1.TabIndex = 5;
            this.kryptonGroupBox1.Values.Heading = "STOCK MAINTAIN";
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.CaptionStyle = Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonGroupBox2.GroupBackStyle = Krypton.Toolkit.PaletteBackStyle.ButtonForm;
            this.kryptonGroupBox2.GroupBorderStyle = Krypton.Toolkit.PaletteBorderStyle.ControlRibbonAppMenu;
            this.kryptonGroupBox2.Location = new System.Drawing.Point(716, 355);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            this.kryptonGroupBox2.PaletteMode = Krypton.Toolkit.PaletteMode.Office365White;
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.btnGetReport);
            this.kryptonGroupBox2.Panel.Controls.Add(this.btnViewInwardsData);
            this.kryptonGroupBox2.Panel.Controls.Add(this.btnViewOutwardsData);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(535, 188);
            this.kryptonGroupBox2.TabIndex = 6;
            this.kryptonGroupBox2.Values.Heading = "VIEW INWARDS / OUTWARDS DATA";
            // 
            // btnGetReport
            // 
            this.btnGetReport.CornerRoundingRadius = -1F;
            this.btnGetReport.Location = new System.Drawing.Point(101, 115);
            this.btnGetReport.Name = "btnGetReport";
            this.btnGetReport.Size = new System.Drawing.Size(326, 25);
            this.btnGetReport.TabIndex = 12;
            this.btnGetReport.Values.Text = "GET REPORT";
            this.btnGetReport.Click += new System.EventHandler(this.btnGetReport_Click);
            // 
            // btnViewDataGrid
            // 
            this.btnViewDataGrid.CornerRoundingRadius = -1F;
            this.btnViewDataGrid.Location = new System.Drawing.Point(101, 61);
            this.btnViewDataGrid.Name = "btnViewDataGrid";
            this.btnViewDataGrid.Size = new System.Drawing.Size(326, 25);
            this.btnViewDataGrid.TabIndex = 7;
            this.btnViewDataGrid.Values.Text = "SHOW PRODUCT MASTER";
            this.btnViewDataGrid.Click += new System.EventHandler(this.btnViewDataGrid_Click);
            // 
            // kryptonGroupBox3
            // 
            this.kryptonGroupBox3.CaptionStyle = Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonGroupBox3.GroupBackStyle = Krypton.Toolkit.PaletteBackStyle.ButtonForm;
            this.kryptonGroupBox3.GroupBorderStyle = Krypton.Toolkit.PaletteBorderStyle.ControlRibbonAppMenu;
            this.kryptonGroupBox3.Location = new System.Drawing.Point(716, 29);
            this.kryptonGroupBox3.Name = "kryptonGroupBox3";
            // 
            // kryptonGroupBox3.Panel
            // 
            this.kryptonGroupBox3.Panel.Controls.Add(this.btnSearchProduct);
            this.kryptonGroupBox3.Panel.Controls.Add(this.btnViewDataGrid);
            this.kryptonGroupBox3.Panel.Controls.Add(this.txtProductItem);
            this.kryptonGroupBox3.Size = new System.Drawing.Size(535, 131);
            this.kryptonGroupBox3.TabIndex = 4;
            this.kryptonGroupBox3.Values.Heading = "PRODUCT MASTER";
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.CornerRoundingRadius = -1F;
            this.btnSearchProduct.Location = new System.Drawing.Point(337, 21);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(90, 25);
            this.btnSearchProduct.TabIndex = 6;
            this.btnSearchProduct.Values.Text = "SEARCH";
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // txtProductItem
            // 
            this.txtProductItem.AllowDrop = true;
            this.txtProductItem.Location = new System.Drawing.Point(101, 23);
            this.txtProductItem.Name = "txtProductItem";
            this.txtProductItem.Size = new System.Drawing.Size(230, 23);
            this.txtProductItem.TabIndex = 5;
            this.txtProductItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductItem_KeyDown);
            // 
            // pieChart1
            // 
            this.pieChart1.Location = new System.Drawing.Point(0, 0);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(684, 939);
            this.pieChart1.TabIndex = 14;
            this.pieChart1.Text = "pieChart1";
            // 
            // btnEditEntries
            // 
            this.btnEditEntries.CornerRoundingRadius = -1F;
            this.btnEditEntries.Location = new System.Drawing.Point(100, 26);
            this.btnEditEntries.Name = "btnEditEntries";
            this.btnEditEntries.Size = new System.Drawing.Size(326, 25);
            this.btnEditEntries.TabIndex = 13;
            this.btnEditEntries.Values.Text = "EDIT ENTRIES";
            this.btnEditEntries.Click += new System.EventHandler(this.btnEditEntries_Click);
            // 
            // kryptonGroupBox4
            // 
            this.kryptonGroupBox4.CaptionStyle = Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonGroupBox4.GroupBackStyle = Krypton.Toolkit.PaletteBackStyle.ButtonForm;
            this.kryptonGroupBox4.GroupBorderStyle = Krypton.Toolkit.PaletteBorderStyle.ControlRibbonAppMenu;
            this.kryptonGroupBox4.Location = new System.Drawing.Point(717, 572);
            this.kryptonGroupBox4.Name = "kryptonGroupBox4";
            // 
            // kryptonGroupBox4.Panel
            // 
            this.kryptonGroupBox4.Panel.Controls.Add(this.btnEditEntries);
            this.kryptonGroupBox4.Size = new System.Drawing.Size(535, 97);
            this.kryptonGroupBox4.TabIndex = 7;
            this.kryptonGroupBox4.Values.Heading = "EDIT MODE";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 939);
            this.Controls.Add(this.kryptonGroupBox4);
            this.Controls.Add(this.pieChart1);
            this.Controls.Add(this.kryptonGroupBox3);
            this.Controls.Add(this.kryptonGroupBox2);
            this.Controls.Add(this.kryptonGroupBox1);
            this.Controls.Add(this.dataGridViewProducts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STOCK INVENTORY";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3.Panel)).EndInit();
            this.kryptonGroupBox3.Panel.ResumeLayout(false);
            this.kryptonGroupBox3.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).EndInit();
            this.kryptonGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox4.Panel)).EndInit();
            this.kryptonGroupBox4.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox4)).EndInit();
            this.kryptonGroupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonDataGridView dataGridViewProducts;
        private Krypton.Toolkit.KryptonButton btnAddNewStock;
        private Krypton.Toolkit.KryptonButton btnAddStockOutForm;
        private Krypton.Toolkit.KryptonButton btnViewInwardsData;
        private Krypton.Toolkit.KryptonButton btnViewOutwardsData;
        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox2;
        private Krypton.Toolkit.KryptonButton btnViewDataGrid;
        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox3;
        private Krypton.Toolkit.KryptonButton btnGetReport;
        private LiveCharts.WinForms.PieChart pieChart1;
        private Krypton.Toolkit.KryptonTextBox txtProductItem;
        private Krypton.Toolkit.KryptonButton btnSearchProduct;
        private Krypton.Toolkit.KryptonButton btnEditEntries;
        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox4;
    }
}

