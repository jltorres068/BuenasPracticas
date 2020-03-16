using AliExpress.AliExpress.Business.Services;
using AliExpress.AliExpress.Data.Entites.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AliExpressUTest.AliExpress.Business.Services
{
    [TestClass]
    public class CalculadorTransporteMaritimoServiceUTest
    {
        [TestMethod]
        public void CalcularCostoEnvio_DatosPaquetesCorrectos_RetornaCostoEnvioMayorACero()
        {
            //Arrange
            CalculadorTransporteMaritimoService calculadorTransporteMaritimoService = new CalculadorTransporteMaritimoService();
            DatosPaqueteDTO datosPaqueteDTO = LlenarPedidoDatosCorrectos();

            //Act
            Double dCostoEnvio = calculadorTransporteMaritimoService.CalcularCostoEnvio(datosPaqueteDTO);

            //Assert
            Assert.IsTrue(dCostoEnvio > 0);
        }

        [TestMethod]
        public void CalcularCostoEnvio_DatosPaquetesIncorrectos_RetornaCostoEnvioCero()
        {
            //Arrange
            CalculadorTransporteMaritimoService calculadorTransporteMaritimoService = new CalculadorTransporteMaritimoService();
            DatosPaqueteDTO datosPaqueteDTO = LlenarPedidoDatosConError();

            //Act
            Double dCostoEnvio = calculadorTransporteMaritimoService.CalcularCostoEnvio(datosPaqueteDTO);

            //Assert
            Assert.IsTrue(dCostoEnvio == 0);
        }

        [TestMethod]
        public void CalcularTiempoTraslado_DatosPaquetesCorrectos_RetornaTiempoTrasladoMayorACero()
        {
            //Arrange
            CalculadorTransporteMaritimoService calculadorTransporteMaritimoService = new CalculadorTransporteMaritimoService();
            DatosPaqueteDTO datosPaqueteDTO = LlenarPedidoDatosCorrectos();

            //Act
            Double dTiempoTraslado = calculadorTransporteMaritimoService.CalcularTiempoTraslado(datosPaqueteDTO);

            //Assert
            Assert.IsTrue(dTiempoTraslado > 0);
        }

        [TestMethod]
        public void CalcularTiempoTraslado_DatosPaquetesIncorrectos_RetornaTiempoTrasladoNaN()
        {
            //Arrange
            CalculadorTransporteMaritimoService calculadorTransporteMaritimoService = new CalculadorTransporteMaritimoService();
            DatosPaqueteDTO datosPaqueteDTO = LlenarPedidoDatosConError();

            //Act
            Double dTiempoTraslado = calculadorTransporteMaritimoService.CalcularTiempoTraslado(datosPaqueteDTO);

            //Assert
            Assert.IsTrue(Double.IsNaN(dTiempoTraslado));
        }

        [TestMethod]
        public void CalcularCostoKM_Distancia88_RetornaCostoKm1()
        {
            //Arrange
            Double dDistancia = 88;
            CalculadorTransporteMaritimoService calculadorTransporteMaritimoService = new CalculadorTransporteMaritimoService();

            //Act
            Double dCostoKm = calculadorTransporteMaritimoService.CalcularCostoKM(dDistancia);

            //Assert
            Assert.IsTrue(dCostoKm == 1);
        }

        [TestMethod]
        public void CalcularCostoKM_Distancia888_RetornaCostoKmCeroPuntoCinco()
        {
            //Arrange
            Double dDistancia = 888;
            CalculadorTransporteMaritimoService calculadorTransporteMaritimoService = new CalculadorTransporteMaritimoService();

            //Act
            Double dCostoKm = calculadorTransporteMaritimoService.CalcularCostoKM(dDistancia);

            //Assert
            Assert.IsTrue(dCostoKm == 0.5);
        }

        [TestMethod]
        public void CalcularCostoKM_Distancia8888_RetornaCostoKmCeroPuntoTres()
        {
            //Arrange
            Double dDistancia = 8888;
            CalculadorTransporteMaritimoService calculadorTransporteMaritimoService = new CalculadorTransporteMaritimoService();

            //Act
            Double dCostoKm = calculadorTransporteMaritimoService.CalcularCostoKM(dDistancia);

            //Assert
            Assert.IsTrue(dCostoKm == 0.3);
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
