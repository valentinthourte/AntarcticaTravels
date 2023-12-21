namespace AntarcticaTravels
{
    partial class frmAntarcticaTravels
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tcMain = new TabControl();
            pbQuery = new TabPage();
            cbxDateFilter = new CheckBox();
            lblVessel = new Label();
            cbVessel = new ComboBox();
            cbVoyageType = new ComboBox();
            grdData = new DataGridView();
            Voyage = new DataGridViewTextBoxColumn();
            StartDate = new DataGridViewTextBoxColumn();
            EndDate = new DataGridViewTextBoxColumn();
            Embarkation = new DataGridViewTextBoxColumn();
            Disembarkation = new DataGridViewTextBoxColumn();
            Vessel = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            lblDuration = new Label();
            tbDuration = new TextBox();
            label1 = new Label();
            label2 = new Label();
            lblDates = new Label();
            dtpDateTo = new DateTimePicker();
            dtpDateFrom = new DateTimePicker();
            lblPriceHigh = new Label();
            lblPriceLow = new Label();
            lblPrice = new Label();
            tbPriceHigh = new TextBox();
            tbPriceLow = new TextBox();
            lblVoyage = new Label();
            cbVoyage = new ComboBox();
            btnExecFilter = new Button();
            tpLoad = new TabPage();
            lblLoading = new Label();
            panel1 = new Panel();
            rbLoadAPI = new RadioButton();
            rbLoadCSV = new RadioButton();
            btnAddOperator = new Button();
            btnCopyToClipboard = new Button();
            lblExportedCSV = new Label();
            lblVoyagesLoadedFail = new Label();
            lblVoyagesLoadedOk = new Label();
            lblOperator = new Label();
            cbOperator = new ComboBox();
            btnLoad = new Button();
            btnOpenFile = new Button();
            tbLoad = new TextBox();
            lblLoadCSV = new Label();
            ofdLoadCSV = new OpenFileDialog();
            tcMain.SuspendLayout();
            pbQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdData).BeginInit();
            tpLoad.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tcMain
            // 
            tcMain.Controls.Add(pbQuery);
            tcMain.Controls.Add(tpLoad);
            tcMain.Location = new Point(-2, -6);
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new Size(1129, 656);
            tcMain.TabIndex = 1;
            // 
            // pbQuery
            // 
            pbQuery.Controls.Add(cbxDateFilter);
            pbQuery.Controls.Add(lblVessel);
            pbQuery.Controls.Add(cbVessel);
            pbQuery.Controls.Add(cbVoyageType);
            pbQuery.Controls.Add(grdData);
            pbQuery.Controls.Add(lblDuration);
            pbQuery.Controls.Add(tbDuration);
            pbQuery.Controls.Add(label1);
            pbQuery.Controls.Add(label2);
            pbQuery.Controls.Add(lblDates);
            pbQuery.Controls.Add(dtpDateTo);
            pbQuery.Controls.Add(dtpDateFrom);
            pbQuery.Controls.Add(lblPriceHigh);
            pbQuery.Controls.Add(lblPriceLow);
            pbQuery.Controls.Add(lblPrice);
            pbQuery.Controls.Add(tbPriceHigh);
            pbQuery.Controls.Add(tbPriceLow);
            pbQuery.Controls.Add(lblVoyage);
            pbQuery.Controls.Add(cbVoyage);
            pbQuery.Controls.Add(btnExecFilter);
            pbQuery.Location = new Point(4, 24);
            pbQuery.Name = "pbQuery";
            pbQuery.Padding = new Padding(3);
            pbQuery.Size = new Size(1121, 628);
            pbQuery.TabIndex = 0;
            pbQuery.Text = "Query";
            pbQuery.UseVisualStyleBackColor = true;
            // 
            // cbxDateFilter
            // 
            cbxDateFilter.AutoSize = true;
            cbxDateFilter.Location = new Point(664, 46);
            cbxDateFilter.Name = "cbxDateFilter";
            cbxDateFilter.Size = new Size(15, 14);
            cbxDateFilter.TabIndex = 18;
            cbxDateFilter.UseVisualStyleBackColor = true;
            cbxDateFilter.CheckedChanged += cbxDateFilter_CheckedChanged;
            // 
            // lblVessel
            // 
            lblVessel.AutoSize = true;
            lblVessel.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            lblVessel.Location = new Point(950, 20);
            lblVessel.Name = "lblVessel";
            lblVessel.Size = new Size(60, 25);
            lblVessel.TabIndex = 17;
            lblVessel.Text = "Vessel";
            // 
            // cbVessel
            // 
            cbVessel.FormattingEnabled = true;
            cbVessel.Items.AddRange(new object[] { "Any" });
            cbVessel.Location = new Point(920, 79);
            cbVessel.Name = "cbVessel";
            cbVessel.Size = new Size(121, 23);
            cbVessel.TabIndex = 16;
            // 
            // cbVoyageType
            // 
            cbVoyageType.FormattingEnabled = true;
            cbVoyageType.Items.AddRange(new object[] { "Any" });
            cbVoyageType.Location = new Point(104, 79);
            cbVoyageType.Name = "cbVoyageType";
            cbVoyageType.Size = new Size(127, 23);
            cbVoyageType.TabIndex = 15;
            cbVoyageType.SelectedValueChanged += cbVoyageType_SelectedValueChanged;
            // 
            // grdData
            // 
            grdData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdData.Columns.AddRange(new DataGridViewColumn[] { Voyage, StartDate, EndDate, Embarkation, Disembarkation, Vessel, Price });
            grdData.Location = new Point(-4, 342);
            grdData.Name = "grdData";
            grdData.RowTemplate.Height = 25;
            grdData.Size = new Size(1119, 283);
            grdData.TabIndex = 2;
            grdData.CellContentClick += grdData_CellContentClick;
            // 
            // Voyage
            // 
            Voyage.HeaderText = "Voyage";
            Voyage.Name = "Voyage";
            // 
            // StartDate
            // 
            StartDate.HeaderText = "Start Date (dd/mm/yyyy)";
            StartDate.Name = "StartDate";
            // 
            // EndDate
            // 
            EndDate.HeaderText = "End Date";
            EndDate.Name = "EndDate";
            // 
            // Embarkation
            // 
            Embarkation.HeaderText = "Embarkation";
            Embarkation.Name = "Embarkation";
            // 
            // Disembarkation
            // 
            Disembarkation.HeaderText = "Disembarkation";
            Disembarkation.Name = "Disembarkation";
            // 
            // Vessel
            // 
            Vessel.HeaderText = "Vessel";
            Vessel.Name = "Vessel";
            // 
            // Price
            // 
            Price.HeaderText = "Price";
            Price.Name = "Price";
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Location = new Point(648, 153);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(53, 15);
            lblDuration.TabIndex = 14;
            lblDuration.Text = "Duration";
            // 
            // tbDuration
            // 
            tbDuration.Enabled = false;
            tbDuration.Location = new Point(577, 179);
            tbDuration.Name = "tbDuration";
            tbDuration.Size = new Size(197, 23);
            tbDuration.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(664, 107);
            label1.Name = "label1";
            label1.Size = new Size(19, 15);
            label1.TabIndex = 12;
            label1.Text = "To";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(655, 60);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 11;
            label2.Text = "From";
            // 
            // lblDates
            // 
            lblDates.AutoSize = true;
            lblDates.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            lblDates.Location = new Point(644, 20);
            lblDates.Name = "lblDates";
            lblDates.Size = new Size(57, 25);
            lblDates.TabIndex = 10;
            lblDates.Text = "Dates";
            // 
            // dtpDateTo
            // 
            dtpDateTo.Enabled = false;
            dtpDateTo.Location = new Point(577, 127);
            dtpDateTo.Name = "dtpDateTo";
            dtpDateTo.Size = new Size(197, 23);
            dtpDateTo.TabIndex = 9;
            // 
            // dtpDateFrom
            // 
            dtpDateFrom.Enabled = false;
            dtpDateFrom.Location = new Point(577, 81);
            dtpDateFrom.Name = "dtpDateFrom";
            dtpDateFrom.Size = new Size(197, 23);
            dtpDateFrom.TabIndex = 8;
            dtpDateFrom.Value = new DateTime(2023, 7, 30, 0, 0, 0, 0);
            // 
            // lblPriceHigh
            // 
            lblPriceHigh.AutoSize = true;
            lblPriceHigh.Location = new Point(430, 108);
            lblPriceHigh.Name = "lblPriceHigh";
            lblPriceHigh.Size = new Size(19, 15);
            lblPriceHigh.TabIndex = 7;
            lblPriceHigh.Text = "To";
            // 
            // lblPriceLow
            // 
            lblPriceLow.AutoSize = true;
            lblPriceLow.Location = new Point(419, 60);
            lblPriceLow.Name = "lblPriceLow";
            lblPriceLow.Size = new Size(35, 15);
            lblPriceLow.TabIndex = 6;
            lblPriceLow.Text = "From";
            lblPriceLow.Click += lblPriceLow_Click;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            lblPrice.Location = new Point(415, 20);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(49, 25);
            lblPrice.TabIndex = 5;
            lblPrice.Text = "Price";
            // 
            // tbPriceHigh
            // 
            tbPriceHigh.Location = new Point(392, 126);
            tbPriceHigh.Name = "tbPriceHigh";
            tbPriceHigh.Size = new Size(100, 23);
            tbPriceHigh.TabIndex = 4;
            tbPriceHigh.KeyPress += tbPriceHigh_KeyPress;
            // 
            // tbPriceLow
            // 
            tbPriceLow.Location = new Point(392, 80);
            tbPriceLow.Name = "tbPriceLow";
            tbPriceLow.Size = new Size(100, 23);
            tbPriceLow.TabIndex = 3;
            tbPriceLow.KeyPress += tbPriceLow_KeyPress;
            // 
            // lblVoyage
            // 
            lblVoyage.AutoSize = true;
            lblVoyage.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            lblVoyage.Location = new Point(130, 20);
            lblVoyage.Name = "lblVoyage";
            lblVoyage.Size = new Size(71, 25);
            lblVoyage.TabIndex = 2;
            lblVoyage.Text = "Voyage";
            // 
            // cbVoyage
            // 
            cbVoyage.FormattingEnabled = true;
            cbVoyage.Items.AddRange(new object[] { "Any" });
            cbVoyage.Location = new Point(62, 125);
            cbVoyage.Name = "cbVoyage";
            cbVoyage.Size = new Size(222, 23);
            cbVoyage.TabIndex = 1;
            cbVoyage.Visible = false;
            // 
            // btnExecFilter
            // 
            btnExecFilter.Font = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnExecFilter.Location = new Point(473, 252);
            btnExecFilter.Name = "btnExecFilter";
            btnExecFilter.Size = new Size(123, 40);
            btnExecFilter.TabIndex = 0;
            btnExecFilter.Text = "Find";
            btnExecFilter.UseVisualStyleBackColor = true;
            btnExecFilter.Click += button1_Click_1;
            // 
            // tpLoad
            // 
            tpLoad.Controls.Add(lblLoading);
            tpLoad.Controls.Add(panel1);
            tpLoad.Controls.Add(btnAddOperator);
            tpLoad.Controls.Add(btnCopyToClipboard);
            tpLoad.Controls.Add(lblExportedCSV);
            tpLoad.Controls.Add(lblVoyagesLoadedFail);
            tpLoad.Controls.Add(lblVoyagesLoadedOk);
            tpLoad.Controls.Add(lblOperator);
            tpLoad.Controls.Add(cbOperator);
            tpLoad.Controls.Add(btnLoad);
            tpLoad.Controls.Add(btnOpenFile);
            tpLoad.Controls.Add(tbLoad);
            tpLoad.Controls.Add(lblLoadCSV);
            tpLoad.Location = new Point(4, 24);
            tpLoad.Name = "tpLoad";
            tpLoad.Padding = new Padding(3);
            tpLoad.Size = new Size(1121, 628);
            tpLoad.TabIndex = 1;
            tpLoad.Text = "Load";
            tpLoad.UseVisualStyleBackColor = true;
            tpLoad.Enter += tpLoad_Enter;
            // 
            // lblLoading
            // 
            lblLoading.AutoSize = true;
            lblLoading.Location = new Point(410, 124);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(59, 15);
            lblLoading.TabIndex = 13;
            lblLoading.Text = "Loading...";
            lblLoading.Visible = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(rbLoadAPI);
            panel1.Controls.Add(rbLoadCSV);
            panel1.Location = new Point(126, 37);
            panel1.Name = "panel1";
            panel1.Size = new Size(117, 30);
            panel1.TabIndex = 12;
            // 
            // rbLoadAPI
            // 
            rbLoadAPI.AutoSize = true;
            rbLoadAPI.Location = new Point(66, 8);
            rbLoadAPI.Name = "rbLoadAPI";
            rbLoadAPI.Size = new Size(43, 19);
            rbLoadAPI.TabIndex = 1;
            rbLoadAPI.Text = "API";
            rbLoadAPI.UseVisualStyleBackColor = true;
            // 
            // rbLoadCSV
            // 
            rbLoadCSV.AutoSize = true;
            rbLoadCSV.Checked = true;
            rbLoadCSV.Location = new Point(14, 8);
            rbLoadCSV.Name = "rbLoadCSV";
            rbLoadCSV.Size = new Size(46, 19);
            rbLoadCSV.TabIndex = 0;
            rbLoadCSV.TabStop = true;
            rbLoadCSV.Text = "CSV";
            rbLoadCSV.UseVisualStyleBackColor = true;
            rbLoadCSV.CheckedChanged += rbLoadCSV_CheckedChanged;
            // 
            // btnAddOperator
            // 
            btnAddOperator.Location = new Point(178, 121);
            btnAddOperator.Name = "btnAddOperator";
            btnAddOperator.Size = new Size(33, 23);
            btnAddOperator.TabIndex = 11;
            btnAddOperator.Text = "+";
            btnAddOperator.UseVisualStyleBackColor = true;
            btnAddOperator.Click += btnAddOperator_Click;
            // 
            // btnCopyToClipboard
            // 
            btnCopyToClipboard.Location = new Point(595, 73);
            btnCopyToClipboard.Name = "btnCopyToClipboard";
            btnCopyToClipboard.Size = new Size(43, 23);
            btnCopyToClipboard.TabIndex = 10;
            btnCopyToClipboard.Text = "Copy";
            btnCopyToClipboard.UseVisualStyleBackColor = true;
            btnCopyToClipboard.Visible = false;
            btnCopyToClipboard.Click += btnCopyToClipboard_Click;
            // 
            // lblExportedCSV
            // 
            lblExportedCSV.AutoSize = true;
            lblExportedCSV.Location = new Point(420, 76);
            lblExportedCSV.MaximumSize = new Size(169, 0);
            lblExportedCSV.Name = "lblExportedCSV";
            lblExportedCSV.Size = new Size(169, 15);
            lblExportedCSV.TabIndex = 9;
            lblExportedCSV.Text = "Formatted CSV file exported to ";
            lblExportedCSV.Visible = false;
            // 
            // lblVoyagesLoadedFail
            // 
            lblVoyagesLoadedFail.AutoSize = true;
            lblVoyagesLoadedFail.Location = new Point(41, 187);
            lblVoyagesLoadedFail.MaximumSize = new Size(300, 0);
            lblVoyagesLoadedFail.Name = "lblVoyagesLoadedFail";
            lblVoyagesLoadedFail.Size = new Size(130, 15);
            lblVoyagesLoadedFail.TabIndex = 8;
            lblVoyagesLoadedFail.Text = "Failed to load voyages: ";
            lblVoyagesLoadedFail.Visible = false;
            // 
            // lblVoyagesLoadedOk
            // 
            lblVoyagesLoadedOk.AutoSize = true;
            lblVoyagesLoadedOk.Location = new Point(41, 163);
            lblVoyagesLoadedOk.Name = "lblVoyagesLoadedOk";
            lblVoyagesLoadedOk.Size = new Size(155, 15);
            lblVoyagesLoadedOk.TabIndex = 7;
            lblVoyagesLoadedOk.Text = "Voyages loaded successfully";
            lblVoyagesLoadedOk.Visible = false;
            // 
            // lblOperator
            // 
            lblOperator.AutoSize = true;
            lblOperator.Location = new Point(41, 103);
            lblOperator.Name = "lblOperator";
            lblOperator.Size = new Size(54, 15);
            lblOperator.TabIndex = 6;
            lblOperator.Text = "Operator";
            // 
            // cbOperator
            // 
            cbOperator.FormattingEnabled = true;
            cbOperator.Location = new Point(41, 121);
            cbOperator.Name = "cbOperator";
            cbOperator.Size = new Size(121, 23);
            cbOperator.TabIndex = 5;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(315, 121);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 23);
            btnLoad.TabIndex = 4;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += button1_Click;
            // 
            // btnOpenFile
            // 
            btnOpenFile.Location = new Point(357, 72);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(33, 23);
            btnOpenFile.TabIndex = 3;
            btnOpenFile.Text = "...";
            btnOpenFile.UseVisualStyleBackColor = true;
            btnOpenFile.Click += btnOpenFile_Click;
            // 
            // tbLoad
            // 
            tbLoad.Location = new Point(41, 73);
            tbLoad.Name = "tbLoad";
            tbLoad.Size = new Size(310, 23);
            tbLoad.TabIndex = 2;
            // 
            // lblLoadCSV
            // 
            lblLoadCSV.AutoSize = true;
            lblLoadCSV.Location = new Point(41, 41);
            lblLoadCSV.Name = "lblLoadCSV";
            lblLoadCSV.Size = new Size(79, 15);
            lblLoadCSV.TabIndex = 0;
            lblLoadCSV.Text = "Load Voyages";
            // 
            // ofdLoadCSV
            // 
            ofdLoadCSV.FileName = "openFileDialog1";
            ofdLoadCSV.FileOk += ofdLoadCSV_FileOk;
            // 
            // frmAntarcticaTravels
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1118, 650);
            Controls.Add(tcMain);
            Name = "frmAntarcticaTravels";
            Text = "Antarctica Travels";
            Load += Form1_Load;
            tcMain.ResumeLayout(false);
            pbQuery.ResumeLayout(false);
            pbQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdData).EndInit();
            tpLoad.ResumeLayout(false);
            tpLoad.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcMain;
        private TabPage pbQuery;
        private TabPage tpLoad;
        private Button btnExecFilter;
        private TextBox tbPriceLow;
        private Label lblVoyage;
        private ComboBox cbVoyage;
        private DateTimePicker dtpDateFrom;
        private Label lblPriceHigh;
        private Label lblPriceLow;
        private Label lblPrice;
        private TextBox tbPriceHigh;
        private DateTimePicker dtpDateTo;
        private TextBox tbDuration;
        private Label label1;
        private Label label2;
        private Label lblDates;
        private Label lblDuration;
        private DataGridView grdData;
        private ComboBox cbVoyageType;
        private Label lblVessel;
        private ComboBox cbVessel;
        private CheckBox cbxDateFilter;
        private Label lblLoadCSV;
        private OpenFileDialog ofdLoadCSV;
        private Button btnOpenFile;
        private TextBox tbLoad;
        private Button btnLoad;
        private Label lblOperator;
        private ComboBox cbOperator;
        private DataGridViewTextBoxColumn Voyage;
        private DataGridViewTextBoxColumn StartDate;
        private DataGridViewTextBoxColumn EndDate;
        private DataGridViewTextBoxColumn Embarkation;
        private DataGridViewTextBoxColumn Disembarkation;
        private DataGridViewTextBoxColumn Vessel;
        private DataGridViewTextBoxColumn Price;
        private Label lblVoyagesLoadedFail;
        private Label lblVoyagesLoadedOk;
        private Label lblExportedCSV;
        private Button btnCopyToClipboard;
        private Button btnAddOperator;
        private Panel panel1;
        private RadioButton rbLoadAPI;
        private RadioButton rbLoadCSV;
        private Label lblLoading;
    }
}