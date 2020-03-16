using AliExpress.AliExpress.Business.Estrategia;
using AliExpress.AliExpress.Business.Services;
using AliExpress.Interfaces.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AliExpressUTest.AliExpress.Business.Estrategia
{
    [TestClass]
    public class EstrategiaCalculadorTransporteServiceUTest
    {
        [TestMethod]
        public void CrearInstancia_ITransporteValorUno_RetornaInstanciaCalculadorTransporteMaritimoService()
        {
            //Arrange
            ICalculadorTransporteService calculadorTransporteService = null;
            EstrategiaCalculadorTransporteService estrategiaCalculadorTransporteService = new EstrategiaCalculadorTransporteService();

            //Act
            calculadorTransporteService = estrategiaCalculadorTransporteService.CrearInstancia(1);

            //Assert
            Assert.IsInstanceOfType(calculadorTransporteService, typeof(CalculadorTransporteMaritimoService));
        }

        [TestMethod]
        public void CrearInstancia_ITransporteValorCero_RetornaInstanciaNulo()
        {
            //Arrange
            ICalculadorTransporteService calculadorTransporteService = null;
            EstrategiaCalculadorTransporteService estrategiaCalculadorTransporteService = new EstrategiaCalculadorTransporteService();

            //Act
            calculadorTransporteService = estrategiaCalculadorTransporteService.CrearInstancia(0);

            //Assert
            Assert.IsNull(calculadorTransporteService);
        }
    }
}
