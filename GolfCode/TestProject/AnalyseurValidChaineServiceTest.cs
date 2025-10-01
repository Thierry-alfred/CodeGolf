using GolfCodeDomaine.Services;
namespace TestProject
{
    public class AnalyseurValidChaineServiceTest
    {
        [Fact]
        public void PourUneChaineContenantDesCaratereNonValide_RetourneFaux()
        {
            //Act
            string chaine = "2 + 3 * a";
            //Arrange
            bool resultat = AnalyseurValidChaineService.AnalyseValidChaine(chaine);
            //Assert

            Assert.False(resultat);
        }

        [Fact]
        public void PourUneChaineContenantDesCaratereValide_RetourneVrai()
        {
            //Act
            string chaine = "2 ^ 5 + 3 * 8";
            //Arrange
            bool resultat = AnalyseurValidChaineService.AnalyseValidChaine(chaine);
            //Assert

            Assert.True(resultat);
        }

        [Fact]
        public void PourUneChaineContenantDesCaratereValideAvecValeurAbsolue_RetourneVrai()
        {
            //Act
            string chaine = "2 + 3 * 8 + sqrt(4)";
            //Arrange
            bool resultat = AnalyseurValidChaineService.AnalyseValidChaine(chaine);
            //Assert

            Assert.True(resultat);
        }
    }
}