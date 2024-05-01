namespace Stock_Inventory
{
    partial class OutwardsDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutwardsDataForm));
            this.outwardsDataGridView = new Krypton.Toolkit.KryptonDataGridView();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.productComboBox = new Krypton.Toolkit.KryptonComboBox();
            this.endDatePicker = new Krypton.Toolkit.KryptonDateTimePicker();
            this.startDatePicker = new Krypton.Toolkit.KryptonDateTimePicker();
            this.partyComboBox = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.outwardsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partyComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // outwardsDataGridView
            // 
            this.outwardsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.outwardsDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.outwardsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.outwardsDataGridView.Location = new System.Drawing.Point(0, 87);
            this.outwardsDataGridView.Name = "outwardsDataGridView";
            this.outwardsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.outwardsDataGridView.Size = new System.Drawing.Size(902, 556);
            this.outwardsDataGridView.TabIndex = 0;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(17, 9);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(39, 20);
            this.kryptonLabel2.TabIndex = 10;
            this.kryptonLabel2.Values.Text = "From";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(201, 9);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(24, 20);
            this.kryptonLabel1.TabIndex = 9;
            this.kryptonLabel1.Values.Text = "To";
            // 
            // productComboBox
            // 
            this.productComboBox.CornerRoundingRadius = -1F;
            this.productComboBox.DropDownWidth = 144;
            this.productComboBox.IntegralHeight = false;
            this.productComboBox.Location = new System.Drawing.Point(476, 39);
            this.productComboBox.Name = "productComboBox";
            this.productComboBox.Size = new System.Drawing.Size(210, 21);
            this.productComboBox.Sorted = true;
            this.productComboBox.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.productComboBox.TabIndex = 8;
            this.productComboBox.Text = "Select Product Name";
            // 
            // endDatePicker
            // 
            this.endDatePicker.CornerRoundingRadius = -1F;
            this.endDatePicker.Location = new System.Drawing.Point(230, 9);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(137, 21);
            this.endDatePicker.TabIndex = 7;
            // 
            // startDatePicker
            // 
            this.startDatePicker.CornerRoundingRadius = -1F;
            this.startDatePicker.Location = new System.Drawing.Point(60, 9);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(135, 21);
            this.startDatePicker.TabIndex = 6;
            this.startDatePicker.ValueNullable = new System.DateTime(2023, 10, 1, 12, 0, 0, 0);
            // 
            // partyComboBox
            // 
            this.partyComboBox.CornerRoundingRadius = -1F;
            this.partyComboBox.DropDownWidth = 144;
            this.partyComboBox.IntegralHeight = false;
            this.partyComboBox.Location = new System.Drawing.Point(739, 39);
            this.partyComboBox.Name = "partyComboBox";
            this.partyComboBox.Size = new System.Drawing.Size(144, 21);
            this.partyComboBox.Sorted = true;
            this.partyComboBox.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.partyComboBox.TabIndex = 11;
            this.partyComboBox.Text = "Select Party";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.GroupBackStyle = Krypton.Toolkit.PaletteBackStyle.ButtonForm;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(12, 8);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.startDatePicker);
            this.kryptonGroupBox1.Panel.Controls.Add(this.endDatePicker);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel2);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(394, 60);
            this.kryptonGroupBox1.TabIndex = 12;
            this.kryptonGroupBox1.Values.Heading = "DATE FILTER";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(417, 40);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(53, 20);
            this.kryptonLabel3.TabIndex = 13;
            this.kryptonLabel3.Values.Text = "Product";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(695, 40);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(38, 20);
            this.kryptonLabel4.TabIndex = 14;
            this.kryptonLabel4.Values.Text = "Party";
            // 
            // OutwardsDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 643);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.kryptonGroupBox1);
            this.Controls.Add(this.partyComboBox);
            this.Controls.Add(this.productComboBox);
            this.Controls.Add(this.outwardsDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OutwardsDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OUTWARDS DATA";
            ((System.ComponentModel.ISupportInitialize)(this.outwardsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partyComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonDataGridView outwardsDataGridView;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonComboBox productComboBox;
        private Krypton.Toolkit.KryptonDateTimePicker endDatePicker;
        private Krypton.Toolkit.KryptonDateTimePicker startDatePicker;
        private Krypton.Toolkit.KryptonComboBox partyComboBox;
        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
    }
}