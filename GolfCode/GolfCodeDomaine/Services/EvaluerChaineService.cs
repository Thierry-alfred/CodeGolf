using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GolfCodeDomaine.Services
{
    public static class EvaluerChaineService
    {
        public static string EvaluerChaine(List<string> chaines)
        {
            bool continueExecution = true;
            string resultat = string.Empty;
            try
            {
                int sqrtcount = chaines.Count(op => op == "sqrt");
                for (int i = 0; i < sqrtcount; i++)
                {
                    chaines = OperationService.Sqrt(chaines);
                }

                while (chaines.Contains("("))
                {
                    chaines = OperationService.ExecuteParenthese(chaines);
                }

                resultat = OperationService.Excecute(chaines);
                return resultat;
            }
            catch
            {
                return "Erreur d'évaluation";
            }
        }

    }
}
