using GolfCodeDomaine.Services;
namespace TestProject
{
    public class OperationServiceTest
    {
        [Fact]
        public void PourUneChaineContenantOperationSqrt_OnAppelLeServiceSqrt()
        {
            //Act
            string chaine = "21 + 6 -7 * 2 / 2 - 2^2 + sqrt(4) - 6";
            var decoup = DecoupeurChaineService.DecouperEnElements(chaine);

            //Arrange
            List<string> resultat = OperationService.Sqrt(decoup);
            
            //Assert
            Assert.Equal(17,     resultat.Count);
            Assert.Equal("21",   resultat[0]);
            Assert.Equal("+",    resultat[1]);
            Assert.Equal("6",    resultat[2]);
            Assert.Equal("-",    resultat[3]);
            Assert.Equal("7", resultat[4]);
            Assert.Equal("*",    resultat[5]);
            Assert.Equal("2",   resultat[6]);
            Assert.Equal("/",    resultat[7]);
            Assert.Equal("2",    resultat[8]);
            Assert.Equal("-",    resultat[9]);
            Assert.Equal("2",    resultat[10]);
            Assert.Equal("^",    resultat[11]);
            Assert.Equal("2",    resultat[12]);
            Assert.Equal("+",    resultat[13]);
            Assert.Equal("2",    resultat[14]);
            Assert.Equal("-",    resultat[15]);
            Assert.Equal("6",    resultat[16]);
        }

        [Fact]
        public void PourUneChaineContenantOperationMultiplication_OnAppelLeServiceMultiplication()
        {
            //Act
            string chaine = "21 + 6 -7 * 2 / 2";
            var decoup = DecoupeurChaineService.DecouperEnElements(chaine);

            //Arrange
            List<string> resultat = OperationService.Multiplication(decoup);

            //Assert
            Assert.Equal(7, resultat.Count);
            Assert.Equal("21", resultat[0]);
            Assert.Equal("+", resultat[1]);
            Assert.Equal("6", resultat[2]);
            Assert.Equal("-", resultat[3]);
            Assert.Equal("14", resultat[4]);
            Assert.Equal("/", resultat[5]);
            Assert.Equal("2", resultat[6]);
        }

        [Fact]
        public void PourUneChaineContenantOperationDivision_OnAppelLeServiceDivision()
        {
            //Act
            string chaine = "21 + 6 -7 * 2 / 2";
            var decoup = DecoupeurChaineService.DecouperEnElements(chaine);

            //Arrange
            List<string> resultat = OperationService.Division(decoup);

            //Assert
            Assert.Equal(7, resultat.Count);
            Assert.Equal("21", resultat[0]);
            Assert.Equal("+", resultat[1]);
            Assert.Equal("6", resultat[2]);
            Assert.Equal("-", resultat[3]);
            Assert.Equal("7", resultat[4]);
            Assert.Equal("*", resultat[5]);
            Assert.Equal("1", resultat[6]);
        }

        [Fact]
        public void PourUneChaineContenantOperationAddition_OnAppelLeServiceAddition()
        {
            //Act
            string chaine = "21 + 6 -7 * 2 / 2";
            var decoup = DecoupeurChaineService.DecouperEnElements(chaine);

            //Arrange
            List<string> resultat = OperationService.Addition(decoup);

            //Assert
            Assert.Equal(7, resultat.Count);
            Assert.Equal("27", resultat[0]);
            Assert.Equal("-", resultat[1]);
            Assert.Equal("7", resultat[2]);
            Assert.Equal("*", resultat[3]);
            Assert.Equal("2", resultat[4]);
            Assert.Equal("/", resultat[5]);
            Assert.Equal("2", resultat[6]);
        }

        [Fact]
        public void PourUneChaineContenantOperationSoustration_OnAppelLeServiceSoustraction()
        {
            //Act
            string chaine = "21 + 6 -7 * 2 / 2";
            var decoup = DecoupeurChaineService.DecouperEnElements(chaine);

            //Arrange
            List<string> resultat = OperationService.Soustraction(decoup);

            //Assert
            Assert.Equal(7, resultat.Count);
            Assert.Equal("21", resultat[0]);
            Assert.Equal("+", resultat[1]);
            Assert.Equal("-1", resultat[2]);
            Assert.Equal("*", resultat[3]);
            Assert.Equal("2", resultat[4]);
            Assert.Equal("/", resultat[5]);
            Assert.Equal("2", resultat[6]);
        }

        [Fact]
        public void PourUneChaineContenantOperationAvecPlusieurSigne_OnAppelLeServiceOperationDeSigne()
        {
            //Act
            string chaine = "- 1 --1";
            var decoup = DecoupeurChaineService.DecouperEnElements(chaine);

            //Arrange
            List<string> resultat = OperationService.OperationDeSigne(decoup);

            //Assert
            Assert.Equal(4, resultat.Count);
            Assert.Equal("-", resultat[0]);
            Assert.Equal("1", resultat[1]);
            Assert.Equal("+", resultat[2]);
            Assert.Equal("1", resultat[3]);
        }

        [Fact]
        public void PourUneChaineContenantOperationAvecPlusieurParenthese_OnAppelLeServiceExecuteParenthese()
        {
            //Act
            string chaine = "(2+5)*3";
            var decoup = DecoupeurChaineService.DecouperEnElements(chaine);

            //Arrange
            List<string> resultat = OperationService.ExecuteParenthese(decoup);

            //Assert
            Assert.Equal(3, resultat.Count);
            Assert.Equal("7", resultat[0]);
            Assert.Equal("*", resultat[1]);
            Assert.Equal("3", resultat[2]);
        }

        [Fact]
        public void PourUneChaineValide_OnAppelLeServiceExecute()
        {
            //Act
            string chaine = "2+5*3";
            var decoup = DecoupeurChaineService.DecouperEnElements(chaine);

            //Arrange
            string resultat = OperationService.Excecute(decoup);

            //Assert
            Assert.Equal("17", resultat);
        }

        [Fact]
        public void PourUneChaineContenantOperationDivisionParZero_OnRenvoieErreur()
        {
            //Act
            string chaine = "21 + 6 -7 * 2 / 0";
            var decoup = DecoupeurChaineService.DecouperEnElements(chaine);

            //Arrange Assert
            Assert.Throws<DivideByZeroException>(() => OperationService.Division(decoup));
        }
    }
}