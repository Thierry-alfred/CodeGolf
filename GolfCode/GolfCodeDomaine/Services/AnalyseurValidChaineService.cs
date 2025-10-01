using System.Text.RegularExpressions;

namespace GolfCodeDomaine.Services
{
    public static class AnalyseurValidChaineService
    {
        private static readonly Regex _regexValide = new Regex(@"^(?:[\d+\-*/^().\s]+|sqrt)+$", RegexOptions.Compiled);

        /// <summary>
        /// Vérifie si la chaîne ne contient que des caractères autorisés.
        /// </summary>
        /// <param name="chaine">Chaîne à analyser.</param>
        /// <returns>True si valide, sinon False.</returns>
        public static bool AnalyseValidChaine(string chaine)
        {
            if (string.IsNullOrWhiteSpace(chaine))
                return false;

            return _regexValide.IsMatch(chaine);
        }
    }
}
