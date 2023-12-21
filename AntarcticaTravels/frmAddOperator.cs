using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntarcticaTravels
{
    public partial class frmAddOperator : Form
    {
        public frmAddOperator()
        {
            InitializeComponent();
        }

        private void btnCreateOperator_Click(object sender, EventArgs e)
        {

            Operator op = GetOperatorFromForm();
            OperatorHelper.AddOperator(op);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private Operator GetOperatorFromForm()
        {
            string name = tbName.Text;
            int startDateIndex = int.Parse(tbStartDate.Text);
            int endDateIndex = int.Parse(tbEndDate.Text);
            int voyageIndex = int.Parse(tbVoyage.Text);
            int embarkationIndex = int.Parse(tbEmbarkation.Text);
            int disembarkationIndex = int.Parse(tbDisembarkation.Text);
            int vesselIndex = int.Parse(tbVessel.Text);
            int startCabinIndex = int.Parse(tbStartCabin.Text);

            return new CsvOperator(name, startDateIndex, endDateIndex, voyageIndex, embarkationIndex, disembarkationIndex, vesselIndex, startCabinIndex);
        }

    }
}
