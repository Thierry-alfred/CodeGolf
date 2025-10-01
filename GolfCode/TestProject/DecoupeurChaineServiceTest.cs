using GolfCodeDomaine.Services;
namespace TestProject
{
    public class DecoupeurChaineServiceTest
    {
        [Fact]
        public void PourUneChaineContenantDesCaratere_OnAppelDecouperElement()
        {
            //Act
            string chaine = "22 + 3 * sqrt(50) + 2";

            //Arrange
            List<string> resultat = DecoupeurChaineService.DecouperEnElements(chaine);
            
            //Assert
            Assert.Equal(10,     resultat.Count);
            Assert.Equal("22",   resultat[0]);
            Assert.Equal("+",    resultat[1]);
            Assert.Equal("3",    resultat[2]);
            Assert.Equal("*",    resultat[3]);
            Assert.Equal("sqrt", resultat[4]);
            Assert.Equal("(",    resultat[5]);
            Assert.Equal("50",   resultat[6]);
            Assert.Equal(")",    resultat[7]);
            Assert.Equal("+",    resultat[8]);
            Assert.Equal("2",    resultat[9]);
        }
    }
}