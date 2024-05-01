using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Windows.Forms.DataVisualization.Charting;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;


namespace Stock_Inventory
{
    public partial class Form1 : KryptonForm
    {
        private List<StockItem> stockItems = new List<StockItem>();
        private InAndOutReportForm inAndOutReportForm;

        public Form1()
        {
            InitializeComponent();

            this.MaximizeBox = false;

            // Load stock data from Excel when the form is initialized
            LoadStockFromExcel();

            // Load data into the DataGridView
            LoadStockData();

            // Set the initial visibility of the dataGridViewProducts to false
            dataGridViewProducts.Visible = false;

            inAndOutReportForm = new InAndOutReportForm();

            // Populate data into the PieChart
            pieChart1.Series = new LiveCharts.SeriesCollection();
            foreach (var item in stockItems)
            {
                pieChart1.Series.Add(new PieSeries
                {
                    Title = item.ProductName,
                    Values = new ChartValues<int> { item.CurrentStock },
                    DataLabels = true,
                });
            }

            // Define a list of product names for suggestions
            AutoCompleteStringCollection productSuggestions = new AutoCompleteStringCollection();

            // Populate productSuggestions with your product names
            foreach (var item in stockItems)
            {
                productSuggestions.Add(item.ProductName);
            }

            // Set up the TextBox properties for auto-complete
            txtProductItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtProductItem.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtProductItem.AutoCompleteCustomSource = productSuggestions;
        }

        public void LoadStockData()
        {
            // Clear existing rows
            dataGridViewProducts.Rows.Clear();

            // Add columns to the DataGridView (if not already defined)
            if (dataGridViewProducts.ColumnCount == 0)
            {
                dataGridViewProducts.Columns.Add("SrNo", "Sr No");
                dataGridViewProducts.Columns.Add("ProductName", "Product Name");
                dataGridViewProducts.Columns.Add("CurrentStock", "Current Stock");
            }

            foreach (var item in stockItems)
            {
                // Add rows to the DataGridView by specifying values for each column
                dataGridViewProducts.Rows.Add(item.SrNo, item.ProductName, item.CurrentStock);
            }
        }

        
        private void btnAddNewStock_Click(object sender, EventArgs e)
        {
            // Load data from Excel before opening the new stock form
            LoadStockFromExcel();

            AddNewStockForm newStockForm = new AddNewStockForm(stockItems, this, SaveToExcel, LoadStockFromExcel, "", 0, "", false);
            newStockForm.ShowDialog();
        }


        private void btnAddStockOutForm_Click(object sender, EventArgs e)
        {
            // Load data from Excel before opening the new stock form
            LoadStockFromExcel();

            AddStockOutForm outStockForm = new AddStockOutForm(stockItems, this, SaveToExcelOut, LoadStockFromExcel);
            outStockForm.ShowDialog();
        }

        private void SaveToExcel()
        {
            string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "stockInventory.xlsx");
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties=Excel 12.0";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = conn;

                    // Check if the table 'StockData' exists
                    cmd.CommandText = "SELECT COUNT(*) FROM [StockData$]";
                    int tableExists = (int)cmd.ExecuteScalar();

                    if (tableExists == 0)
                    {
                        // The table doesn't exist, so create it
                        cmd.CommandText = "CREATE TABLE [StockData$] ([Sr No] INT, [Product Name] NVARCHAR(255), [Current Stock] INT)";
                        cmd.ExecuteNonQuery();
                    }

                    // Iterate over stockItems and update the Excel file for each product separately
                    foreach (var item in stockItems)
                    {
                        if (item.CurrentStock > 0)
                            // Create a dictionary to keep track of existing product stock
                        {
                            Dictionary<string, int> existingStock = new Dictionary<string, int>();

                            // Read existing data into the dictionary for the specific product
                            cmd.CommandText = $"SELECT [Product Name], [Current Stock] FROM [StockData$] WHERE [Product Name] = '{item.ProductName}'";
                            using (OleDbDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string productName = reader["Product Name"].ToString();
                                    int currentStock = Convert.ToInt32(reader["Current Stock"]);
                                    existingStock[productName] = currentStock;
                                }
                            }

                            // Update data in the Excel table for the specific product
                            if (existingStock.ContainsKey(item.ProductName))
                            {
                                // Product already exists, update the quantity
                                int newQuantity = existingStock[item.ProductName] + item.CurrentStock;

                                cmd.CommandText = $"UPDATE [StockData$] SET [Current Stock] = {newQuantity} WHERE [Product Name] = '{item.ProductName}'";
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                // Product doesn't exist, insert a new row
                                cmd.CommandText = $"INSERT INTO [StockData$] ([Sr No], [Product Name], [Current Stock]) " +
                                    $"VALUES ({item.SrNo}, '{item.ProductName}', {item.CurrentStock})";
                                cmd.ExecuteNonQuery();
                            }
                        }
                    } 
                }
            }

            // Refresh the DataGridView with the updated data
            LoadStockFromExcel();
            LoadStockData();
        }

        private void SaveToExcelOut()
        {
            string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "stockInventory.xlsx");
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties=Excel 12.0";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = conn;

                    // Check if the table 'StockData' exists
                    cmd.CommandText = "SELECT COUNT(*) FROM [StockData$]";
                    int tableExists = (int)cmd.ExecuteScalar();

                    if (tableExists == 0)
                    {
                        // The table doesn't exist, so create it
                        cmd.CommandText = "CREATE TABLE [StockData$] ([Sr No] INT, [Product Name] NVARCHAR(255), [Current Stock] INT)";
                        cmd.ExecuteNonQuery();
                    }

                    // Iterate over stockItems and update the Excel file for each product separately
                    foreach (var item in stockItems)
                    {
                        if (item.CurrentStock != 0) // Check if there is any change in quantity
                        {
                            // Create a dictionary to keep track of existing product stock
                            Dictionary<string, int> existingStock = new Dictionary<string, int>();

                            // Read existing data into the dictionary for the specific product
                            cmd.CommandText = $"SELECT [Product Name], [Current Stock] FROM [StockData$] WHERE [Product Name] = '{item.ProductName}'";
                            using (OleDbDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string productName = reader["Product Name"].ToString();
                                    int currentStock = Convert.ToInt32(reader["Current Stock"]);
                                    existingStock[productName] = currentStock;
                                }
                            }

                            // Update data in the Excel table for the specific product by subtracting the quantity
                            if (existingStock.ContainsKey(item.ProductName))
                            {
                                int currentQuantity = existingStock[item.ProductName];
                                int newQuantity = currentQuantity - item.CurrentStock; // Subtract the quantity

                                if (newQuantity < 0)
                                {
                                    newQuantity = 0; // Ensure quantity is not negative
                                }

                                cmd.CommandText = $"UPDATE [StockData$] SET [Current Stock] = {newQuantity} WHERE [Product Name] = '{item.ProductName}'";
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }

            // Refresh the DataGridView with the updated data
            LoadStockFromExcel();
            LoadStockData();
        }

        private void LoadStockFromExcel()
        {
            string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "stockInventory.xlsx");
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties=Excel 12.0";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                // Retrieve data from the Excel sheet
                string query = "SELECT * FROM [StockData$]";
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, conn))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Clear existing stock data
                    stockItems.Clear();

                    // Populate stock data from the DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int srNo = Convert.ToInt32(row["Sr No"]);
                        string productName = row["Product Name"].ToString();
                        int currentStock = Convert.ToInt32(row["Current Stock"]);

                        StockItem stockItem = new StockItem
                        {
                            SrNo = srNo,
                            ProductName = productName,
                            CurrentStock = currentStock
                        };

                        stockItems.Add(stockItem);
                    }
                }
            }
        }

        private void btnViewInwardsData_Click(object sender, EventArgs e)
        {
            InwardsDataForm inwardsForm = new InwardsDataForm();
            LoadInwardsData(inwardsForm);
            inwardsForm.Show();
        }

        private void btnViewOutwardsData_Click(object sender, EventArgs e)
        {
            OutwardsDataForm outwardsData = new OutwardsDataForm();
            LoadOutwardsData(outwardsData);
            outwardsData.Show();
        }

        private void LoadInwardsData(InwardsDataForm inwardsForm)
        {
            string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "stockInventory.xlsx");
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties=Excel 12.0";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                // Retrieve data from the 'InwardDetails' sheet
                string query = "SELECT * FROM [InwardDetails$]";
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, conn))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Load the data into the inwardsDataGridView on InwardsDataForm
                    inwardsForm.LoadInwardsData(dataTable);
                }
            }
        }

        private void LoadOutwardsData(OutwardsDataForm outwardsForm)
        {
            string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "stockInventory.xlsx");
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties=Excel 12.0";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                // Retrieve data from the 'InwardDetails' sheet
                string query = "SELECT * FROM [OutwardDetails$]";
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, conn))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Load the data into the inwardsDataGridView on InwardsDataForm
                    outwardsForm.LoadOutwardsData(dataTable);
                }
            }
        }

        private void btnViewDataGrid_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.Visible)
            {
                // Hide the dataGridViewProducts and show the chart
                dataGridViewProducts.Hide();
                pieChart1.Show();
                btnViewDataGrid.Text = "SHOW PRODUCT MASTER";
            }
            else
            {
                // Show the dataGridViewProducts and hide the chart
                dataGridViewProducts.Show();
                pieChart1.Hide(); // Hide the PieChart
                btnViewDataGrid.Text = "HIDE PRODUCT MASTER";
            }
        }

        private void btnGetReport_Click(object sender, EventArgs e)
        {
            DataTable inwardData = LoadInwardDataFromExcel();
            DataTable outwardData = LoadOutwardDataFromExcel();

            InAndOutReportForm reportForm = new InAndOutReportForm();
            reportForm.LoadReportData(inwardData, outwardData);
            reportForm.Show();
        }

        private DataTable LoadInwardDataFromExcel()
        {
            // Load data from the "InwardDetails" sheet
            string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "stockInventory.xlsx");
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties=Excel 12.0";

            string query = "SELECT * FROM [InwardDetails$]";

            return LoadDataFromExcel(connectionString, query);
        }

        private DataTable LoadOutwardDataFromExcel()
        {
            // Load data from the "OutwardDetails" sheet
            string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "stockInventory.xlsx");
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties=Excel 12.0";

            string query = "SELECT * FROM [OutwardDetails$]";

            return LoadDataFromExcel(connectionString, query);
        }

        private DataTable LoadDataFromExcel(string connectionString, string query)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, conn))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            string searchTerm = txtProductItem.Text.Trim(); // Get the search term from the textbox

            if (string.IsNullOrEmpty(searchTerm))
            {
                // If the search term is empty, show all products
                LoadStockData();
            }
            else
            {
                // Perform the search
                SearchProduct(searchTerm);
            }
        }

        private void SearchProduct(string searchTerm)
        {
            // Clear the DataGridView to display the search results
            dataGridViewProducts.Rows.Clear();

            foreach (var item in stockItems)
            {
                if (item.ProductName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    // If the product name contains the search term (case-insensitive), add it to the DataGridView
                    dataGridViewProducts.Rows.Add(item.SrNo, item.ProductName, item.CurrentStock);
                }
            }

            if (dataGridViewProducts.Rows.Count == 0)
            {
                // If no results were found, display a message
                MessageBox.Show("No matching products found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtProductItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchProduct_Click(this, new EventArgs());
            }
        }

        private const string AdminPassword = "Admin@022";
        private bool isAdminMode = false;

        private void btnEditEntries_Click(object sender, EventArgs e)
        {
            if (!isAdminMode)
            {
                // Ask for the password
                string password = PromptForPassword();

                if (password != AdminPassword)
                {
                    MessageBox.Show("Invalid password. Access denied.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                isAdminMode = true;
            }

            string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "stockInventory.xlsx");

            if (System.IO.File.Exists(filePath))
            {
                // Check if the Excel file exists and open it with administrator privileges
                System.Diagnostics.Process.Start("excel.exe", filePath);
            }
            else
            {
                // Handle the case where the file doesn't exist
                MessageBox.Show("The Excel file does not exist. Please create it first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Close the form
            this.Close();
        }

        private string PromptForPassword()
        {
            using (var form = new Form())
            {
                form.Text = "Enter Password";
                form.Size = new Size(240, 130);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.StartPosition = FormStartPosition.CenterScreen;

                var label = new Label
                {
                    Text = "Enter the admin password:",
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                var passwordBox = new TextBox
                {
                    Location = new Point(10, 35),
                    Size = new Size(200, 20),
                    PasswordChar = '*'
                };

                var okButton = new Button
                {
                    Text = "OK",
                    Location = new Point(135, 60)
                };

                okButton.Click += (s, e) => { form.DialogResult = DialogResult.OK; form.Close(); };

                form.Controls.Add(label);
                form.Controls.Add(passwordBox);
                form.Controls.Add(okButton);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    return passwordBox.Text;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
