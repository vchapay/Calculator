using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgainCalc
{
    internal static class Solver
    {
        private static string _expression;
        private static string[] _tokens;
        private static readonly Stack<double> operands = new Stack<double>();

        /// <summary>
        /// Пробует найти результат заданного строкой выражения.
        /// </summary>
        /// <param name="expression">Выражение, которое нужно решить</param>
        /// <param name="result">Результат решения</param>
        /// <returns>True, если решение найдено. Иначе false.</returns>
        public static bool TrySolve(string expression, out string result)
        {
            if (expression == null) throw new ArgumentNullException();

            if (expression == string.Empty)
            {
                result = "";
                return false;
            }

            try
            {
                _expression = PostfixConverter.Convert(expression);
                result = Solve().ToString();
                return true;
            }

            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
        }

        private static double Solve()
        {
            operands.Clear();
            _tokens = _expression.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string token;
            char charToken;
            for (int i = 0; i < _tokens.Length; i++)
            {
                token = _tokens[i];
                charToken = token[0];
                if (token.Length > 1 || char.IsDigit(charToken))
                {
                    operands.Push(double.Parse(token));
                }

                else
                {
                    SolveOperation(charToken);
                }
            }

            return operands.Pop();
        }

        private static void SolveOperation(char charToken)
        {
            double operationResult = 0;
            if (Operation.IsBynary(charToken))
            {
                double right = operands.Pop();
                double left = operands.Pop();
                operationResult = Operation.SolveBinary(left, right, charToken);
            }

            if (Operation.IsUnary(charToken))
            {
                double operand = operands.Pop();
                operationResult = Operation.SolveUnary(operand, charToken);
            }

            operands.Push(operationResult);
        }
    }
}
