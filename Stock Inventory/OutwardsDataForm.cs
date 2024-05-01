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

namespace Stock_Inventory
{
    public partial class OutwardsDataForm : KryptonForm
    {
        public OutwardsDataForm()
        {
            InitializeComponent();

            this.MaximizeBox = false;

            // Add event handlers
            startDatePicker.ValueChanged += FilterData;
            endDatePicker.ValueChanged += FilterData;
            productComboBox.SelectedIndexChanged += FilterData;
            partyComboBox.SelectedIndexChanged += FilterData;
        }

        public void LoadOutwardsData(DataTable dataTable)
        {
            outwardsDataGridView.DataSource = dataTable;

            // Assuming that the "Product Name" and "Party No" columns exist in your DataTable
            if (dataTable.Columns.Contains("Product Name") && dataTable.Columns.Contains("Party No"))
            {
                // Get distinct product names and party numbers from the DataTable
                var productNames = dataTable.AsEnumerable()
                    .Select(row => row.Field<string>("Product Name"))
                    .Where(name => !string.IsNullOrEmpty(name)) // Filter out null or empty product names
                    .Distinct()
                    .ToList();

                var partyNumbers = dataTable.AsEnumerable()
                    .Select(row => row.Field<string>("Party No"))
                    .Where(number => !string.IsNullOrEmpty(number)) // Filter out null or empty party numbers
                    .Distinct()
                    .ToList();

                // Clear existing items before adding new ones
                productComboBox.Items.Clear();
                partyComboBox.Items.Clear();

                // Add an empty option to clear the filter for both ComboBoxes
                productComboBox.Items.Add("");
                partyComboBox.Items.Add("");

                // Add the product names and party numbers to the respective ComboBoxes
                productComboBox.Items.AddRange(productNames.ToArray());
                partyComboBox.Items.AddRange(partyNumbers.ToArray());

                // Set an initial selection for both ComboBoxes
                productComboBox.SelectedItem = "";
                partyComboBox.SelectedItem = "";
            }
        }

        private void FilterData(object sender, EventArgs e)
        {
            // Get the selected start and end dates
            DateTime startDate = startDatePicker.Value;
            DateTime endDate = endDatePicker.Value;

            // Get the selected product name
            string selectedProduct = productComboBox.SelectedItem as string;

            string selectedParty = partyComboBox.SelectedItem as string;

            // Apply the filter to the DataTable
            DataTable dataTable = (outwardsDataGridView.DataSource as DataTable);

            // Filter by date range
            string dateFilter = $"Date >= #{startDate:MM/dd/yyyy}# AND Date <= #{endDate:MM/dd/yyyy}#";

            // Filter by product name and party name
            string filter = dateFilter;

            if (!string.IsNullOrEmpty(selectedProduct))
            {
                // Filter based on the "Product Name" column
                filter += $" AND [Product Name] = '{selectedProduct}'";
            }

            if (!string.IsNullOrEmpty(selectedParty))
            {
                // Filter based on the "Party No" column
                filter += $" AND [Party No] = '{selectedParty}'";
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

    }
}
