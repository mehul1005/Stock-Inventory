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
    public partial class AddStockOutForm : KryptonForm
    {
        private List<StockItem> tempStockItems = new List<StockItem>();
        private List<StockItem> stockItems;
        private List<Client> clients = new List<Client>();
        private Form1 mainForm; // Field to reference the main form
        private Action SaveToExcelOut;
        private Action loadFromExcel; // Define a delegate for LoadStockFromExcel
        private IniFile iniFile;

        public AddStockOutForm(List<StockItem> stockItems, Form1 mainForm, Action saveToExcelOut, Action loadFromExcel)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.stockItems = stockItems;
            this.mainForm = mainForm; // Initialize the mainForm field
            this.SaveToExcelOut = saveToExcelOut;
            this.loadFromExcel = loadFromExcel;

            LoadNamesFromFile();

            iniFile = new IniFile("productNames.ini");
            string productNames = iniFile.Read("Products", "Names", "");
            if (!string.IsNullOrEmpty(productNames))
            {
                string[] productNameArray = productNames.Split(',');
                cmbProductOutNames.Items.AddRange(productNameArray);
            }

            iniFile = new IniFile("machineNo.ini");
            string machineNo = iniFile.Read("Machine", "No", "");
            if (!string.IsNullOrEmpty(machineNo))
            {
                string[] machineNoArray = machineNo.Split(',');
                cmbMachineNo.Items.AddRange(machineNoArray);
            }
        }

        public class Client
        {
            public string Name { get; set; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string productName = cmbProductOutNames.Text;
            string quantityToRemoveText = txtQuantityToRemove.Text;
            //string machineNo = string.IsNullOrEmpty(txtMachineNo.Text) ? "" : txtMachineNo.Text.Trim();
            string machineNo = cmbMachineNo.Text;
            string clientName = cmbPartyNo.SelectedItem as string;

            // Check if any required fields are blank
            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(quantityToRemoveText) || string.IsNullOrEmpty(machineNo) || string.IsNullOrEmpty(clientName))
            {
                MessageBox.Show("Please Fill in All Required Fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method
            }

            // Parse the quantity to remove
            if (!int.TryParse(quantityToRemoveText, out int quantityToRemove))
            {
                MessageBox.Show("Quantity to Remove Must be a Valid Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method
            }

            DateTime currentDate = DateTime.Now; // Get the current date
            string remarks = txtProductOutDetails.Text;

            // Subtract the quantity from the main stock
            SubtractQuantityFromMainStock(productName, quantityToRemove);

            // Check if subtraction was allowed before proceeding
            if (!isSubtractionAllowed)
            {
                // If subtraction is not allowed, return or take appropriate action
                return;
            }

            // Calculate the next SrNo, providing a default value of 0 if the list is empty
            int nextSrNo = (stockItems.DefaultIfEmpty(new StockItem { SrNo = 0 })).Max(item => item.SrNo) + 1;

            // Create a new stock item in the temporary list with the calculated SrNo
            StockItem newItem = new StockItem
            {
                SrNo = nextSrNo,
                ProductName = productName,
                CurrentStock = quantityToRemove
            };

            tempStockItems.Add(newItem);

            // Update the temporary list to the main form's list
            stockItems.Clear();
            stockItems.AddRange(tempStockItems);

            // Call the SaveToExcel method through the delegate in the main form
            SaveToExcelOut();

            // Save the details to the second sheet of the Excel file
            SaveDetailsToExcel(productName, quantityToRemove, currentDate, remarks, machineNo, clientName);

            // Close the form
            this.Close();
        }

        // Add a boolean variable to check whether subtraction is allowed
        bool isSubtractionAllowed = true;
        private void SubtractQuantityFromMainStock(string productName, int quantityToRemove)
        {
            // Find the stock item by product name in the main stock
            StockItem existingItem = stockItems.FirstOrDefault(item => item.ProductName == productName);

            if (existingItem != null)
            {
                // Check if there is sufficient stock to subtract
                if (existingItem.CurrentStock >= quantityToRemove)
                {
                    // Subtract the quantity
                    existingItem.CurrentStock -= quantityToRemove;
                }
                else
                {
                    // Show a message indicating insufficient stock
                    MessageBox.Show($"Insufficient stock for product '{productName}'. Stock available: {existingItem.CurrentStock}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isSubtractionAllowed = false;  // Set the flag to indicate that subtraction is not allowed
                    // Optionally, you can choose to return or throw an exception to prevent further processing
                }
            }
        }


        private void SaveDetailsToExcel(string productName, int quantityToRemove, DateTime date, string remarks, string machineNo, string clientName)
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
                    cmd.CommandText = "SELECT COUNT(*) FROM [OutwardDetails$]";
                    int tableExists = (int)cmd.ExecuteScalar();

                    if (tableExists == 0)
                    {
                        // The second sheet doesn't exist, so create it
                        cmd.CommandText = "CREATE TABLE [OutwardDetails$] ([Date] DATE, [Product Name] NVARCHAR(255), [Quantity] INT, [Party No] NVARCHAR(255), [Machine No] NVARCHAR(255), [Remarks] NVARCHAR(255))";
                        cmd.ExecuteNonQuery();
                    }

                    // Insert a new row in the 'InwardDetails' sheet with date, product name, and quantity
                    cmd.CommandText = $"INSERT INTO [OutwardDetails$] ([Date], [Product Name], [Quantity], [Party No], [Machine No], [Remarks]) " +
                        $"VALUES ('{date.ToString("yyyy-MM-dd")}', '{productName}', {quantityToRemove}, '{clientName}', '{machineNo}', '{remarks}')";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void LoadNamesFromFile()
        {
            // Load client names
            if (System.IO.File.Exists("client_names.txt"))
            {
                var clientNames = System.IO.File.ReadAllLines("client_names.txt");
                clients.AddRange(clientNames.Select(name => new Client { Name = name }));
                cmbPartyNo.Items.AddRange(clientNames);
            }
        }

        private void SaveNamesToFile()
        {
            // Save client names only if they don't already exist in the file
            string[] existingClientNames = System.IO.File.ReadAllLines("client_names.txt");
            List<string> newClientNames = clients.Select(client => client.Name).Except(existingClientNames).ToList();
            System.IO.File.AppendAllLines("client_names.txt", newClientNames);
        }

        private void btnAddNewParty_Click(object sender, EventArgs e)
        {
            string clientName = txtClientName.Text.Trim();

            if (string.IsNullOrEmpty(clientName))
            {
                MessageBox.Show("Please Enter New Party Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return; // Exit the method if the name is blank
            }

            clients.Add(new Client { Name = clientName });
            cmbPartyNo.Items.Add(clientName); // Add to the ComboBox
            SaveNamesToFile(); // Save names to the text file
            txtClientName.Clear();
            MessageBox.Show("Added New Party To List", "Added Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
