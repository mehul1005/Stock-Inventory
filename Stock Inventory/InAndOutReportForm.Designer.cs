namespace Stock_Inventory
{
    partial class InAndOutReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InAndOutReportForm));
            this.reportDataGridView = new Krypton.Toolkit.KryptonDataGridView();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.endDatePicker = new Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.startDatePicker = new Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.productComboBox = new Krypton.Toolkit.KryptonComboBox();
            this.lblParty = new Krypton.Toolkit.KryptonLabel();
            this.cmbPartyNo = new Krypton.Toolkit.KryptonComboBox();
            this.ClearFilterButton = new Krypton.Toolkit.KryptonButton();
            this.printButton = new Krypton.Toolkit.KryptonButton();
            this.lblCurrentStock = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.reportDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPartyNo)).BeginInit();
            this.SuspendLayout();
            // 
            // reportDataGridView
            // 
            this.reportDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.reportDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.reportDataGridView.Location = new System.Drawing.Point(12, 87);
            this.reportDataGridView.Name = "reportDataGridView";
            this.reportDataGridView.Size = new System.Drawing.Size(1249, 815);
            this.reportDataGridView.TabIndex = 0;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(426, 39);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(53, 20);
            this.kryptonLabel4.TabIndex = 17;
            this.kryptonLabel4.Values.Text = "Product";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.GroupBackStyle = Krypton.Toolkit.PaletteBackStyle.ButtonForm;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(12, 8);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.endDatePicker);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel5);
            this.kryptonGroupBox1.Panel.Controls.Add(this.startDatePicker);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel6);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(394, 60);
            this.kryptonGroupBox1.TabIndex = 16;
            this.kryptonGroupBox1.Values.Heading = "DATE FILTER";
            // 
            // endDatePicker
            // 
            this.endDatePicker.CornerRoundingRadius = -1F;
            this.endDatePicker.Location = new System.Drawing.Point(232, 9);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(137, 21);
            this.endDatePicker.TabIndex = 2;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(19, 9);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(39, 20);
            this.kryptonLabel5.TabIndex = 5;
            this.kryptonLabel5.Values.Text = "From";
            // 
            // startDatePicker
            // 
            this.startDatePicker.CornerRoundingRadius = -1F;
            this.startDatePicker.Location = new System.Drawing.Point(62, 9);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(135, 21);
            this.startDatePicker.TabIndex = 1;
            this.startDatePicker.ValueNullable = new System.DateTime(2023, 10, 1, 0, 0, 0, 0);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(203, 9);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(24, 20);
            this.kryptonLabel6.TabIndex = 4;
            this.kryptonLabel6.Values.Text = "To";
            // 
            // productComboBox
            // 
            this.productComboBox.CornerRoundingRadius = -1F;
            this.productComboBox.DropDownWidth = 144;
            this.productComboBox.IntegralHeight = false;
            this.productComboBox.Location = new System.Drawing.Point(485, 39);
            this.productComboBox.Name = "productComboBox";
            this.productComboBox.Size = new System.Drawing.Size(259, 21);
            this.productComboBox.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.productComboBox.TabIndex = 15;
            this.productComboBox.Text = "Select Product Name";
            this.productComboBox.SelectedIndexChanged += new System.EventHandler(this.productComboBox_SelectedIndexChanged);
            // 
            // lblParty
            // 
            this.lblParty.Location = new System.Drawing.Point(754, 39);
            this.lblParty.Name = "lblParty";
            this.lblParty.Size = new System.Drawing.Size(38, 20);
            this.lblParty.TabIndex = 19;
            this.lblParty.Values.Text = "Party";
            // 
            // cmbPartyNo
            // 
            this.cmbPartyNo.CornerRoundingRadius = -1F;
            this.cmbPartyNo.DropDownWidth = 144;
            this.cmbPartyNo.IntegralHeight = false;
            this.cmbPartyNo.Location = new System.Drawing.Point(798, 39);
            this.cmbPartyNo.Name = "cmbPartyNo";
            this.cmbPartyNo.Size = new System.Drawing.Size(144, 21);
            this.cmbPartyNo.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.cmbPartyNo.TabIndex = 18;
            this.cmbPartyNo.Text = "Select Party";
            // 
            // ClearFilterButton
            // 
            this.ClearFilterButton.CornerRoundingRadius = -1F;
            this.ClearFilterButton.Location = new System.Drawing.Point(964, 36);
            this.ClearFilterButton.Name = "ClearFilterButton";
            this.ClearFilterButton.Size = new System.Drawing.Size(90, 25);
            this.ClearFilterButton.TabIndex = 20;
            this.ClearFilterButton.Values.Text = "Clear Filter";
            this.ClearFilterButton.Click += new System.EventHandler(this.ClearFilterButton_Click);
            // 
            // printButton
            // 
            this.printButton.ButtonStyle = Krypton.Toolkit.ButtonStyle.NavigatorMini;
            this.printButton.CornerRoundingRadius = -1F;
            this.printButton.Location = new System.Drawing.Point(1171, 36);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(90, 25);
            this.printButton.TabIndex = 21;
            this.printButton.Values.Text = "Print";
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // lblCurrentStock
            // 
            this.lblCurrentStock.LabelStyle = Krypton.Toolkit.LabelStyle.TitlePanel;
            this.lblCurrentStock.Location = new System.Drawing.Point(1055, 906);
            this.lblCurrentStock.Name = "lblCurrentStock";
            this.lblCurrentStock.Size = new System.Drawing.Size(166, 29);
            this.lblCurrentStock.TabIndex = 22;
            this.lblCurrentStock.Values.Text = "CURRENT STOCK:";
            // 
            // InAndOutReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 939);
            this.Controls.Add(this.lblCurrentStock);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.ClearFilterButton);
            this.Controls.Add(this.lblParty);
            this.Controls.Add(this.cmbPartyNo);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.kryptonGroupBox1);
            this.Controls.Add(this.productComboBox);
            this.Controls.Add(this.reportDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InAndOutReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InAndOutReportForm";
            ((System.ComponentModel.ISupportInitialize)(this.reportDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPartyNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonDataGridView reportDataGridView;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private Krypton.Toolkit.KryptonDateTimePicker endDatePicker;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonDateTimePicker startDatePicker;
        private Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private Krypton.Toolkit.KryptonComboBox productComboBox;
        private Krypton.Toolkit.KryptonLabel lblParty;
        private Krypton.Toolkit.KryptonComboBox cmbPartyNo;
        private Krypton.Toolkit.KryptonButton ClearFilterButton;
        private Krypton.Toolkit.KryptonButton printButton;
        private Krypton.Toolkit.KryptonLabel lblCurrentStock;
    }
}