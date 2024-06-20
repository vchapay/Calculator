using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgainCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Resolve(object sender, EventArgs e)
        {
            if (InputPresenter.IsValidForm(inputBox.Text))
            {
                if (!Solver.TrySolve(inputBox.Text, out string result, out string m))
                    result = m;

                expressionLbl.Text = result;
            }

            else expressionLbl.Text = "";
        }
    }
}
