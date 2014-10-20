using ExpressionEvaluator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WatchfaceStudio.Entities
{
    public static class ExpressionCalculator
    {
        private static Regex ConditionalRegex = new Regex(@"\$([^\$]+)\$");

        public static double Calc(string formula)
        {
            try
            {
                if (string.IsNullOrEmpty(formula)) return 0;
                var resolvedFormula = FacerTags.ResolveTags(formula).Replace(" ", string.Empty);
                double dblVal;
                if (double.TryParse(resolvedFormula, out dblVal))
                    return dblVal;

                //convert formula to c#
                resolvedFormula = ConditionalRegex.Replace(resolvedFormula, "($1)");
                resolvedFormula = resolvedFormula
                    .Replace("=", "==")
                    .Replace('[', '(')
                    .Replace(']', ')')
                    .Replace(">==", ">=")
                    .Replace("<==", "<=")
                    .Replace("!==", "!=");
                var expression = new CompiledExpression(resolvedFormula);
                var result = expression.Eval();
                return Convert.ToDouble(result);
            }
            catch
            {
                throw new Exception("Couldn't parse '" + Convert.ToString(formula) + "'");
            }
        }
    }
}
