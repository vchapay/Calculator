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
            InputPresenter.Input = inputBox.Text;
        }

        private void WriteChar(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            inputBox.Text += btn.Tag.ToString();
        }

        private void ClearAll(object sender, MouseEventArgs e)
        {
            inputBox.Text = string.Empty;
        }

        private void Clear(object sender, MouseEventArgs e)
        {
            if (inputBox.Text != string.Empty)
                inputBox.Text = inputBox.Text.Remove(inputBox.Text.Length - 1, 1);
        }

        private void ChangeNumSign(object sender, MouseEventArgs e)
        {
            inputBox.Text = InputPresenter.ChangeNumSign();
        }

        private void SaveSelectionPos(object sender, EventArgs e)
        {
            InputPresenter.SelectionCursorPos = inputBox.SelectionStart;
        }
    }
}
