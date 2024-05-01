namespace Stock_Inventory
{
    partial class AddNewStockForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewStockForm));
            this.btnSave = new Krypton.Toolkit.KryptonButton();
            this.txtQuantity = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonHeader1 = new Krypton.Toolkit.KryptonHeader();
            this.txtNewProductNames = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.addNewProductName = new Krypton.Toolkit.KryptonButton();
            this.txtProductDetails = new Krypton.Toolkit.KryptonTextBox();
            this.lblDetails = new Krypton.Toolkit.KryptonLabel();
            this.kryptonHeader2 = new Krypton.Toolkit.KryptonHeader();
            this.kryptonSeparator1 = new Krypton.Toolkit.KryptonSeparator();
            this.cmbProductNames = new Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProductNames)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.CornerRoundingRadius = -1F;
            this.btnSave.Location = new System.Drawing.Point(329, 207);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 25);
            this.btnSave.TabIndex = 4;
            this.btnSave.Values.Text = "Add New Stock";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(122, 107);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(334, 23);
            this.txtQuantity.TabIndex = 2;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(14, 71);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(89, 20);
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.Text = "Product Name";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(14, 107);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(103, 20);
            this.kryptonLabel2.TabIndex = 4;
            this.kryptonLabel2.Values.Text = "Product Quantity";
            // 
            // kryptonHeader1
            // 
            this.kryptonHeader1.Location = new System.Drawing.Point(14, 350);
            this.kryptonHeader1.Name = "kryptonHeader1";
            this.kryptonHeader1.Size = new System.Drawing.Size(325, 31);
            this.kryptonHeader1.TabIndex = 6;
            this.kryptonHeader1.Values.Description = "";
            this.kryptonHeader1.Values.Heading = "ADD NEW PRODUCT NAME TO LIST";
            this.kryptonHeader1.Values.Image = null;
            // 
            // txtNewProductNames
            // 
            this.txtNewProductNames.Location = new System.Drawing.Point(122, 409);
            this.txtNewProductNames.Name = "txtNewProductNames";
            this.txtNewProductNames.Size = new System.Drawing.Size(334, 23);
            this.txtNewProductNames.TabIndex = 7;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(14, 409);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(89, 20);
            this.kryptonLabel3.TabIndex = 8;
            this.kryptonLabel3.Values.Text = "Product Name";
            // 
            // addNewProductName
            // 
            this.addNewProductName.CornerRoundingRadius = -1F;
            this.addNewProductName.Location = new System.Drawing.Point(306, 447);
            this.addNewProductName.Name = "addNewProductName";
            this.addNewProductName.Size = new System.Drawing.Size(150, 25);
            this.addNewProductName.TabIndex = 9;
            this.addNewProductName.Values.Text = "Add New Product Name";
            this.addNewProductName.Click += new System.EventHandler(this.addNewProductName_Click);
            // 
            // txtProductDetails
            // 
            this.txtProductDetails.Location = new System.Drawing.Point(122, 144);
            this.txtProductDetails.Multiline = true;
            this.txtProductDetails.Name = "txtProductDetails";
            this.txtProductDetails.Size = new System.Drawing.Size(334, 47);
            this.txtProductDetails.TabIndex = 3;
            // 
            // lblDetails
            // 
            this.lblDetails.Location = new System.Drawing.Point(14, 144);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(57, 20);
            this.lblDetails.TabIndex = 11;
            this.lblDetails.Values.Text = "Remarks";
            // 
            // kryptonHeader2
            // 
            this.kryptonHeader2.Location = new System.Drawing.Point(14, 14);
            this.kryptonHeader2.Name = "kryptonHeader2";
            this.kryptonHeader2.Size = new System.Drawing.Size(442, 31);
            this.kryptonHeader2.TabIndex = 12;
            this.kryptonHeader2.Values.Description = "";
            this.kryptonHeader2.Values.Heading = "ADD NEW PRODUCT QUANTITY TO STOCK DATA";
            this.kryptonHeader2.Values.Image = null;
            // 
            // kryptonSeparator1
            // 
            this.kryptonSeparator1.Location = new System.Drawing.Point(21, 303);
            this.kryptonSeparator1.Name = "kryptonSeparator1";
            this.kryptonSeparator1.Size = new System.Drawing.Size(424, 10);
            this.kryptonSeparator1.TabIndex = 13;
            // 
            // cmbProductNames
            // 
            this.cmbProductNames.CornerRoundingRadius = -1F;
            this.cmbProductNames.DropDownWidth = 281;
            this.cmbProductNames.IntegralHeight = false;
            this.cmbProductNames.Location = new System.Drawing.Point(122, 71);
            this.cmbProductNames.Name = "cmbProductNames";
            this.cmbProductNames.Size = new System.Drawing.Size(334, 21);
            this.cmbProductNames.Sorted = true;
            this.cmbProductNames.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.cmbProductNames.TabIndex = 1;
            // 
            // AddNewStockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 499);
            this.Controls.Add(this.kryptonSeparator1);
            this.Controls.Add(this.kryptonHeader2);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.txtProductDetails);
            this.Controls.Add(this.addNewProductName);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.txtNewProductNames);
            this.Controls.Add(this.kryptonHeader1);
            this.Controls.Add(this.cmbProductNames);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddNewStockForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Stock";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProductNames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonButton btnSave;
        private Krypton.Toolkit.KryptonTextBox txtQuantity;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonHeader kryptonHeader1;
        private Krypton.Toolkit.KryptonTextBox txtNewProductNames;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonButton addNewProductName;
        private Krypton.Toolkit.KryptonTextBox txtProductDetails;
        private Krypton.Toolkit.KryptonLabel lblDetails;
        private Krypton.Toolkit.KryptonHeader kryptonHeader2;
        private Krypton.Toolkit.KryptonSeparator kryptonSeparator1;
        private Krypton.Toolkit.KryptonComboBox cmbProductNames;
    }
}