using System.Collections.Generic;

namespace AgainCalc
{
    /// <summary>
    /// Предоставляет логику для преобразования строкового
    /// выражения в постфиксную форму
    /// </summary>
    public static class PostfixConverter
    {
        /// <summary>
        /// Записывает заданное строковое выражение в постфиксной форме
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string Convert(string expression)
        {
            string converted = "";
            char c;
            string lastToken = "";
            expression = expression.Replace(" ", "");

            Stack<char> operators = new Stack<char>();
            List<string> operands = new List<string>();
            Stack<string> funcs = new Stack<string>();

            if (expression[0] == '+' || expression[0] == '-')
                expression = "0" + expression;

            expression = InputPresenter.IntrepretateModuleBrackets(expression);

            try
            {
                for (int i = 0; i < expression.Length; i++)
                {
                    c = expression[i];
                    if (char.IsDigit(c))
                    {
                        string number = "";
                        while (char.IsDigit(c) || c == ',')
                        {
                            number += expression[i];
                            i++;
                            if (i == expression.Length) break;

                            c = expression[i];
                        }

                        converted += number + " ";
                        operands.Add(number);
                        i--;

                        c = expression[i];

                        lastToken = number;
                        continue;
                    }

                    if (Operation.IsBynary(c))
                    {
                        if ((c == '-' || c == '+') &&
                            (Operation.IsOpenBracket(lastToken[0]) || lastToken == ""))
                            converted += "0 ";

                        if (operators.Count > 0)
                            if (Operation.GetPriority(operators.Peek()) >= Operation.GetPriority(c))
                                converted += operators.Pop() + " ";

                        operators.Push(c);
                    }

                    if (Operation.IsOpenBracket(c))
                        operators.Push(c);

                    if (Operation.IsCloseBracket(c))
                    {
                        char openBr = '\0';
                        switch (c)
                        {
                            case ')':
                                openBr = '(';
                                break;
                            case ']':
                                openBr = '[';
                                break;
                            case '}':
                                openBr = '{';
                                break;
                        }

                        while (operators.Peek() != openBr)
                        {
                            converted += operators.Pop() + " ";
                        }

                        operators.Pop();

                        if (c == '}')
                            converted += "a ";

                        if (funcs.Count > 0)
                            converted += funcs.Pop() + " ";
                    }

                    if (c == '%')
                    {
                        if (operators.Count > 0 && !Operation.IsOpenBracket(operators.Peek()))
                        {
                            string first = operands[operands.Count - 2];
                            converted += $"{first} * 100 / {operators.Pop()}";
                        }

                        else converted += "100 / ";
                    }

                    if (Operation.IsUnary(c) && c != '%')
                    {
                        converted += c + " ";
                    }

                    if (char.IsLetter(c))
                    {
                        string f = "";
                        while (char.IsLetter(c))
                        {
                            f += c;
                            i++;

                            if (i == expression.Length)
                                break;

                            c = expression[i];
                        }

                        i--;
                        funcs.Push(f);
                        lastToken = f;
                        continue;
                    }

                    lastToken = c.ToString();
                }

                while (operators.Count > 0)
                {
                    converted += operators.Pop() + " ";
                }

                return converted;
            }

            catch { return ""; }
        }
    }
}
