using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator_duble2
{
    public class Calc
    {
        public string Option(string expression)
        {
            var values = GetValues(expression);
            if (values.Item2 == "/" && values.Item3 == "0")
            {
                return "NOT ÷ 0";
            }
            switch (values.Item2)
            {
                case "*": return Multiply(values.Item1, values.Item3) < 999999999 && Multiply(values.Item1, values.Item3) > -999999999 ? Multiply(values.Item1, values.Item3).ToString() : "EXCEEDED";
                case "/": return Divide(values.Item1, values.Item3) < 999999999 && Divide(values.Item1, values.Item3) > -999999999 ? Divide(values.Item1, values.Item3).ToString() : "EXCEEDED"; ;
                case "+": return Sum(values.Item1, values.Item3) < 999999999 && Sum(values.Item1, values.Item3) > -999999999 ? Sum(values.Item1, values.Item3).ToString() : "EXCEEDED"; ;
                case "-": return Minus(values.Item1, values.Item3) < 999999999 && Minus(values.Item1, values.Item3) > -999999999 ? Minus(values.Item1, values.Item3).ToString() : "EXCEEDED";
                default: return "error";
            }
        }
        public int Multiply(string first, string second)
        {
            return int.Parse(first) * int.Parse(second);
        }
        public int Divide(string first, string second)
        {
            return int.Parse(first)/ int.Parse(second);
        }
        public int Sum(string first, string second)
        {
            return int.Parse(first) + int.Parse(second);
        }
        public int Minus(string first, string second)
        {
            return (int)int.Parse(first) - int.Parse(second);
        }
        public (string, string, string) GetValues(string expression)
        {
            Regex regex = new Regex(@"([+, -])?(\d+)(.)(\d+)");
            return (regex.Match(expression).Groups[1].Value + regex.Match(expression).Groups[2].Value, regex.Match(expression).Groups[3].Value, regex.Match(expression).Groups[4].Value);
        }
      

    }
}
