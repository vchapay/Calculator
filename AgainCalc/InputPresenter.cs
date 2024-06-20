using System;
using System.Collections.Generic;
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

        public const string OperandChars = "0123456789.";

        public const string OperatorChars = "+-*/^!%";

        private const string impossibleFirstChars = ")}]*/^!%";

        private static readonly Regex binaryInRow = new Regex(@"[/*+^-]{2}[/*+^-]*");

        private static readonly Regex impossibleUnary = new Regex(@"([-/*+^\(\[\{a-z]+[!%]+)|([!%]+[\(\[\{a-z]+)");

        private static readonly Regex impossibleBinary = new Regex(@"[-+/*^]+[\)\]\}!%]+");

        private static readonly Regex emptyBrackets = new Regex(@"[\(\[\{]+[-+*/^!%]*[\)\]\}]+");

        private static readonly Regex correctNumSample = 
            new Regex(@"\A\d+(\.?\d+)?\Z");

        private static readonly Regex bracketsBetweenNumbers = 
            new Regex(@"\d+\.?[\(\)\{\}\[\]|]+\.?\d+");

        private static readonly Regex unaryFunc =
            new Regex(@"[-\(\[\{+*/^]*(sin|cos|tg|ctg|lg|ln)\(+");

        private static readonly Regex binaryFunc =
            new Regex(@"( log base )");

        private static readonly Regex isThereFuncs =
            new Regex(@"\p{Ll}");

        private static readonly Regex funcSplitter = new Regex(@"^\p{Ll}");

        private static readonly Regex operandsSplitter = new Regex(@"[\D,]");

        /// <summary>
        /// Проверяет, имеет ли заданное строковое выражение смысл
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsValidForm(string expression)
        {
            if (expression == null || expression == string.Empty)
                return false;
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

        private static bool IsFuncsValid(string expression)
        {
            string str = unaryFunc.Replace(expression, "");
            str = binaryFunc.Replace(str, "");

            return !isThereFuncs.IsMatch(str);
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
