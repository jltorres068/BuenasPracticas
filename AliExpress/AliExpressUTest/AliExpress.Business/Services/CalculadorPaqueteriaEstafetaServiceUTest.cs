using AliExpress.AliExpress.Business.Services;
using AliExpress.AliExpress.Data.Entites.Enumerables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AliExpressUTest.AliExpress.Business.Services
{
    [TestClass]
    public class CalculadorPaqueteriaEstafetaServiceUTest
    {
        [TestMethod]
        public void CalcularMargenUtilidad_FechaPedido14Febrero_Retorna10()
        {
            //Arrange
            DateTime dtFechaPedido = new DateTime(2020, 02, 14);
            CalculadorPaqueteriaEstafetaService calculadorPaqueteriaEstafetaService = new CalculadorPaqueteriaEstafetaService();

            //Act
            Double dUtilidad = calculadorPaqueteriaEstafetaService.CalcularMargenUtilidad(dtFechaPedido);

            //Arrange
            Assert.IsTrue(dUtilidad == 10);
        }

        [TestMethod]
        public void CalcularMargenUtilidad_FechaPedidoMesDiciembre_Retorna50()
        {
            //Arrange
            DateTime dtFechaPedido = new DateTime(2020, 12, 06);
            CalculadorPaqueteriaEstafetaService calculadorPaqueteriaEstafetaService = new CalculadorPaqueteriaEstafetaService();

            //Act
            Double dUtilidad = calculadorPaqueteriaEstafetaService.CalcularMargenUtilidad(dtFechaPedido);

            //Arrange
            Assert.IsTrue(dUtilidad == 50);
        }

        [TestMethod]
        public void CalcularMargenUtilidad_FechaPedidoMesNoviembre_Retorna45()
        {
            //Arrange
            DateTime dtFechaPedido = new DateTime(2020, 11, 06);
            CalculadorPaqueteriaEstafetaService calculadorPaqueteriaEstafetaService = new CalculadorPaqueteriaEstafetaService();

            //Act
            Double dUtilidad = calculadorPaqueteriaEstafetaService.CalcularMargenUtilidad(dtFechaPedido);

            //Arrange
            Assert.IsTrue(dUtilidad == 45);
        }

        [TestMethod]
        public void CalculadorTiempoReparto_ITransporteTerrestre_Retorna008()
        {
            //Arrange
            Double dTiempoReparto = 0;
            int iTransporte = (int)EnumTransportes.Terrestre;
            CalculadorPaqueteriaEstafetaService calculadorPaqueteriaEstafetaService = new CalculadorPaqueteriaEstafetaService();

            //Act
            dTiempoReparto = calculadorPaqueteriaEstafetaService.CalculadorTiempoReparto(iTransporte);

            //Arrange
            Assert.IsTrue(dTiempoReparto == 0.08);
        }

        [TestMethod]
        public void CalculadorTiempoReparto_ITransporteAereo_Retorna0()
        {
            //Arrange
            Double dTiempoReparto = 0;
            int iTransporte = (int)EnumTransportes.Aéreo;
            CalculadorPaqueteriaEstafetaService calculadorPaqueteriaEstafetaService = new CalculadorPaqueteriaEstafetaService();

            //Act
            dTiempoReparto = calculadorPaqueteriaEstafetaService.CalculadorTiempoReparto(iTransporte);

            //Arrange
            Assert.IsTrue(dTiempoReparto == 0);
        }
    }
}
