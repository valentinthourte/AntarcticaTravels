namespace AntarcticaTravels
{
    partial class frmAddOperator
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
            lblName = new Label();
            tbName = new TextBox();
            tbStartDate = new TextBox();
            lblStartDate = new Label();
            tbEndDate = new TextBox();
            lblEndDate = new Label();
            tbVoyage = new TextBox();
            lblVoyage = new Label();
            tbEmbarkation = new TextBox();
            lblEmbarkation = new Label();
            tbDisembarkation = new TextBox();
            lblDisembark = new Label();
            tbVessel = new TextBox();
            lblVessel = new Label();
            tbStartCabin = new TextBox();
            lblStartCabin = new Label();
            btnCreateOperator = new Button();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 33);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // tbName
            // 
            tbName.Location = new Point(155, 30);
            tbName.Name = "tbName";
            tbName.Size = new Size(188, 23);
            tbName.TabIndex = 1;
            // 
            // tbStartDate
            // 
            tbStartDate.Location = new Point(155, 59);
            tbStartDate.Name = "tbStartDate";
            tbStartDate.Size = new Size(188, 23);
            tbStartDate.TabIndex = 3;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(12, 62);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(90, 15);
            lblStartDate.TabIndex = 2;
            lblStartDate.Text = "Start Date Index";
            // 
            // tbEndDate
            // 
            tbEndDate.Location = new Point(155, 88);
            tbEndDate.Name = "tbEndDate";
            tbEndDate.Size = new Size(188, 23);
            tbEndDate.TabIndex = 5;
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(12, 91);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(86, 15);
            lblEndDate.TabIndex = 4;
            lblEndDate.Text = "End Date Index";
            // 
            // tbVoyage
            // 
            tbVoyage.Location = new Point(155, 117);
            tbVoyage.Name = "tbVoyage";
            tbVoyage.Size = new Size(188, 23);
            tbVoyage.TabIndex = 7;
            // 
            // lblVoyage
            // 
            lblVoyage.AutoSize = true;
            lblVoyage.Location = new Point(12, 120);
            lblVoyage.Name = "lblVoyage";
            lblVoyage.Size = new Size(77, 15);
            lblVoyage.TabIndex = 6;
            lblVoyage.Text = "Voyage Index";
            // 
            // tbEmbarkation
            // 
            tbEmbarkation.Location = new Point(155, 146);
            tbEmbarkation.Name = "tbEmbarkation";
            tbEmbarkation.Size = new Size(188, 23);
            tbEmbarkation.TabIndex = 9;
            // 
            // lblEmbarkation
            // 
            lblEmbarkation.AutoSize = true;
            lblEmbarkation.Location = new Point(12, 149);
            lblEmbarkation.Name = "lblEmbarkation";
            lblEmbarkation.Size = new Size(106, 15);
            lblEmbarkation.TabIndex = 8;
            lblEmbarkation.Text = "Embarkation Index";
            // 
            // tbDisembarkation
            // 
            tbDisembarkation.Location = new Point(155, 175);
            tbDisembarkation.Name = "tbDisembarkation";
            tbDisembarkation.Size = new Size(188, 23);
            tbDisembarkation.TabIndex = 11;
            // 
            // lblDisembark
            // 
            lblDisembark.AutoSize = true;
            lblDisembark.Location = new Point(12, 178);
            lblDisembark.Name = "lblDisembark";
            lblDisembark.Size = new Size(122, 15);
            lblDisembark.TabIndex = 10;
            lblDisembark.Text = "Disembarkation Index";
            // 
            // tbVessel
            // 
            tbVessel.Location = new Point(155, 204);
            tbVessel.Name = "tbVessel";
            tbVessel.Size = new Size(188, 23);
            tbVessel.TabIndex = 13;
            // 
            // lblVessel
            // 
            lblVessel.AutoSize = true;
            lblVessel.Location = new Point(12, 207);
            lblVessel.Name = "lblVessel";
            lblVessel.Size = new Size(70, 15);
            lblVessel.TabIndex = 12;
            lblVessel.Text = "Vessel Index";
            // 
            // tbStartCabin
            // 
            tbStartCabin.Location = new Point(155, 233);
            tbStartCabin.Name = "tbStartCabin";
            tbStartCabin.Size = new Size(188, 23);
            tbStartCabin.TabIndex = 15;
            // 
            // lblStartCabin
            // 
            lblStartCabin.AutoSize = true;
            lblStartCabin.Location = new Point(12, 236);
            lblStartCabin.Name = "lblStartCabin";
            lblStartCabin.Size = new Size(97, 15);
            lblStartCabin.TabIndex = 14;
            lblStartCabin.Text = "Start Cabin Index";
            // 
            // btnCreateOperator
            // 
            btnCreateOperator.Location = new Point(137, 290);
            btnCreateOperator.Name = "btnCreateOperator";
            btnCreateOperator.Size = new Size(75, 23);
            btnCreateOperator.TabIndex = 16;
            btnCreateOperator.Text = "Create";
            btnCreateOperator.UseVisualStyleBackColor = true;
            btnCreateOperator.Click += btnCreateOperator_Click;
            // 
            // frmAddOperator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(368, 448);
            Controls.Add(btnCreateOperator);
            Controls.Add(tbStartCabin);
            Controls.Add(lblStartCabin);
            Controls.Add(tbVessel);
            Controls.Add(lblVessel);
            Controls.Add(tbDisembarkation);
            Controls.Add(lblDisembark);
            Controls.Add(tbEmbarkation);
            Controls.Add(lblEmbarkation);
            Controls.Add(tbVoyage);
            Controls.Add(lblVoyage);
            Controls.Add(tbEndDate);
            Controls.Add(lblEndDate);
            Controls.Add(tbStartDate);
            Controls.Add(lblStartDate);
            Controls.Add(tbName);
            Controls.Add(lblName);
            Name = "frmAddOperator";
            Text = "Add Operator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private TextBox tbName;
        private TextBox tbStartDate;
        private Label lblStartDate;
        private TextBox tbEndDate;
        private Label lblEndDate;
        private TextBox tbVoyage;
        private Label lblVoyage;
        private TextBox tbEmbarkation;
        private Label lblEmbarkation;
        private TextBox tbDisembarkation;
        private Label lblDisembark;
        private TextBox tbVessel;
        private Label lblVessel;
        private TextBox tbStartCabin;
        private Label lblStartCabin;
        private Button btnCreateOperator;
    }
}