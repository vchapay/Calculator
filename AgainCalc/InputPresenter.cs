using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AgainCalc
{
    public class InputPresenter
    {
        public InputPresenter() { }

        public const string NonOperandChars = "+-/*^!%()[]{}";

        public const string OperandChars = "0123456789,";

        public const string OperatorChars = "+-*/^!%";

        private readonly Regex correctOperatorsSample = 
            new Regex(@"\A!?%?[\]\)\}]*(!?%?[/*\-+^]{1})?[\(\[\{]*[+-]?\Z");

        private readonly Regex correctNumSample = 
            new Regex(@"\A\d+(,?\d+)?\Z");

        private readonly Regex incorrectBracketSample = 
            new Regex(@"\d+,?[\(\)\{\}\[\]]+,?\d+");

        public event EventHandler InputChanged;

        public static bool IsValidChar(char c)
        {
            return NonOperandChars.Contains(c) || OperandChars.Contains(c);
        }

        public bool IsValidForm(string expression)
        {
            if (expression == null || expression == string.Empty)
                return false;

            //expression = IntrepretateModuleBrackets(expression);
            return IsValidBrackets(expression) && 
                IsValidOperators(expression) && 
                IsValidOperands(expression);
        }

        public static string IntrepretateModuleBrackets(string expression)
        {
            return null;
        }

        private bool IsValidOperands(string expression)
        {
            string[] operands = expression.Split(NonOperandChars.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);

            string operand;
            for (int i = 0; i < operands.Length; i++)
            {
                operand = operands[i];

                if (!correctNumSample.IsMatch(operand))
                    return false;
            }

            return true;
        }

        private bool IsValidOperators(string expression)
        {
            if (Operation.IsBynary(expression.Last()))
                return false;

            string[] nonOperands = expression.Split(OperandChars.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);

            string current; 
            for (int i = 0; i < nonOperands.Length; i++)
            {
                current = nonOperands[i];

                //if ((i == 0 || i == nonOperands.Length - 1) && 
                    //firstAndLastBrs.IsMatch(current))
                    //continue;

                if (!correctOperatorsSample.IsMatch(current))
                    return false;
            }

            return true;
        }

        private bool IsValidBrackets(string expression)
        {
            if (incorrectBracketSample.IsMatch(expression))
                return false;

            return CheckBrackets(expression, new char[] { '(', ')' }) &&
                CheckBrackets(expression, new char[] { '[', ']' }) &&
                CheckBrackets(expression, new char[] { '{', '}' });
        }

        private bool CheckBrackets(string expression, char[] brs)
        {
            char c;
            int opensCount = 0;
            int closesCount = 0;
            for (int i = 0; i < expression.Length; i++)
            {
                c = expression[i];
                if (Operation.IsBracket(c))
                {
                    if (c == brs[0]) opensCount++;
                    if (c == brs[1]) closesCount++;

                    if (closesCount > opensCount) return false;
                }
            }

            return opensCount == closesCount;
        }

        private void OnInputChanged(EventArgs e)
        {
            InputChanged?.Invoke(this, e);
        }
    }
}
