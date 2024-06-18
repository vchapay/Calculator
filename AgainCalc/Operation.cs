using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgainCalc
{
    internal static class Operation
    {
        /// <summary>
        /// Возвращает число от 1 до 4, означающее приоритетность оператора.
        /// </summary>
        /// <param name="op">Оператор</param>
        /// <returns>Приоритетность в виде числа от 1 до 4</returns>
        public static int GetPriority(char op)
        {
            switch (op)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                case '^':
                    return 3;
                case '!':
                case 'a':
                    return 4;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Возвращает логическое значение, является ли оператор бинарным.
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        public static bool IsBynary(char op)
        {
            return "+-/*^".Contains(op);
        }

        public static bool IsBracket(char ch)
        {
            return "()[]|".Contains(ch);
        }

        public static bool IsOpenBracket(char ch)
        {
            return "[({".Contains(ch);
        }

        public static bool IsCloseBracket(char ch)
        {
            return "])}".Contains(ch);
        }

        /// <summary>
        /// Возвращает логическое значение, является ли оператор унарным.
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        public static bool IsUnary(char op)
        {
            return "!a".Contains(op);
        }

        public static bool IsOperator(char op)
        {
            return IsBynary(op) || IsUnary(op);
        }

        /// <summary>
        /// Возвращает результат бинарной операции в соответствии с переданными операндами и оператором.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="op"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double SolveBinary(double left, double right, char op)
        {
            switch (op)
            {
                case '+':
                    return left + right;
                case '-':
                    return left - right;
                case '*':
                    return left * right;
                case '/':
                    return left / right;
                case '^':
                    return Math.Pow(left, right);
                default:
                    throw new ArgumentException("Обнаружен неизвестный оператор");
            }
        }

        /// <summary>
        /// Возвращает результат унарной операции в соответствии с переданными операндом и оператором.
        /// </summary>
        /// <param name="operand"></param>
        /// <param name="op"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double SolveUnary(double operand, char op)
        {
            switch (op)
            {
                case '!':
                    if (operand == (int)operand)
                        return FindFactorial((int)operand);
                    else throw new ArgumentException("Факториал от дробного числа неопределен");
                case 'a':
                    return Math.Abs(operand);
                default:
                    throw new ArgumentException("Обнаружен неизвестный оператор");
            }
        }

        private static int FindFactorial(int baseNum)
        {
            int result = 1;
            for (int i = 1; i <= baseNum; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
