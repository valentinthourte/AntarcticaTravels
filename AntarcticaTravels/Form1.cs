namespace AntarcticaTravels
{
    public partial class frmAntarcticaTravels : Form
    {
        private List<Voyage> completeVoyageList;
        private List<Voyage> voyageList;
        private List<Vessel> vesselList;
        private List<Operator> operatorList;
        private string LastExportedPath = string.Empty;

        public Operator SelectedOperator { get => operatorList.Find(op => op.Name == cbOperator.Text); }

        public frmAntarcticaTravels()
        {
            InitializeComponent();
            InitializeFields();
        }

        private void InitializeFields()
        {
            try
            {
                this.completeVoyageList = new();
                this.voyageList = completeVoyageList;
                operatorList = OperatorHelper.GetCSVOperators();
                dtpDateFrom.Value = DateTime.Now;
                dtpDateTo.Value = DateTime.Now.AddMonths(1);
                vesselList = VoyageHelper.GetVesselsFromVoyages(voyageList);
                cbVessel.SelectedIndex = 0;
                cbVessel.Items.AddRange(vesselList.Select(vessel => vessel.VesselName).ToArray());
                foreach (DataGridViewColumn column in grdData.Columns)
                {
                    column.Width = grdData.Width / grdData.Columns.Count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ValidateFilter();
            this.voyageList = completeVoyageList;
            if (cbVoyage.SelectedIndex > 0)
            {
                this.voyageList = this.voyageList.Where(voyage => voyage.VoyageName == cbVoyage.Items[cbVoyage.SelectedIndex].ToString()).ToList();

            }

            if (tbPriceLow.Text.Length > 0)
            {
                var lowPriceFilter = int.Parse(tbPriceLow.Text);

                voyageList = voyageList.Where(voyage => voyage.VoyageVessel.GetCheapestPrice() >= lowPriceFilter).ToList();
            }
            if (tbPriceHigh.Text.Length > 0)
            {
                var highPriceFilter = int.Parse(tbPriceHigh.Text);
                voyageList = voyageList.Where(voyage => voyage.VoyageVessel.GetCheapestPrice() <= highPriceFilter).ToList();
            }
            if (cbxDateFilter.Checked)
            {
                voyageList = voyageList.Where(voyage => voyage.StartDate > dtpDateFrom.Value && voyage.EndDate < dtpDateTo.Value).ToList();
                string durationText = tbDuration.Text;
                if (!string.IsNullOrEmpty(durationText))
                {
                    voyageList = voyageList.Where(voyage => (voyage.EndDate.Date - voyage.StartDate.Date).Days.ToString() == durationText).ToList();
                }
            }
            if (cbVessel.SelectedIndex != 0)
            {
                voyageList = voyageList.Where(voyage => voyage.GetVesselName() == cbVessel.SelectedItem.ToString()).ToList();
            }
            PopulateGrid();
        }

        private void ValidateFilter()
        {
            Console.WriteLine("Validating...");
        }

        private void lblPriceLow_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbVoyage.SelectedIndex = 0;
            this.voyageList.DistinctBy(voyage => voyage.VoyageName).ToList().ForEach(voyage =>
            {
                cbVoyage.Items.Add(voyage.VoyageName);
            });
            cbVoyageType.Items.Add("Arctic");
            cbVoyageType.Items.Add("Antarctic");
            cbVoyageType.SelectedIndex = 0;
        }

        private void PopulateGrid()
        {
            grdData.Rows.Clear();
            this.voyageList.OrderBy(voyage => voyage.CheapestPrice()).ToList().ForEach(voyage =>
            {
                string[] row = { voyage.VoyageName, voyage.StartDate.ToString(), voyage.EndDate.ToString(), voyage.Embarkation, voyage.Disembarkation, voyage.VoyageVessel.VesselName, voyage.CheapestPrice().ToString() };
                grdData.Rows.Add(row);
            });

        }

        private void cbVoyageType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbVoyageType.Items[cbVoyageType.SelectedIndex].ToString()))
            {
                cbVoyage.Visible = true;
            }
        }

        private void cbxDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            dtpDateFrom.Enabled = cbxDateFilter.Checked;
            dtpDateTo.Enabled = cbxDateFilter.Checked;
            tbDuration.Enabled = cbxDateFilter.Checked;
        }

        private void tbPriceLow_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the key pressed is a valid digit (0-9) or the decimal point (if not already present)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                // Reject the key press by handling it (canceling it)
                e.Handled = true;
            }

            // If the decimal point (.) is already present, prevent another decimal point
            if (e.KeyChar == '.' && tbPriceLow.Text.Contains("."))
            {
                // Reject the key press by handling it (canceling it)
                e.Handled = true;
            }
        }

        private void tbPriceHigh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                // Reject the key press by handling it (canceling it)
                e.Handled = true;
            }

            // If the decimal point (.) is already present, prevent another decimal point
            if (e.KeyChar == '.' && tbPriceHigh.Text.Contains("."))
            {
                // Reject the key press by handling it (canceling it)
                e.Handled = true;
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            ofdLoadCSV.ShowDialog();
        }

        private void ofdLoadCSV_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tbLoad.Text = ofdLoadCSV.FileName;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                lblLoading.Visible = true;
                btnLoad.Enabled = false;
                var voyages = await LoadVoyages();
                this.completeVoyageList.AddRange(voyages);
                LastExportedPath = FileHelper.WriteCSVForWebPage(voyages, SelectedOperator.Name);
                lblVoyagesLoadedOk.Visible = true;
                lblExportedCSV.Text = $"Formatted CSV file exported to {LastExportedPath}";
                lblExportedCSV.Visible = true;
                btnCopyToClipboard.Visible = true;
                lblLoading.Visible = false;
                btnLoad.Enabled = true;
            }
            catch (Exception ex)
            {
                lblLoading.Visible = false;
                btnLoad.Enabled = true;
            }
        }

        private async Task<List<Voyage>> LoadVoyages()
        {
            List<Voyage> voyages = new List<Voyage>();
            Operator op = SelectedOperator;
            ClearLoadLabels();
            try
            {
                voyages = await op.GetVoyagesAsync(tbLoad.Text);
            }
            catch (Exception ex)
            {
                lblVoyagesLoadedFail.Text += ex.Message;
                lblVoyagesLoadedFail.Visible = true;
                throw;
            }
            return voyages;
        }

        private void ClearLoadLabels()
        {
            lblVoyagesLoadedOk.Visible = false;
            lblVoyagesLoadedFail.Visible = false;
            lblExportedCSV.Visible = false;
            btnCopyToClipboard.Visible = false;
        }

        private void UpdateOperators()
        {
            cbOperator.Items.Clear();
            operatorList = rbLoadCSV.Checked ? OperatorHelper.GetCSVOperators() : OperatorHelper.GetAPIOperators();
            cbOperator.Items.AddRange(operatorList.Select(op => op.Name).ToArray());
            cbOperator.SelectedIndex = 0;
        }
        private void tpLoad_Enter(object sender, EventArgs e)
        {
            UpdateOperators();
            cbOperator.SelectedIndex = 0;
        }

        private void grdData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(LastExportedPath);
        }

        private void btnAddOperator_Click(object sender, EventArgs e)
        {
            frmAddOperator frmAddOperator = new frmAddOperator();
            frmAddOperator.ShowDialog();
            UpdateOperators();

        }

        private void rbLoadCSV_CheckedChanged(object sender, EventArgs e)
        {
            UpdateOperators();  
        }
    }
}