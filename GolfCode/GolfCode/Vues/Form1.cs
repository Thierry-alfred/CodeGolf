using GolfCodeDomaine.Services;
namespace GolfCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtChaine_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == (char)Keys.Enter)
            {
                string chaine = txtChaine.Text;
                if (AnalyseurValidChaineService.AnalyseValidChaine(chaine))
                {
                    lblresult.Text = "Chaîne valide";
                    lblresult.ForeColor = Color.Green;
                    var elements = DecoupeurChaineService.DecouperEnElements(chaine);

                    var res = EvaluerChaineService.EvaluerChaine(elements);

                    lblEvaluer.Text = res;
                }
                else
                {
                    lblresult.Text = "Chaîne non valide";
                    lblresult.ForeColor = Color.Red;
                }
            }
        }
    }
}
