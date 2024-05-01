namespace Stock_Inventory
{
    partial class InwardsDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InwardsDataForm));
            this.inwardsDataGridView = new Krypton.Toolkit.KryptonDataGridView();
            this.startDatePicker = new Krypton.Toolkit.KryptonDateTimePicker();
            this.endDatePicker = new Krypton.Toolkit.KryptonDateTimePicker();
            this.productComboBox = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.EditButton = new Krypton.Toolkit.KryptonButton();
            this.SaveButton = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.inwardsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inwardsDataGridView
            // 
            this.inwardsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.inwardsDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.inwardsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.inwardsDataGridView.Location = new System.Drawing.Point(0, 90);
            this.inwardsDataGridView.Name = "inwardsDataGridView";
            this.inwardsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.inwardsDataGridView.Size = new System.Drawing.Size(902, 553);
            this.inwardsDataGridView.TabIndex = 0;
            // 
            // startDatePicker
            // 
            this.startDatePicker.CornerRoundingRadius = -1F;
            this.startDatePicker.Location = new System.Drawing.Point(62, 9);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(135, 21);
            this.startDatePicker.TabIndex = 1;
            this.startDatePicker.ValueNullable = new System.DateTime(2023, 10, 1, 12, 0, 0, 0);
            // 
            // endDatePicker
            // 
            this.endDatePicker.CornerRoundingRadius = -1F;
            this.endDatePicker.Location = new System.Drawing.Point(232, 9);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(137, 21);
            this.endDatePicker.TabIndex = 2;
            // 
            // productComboBox
            // 
            this.productComboBox.CornerRoundingRadius = -1F;
            this.productComboBox.DropDownWidth = 144;
            this.productComboBox.IntegralHeight = false;
            this.productComboBox.Location = new System.Drawing.Point(494, 43);
            this.productComboBox.Name = "productComboBox";
            this.productComboBox.Size = new System.Drawing.Size(245, 21);
            this.productComboBox.Sorted = true;
            this.productComboBox.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.productComboBox.TabIndex = 3;
            this.productComboBox.Text = "Select Product Name";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(203, 9);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(24, 20);
            this.kryptonLabel1.TabIndex = 4;
            this.kryptonLabel1.Values.Text = "To";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(19, 9);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(39, 20);
            this.kryptonLabel2.TabIndex = 5;
            this.kryptonLabel2.Values.Text = "From";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.GroupBackStyle = Krypton.Toolkit.PaletteBackStyle.ButtonForm;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.endDatePicker);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel2);
            this.kryptonGroupBox1.Panel.Controls.Add(this.startDatePicker);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(394, 60);
            this.kryptonGroupBox1.TabIndex = 13;
            this.kryptonGroupBox1.Values.Heading = "DATE FILTER";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(435, 43);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(53, 20);
            this.kryptonLabel3.TabIndex = 14;
            this.kryptonLabel3.Values.Text = "Product";
            // 
            // EditButton
            // 
            this.EditButton.CornerRoundingRadius = -1F;
            this.EditButton.Location = new System.Drawing.Point(779, 24);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(111, 25);
            this.EditButton.TabIndex = 15;
            this.EditButton.Values.Text = "Edit Entry";
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.CornerRoundingRadius = -1F;
            this.SaveButton.Location = new System.Drawing.Point(779, 55);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(111, 25);
            this.SaveButton.TabIndex = 16;
            this.SaveButton.Values.Text = "Save";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // InwardsDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 643);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.kryptonGroupBox1);
            this.Controls.Add(this.productComboBox);
            this.Controls.Add(this.inwardsDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InwardsDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INWARDS DATA";
            ((System.ComponentModel.ISupportInitialize)(this.inwardsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonDataGridView inwardsDataGridView;
        private Krypton.Toolkit.KryptonDateTimePicker startDatePicker;
        private Krypton.Toolkit.KryptonDateTimePicker endDatePicker;
        private Krypton.Toolkit.KryptonComboBox productComboBox;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonButton EditButton;
        private Krypton.Toolkit.KryptonButton SaveButton;
    }
}