using AliExpress.AliExpress.Business.Services;
using AliExpress.AliExpress.Data.Entites.Enumerables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliExpressUTest.AliExpress.Business.Services
{
    [TestClass]
    public class CalculadorPaqueteriaFedexServiceUTest
    {
        [TestMethod]
        public void CalcularMargenUtilidad_FechaPedidoMesEnero_Retorna30()
        {
            //Arrange
            DateTime dtFechaPedido = new DateTime(2020, 01, 14);
            CalculadorPaqueteriaFedexService calculadorPaqueteriaFedexService = new CalculadorPaqueteriaFedexService();

            //Act
            Double dUtilidad = calculadorPaqueteriaFedexService.CalcularMargenUtilidad(dtFechaPedido);

            //Arrange
            Assert.IsTrue(dUtilidad == 30);
        }

        [TestMethod]
        public void CalcularMargenUtilidad_FechaPedidoMesFebrero_Retorna40()
        {
            //Arrange
            DateTime dtFechaPedido = new DateTime(2020, 02, 06);
            CalculadorPaqueteriaFedexService calculadorPaqueteriaFedexService = new CalculadorPaqueteriaFedexService();

            //Act
            Double dUtilidad = calculadorPaqueteriaFedexService.CalcularMargenUtilidad(dtFechaPedido);

            //Arrange
            Assert.IsTrue(dUtilidad == 40);
        }

        [TestMethod]
        public void CalculadorTiempoReparto_ITransporteTerrestre_Retorna10()
        {
            //Arrange
            Double dTiempoReparto = 0;
            int iTransporte = (int)EnumTransportes.Terrestre;
            CalculadorPaqueteriaFedexService calculadorPaqueteriaFedexService = new CalculadorPaqueteriaFedexService();

            //Act
            dTiempoReparto = calculadorPaqueteriaFedexService.CalculadorTiempoReparto(iTransporte);

            //Arrange
            Assert.IsTrue(dTiempoReparto == 10);
        }

        [TestMethod]
        public void CalculadorTiempoReparto_ITransporteAereo_Retorna0()
        {
            //Arrange
            Double dTiempoReparto = 0;
            int iTransporte = (int)EnumTransportes.Aéreo;
            CalculadorPaqueteriaFedexService calculadorPaqueteriaFedexService = new CalculadorPaqueteriaFedexService();

            //Act
            dTiempoReparto = calculadorPaqueteriaFedexService.CalculadorTiempoReparto(iTransporte);

            //Arrange
            Assert.IsTrue(dTiempoReparto == 0);
        }

        [TestMethod]
        public void CalculadorTiempoReparto_ITransporteMaritimo_Retorna21()
        {
            //Arrange
            Double dTiempoReparto = 0;
            int iTransporte = (int)EnumTransportes.Marítimo;
            CalculadorPaqueteriaFedexService calculadorPaqueteriaFedexService = new CalculadorPaqueteriaFedexService();

            //Act
            dTiempoReparto = calculadorPaqueteriaFedexService.CalculadorTiempoReparto(iTransporte);

            //Arrange
            Assert.IsTrue(dTiempoReparto == 21);
        }
    }
}
