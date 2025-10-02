using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfCodeDomaine.Services
{
    public static class OperationService
    {
        public static List<string> Addition(List<string> chaines)
        {
            chaines = chaines.Select(c => c.Replace(',', '.')).ToList();
            int index = chaines.IndexOf("+");
            if (index == 0 && chaines.Count >= 2 && double.TryParse(chaines[1], NumberStyles.Any, CultureInfo.InvariantCulture, out double valeur))
            {
                chaines.RemoveAt(0);
                return chaines;
            }

            if (index - 1 >= 0 && index + 1 < chaines.Count &&
                double.TryParse(chaines[index - 1], NumberStyles.Any, CultureInfo.InvariantCulture, out double valeur1) &&
                double.TryParse(chaines[index + 1], NumberStyles.Any, CultureInfo.InvariantCulture, out double valeur2))
            {
                if (index - 2 >= 0 && chaines[index - 2] == "-")
                    valeur1 = -valeur1;
                double addition = valeur1 + valeur2;
                if(addition < 0 && index - 2 >= 0)
                {
                    chaines[index - 2] = "-";
                }
                else if(index - 2 >= 0)
                {
                    chaines[index - 2] = "+";
                }
                chaines[index - 1] = Math.Abs(addition).ToString();
                chaines.RemoveAt(index);
                chaines.RemoveAt(index);
                return chaines;
            }
            else
            {
                throw new Exception("Erreur d'évaluation");
            }
        }

        public static List<string> Multiplication(List<string> chaines)
        {
            int index = chaines.IndexOf("*");
            if (index - 1 >= 0 && index + 1 < chaines.Count &&
                double.TryParse(chaines[index - 1], NumberStyles.Any, CultureInfo.InvariantCulture, out double valeur1) &&
                double.TryParse(chaines[index + 1], NumberStyles.Any, CultureInfo.InvariantCulture, out double valeur2))
            {
                double multiplication = Math.Round(valeur1 * valeur2,2);
                chaines[index - 1] = multiplication.ToString();
                chaines.RemoveAt(index);
                chaines.RemoveAt(index);
                return chaines;
            }
            else
            {
                throw new Exception("Erreur d'évaluation");
            }
        }

        public static List<string> Pow(List<string> chaines)
        {
            int index = chaines.IndexOf("^");
            if (index - 1 >= 0 && index + 1 < chaines.Count &&
                double.TryParse(chaines[index - 1], NumberStyles.Any, CultureInfo.InvariantCulture, out double baseValue) &&
                double.TryParse(chaines[index + 1], NumberStyles.Any, CultureInfo.InvariantCulture, out double exponent))
            {
                double puissance = Math.Pow(baseValue, exponent);
                chaines[index - 1] = puissance.ToString();
                chaines.RemoveAt(index);
                chaines.RemoveAt(index);
                return chaines;
            }
            else
            {
                throw new Exception("Erreur d'évaluation");
            }
        }

        public static List<string> Sqrt(List<string> chaines)
        {
            int index = chaines.IndexOf("sqrt");
            if (index + 2 < chaines.Count && chaines[index + 1] == "(" && double.TryParse(chaines[index + 2], NumberStyles.Any, CultureInfo.InvariantCulture, out double valeur))
            {
                double racine = Math.Sqrt(valeur);
                chaines[index] = racine.ToString();
                chaines.RemoveAt(index + 1);
                chaines.RemoveAt(index + 1);
                if (index + 1 < chaines.Count && chaines[index + 1] == ")")
                {
                    chaines.RemoveAt(index + 1);
                }
                return chaines;
            }
            else
            {
                throw new Exception("Erreur d'évaluation");
            }
        }

        public static List<string> Division(List<string> chaines)
        {
            chaines = chaines.Select(c => c.Replace(',', '.')).ToList();
            int index = chaines.IndexOf("/");
            if (index - 1 >= 0 && index + 1 < chaines.Count &&
                double.TryParse(chaines[index - 1], NumberStyles.Any, CultureInfo.InvariantCulture, out double valeur1) &&
                double.TryParse(chaines[index + 1], NumberStyles.Any, CultureInfo.InvariantCulture, out double valeur2))
            {
                if (valeur2 == 0)
                {
                    throw new DivideByZeroException("Division par zéro impossible");
                }
                double division = valeur1 / valeur2;
                chaines[index - 1] = division.ToString();
                chaines.RemoveAt(index);
                chaines.RemoveAt(index);
                return chaines;
            }
            else
            {
                throw new Exception("Erreur d'évaluation");
            }
        }

        public static List<string> Soustraction(List<string> chaines)
        {
            chaines = chaines.Select(c => c.Replace(',', '.')).ToList();
            int index = chaines.IndexOf("-");
            if (index == 0 && chaines.Count >= 2 && double.TryParse(chaines[1], NumberStyles.Any, CultureInfo.InvariantCulture, out double valeurNeg))
            {
                chaines[0] = (-valeurNeg).ToString(); 
                chaines.RemoveAt(1);                  
                return chaines;         
            }
            if (index - 1 >= 0 && index + 1 < chaines.Count &&
                double.TryParse(chaines[index - 1], NumberStyles.Any, CultureInfo.InvariantCulture, out double valeur1) &&
                double.TryParse(chaines[index + 1], NumberStyles.Any, CultureInfo.InvariantCulture, out double valeur2))
            {
                double soustraction = valeur1 - valeur2;
                chaines[index - 1] = soustraction.ToString();
                chaines.RemoveAt(index);
                chaines.RemoveAt(index);
                return chaines;
            }
            else
            {
                throw new Exception("Erreur d'évaluation");
            }
        }

        public static List<string> OperationDeSigne(List<string> chaines)
        {
            for (int i = 0; i < chaines.Count - 1; i++)
            {
                string actuel = chaines[i];
                string suivant = chaines[i + 1];

                if ((actuel == "+" || actuel == "-") && (suivant == "+" || suivant == "-"))
                {
                    string nouveauSigne;
                    if (actuel == suivant)
                        nouveauSigne = "+";
                    else 
                        nouveauSigne = "-";

                    chaines[i] = nouveauSigne;
                    chaines.RemoveAt(i + 1);
                    i--; 
                }
            }
            return chaines;
        }

        public static List<string> ExecuteParenthese(List<string> chaines)
        {
            int debut = chaines.IndexOf("(");
            int fin = chaines.IndexOf(")");

            var sousListe = chaines.GetRange(debut + 1, fin - debut - 1);

            string valeur = Excecute(sousListe);
            
            chaines.RemoveRange(debut, fin - debut + 1);
            chaines.Insert(debut,valeur.ToString());

            return chaines;
        }

        public static string Excecute(List<string> chaines)
        {
            int powcount = chaines.Count(op => op == "^");
            for (int i = 0; i < powcount; i++)
            {
                chaines = OperationService.Pow(chaines);
            }

            int multiplicationCount = chaines.Count(op => op == "*");
            for (int i = 0; i < multiplicationCount; i++)
            {
                chaines = OperationService.Multiplication(chaines);
            }

            int divisionCount = chaines.Count(op => op == "/");
            for (int i = 0; i < divisionCount; i++)
            {
                chaines = OperationService.Division(chaines);
            }

            chaines = OperationService.OperationDeSigne(chaines);

            while (chaines.Contains("+"))
            {
                chaines = OperationService.Addition(chaines);
            }

            int soustractionCount = chaines.Count(op => op == "-");
            for (int i = 0; i < soustractionCount; i++)
            {
                chaines = OperationService.Soustraction(chaines);
            }

            return string.Join(" ",chaines);
        }
    }
}
