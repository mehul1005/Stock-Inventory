using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Inventory
{
    public partial class InAndOutReportForm : KryptonForm
    {
        private List<Client> clients = new List<Client>();
        private DataTable inwardData;
        private DataTable outwardData;
        private IniFile iniFile;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PageSetupDialog pageSetupDialog;
        private PrintPreviewDialog printPreviewDialog;

        public InAndOutReportForm()
        {
            InitializeComponent();

            // Add event handlers
            startDatePicker.ValueChanged += FilterData;
            endDatePicker.ValueChanged += FilterData;
            productComboBox.SelectedIndexChanged += FilterData;
            cmbPartyNo.SelectedIndexChanged += FilterData;

            LoadNamesFromFile();

            // Add Load event handler
            Load += (sender, e) => FilterData(sender, e); // Trigger initial data population

            iniFile = new IniFile("productNames.ini");
            string productNames = iniFile.Read("Products", "Names", "");
            if (!string.IsNullOrEmpty(productNames))
            {
                string[] productNameArray = productNames.Split(',');
                productComboBox.Items.AddRange(productNameArray);
            }
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
        }

        public class Client
        {
            public string Name { get; set; }
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

        private void FilterData(object sender, EventArgs e)
        {
            DateTime startDate = startDatePicker.Value;
            DateTime endDate = endDatePicker.Value;
            string selectedProduct = productComboBox.SelectedItem as string;
            string selectedClient = cmbPartyNo.SelectedItem as string; // Get the selected client name

            // Clear the current data in the reportDataGridView
            reportDataGridView.Rows.Clear();

            // Loop through the dates
            foreach (DateTime date in inwardData.AsEnumerable().Select(row => row.Field<DateTime>("Date")).Distinct())
            {
                var inwardRows = inwardData.Select($"Date = #{date:MM/dd/yyyy}#");
                var outwardRows = outwardData.Select($"Date = #{date:MM/dd/yyyy}#");

                foreach (var inwardRow in inwardRows)
                {
                    string productName = inwardRow.Field<string>("Product Name");
                    int quantity = 0;

                    // Check if the "Quantity" column contains a valid integer
                    if (inwardRow["Quantity"] != DBNull.Value && int.TryParse(inwardRow["Quantity"].ToString(), out int parsedQuantity))
                    {
                        quantity = parsedQuantity;
                    }

                    // Filter data based on selected date range, product, and client name
                    if (date >= startDate && date <= endDate &&
                        (string.IsNullOrEmpty(selectedProduct) || selectedProduct == productName) &&
                        (string.IsNullOrEmpty(selectedClient) || selectedClient == "N/A"))
                    {
                        // Check if there is a corresponding outward entry
                        var correspondingOutwardRows = outwardData.AsEnumerable()
                            .Where(outwardRow =>
                                outwardRow.Field<string>("Product Name") == productName &&
                                outwardRow.Field<DateTime>("Date") == date);

                        foreach (var outwardRow in correspondingOutwardRows)
                        {
                            int outwardQuantity = 0;
                            // Check if the "Quantity" column contains a valid integer
                            if (outwardRow["Quantity"] != DBNull.Value && int.TryParse(outwardRow["Quantity"].ToString(), out int parsedOutwardQuantity))
                            {
                                outwardQuantity = parsedOutwardQuantity;
                            }

                            reportDataGridView.Rows.Add(
                                date.ToString("dd/MM/yyyy"),
                                productName,
                                quantity,
                                "",
                                0
                            );
                        }

                        // If there is no corresponding outward entry, add the inward entry
                        if (!correspondingOutwardRows.Any())
                        {
                            reportDataGridView.Rows.Add(
                                date.ToString("dd/MM/yyyy"),
                                productName,
                                quantity,
                                "",
                                0
                            );
                        }
                    }
                }

                foreach (var outwardRow in outwardRows)
                {
                    string productName = outwardRow.Field<string>("Product Name");
                    int quantity = 0;
                    string partyNo = outwardRow.Field<string>("Party No");
                    string machineNo = outwardRow.Field<string>("Machine No");
                    string remarks = outwardRow.Field<string>("Remarks"); // Get the "Remarks" value

                    // Check if the "Quantity" column contains a valid integer
                    if (outwardRow["Quantity"] != DBNull.Value && int.TryParse(outwardRow["Quantity"].ToString(), out int parsedQuantity))
                    {
                        quantity = parsedQuantity;
                    }

                    // Filter data based on selected date range, product, and client name
                    if (date >= startDate && date <= endDate &&
                        (string.IsNullOrEmpty(selectedProduct) || selectedProduct == productName) &&
                        (string.IsNullOrEmpty(selectedClient) || selectedClient == partyNo) &&
                        inwardData.AsEnumerable().Any(inwardRow =>
                            inwardRow.Field<string>("Product Name") == productName))
                    {
                        reportDataGridView.Rows.Add(
                            date.ToString("dd/MM/yyyy"),
                            "", // No corresponding inward product
                            0,   // No corresponding inward quantity
                            productName,
                            quantity,
                            partyNo,
                            machineNo,
                            remarks // Add the "Remarks" column
                        );
                    }
                }
            }
        }

        public void LoadReportData(DataTable inwardData, DataTable outwardData)
        {
            // Store the data in class-level fields
            this.inwardData = inwardData;
            this.outwardData = outwardData;

            // Assuming you have a DataGridView named reportDataGridView in your form
            reportDataGridView.Columns.Clear();

            // Display column headers for inward and outward data
            reportDataGridView.Columns.Add("Date", "Date");
            reportDataGridView.Columns.Add("Inward Product", "Inward Product");
            reportDataGridView.Columns.Add("Inward Quantity", "Inward Quantity");
            reportDataGridView.Columns.Add("Outward Product", "Outward Product");
            reportDataGridView.Columns.Add("Outward Quantity", "Outward Quantity");
            reportDataGridView.Columns.Add("Party No", "Party No");
            reportDataGridView.Columns.Add("Machine No", "Machine No");
            reportDataGridView.Columns.Add("Remarks OutWards", "Remarks");

            // Loop through the dates and display data side by side
            foreach (DateTime date in inwardData.AsEnumerable().Select(row => row.Field<DateTime>("Date")).Distinct())
            {
                var formattedDate = date.ToString("MM/dd/yyyy"); // Convert the date to a string
                var inwardRows = inwardData.Select($"CONVERT([Date], 'System.String') = '#{formattedDate}'");
                var outwardRows = outwardData.Select($"CONVERT([Date], 'System.String') = '#{formattedDate}'");


                foreach (var inwardRow in inwardRows)
                {
                    string productName = inwardRow.Field<string>("Product Name");
                    int quantity = 0;

                    // Check if the "Quantity" column contains a valid integer
                    if (inwardRow["Quantity"] != DBNull.Value && int.TryParse(inwardRow["Quantity"].ToString(), out int parsedQuantity))
                    {
                        quantity = parsedQuantity;
                    }

                    reportDataGridView.Rows.Add(
                        date.ToString("dd/MM/yyyy"), // Updated date format
                        productName,
                        quantity,
                        "", // No corresponding outward product
                        0 // No corresponding outward quantity
                    );
                }

                foreach (var outwardRow in outwardRows)
                {
                    string productName = outwardRow.Field<string>("Product Name");
                    int quantity = 0;
                    string partyNo = outwardRow.Field<string>("Party No");
                    string machineNo = outwardRow.Field<string>("Machine No");
                    string remarks = outwardRow.Field<string>("Remarks"); // Get the "Remarks" value

                    // Check if the "Quantity" column contains a valid integer
                    if (outwardRow["Quantity"] != DBNull.Value && int.TryParse(outwardRow["Quantity"].ToString(), out int parsedQuantity))
                    {
                        quantity = parsedQuantity;
                    }

                    reportDataGridView.Rows.Add(
                        date.ToString("dd/MM/yyyy"), // Updated date format
                        "", // No corresponding inward product
                        0, // No corresponding inward quantity
                        productName,
                        quantity,
                        partyNo,
                        machineNo,
                        remarks // Add the "Remarks" column
                    );
                }
            }
        }


        private void ResetReportData()
        {
            // Call the LoadReportData method to load the original data
            LoadReportData(inwardData, outwardData);
        }

        private void ClearFilterButton_Click(object sender, EventArgs e)
        {
            // Create a DateTime object with the desired date
            DateTime specificDate = new DateTime(2023, 10, 1);

            // Clear any selected values or filters
            productComboBox.SelectedIndex = -1; // Clear the selected product
            cmbPartyNo.SelectedIndex = -1; // Clear the selected client
            startDatePicker.Value = specificDate; // Set the start date to today
            endDatePicker.Value = DateTime.Today; // Set the end date to today

            // Manually trigger the FilterData method to reset and populate the report data
            FilterData(sender, e);
        }


        private void printButton_Click(object sender, EventArgs e)
        {
            pageSetupDialog = new PageSetupDialog();
            pageSetupDialog.Document = printDocument1;

            // Show the Page Setup dialog
            if (pageSetupDialog.ShowDialog() == DialogResult.OK)
            {
                printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = printDocument1;

                // Show the Print Preview dialog
                printPreviewDialog.ShowDialog();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Define some variables to keep track of the print area and rows
            int leftMargin = e.MarginBounds.Left;
            int topMargin = e.MarginBounds.Top;
            int numRows = reportDataGridView.Rows.Count;
            int currentRow = 0;
            bool hasMorePages = false;
            int cellHeight = 0;

            // Check if there are any more rows to print
            if (currentRow != numRows)
            {
                DataGridViewRow dataRow = reportDataGridView.Rows[currentRow];
                cellHeight = dataRow.Height;

                // Print header row
                foreach (DataGridViewCell cell in dataRow.Cells)
                {
                    if (cell.Visible)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), new Rectangle(leftMargin, topMargin, cell.OwningColumn.Width, cellHeight));
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(leftMargin, topMargin, cell.OwningColumn.Width, cellHeight));
                        e.Graphics.DrawString(cell.OwningColumn.HeaderText, reportDataGridView.Font, new SolidBrush(Color.Black), new RectangleF(leftMargin, topMargin, cell.OwningColumn.Width, cellHeight));
                        leftMargin += cell.OwningColumn.Width;
                    }
                }

                topMargin += cellHeight;

                // Print data rows
                while (currentRow < numRows)
                {
                    hasMorePages = false;

                    dataRow = reportDataGridView.Rows[currentRow];
                    leftMargin = e.MarginBounds.Left;
                    cellHeight = dataRow.Height;

                    foreach (DataGridViewCell cell in dataRow.Cells)
                    {
                        if (cell.Visible)
                        {
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(leftMargin, topMargin, cell.OwningColumn.Width, cellHeight));
                            e.Graphics.DrawString(cell.FormattedValue.ToString(), reportDataGridView.Font, new SolidBrush(Color.Black), new RectangleF(leftMargin, topMargin, cell.OwningColumn.Width, cellHeight));
                            leftMargin += cell.OwningColumn.Width;
                        }
                    }

                    topMargin += cellHeight;

                    currentRow++;

                    if (topMargin + cellHeight > e.MarginBounds.Bottom)
                    {
                        hasMorePages = true;
                        break;
                    }
                }
            }

            e.HasMorePages = hasMorePages;
        }

        private void productComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected product from the productComboBox
            string selectedProduct = productComboBox.SelectedItem as string;

            if (string.IsNullOrEmpty(selectedProduct))
            {
                // Handle the case where no product is selected
                lblCurrentStock.Text = "No product selected";
            }
            else
            {
                // Find the current stock of the selected product
                int currentStock = GetProductCurrentStock(selectedProduct);

                // Update the lblCurrentStock label
                lblCurrentStock.Text = $"CURRENT STOCK: {currentStock}";
            }
        }

        private int GetProductCurrentStock(string productName)
        {
            // Use your code to retrieve data from Excel and find the current stock
            string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "stockInventory.xlsx");
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties=Excel 12.0";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                // Create your SQL query to retrieve the current stock for the selected product
                string query = $"SELECT [Current Stock] FROM [StockData$] WHERE [Product Name] = @ProductName";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductName", productName);
                    var result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        // Check if the result is not DBNull and parse it to an integer
                        return Convert.ToInt32(result);
                    }
                }
            }

            return 0; // Return 0 if the product is not found or there's an issue.
        }
    }
}
