

using System.Text.RegularExpressions;

namespace GolfCodeDomaine.Services
{
    public class DecoupeurChaineService
    {
         private static readonly Regex _regexElements = new Regex(@"(\d+\.?\d*|[-+*/^()]|sqrt)", RegexOptions.Compiled);

        /// <summary>
        /// Découpe une chaîne en éléments (nombres, opérateurs).
        /// </summary>
        /// <param name="expression">Chaîne à découper.</param>
        /// <returns>Liste d'éléments.</returns>
        public List<string> DecouperEnElements(string expression)
        {
            var elements = new List<string>();
            var correspondances = _regexElements.Matches(expression);

            foreach (Match correspondance in correspondances)
            {
                if (!string.IsNullOrWhiteSpace(correspondance.Value))
                {
                    elements.Add(correspondance.Value.Trim());
                }
            }

            return elements;
        }
    }
}
