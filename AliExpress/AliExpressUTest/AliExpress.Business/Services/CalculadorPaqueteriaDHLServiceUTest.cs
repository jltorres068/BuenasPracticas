using AliExpress.AliExpress.Business.Services;
using AliExpress.AliExpress.Data.Entites.Enumerables;
using AliExpress.Interfaces.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliExpressUTest.AliExpress.Business.Services
{
    [TestClass]
    public class CalculadorPaqueteriaDHLServiceUTest
    {
        [TestMethod]
        public void CalcularMargenUtilidad_FechaPedidoMesJunio_Retorna50()
        {
            //Arrange
            DateTime dtFechaPedido = new DateTime(2020, 06, 06);
            CalculadorPaqueteriaDHLService calculadorPaqueteriaDHLService = new CalculadorPaqueteriaDHLService();

            //Act
            Double dUtilidad = calculadorPaqueteriaDHLService.CalcularMargenUtilidad(dtFechaPedido);

            //Arrange
            Assert.IsTrue(dUtilidad == 50);
        }

        [TestMethod]
        public void CalcularMargenUtilidad_FechaPedidoMesNoviembre_Retorna30()
        {
            //Arrange
            DateTime dtFechaPedido = new DateTime(2020, 11, 06);
            CalculadorPaqueteriaDHLService calculadorPaqueteriaDHLService = new CalculadorPaqueteriaDHLService();

            //Act
            Double dUtilidad = calculadorPaqueteriaDHLService.CalcularMargenUtilidad(dtFechaPedido);

            //Arrange
            Assert.IsTrue(dUtilidad == 30);
        }

        [TestMethod]
        public void CalculadorTiempoReparto_ITransporteAereo_Retorna3()
        {
            //Arrange
            Double dTiempoReparto = 0;
            int iTransporte = (int)EnumTransportes.Aéreo;
            CalculadorPaqueteriaDHLService calculadorPaqueteriaDHLService = new CalculadorPaqueteriaDHLService();

            //Act
            dTiempoReparto = calculadorPaqueteriaDHLService.CalculadorTiempoReparto(iTransporte);

            //Arrange
            Assert.IsTrue(dTiempoReparto == 3);
        }

        [TestMethod]
        public void CalculadorTiempoReparto_ITransporteMaritimo_Retorna20()
        {
            //Arrange
            Double dTiempoReparto = 0;
            int iTransporte = (int)EnumTransportes.Marítimo;
            CalculadorPaqueteriaDHLService calculadorPaqueteriaDHLService = new CalculadorPaqueteriaDHLService();

            //Act
            dTiempoReparto = calculadorPaqueteriaDHLService.CalculadorTiempoReparto(iTransporte);

            //Arrange
            Assert.IsTrue(dTiempoReparto == 20);
        }

        [TestMethod]
        public void CalculadorTiempoReparto_ITransporteTerrestre_Retorna12()
        {
            //Arrange
            Double dTiempoReparto = 0;
            int iTransporte = (int)EnumTransportes.Terrestre;
            CalculadorPaqueteriaDHLService calculadorPaqueteriaDHLService = new CalculadorPaqueteriaDHLService();

            //Act
            dTiempoReparto = calculadorPaqueteriaDHLService.CalculadorTiempoReparto(iTransporte);

            //Arrange
            Assert.IsTrue(dTiempoReparto == 12);
        }

        [TestMethod]
        public void CalculadorTiempoReparto_ITransporteCero_Retorna0()
        {
            //Arrange
            Double dTiempoReparto = 0;
            int iTransporte = 0;
            CalculadorPaqueteriaDHLService calculadorPaqueteriaDHLService = new CalculadorPaqueteriaDHLService();

            //Act
            dTiempoReparto = calculadorPaqueteriaDHLService.CalculadorTiempoReparto(iTransporte);

            //Arrange
            Assert.IsTrue(dTiempoReparto == 0);
        }
    }
}
