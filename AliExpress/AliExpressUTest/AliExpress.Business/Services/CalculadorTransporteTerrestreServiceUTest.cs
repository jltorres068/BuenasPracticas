using AliExpress.AliExpress.Business.Services;
using AliExpress.AliExpress.Data.Entites.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AliExpressUTest.AliExpress.Business.Services
{
    [TestClass]
    public class CalculadorTransporteTerrestreServiceUTest
    {
        [TestMethod]
        public void CalcularCostoEnvio_DatosPaquetesCorrectos_RetornaCostoEnvioMayorACero()
        {
            //Arrange
            CalculadorTransporteTerrestreService calculadorTransporteTerrestreService = new CalculadorTransporteTerrestreService();
            DatosPaqueteDTO datosPaqueteDTO = LlenarPedidoDatosCorrectos();

            //Act
            Double dCostoEnvio = calculadorTransporteTerrestreService.CalcularCostoEnvio(datosPaqueteDTO);

            //Assert
            Assert.IsTrue(dCostoEnvio > 0);
        }

        [TestMethod]
        public void CalcularCostoEnvio_DatosPaquetesIncorrectos_RetornaCostoEnvioCero()
        {
            //Arrange
            CalculadorTransporteTerrestreService calculadorTransporteTerrestreService = new CalculadorTransporteTerrestreService();
            DatosPaqueteDTO datosPaqueteDTO = LlenarPedidoDatosConError();

            //Act
            Double dCostoEnvio = calculadorTransporteTerrestreService.CalcularCostoEnvio(datosPaqueteDTO);

            //Assert
            Assert.IsTrue(dCostoEnvio == 0);
        }

        [TestMethod]
        public void CalcularTiempoTraslado_DatosPaquetesCorrectos_RetornaTiempoTrasladoMayorACero()
        {
            //Arrange
            CalculadorTransporteTerrestreService calculadorTransporteTerrestreService = new CalculadorTransporteTerrestreService();
            DatosPaqueteDTO datosPaqueteDTO = LlenarPedidoDatosCorrectos();

            //Act
            Double dTiempoTraslado = calculadorTransporteTerrestreService.CalcularTiempoTraslado(datosPaqueteDTO);

            //Assert
            Assert.IsTrue(dTiempoTraslado > 0);
        }

        [TestMethod]
        public void CalcularTiempoTraslado_DatosPaquetesIncorrectos_RetornaTiempoTrasladoNaN()
        {
            //Arrange
            CalculadorTransporteTerrestreService calculadorTransporteTerrestreService = new CalculadorTransporteTerrestreService();
            DatosPaqueteDTO datosPaqueteDTO = LlenarPedidoDatosConError();

            //Act
            Double dTiempoTraslado = calculadorTransporteTerrestreService.CalcularTiempoTraslado(datosPaqueteDTO);

            //Assert
            Assert.IsTrue(Double.IsNaN(dTiempoTraslado));
        }

        [TestMethod]
        public void CalcularCostoKM_Distancia43_RetornaCostoKm15()
        {
            //Arrange
            Double dDistancia = 43;
            CalculadorTransporteTerrestreService calculadorTransporteTerrestreService = new CalculadorTransporteTerrestreService();

            //Act
            Double dCostoKm = calculadorTransporteTerrestreService.CalcularCostoKM(dDistancia);

            //Assert
            Assert.IsTrue(dCostoKm == 15);
        }

        [TestMethod]
        public void CalcularCostoKM_Distancia143_RetornaCostoKm10()
        {
            //Arrange
            Double dDistancia = 143;
            CalculadorTransporteTerrestreService calculadorTransporteTerrestreService = new CalculadorTransporteTerrestreService();

            //Act
            Double dCostoKm = calculadorTransporteTerrestreService.CalcularCostoKM(dDistancia);

            //Assert
            Assert.IsTrue(dCostoKm == 10);
        }

        [TestMethod]
        public void CalcularCostoKM_Distancia241_RetornaCostoKm8()
        {
            //Arrange
            Double dDistancia = 241;
            CalculadorTransporteTerrestreService calculadorTransporteTerrestreService = new CalculadorTransporteTerrestreService();

            //Act
            Double dCostoKm = calculadorTransporteTerrestreService.CalcularCostoKM(dDistancia);

            //Assert
            Assert.IsTrue(dCostoKm == 8);
        }

        [TestMethod]
        public void CalcularCostoKM_Distancia2421_RetornaCostoKm7()
        {
            //Arrange
            Double dDistancia = 2421;
            CalculadorTransporteTerrestreService calculadorTransporteTerrestreService = new CalculadorTransporteTerrestreService();

            //Act
            Double dCostoKm = calculadorTransporteTerrestreService.CalcularCostoKM(dDistancia);

            //Assert
            Assert.IsTrue(dCostoKm == 7);
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
