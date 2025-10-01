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
                var service = new AnalyseurValidChaineService();
                string chaine = txtChaine.Text;
                if (service.AnalyseValidChaine(chaine))
                {
                    lblresult.Text = "Chaîne valide";
                    lblresult.ForeColor = Color.Green;
                    var res = new DecoupeurChaineService().DecouperEnElements(chaine);
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
