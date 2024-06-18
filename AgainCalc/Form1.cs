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
        InputPresenter inputPresenter = new InputPresenter();
        public Form1()
        {
            InitializeComponent();
            //inputPresenter.InputChanged += (object sender, EventArgs e) => inputBox.Text = inputPresenter.InputValue;
        }

        private void WhenKeysPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b') return;
            if (InputPresenter.IsValidChar(e.KeyChar))
                return;

            e.Handled = true;
        }

        private void WriteSym(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            inputBox.Text += button.Text;
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (inputPresenter.IsValidForm(inputBox.Text))
            {
                Solver.TrySolve(inputBox.Text, out string result);
                expressionLbl.Text = result;
            }

            else expressionLbl.Text = "";
        }
    }
}
