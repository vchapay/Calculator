using System;
using System.Linq;

namespace AgainCalc
{
    internal static class Operation
    {
        private static readonly Random rnd = new Random();

        private static readonly string[] unaryFunctions = new string[]
        {
            "sin",
            "cos",
            "tg",
            "ctg",
            "lg",
            "ln",
            "randb",
            "sec",
            "csc",
            "asin",
            "acos",
            "atg",
            "actg",
            "ceilling",
            "floor",
            "round",
            "trun"
        };

        private static readonly string[] binaryFunctions = new string[]
        {
            "log",
            "rand"
        };

        public const string Constants = "πeφ";

        /// <summary>
        /// Возвращает число от 1 до 4, означающее приоритетность оператора.
        /// </summary>
        /// <param name="op">Оператор</param>
        /// <returns>Приоритетность в виде числа от 1 до 4</returns>
        public static int GetPriority(char op)
        {
            switch (op)
            {
                case '(':
                case '[':
                case '{':
                    return 0;
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
                    return 5;
            }
        }

        public static bool IsConstantName(string name)
        {
            return Constants.Contains(name);
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
            return "()[]{}".Contains(ch);
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

        public static bool IsFunction(string name)
        {
            return unaryFunctions.Contains(name) || binaryFunctions.Contains(name);
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
                    throw new ArgumentException("Обнаружен неизвестный бинарный оператор");
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
                    throw new ArgumentException("Обнаружен неизвестный унарный оператор");
            }
        }

        public static double SolveFunction(string func, params double[] args)
        {
            if (args == null || args.Length == 0)
                throw new ArgumentException("Не было передано ни одного аргумента для математической функции");

            if (IsUnaryFunction(func))
                return SolveUnaryFunction(func, args[0]);

            if (args.Length < 2)
                throw new ArgumentException("Недостаточно аргументов для математической функции");

            return SolveBinaryFunction(func, args);
        }

        private static double SolveBinaryFunction(string func, double[] args)
        {
            switch (func)
            {
                case "log":
                    return Math.Log(args[1], args[0]);
                case "rand":
                    if ((int)args[0] > (int)args[1])
                        return rnd.Next((int)args[1], (int)args[0]);
                    else return 0;
                default: throw new ArgumentException("Обнаружена неизвестная функция");
            }
        }

        private static double SolveUnaryFunction(string func, double arg)
        {
            switch (func)
            {
                case "sin":
                    return Math.Sin(arg);
                case "cos":
                    return Math.Cos(arg);
                case "tg":
                    return Math.Tan(arg);
                case "ctg":
                    return 1 / Math.Tan(arg);
                case "lg":
                    return Math.Log10(arg);
                case "ln":
                    return Math.Log(arg);
                case "randb":
                    return rnd.NextDouble() + arg;
                case "abs":
                    return Math.Abs(arg);
                case "sec":
                    return 1 / Math.Cos(arg);
                case "csc":
                    return 1 / Math.Sin(arg);
                case "asin":
                    return Math.Asin(arg);
                case "acos":
                    return Math.Acos(arg);
                case "atg":
                    return Math.Atan(arg);
                case "actg":
                    return Math.Atan(-arg) + Math.PI / 2;
                case "ceilling":
                    return Math.Ceiling(arg);
                case "floor":
                    return Math.Floor(arg);
                case "round":
                    return Math.Round(arg);
                case "trun":
                    return Math.Truncate(arg);
                default: throw new ArgumentException("Обнаружена неизвестная функция");
            }
        }

        public static bool IsUnaryFunction(string func)
        {
            return unaryFunctions.Contains(func);
        }

        private static double FindFactorial(int baseNum)
        {
            double result = 1;
            for (int i = 1; i <= baseNum; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
