using AliExpress.AliExpress.Business.Services;
using AliExpress.AliExpress.Data.Entites.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AliExpressUTest.AliExpress.Business.Services
{
    [TestClass]
    public class CalculadorTransporteAereoServiceUTest
    {
        [TestMethod]
        public void CalcularCostoEnvio_DatosPaquetesCorrectos_RetornaCostoEnvioMayorACero()
        {
            //Arrange
            CalculadorTransporteAereoService calculadorTransporteAereoService = new CalculadorTransporteAereoService();
            DatosPaqueteDTO datosPaqueteDTO = LlenarPedidoDatosCorrectos();

            //Act
            Double dCostoEnvio = calculadorTransporteAereoService.CalcularCostoEnvio(datosPaqueteDTO);

            //Assert
            Assert.IsTrue(dCostoEnvio > 0);
        }

        [TestMethod]
        public void CalcularCostoEnvio_DatosPaquetesIncorrectos_RetornaCostoEnvioCero()
        {
            //Arrange
            CalculadorTransporteAereoService calculadorTransporteAereoService = new CalculadorTransporteAereoService();
            DatosPaqueteDTO datosPaqueteDTO = LlenarPedidoDatosConError();

            //Act
            Double dCostoEnvio = calculadorTransporteAereoService.CalcularCostoEnvio(datosPaqueteDTO);

            //Assert
            Assert.IsTrue(dCostoEnvio == 0);
        }

        [TestMethod]
        public void CalcularTiempoTraslado_DatosPaquetesCorrectos_RetornaTiempoTrasladoMayorACero()
        {
            //Arrange
            CalculadorTransporteAereoService calculadorTransporteAereoService = new CalculadorTransporteAereoService();
            DatosPaqueteDTO datosPaqueteDTO = LlenarPedidoDatosCorrectos();

            //Act
            Double dTiempoTraslado = calculadorTransporteAereoService.CalcularTiempoTraslado(datosPaqueteDTO);

            //Assert
            Assert.IsTrue(dTiempoTraslado > 0);
        }

        [TestMethod]
        public void CalcularTiempoTraslado_DatosPaquetesIncorrectos_RetornaTiempoTrasladoNaN()
        {
            //Arrange
            CalculadorTransporteAereoService calculadorTransporteAereoService = new CalculadorTransporteAereoService();
            DatosPaqueteDTO datosPaqueteDTO = LlenarPedidoDatosConError();

            //Act
            Double dTiempoTraslado = calculadorTransporteAereoService.CalcularTiempoTraslado(datosPaqueteDTO);
            
            //Assert
            Assert.IsTrue(Double.IsNaN(dTiempoTraslado));
        }

        private DatosPaqueteDTO LlenarPedidoDatosConError()
        {
            DatosPaqueteDTO datosPaqueteDTO = new DatosPaqueteDTO
            {
                dDistancia = 0,
                dUtilidad = 0,
                dVelocidad = 0,
                dTiempoReparto = 0,
            };
            return datosPaqueteDTO;
        }

        private DatosPaqueteDTO LlenarPedidoDatosCorrectos()
        {
            DatosPaqueteDTO datosPaqueteDTO = new DatosPaqueteDTO
            {
               dDistancia = 80,
               dUtilidad = 45,
               dVelocidad = 80,
               dTiempoReparto = 10,
            };
            return datosPaqueteDTO;
        }
    }
}
