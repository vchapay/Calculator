using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AgainCalc
{
    /// <summary>
    /// Предоставляет логику проверки корректности строковых выражений
    /// </summary>
    public static class InputPresenter
    {

        public const string NonOperandChars = "+-/*^!%()[]{}|";

        public const string OperandChars = "0123456789,";

        public const string OperatorChars = "+-*/^!%";

        public static string Input
        {
            get => expression;
            set => expression = value ?? expression;
        }

        public static int SelectionCursorPos
        {
            get => selectionCursorPos;
            set => selectionCursorPos = value > 0 ? value : 0;
        }

        public static int SelectionLenght
        {
            get => selectionLenght;
            set => selectionLenght = value > 0 ? value : 0;
        }

        private static string expression;

        private static int selectionCursorPos;

        private static int selectionLenght;

        private const string impossibleFirstChars = ")}]*/^!%";

        private static readonly Regex binaryInRow = new Regex(@"[/*+^-]{2}[/*+^-]*");

        private static readonly Regex impossibleUnary = new Regex(@"([-/*+^\(\[\{a-z]+[!%]+)|([!%]+[\(\[\{a-z]+)");

        private static readonly Regex impossibleBinary = new Regex(@"[-+/*^]+[\)\]\}!%]+");

        private static readonly Regex emptyBrackets = new Regex(@"[\(\[\{;]+[-+*/^!%]*[;\)\]\}]+");

        private static readonly Regex correctNumSample = 
            new Regex(@"\A\d+(,?\d+)?\Z");

        private static readonly Regex bracketsBetweenNumbers = 
            new Regex(@"\d+\.?[\(\)\{\}\[\]|]+\.?\d+");

        private static readonly Regex unaryFuncSample =
            new Regex(@"[-\(\[\{+*/^]*(sin|cos|tg|ctg|lg|ln){1}\(+");

        private static readonly Regex binaryFuncSample =
            new Regex(@"[-\(\[\{+*/^]*(log){1}\(.*[\d\)\]\}!%];");

        private static readonly Regex funcsNames =
            new Regex(@"\A(log|sin|cos|tg|ctg|lg|ln){1}\Z");

        private static readonly Regex funcsSplitter = new Regex(@"\P{L}");

        private static readonly Regex operandsSplitter = 
            new Regex(@"[a-z-+*/^\[\]\(\)\{\}!%;]+");

        /// <summary>
        /// Проверяет, имеет ли заданное строковое выражение смысл
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsValidForm(string expression)
        {
            if (expression == null || expression == string.Empty)
                return false;

            expression = expression.Replace(" ", "");
            expression = IntrepretateModuleBrackets(expression);
            return IsBracketsValid(expression) && 
                IsOperatorsValid(expression) && 
                IsOperandsValid(expression) &&
                IsFuncsValid(expression);
        }

        public static string IntrepretateModuleBrackets(string expression)
        {
            string interpretated = expression;
            char prevChar = '\0';
            char c;
            for (int i = 0; i < expression.Length; i++)
            {
                c = expression[i];

                if (c == '|')
                {
                    if (prevChar == '\0' ||
                        Operation.IsBynary(prevChar) ||
                        Operation.IsOpenBracket(prevChar))
                    {
                        interpretated = interpretated.Remove(i, 1);
                        interpretated = interpretated.Insert(i, "{");
                    }

                    else
                    {
                        interpretated = interpretated.Remove(i, 1);
                        interpretated = interpretated.Insert(i, "}");
                    }
                }

                prevChar = c;
            }

            return interpretated;
        }

        public static string ChangeNumSign()
        {
            int[] numPos = FindNumPos();
            if (numPos.Length == 0)
                return expression;

            int numBeg = numPos[0];
            int numEnd = numPos[1];
            int indBefore = numBeg - 1;
            char charBefore = numBeg == 0 ? '\0' : expression[indBefore];

            if (charBefore == '\0')
                return "-" + expression;

            if (charBefore == '+')
            {
                expression = expression.Remove(indBefore, 1);
                expression = expression.Insert(indBefore, "-");
                return expression;
            }

            if (charBefore == '-')
            {
                expression = expression.Remove(indBefore, 1); 
                expression = expression.Insert(indBefore, "+");
                return expression;
            }

            if ("*/^".Contains(charBefore))
            {
                expression = expression.Insert(numBeg, "(-");
                selectionCursorPos += 2;
                expression = expression.Insert(numEnd + 3, ")");
                return expression;
            }

            if (charBefore == '(')
            {
                selectionCursorPos++;
                expression = expression.Insert(numBeg, "-");
                return expression;
            }

            return expression;
        }

        private static int[] FindNumPos()
        {
            int numBeg;
            int numEnd;

            if (selectionCursorPos < expression.Length
                && selectionCursorPos > 0)
            {
                if (!OperandChars.Contains(expression[selectionCursorPos]) &&
                    !OperandChars.Contains(expression[selectionCursorPos - 1]))
                {
                    return new int[0];
                }

                else
                {
                    numBeg = FindNumBeg();
                    numEnd = FindNumEnd();
                }
            }
            
            else if (selectionCursorPos == expression.Length)
            { 
                numBeg = FindNumBeg();
                numEnd = expression.LastIndexOf(expression.Where((c) => OperandChars.Contains(c)).Last());
            }

            else
            {
                numBeg = expression.IndexOf(expression.Where((c) => OperandChars.Contains(c)).First());
                numEnd = FindNumEnd();
            }

            return new int[2] { numBeg, numEnd };
        }

        private static int FindNumEnd()
        {
            int numEnd = expression.Length - 1;
            for (int i = expression.Length - 1; i >= selectionCursorPos; i--)
            {
                if (!char.IsDigit(expression[i]))
                    numEnd = i - 1;
            }

            return numEnd;
        }

        private static int FindNumBeg()
        {
            int numBeg = 0;
            for (int i = 0; i < selectionCursorPos; i++)
            {
                if (!char.IsDigit(expression[i]))
                    numBeg = i + 1;
            }

            return numBeg;
        }

        private static bool IsFuncsValid(string expression)
        {
            string[] onlyLetters = funcsSplitter.Split(expression);

            int funcsCount = 0;

            string cur;
            for (int i = 0; i < onlyLetters.Length; i++)
            {
                cur = onlyLetters[i];
                if (cur == "") continue;
                if (!funcsNames.IsMatch(cur)) return false;
                funcsCount++;
            }

            int binaries = 0;
            int nextLogInd = expression.IndexOf("log");
            string logStr = expression;
            while (nextLogInd != -1)
            {
                logStr = logStr.Substring(nextLogInd);
                if (binaryFuncSample.IsMatch(logStr))
                    binaries++;

                logStr = logStr.Remove(0, 3);

                nextLogInd = logStr.IndexOf("log");
            }

            int unaries = unaryFuncSample.Matches(expression).Count;
            int semicolons = expression.Where((c) => c == ';').Count();

            return funcsCount == binaries + unaries && semicolons == binaries;

        }

        private static bool IsOperandsValid(string expression)
        {
            string[] operands = operandsSplitter.Split(expression);

            string operand;
            for (int i = 0; i < operands.Length; i++)
            {
                operand = operands[i];

                if (operand.Length == 0)
                    continue;

                if (!correctNumSample.IsMatch(operand))
                    return false;
            }

            return true;
        }

        private static bool IsOperatorsValid(string expression)
        {
            if (Operation.IsBynary(expression.Last()))
                return false;

            if (impossibleFirstChars.Contains(expression[0]))
                return false;

            string[] nonOperands = expression.Split(OperandChars.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);

            string current; 
            for (int i = 0; i < nonOperands.Length; i++)
            {
                current = nonOperands[i];

                if (binaryInRow.IsMatch(current))
                    return false;

                if (impossibleBinary.IsMatch(current))
                    return false;

                if (impossibleUnary.IsMatch(current))
                    return false;

                if (emptyBrackets.IsMatch(current))
                    return false;
            }

            return true;
        }

        private static bool IsBracketsValid(string expression)
        {
            if (bracketsBetweenNumbers.IsMatch(expression))
                return false;

            return CheckBrackets(expression, new char[] { '(', ')' }) &&
                CheckBrackets(expression, new char[] { '[', ']' }) &&
                CheckBrackets(expression, new char[] { '{', '}' });
        }

        private static bool CheckBrackets(string expression, char[] brs)
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
    }
}
