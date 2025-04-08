using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgainCalc
{
    /// <summary>
    /// Предоставляет логику для решения выражений, заданных произвольной строкой
    /// </summary>
    internal static class Solver
    {

        private static string _expression;
        private static string[] _tokens;
        private static readonly Stack<double> operands = new Stack<double>();
        private static int _rounding;
        private static string _message = "";

        /// <summary>
        /// Возвращает и задает число знаков после запятой, 
        /// до которых округляется результат
        /// </summary>
        public static int Rounding
        {
            get => _rounding;
            set => _rounding = value;
        }

        /// <summary>
        /// Пробует найти результат заданного строкой выражения (в инфиксной форме).
        /// </summary>
        /// <param name="expression">Выражение, которое нужно решить</param>
        /// <param name="result">Результат решения</param>
        /// <returns>True, если решение найдено. Иначе false.</returns>
        public static bool TrySolve(string expression, out string result, out string message)
        {
            if (expression == null) throw new ArgumentNullException();

            if (expression == string.Empty)
            {
                result = "";
                message = string.Empty;
                return false;
            }

            try
            {
                _message = "";
                _expression = PostfixConverter.Convert(expression);
                result = Math.Round(Solve(), 15).ToString();
                message = _message;

                if (_message != "")
                {
                    return false;
                }

                return true;
            }

            catch (Exception e)
            {
                result = "";
                message = e.Message;
                return false;
            }
        }

        private static double Solve()
        {
            operands.Clear();
            _tokens = _expression.Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            string token;
            for (int i = 0; i < _tokens.Length; i++)
            {
                token = _tokens[i];

                if (Operation.IsConstantName(token))
                {
                    operands.Push(
                        double.Parse(InputPresenter.ConstantsValues[token]));
                    continue;
                }

                if (token.Length >= 1 && char.IsDigit(token[0]))
                {
                    operands.Push(double.Parse(token));
                }

                else
                {
                    SolveOperation(token);
                }

                if (_message != "") return 0;
            }

            return operands.Pop();
        }

        private static void SolveOperation(string token)
        {
            double operationResult = 0;

            if (Operation.IsFunction(token))
            {
                double first = operands.Pop();
                double second = 0;
                if (!Operation.IsUnaryFunction(token))
                    second = operands.Pop();

                double[] args = new double[] { first, second };
                operationResult = Operation.SolveFunction(token, args);
                operands.Push(operationResult);
                return;
            }

            else if (token.Length > 1)
                _message = "Получен оператор, состоящий из нескольких символов";

            char op = token[0];
            if (Operation.IsBynary(op))
            {
                double right = operands.Pop();
                double left = operands.Pop();
                operationResult = Operation.SolveBinary(left, right, op);
            }

            if (Operation.IsUnary(op))
            {
                double operand = operands.Pop();

                if (op == '!' && (int)operand != operand)
                {
                    _message = "Факториал от дробного числа неопределен";
                    return;
                }

                operationResult = Operation.SolveUnary(operand, op);
            }

            if (op == '%')
            {
                double right = operands.Pop();
                double left = operands.Pop();
                operationResult = left - (Math.Floor(left / right) * right);
            }

            operands.Push(operationResult);
        }
    }
}
