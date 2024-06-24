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

            InputPresenter.SelectionCursorPos = inputBox.SelectionStart;
            InputPresenter.SelectionLenght = inputBox.SelectionLength;
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

        private void InsertBrackets(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            if (e.Button == MouseButtons.Right)
            {
                if (btn.Tag.ToString() == "()")
                {
                    btn.Tag = "[]";
                }

                else if (btn.Tag.ToString() == "[]")
                {
                    btn.Tag = "||";
                }

                else btn.Tag = "()";

                btn.Text = btn.Tag.ToString()[0] + "n" + btn.Tag.ToString()[1];
            }

            if (e.Button == MouseButtons.Left)
            {
                string brs = btn.Tag.ToString();
                inputBox.Text = InputPresenter.InsertBrackets(brs.ToCharArray());
            }
        }

        private void ReverseNum(object sender, MouseEventArgs e)
        {
            inputBox.Text = InputPresenter.ReverseNum();
        }

        private void WriteFunc(object sender, MouseEventArgs e)
        {
            ToolStripMenuItem btn = sender as ToolStripMenuItem;
            inputBox.Text = InputPresenter.WriteFunc(btn.Tag.ToString()); 
        }

        private void SaveSelectionMouseLeave(object sender, EventArgs e)
        {
            InputPresenter.SelectionCursorPos = inputBox.SelectionStart;
            InputPresenter.SelectionLenght = inputBox.SelectionLength;
        }

        private void SaveExpression(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(inputBox.Text))
                return;

            if (!inputsListBox.Items.Contains(inputBox.Text))
                inputsListBox.Items.Add(inputBox.Text);
        }

        private void SelectSavedExpression(object sender, EventArgs e)
        {
            if (inputsListBox.SelectedIndex != -1)
            {
                inputBox.Text = inputsListBox.SelectedItem.ToString();
            }
        }

        private void SaveSelectionMouseUp(object sender, MouseEventArgs e)
        {
            InputPresenter.SelectionCursorPos = inputBox.SelectionStart;
            InputPresenter.SelectionLenght = inputBox.SelectionLength;
        }

        private void ListSavedExpressionsBtnClick(object sender, MouseEventArgs e)
        {
            baseSplitContainer.Panel2Collapsed = !baseSplitContainer.Panel2Collapsed;
        }

        private void RemoveSavedExpression(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (inputsListBox.SelectedIndex != -1)
                {
                    inputsListBox.Items.RemoveAt(inputsListBox.SelectedIndex);
                }
            }
        }
    }
}
