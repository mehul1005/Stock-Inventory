using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Inventory
{
    public partial class AddNewStockForm : KryptonForm
    {
        private List<StockItem> tempStockItems = new List<StockItem>();
        private List<StockItem> stockItems;
        private Form1 mainForm;
        private Action saveToExcel;
        private Action loadFromExcel; // Define a delegate for LoadStockFromExcel
        private IniFile iniFile;

        private string productName;
        private int quantity;
        private string remarks;

        public AddNewStockForm(List<StockItem> stockItems, Form1 mainForm, Action saveToExcel, Action loadFromExcel, string productName, int quantity, string remarks, bool isEditMode = false)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.stockItems = stockItems;
            this.mainForm = mainForm;
            this.saveToExcel = saveToExcel;
            this.loadFromExcel = loadFromExcel;

            iniFile = new IniFile("productNames.ini");
            string productNames = iniFile.Read("Products", "Names", "");
            if (!string.IsNullOrEmpty(productNames))
            {
                string[] productNameArray = productNames.Split(',');
                cmbProductNames.Items.AddRange(productNameArray);
            }

            //if (isEditMode)
            //{
            //    // If in edit mode, set the controls with the provided data
            //    cmbProductNames.SelectedItem = productName;
            //    txtQuantity.Text = quantity.ToString();
            //    txtProductDetails.Text = remarks;
            //    //btnSave.Visible = false; // Hide the Save button, since we're editing
            //    //btnSaveEdit.Visible = true; // Show the Edit button
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string productName = cmbProductNames.Text;
            string quantityText = txtQuantity.Text;

            // Check if the product name or quantity is blank
            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(quantityText))
            {
                MessageBox.Show("Product name and quantity cannot be blank.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method
            }

            // Parse the quantity
            if (!int.TryParse(quantityText, out int quantity))
            {
                MessageBox.Show("Quantity must be a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method
            }

            DateTime currentDate = DateTime.Now; // Get the current date
            string remarks = txtProductDetails.Text;

            StockItem existingItem = tempStockItems.FirstOrDefault(item => item.ProductName == productName);

            // Calculate the next SrNo, providing a default value of 0 if the list is empty
            int nextSrNo = (stockItems.DefaultIfEmpty(new StockItem { SrNo = 0 })).Max(item => item.SrNo) + 1;

            if (existingItem != null)
            {
                // Update the quantity of the existing item in the temporary list
                existingItem.CurrentStock += quantity;
            }
            else
            {
                // Create a new stock item in the temporary list with the calculated SrNo
                StockItem newItem = new StockItem
                {
                    SrNo = nextSrNo,
                    ProductName = productName,
                    CurrentStock = quantity
                };

                tempStockItems.Add(newItem);
            }

            // Update the temporary list to the main form's list
            stockItems.Clear();
            stockItems.AddRange(tempStockItems);

            // Call the SaveToExcel method through the delegate in the main form
            saveToExcel();

            // Save the details to the second sheet of the Excel file
            SaveDetailsToExcel(productName, quantity, currentDate, remarks);

            // Close the form
            this.Close();
        }

        private void SaveDetailsToExcel(string productName, int quantity, DateTime date, string remarks)
        {
            string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "stockInventory.xlsx");
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties=Excel 12.0";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = conn;

                    // Check if the second sheet 'InwardDetails' exists
                    cmd.CommandText = "SELECT COUNT(*) FROM [InwardDetails$]";
                    int tableExists = (int)cmd.ExecuteScalar();

                    if (tableExists == 0)
                    {
                        // The second sheet doesn't exist, so create it
                        cmd.CommandText = "CREATE TABLE [InwardDetails$] ([Date] DATE, [Product Name] NVARCHAR(255), [Quantity] INT, [Remarks] NVARCHAR(255))";
                        cmd.ExecuteNonQuery();
                    }

                    // Insert a new row in the 'InwardDetails' sheet with date, product name, and quantity
                    cmd.CommandText = $"INSERT INTO [InwardDetails$] ([Date], [Product Name], [Quantity], [Remarks]) " +
                        $"VALUES ('{date.ToString("yyyy-MM-dd")}', '{productName}', {quantity}, '{remarks}')";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void addNewProductName_Click(object sender, EventArgs e)
        {
            string newProductName = txtNewProductNames.Text.Trim();

            // Check if the product name or quantity is blank
            if (string.IsNullOrEmpty(newProductName))
            {
                MessageBox.Show("Product name cannot be blank.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method
            }

            if (!string.IsNullOrEmpty(newProductName))
            {
                // Read the existing product names from the INI file
                string existingProductNames = iniFile.Read("Products", "Names", "");

                // Append the new product name to the existing names, separated by a comma
                if (!string.IsNullOrEmpty(existingProductNames))
                {
                    existingProductNames += "," + newProductName;
                }
                else
                {
                    existingProductNames = newProductName;
                }

                // Save the updated product names to the INI file
                iniFile.Write("Products", "Names", existingProductNames);

                // Clear the input field
                txtNewProductNames.Clear();

                // Update the combo box with the new product name
                cmbProductNames.Items.Add(newProductName);
            }
        }
    }
}
