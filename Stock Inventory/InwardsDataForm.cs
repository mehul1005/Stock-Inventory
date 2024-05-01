using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Inventory
{
    public partial class InwardsDataForm : KryptonForm
    {
        private List<StockItem> stockItems;
        private Form1 mainForm;
        private Action saveToExcel;
        private Action loadFromExcel;

        public InwardsDataForm()
        {
            InitializeComponent();

            this.MaximizeBox = false;

            // Add event handlers
            startDatePicker.ValueChanged += FilterData;
            endDatePicker.ValueChanged += FilterData;
            productComboBox.SelectedIndexChanged += FilterData;
        }

        public void LoadInwardsData(DataTable dataTable)
        {
            inwardsDataGridView.DataSource = dataTable;

            // Assuming that the "Product Name" column exists in your DataTable
            if (dataTable.Columns.Contains("Product Name"))
            {
                // Get distinct product names from the DataTable
                var productNames = dataTable.AsEnumerable()
                    .Select(row => row.Field<string>("Product Name"))
                    .Distinct()
                    .ToList();

                // Add the product names to the productComboBox
                productComboBox.Items.Clear(); // Clear existing items
                productComboBox.Items.Add(""); // Add an empty option to clear the filter
                productComboBox.Items.AddRange(productNames.ToArray());

                // Set an initial selection
                productComboBox.SelectedItem = "";
            }
        }

        private void FilterData(object sender, EventArgs e)
        {
            // Get the selected start and end dates
            DateTime startDate = startDatePicker.Value;
            DateTime endDate = endDatePicker.Value;

            // Get the selected product name
            string selectedProduct = productComboBox.SelectedItem as string;

            // Apply the filter to the DataTable
            DataTable dataTable = (inwardsDataGridView.DataSource as DataTable);

            // Filter by date range
            string dateFilter = $"Date >= #{startDate:MM/dd/yyyy}# AND Date <= #{endDate:MM/dd/yyyy}#";

            // Filter by product name
            string productFilter = "";
            if (!string.IsNullOrEmpty(selectedProduct))
            {
                // You should filter based on the "Product Name" column
                productFilter = $"[Product Name] = '{selectedProduct}'";
            }

            string filter = dateFilter;
            if (!string.IsNullOrEmpty(productFilter))
            {
                if (!string.IsNullOrEmpty(filter))
                {
                    filter += " AND " + productFilter;
                }
                else
                {
                    filter = productFilter;
                }
            }

            if (!string.IsNullOrEmpty(filter))
            {
                dataTable.DefaultView.RowFilter = filter;
            }
            else
            {
                // If no filters are applied, show all data
                dataTable.DefaultView.RowFilter = "";
            }
        }

        private string PromptForPassword()
        {
            using (var form = new Form())
            {
                form.Text = "Enter Password";
                form.Size = new Size(240, 130);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.MaximizeBox = false;
                form.MinimizeBox = false;

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

        private const string AdminPassword = "Admin@022";
        private bool isAdminMode = false;
        private DataTable dataTable; // DataTable for holding data from Excel

        private void EditButton_Click(object sender, EventArgs e)
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
                // Load Excel data into DataGridView
                LoadExcelDataIntoDataGridView(filePath);
            }
            else
            {
                // Handle the case where the file doesn't exist
                MessageBox.Show("The Excel file does not exist. Please create it first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadExcelDataIntoDataGridView(string filePath)
        {
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

                    // Load data from the 'InwardDetails' sheet into a DataTable
                    cmd.CommandText = "SELECT * FROM [InwardDetails$]";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the DataTable to your DataGridView
                    inwardsDataGridView.DataSource = dataTable;

                    // Enable editing in all rows
                    foreach (DataGridViewColumn column in inwardsDataGridView.Columns)
                    {
                        column.ReadOnly = false;
                    }
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (dataTable != null)
            {
                // Update changes from DataGridView back to the DataTable
                dataTable.AcceptChanges();

                string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "stockInventory.xlsx");
                string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties=Excel 12.0";

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.Connection = conn;

                        // Create a dictionary to keep track of changes in quantity for each product
                        Dictionary<string, int> quantityChanges = new Dictionary<string, int>();

                        // Loop through the DataTable rows and update records in 'InwardDetails' sheet
                        foreach (DataRowView dataRowView in dataTable.DefaultView)
                        {
                            DataRow dataRow = dataRowView.Row;

                            string dateStr = dataRow["Date"].ToString();
                            string productName = dataRow["Product Name"].ToString();
                            int newQuantity = int.Parse(dataRow["Quantity"].ToString());
                            string remarks = dataRow["Remarks"].ToString();

                            // Parse the date using the correct format from the Excel sheet
                            DateTime date = DateTime.ParseExact(dateStr, "dd-MM-yyyy hh.mm.ss tt", CultureInfo.InvariantCulture);

                            // Find the corresponding row in 'InwardDetails' DataTable
                            DataRow inwardDetailsRow = LoadExcelData("InwardDetails").Select($"[Date] = #{date:MM/dd/yyyy}# AND [Product Name] = '{productName}'").FirstOrDefault();
                            if (inwardDetailsRow != null)
                            {
                                int oldQuantity = int.Parse(inwardDetailsRow["Quantity"].ToString());

                                // Calculate the difference in quantity
                                int quantityDifference = newQuantity - oldQuantity;

                                // Update the record in the 'InwardDetails' sheet
                                cmd.CommandText = $"UPDATE [InwardDetails$] SET [Quantity] = {newQuantity}, [Remarks] = '{remarks}' WHERE [Date] = #{date:MM/dd/yyyy}# AND [Product Name] = '{productName}'";
                                cmd.ExecuteNonQuery();

                                // Track the changes in quantity for each product
                                if (quantityChanges.ContainsKey(productName))
                                {
                                    quantityChanges[productName] += quantityDifference;
                                }
                                else
                                {
                                    quantityChanges[productName] = quantityDifference;
                                }
                            }
                        }

                        // Update the 'StockData' sheet with changes in quantity for each product
                        foreach (var kvp in quantityChanges)
                        {
                            string productName = kvp.Key;
                            int quantityDifference = kvp.Value;

                            DataRow stockDataRow = LoadExcelData("StockData").Select($"[Product Name] = '{productName}'").FirstOrDefault();
                            if (stockDataRow != null)
                            {
                                int currentStockQuantity = int.Parse(stockDataRow["Current Stock"].ToString());
                                int newStockQuantity = currentStockQuantity + quantityDifference;

                                // Update the stock quantity in 'StockData'
                                stockDataRow["Current Stock"] = newStockQuantity;
                            }
                        }

                        // Save the changes to 'StockData' sheet
                        SaveDataTableToExcel(LoadExcelData("StockData"), "StockData", conn);
                    }

                    MessageBox.Show("Changes saved to Excel file.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }



        // Helper method to load data from a specific sheet in Excel
        private DataTable LoadExcelData(string sheetName)
        {
            string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "stockInventory.xlsx");
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties=Excel 12.0";
            string query = $"SELECT * FROM [{sheetName}$]";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        private void SaveDataTableToExcel(DataTable dataTable, string sheetName, OleDbConnection conn)
        {
            using (OleDbCommand cmd = new OleDbCommand("", conn))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    // Build the UPDATE SQL statement for each row
                    string updateQuery = $"UPDATE [{sheetName}$] SET ";
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        if (column.ColumnName != "Product Name") // Exclude Product Name from the SET clause
                        {
                            updateQuery += $"[{column.ColumnName}] = ?, ";
                            cmd.Parameters.AddWithValue(column.ColumnName, row[column]);
                        }
                    }
                    // Remove the trailing comma and space
                    updateQuery = updateQuery.TrimEnd(',', ' ');

                    // Add the WHERE clause to target the specific row by Product Name
                    updateQuery += $" WHERE [Product Name] = ?";

                    cmd.Parameters.AddWithValue("Product_Name", row["Product Name"]);
                    cmd.CommandText = updateQuery;

                    // Execute the UPDATE command
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
