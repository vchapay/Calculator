using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgainCalc
{
    public static class PostfixConverter
    {
        public static string Convert(string expression)
        {
            string converted = "";
            char c;
            char lastChar = '\0';
            expression = expression.Replace(" ", "");
            Stack<char> operators = new Stack<char>();
            List<string> operands = new List<string>();

            if (expression[0] == '+' || expression[0] == '-')
                expression = "0" + expression;

            for (int i = 0; i < expression.Length; i++)
            {
                c = expression[i];
                if (char.IsDigit(c))
                {
                    string number = "";
                    while(char.IsDigit(c) || c == ',')
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
                }

                if (Operation.IsBynary(c))
                {
                    if ((c == '-' || c == '+') && 
                        (Operation.IsOpenBracket(lastChar) || lastChar == '\0'))
                        converted += "0 ";

                    if (operators.Count > 0)
                        if (Operation.GetPriority(operators.Peek()) <= Operation.GetPriority(c))
                            converted += operators.Pop() + " ";

                    operators.Push(c);
                }

                if (Operation.IsOpenBracket(c))
                    operators.Push(c);

                if (Operation.IsCloseBracket(c))
                {
                    while (!Operation.IsOpenBracket(operators.Peek()))
                    {
                        converted += operators.Pop() + " ";
                    }

                    operators.Pop();

                    if (c == '}')
                        converted += "a ";
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

                lastChar = c;
            }

            while (operators.Count > 0)
            {
                converted += operators.Pop() + " ";
            }

            return converted;
        }
    }
}
