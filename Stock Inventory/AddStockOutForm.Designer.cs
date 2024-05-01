namespace Stock_Inventory
{
    partial class AddStockOutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddStockOutForm));
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.txtQuantityToRemove = new Krypton.Toolkit.KryptonTextBox();
            this.btnSave = new Krypton.Toolkit.KryptonButton();
            this.cmbProductOutNames = new Krypton.Toolkit.KryptonComboBox();
            this.lblDetails = new Krypton.Toolkit.KryptonLabel();
            this.txtProductOutDetails = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonHeader1 = new Krypton.Toolkit.KryptonHeader();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.cmbPartyNo = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonSeparator1 = new Krypton.Toolkit.KryptonSeparator();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.txtClientName = new Krypton.Toolkit.KryptonTextBox();
            this.btnAddNewParty = new Krypton.Toolkit.KryptonButton();
            this.kryptonHeader2 = new Krypton.Toolkit.KryptonHeader();
            this.cmbMachineNo = new Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProductOutNames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPartyNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMachineNo)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(14, 112);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(103, 20);
            this.kryptonLabel2.TabIndex = 9;
            this.kryptonLabel2.Values.Text = "Product Quantity";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(14, 71);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(89, 20);
            this.kryptonLabel1.TabIndex = 8;
            this.kryptonLabel1.Values.Text = "Product Name";
            // 
            // txtQuantityToRemove
            // 
            this.txtQuantityToRemove.Location = new System.Drawing.Point(122, 109);
            this.txtQuantityToRemove.Name = "txtQuantityToRemove";
            this.txtQuantityToRemove.Size = new System.Drawing.Size(281, 23);
            this.txtQuantityToRemove.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.CornerRoundingRadius = -1F;
            this.btnSave.Location = new System.Drawing.Point(286, 294);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 25);
            this.btnSave.TabIndex = 13;
            this.btnSave.Values.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbProductOutNames
            // 
            this.cmbProductOutNames.CornerRoundingRadius = -1F;
            this.cmbProductOutNames.DropDownWidth = 281;
            this.cmbProductOutNames.IntegralHeight = false;
            this.cmbProductOutNames.Location = new System.Drawing.Point(122, 71);
            this.cmbProductOutNames.Name = "cmbProductOutNames";
            this.cmbProductOutNames.Size = new System.Drawing.Size(281, 21);
            this.cmbProductOutNames.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.cmbProductOutNames.TabIndex = 6;
            // 
            // lblDetails
            // 
            this.lblDetails.Location = new System.Drawing.Point(14, 225);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(57, 20);
            this.lblDetails.TabIndex = 13;
            this.lblDetails.Values.Text = "Remarks";
            // 
            // txtProductOutDetails
            // 
            this.txtProductOutDetails.Location = new System.Drawing.Point(122, 225);
            this.txtProductOutDetails.Multiline = true;
            this.txtProductOutDetails.Name = "txtProductOutDetails";
            this.txtProductOutDetails.Size = new System.Drawing.Size(281, 47);
            this.txtProductOutDetails.TabIndex = 12;
            // 
            // kryptonHeader1
            // 
            this.kryptonHeader1.Location = new System.Drawing.Point(14, 13);
            this.kryptonHeader1.Name = "kryptonHeader1";
            this.kryptonHeader1.Size = new System.Drawing.Size(321, 31);
            this.kryptonHeader1.TabIndex = 14;
            this.kryptonHeader1.Values.Description = "";
            this.kryptonHeader1.Values.Heading = "OUT PRODUCT FROM STOCK DATA";
            this.kryptonHeader1.Values.Image = null;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(14, 188);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(80, 20);
            this.kryptonLabel3.TabIndex = 16;
            this.kryptonLabel3.Values.Text = "Machine No.";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(14, 150);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(61, 20);
            this.kryptonLabel4.TabIndex = 18;
            this.kryptonLabel4.Values.Text = "Party No.";
            // 
            // cmbPartyNo
            // 
            this.cmbPartyNo.CornerRoundingRadius = -1F;
            this.cmbPartyNo.DropDownWidth = 281;
            this.cmbPartyNo.IntegralHeight = false;
            this.cmbPartyNo.Location = new System.Drawing.Point(122, 149);
            this.cmbPartyNo.Name = "cmbPartyNo";
            this.cmbPartyNo.Size = new System.Drawing.Size(281, 21);
            this.cmbPartyNo.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.cmbPartyNo.TabIndex = 8;
            // 
            // kryptonSeparator1
            // 
            this.kryptonSeparator1.Location = new System.Drawing.Point(12, 353);
            this.kryptonSeparator1.Name = "kryptonSeparator1";
            this.kryptonSeparator1.Size = new System.Drawing.Size(400, 10);
            this.kryptonSeparator1.TabIndex = 20;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(14, 444);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(102, 20);
            this.kryptonLabel5.TabIndex = 22;
            this.kryptonLabel5.Values.Text = "New Party Name";
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(122, 441);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(281, 23);
            this.txtClientName.TabIndex = 21;
            // 
            // btnAddNewParty
            // 
            this.btnAddNewParty.CornerRoundingRadius = -1F;
            this.btnAddNewParty.Location = new System.Drawing.Point(286, 480);
            this.btnAddNewParty.Name = "btnAddNewParty";
            this.btnAddNewParty.Size = new System.Drawing.Size(117, 25);
            this.btnAddNewParty.TabIndex = 23;
            this.btnAddNewParty.Values.Text = "Add";
            this.btnAddNewParty.Click += new System.EventHandler(this.btnAddNewParty_Click);
            // 
            // kryptonHeader2
            // 
            this.kryptonHeader2.Location = new System.Drawing.Point(14, 384);
            this.kryptonHeader2.Name = "kryptonHeader2";
            this.kryptonHeader2.Size = new System.Drawing.Size(237, 31);
            this.kryptonHeader2.TabIndex = 24;
            this.kryptonHeader2.Values.Description = "";
            this.kryptonHeader2.Values.Heading = "ADD NEW PARTY TO LIST";
            this.kryptonHeader2.Values.Image = null;
            // 
            // cmbMachineNo
            // 
            this.cmbMachineNo.CornerRoundingRadius = -1F;
            this.cmbMachineNo.DropDownWidth = 281;
            this.cmbMachineNo.IntegralHeight = false;
            this.cmbMachineNo.Location = new System.Drawing.Point(122, 188);
            this.cmbMachineNo.Name = "cmbMachineNo";
            this.cmbMachineNo.Size = new System.Drawing.Size(281, 21);
            this.cmbMachineNo.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.cmbMachineNo.TabIndex = 11;
            // 
            // AddStockOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 534);
            this.Controls.Add(this.cmbMachineNo);
            this.Controls.Add(this.kryptonHeader2);
            this.Controls.Add(this.btnAddNewParty);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.kryptonSeparator1);
            this.Controls.Add(this.cmbPartyNo);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.kryptonHeader1);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.txtProductOutDetails);
            this.Controls.Add(this.cmbProductOutNames);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.txtQuantityToRemove);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddStockOutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Out Product";
            ((System.ComponentModel.ISupportInitialize)(this.cmbProductOutNames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPartyNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMachineNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonTextBox txtQuantityToRemove;
        private Krypton.Toolkit.KryptonButton btnSave;
        private Krypton.Toolkit.KryptonComboBox cmbProductOutNames;
        private Krypton.Toolkit.KryptonLabel lblDetails;
        private Krypton.Toolkit.KryptonTextBox txtProductOutDetails;
        private Krypton.Toolkit.KryptonHeader kryptonHeader1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonComboBox cmbPartyNo;
        private Krypton.Toolkit.KryptonSeparator kryptonSeparator1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonTextBox txtClientName;
        private Krypton.Toolkit.KryptonButton btnAddNewParty;
        private Krypton.Toolkit.KryptonHeader kryptonHeader2;
        private Krypton.Toolkit.KryptonComboBox cmbMachineNo;
    }
}