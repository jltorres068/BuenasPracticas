using AliExpress.AliExpress.Business.Estrategia;
using AliExpress.AliExpress.Business.Services;
using AliExpress.Interfaces.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AliExpressUTest.AliExpress.Business.Estrategia
{
    [TestClass]
    public class EstrategiaCalculadorPaqueteriaServiceUTest
    {
        [TestMethod]
        public void CrearInstancia_IPaqueteriaValorUno_RetornaInstanciaCalculadorPaqueteriaFedexService()
        {
            //Arrange
            ICalculadorPaqueteriaService calculadorPaqueteriaService = null;
            EstrategiaCalculadorPaqueteriaService estrategiaCalculadorPaqueteriaService = new EstrategiaCalculadorPaqueteriaService();
            
            //Act
             calculadorPaqueteriaService = estrategiaCalculadorPaqueteriaService.CrearInstancia(1);

            //Assert
            Assert.IsInstanceOfType(calculadorPaqueteriaService, typeof(CalculadorPaqueteriaFedexService));
        }

        [TestMethod]
        public void CrearInstancia_IPaqueteriaValorCero_RetornaInstanciaNull()
        {
            //Arrange
            ICalculadorPaqueteriaService calculadorPaqueteriaService = null;
            EstrategiaCalculadorPaqueteriaService estrategiaCalculadorPaqueteriaService = new EstrategiaCalculadorPaqueteriaService();

            //Act
            calculadorPaqueteriaService = estrategiaCalculadorPaqueteriaService.CrearInstancia(0);

            //Assert
            Assert.IsNull(calculadorPaqueteriaService);
        }
    }
}
