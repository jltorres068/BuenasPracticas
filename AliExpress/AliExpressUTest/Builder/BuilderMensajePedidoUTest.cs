using AliExpress.AliExpress.Data.Entites.Enumerables;
using AliExpress.Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AliExpressUTest.Builder
{
    [TestClass]
    public class BuilderMensajePedidoUTest
    {
        [TestMethod]
        public void AsignarExpresion1_FechaEntregaMenorFechaActual_RetornaMensajeSalio()
        {
            string cMensajeEsperado = "Tu paquete salió ";
            DateTime dtFechaEntrega = DateTime.Now.AddDays(-10);
            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarExpresion1(dtFechaEntrega);
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }

        [TestMethod]
        public void AsignarExpresion1_FechaEntregaMayorFechaActual_RetornaMensajeHaSalido()
        {
            string cMensajeEsperado = "Tu paquete ha salido ";
            DateTime dtFechaEntrega = DateTime.Now.AddDays(10);
            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarExpresion1(dtFechaEntrega);
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }

        [TestMethod]
        public void AsignarOrigen_ParametrosConDatos_RetornaMensajeConDatosIngresados()
        {
            string cCiudadOrigen = "Orizaba", cPaisOrigen = "México";
            string cMensajeEsperado = " de Orizaba, México";

            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarOrigen(cCiudadOrigen, cPaisOrigen);
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }

        [TestMethod]
        public void AsignarOrigen_ParametrosSinDatos_RetornaMensajeSinDatosIngresados()
        {
            string cCiudadOrigen = string.Empty, cPaisOrigen = string.Empty;
            string cMensajeEsperado = " de , ";

            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarOrigen(cCiudadOrigen, cPaisOrigen);
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }

        [TestMethod]
        public void AsignarExpresion2_FechaEntregaMayorFechaActual_RetornaMensajeLlegara()
        {
            string cMensajeEsperado = " y llegará";
            DateTime dtFechaEntrega = DateTime.Now.AddDays(10);
            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarExpresion2(dtFechaEntrega);
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }

        [TestMethod]
        public void AsignarExpresion2_FechaEntregaMenorFechaActual_RetornaMensajeLlego()
        {
            string cMensajeEsperado = " y llegó";
            DateTime dtFechaEntrega = DateTime.Now.AddDays(-10);
            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarExpresion2(dtFechaEntrega);
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }

        [TestMethod]
        public void AsignarDestino_ParametrosConDatos_RetornaMensajeConDatosIngresados()
        {
            string cCiudadDestino = "Orizaba", cPaisDestino = "México";
            string cMensajeEsperado = " a Orizaba, México";

            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarDestino(cCiudadDestino, cPaisDestino);
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }

        [TestMethod]
        public void AsignarDestino_ParametrosSinDatos_RetornaMensajeSinDatosIngresados()
        {
            string cCiudadDestino = string.Empty, cPaisDestino = string.Empty;
            string cMensajeEsperado = " a , ";

            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarDestino(cCiudadDestino, cPaisDestino);
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }

        [TestMethod]
        public void AsignarExpresion3_FechaEntregaMenorFechaActual_RetornaMensajeHace()
        {
            string cMensajeEsperado = " hace";
            DateTime dtFechaEntrega = DateTime.Now.AddDays(-10);
            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarExpresion3(dtFechaEntrega);
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }

        [TestMethod]
        public void AsignarExpresion3_FechaEntregaMayorFechaActual_RetornaMensajeDentroDe()
        {
            string cMensajeEsperado = " dentro de";
            DateTime dtFechaEntrega = DateTime.Now.AddDays(10);
            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarExpresion3(dtFechaEntrega);
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }

        [TestMethod]
        public void AsignarRangoTiempo_ParametroConValor_RetornaMensajeConValor()
        {
            string cMensajeEsperado = " 23 minutos";
            DateTime dtFechaEntrega = DateTime.Now.AddDays(10);
            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarRangoTiempo("23 minutos");
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }

        [TestMethod]
        public void AsignarRangoTiempo_ParametroSinValor_RetornaMensajeSinValor()
        {
            string cMensajeEsperado = " ";
            DateTime dtFechaEntrega = DateTime.Now.AddDays(10);
            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarRangoTiempo(string.Empty);
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }

        [TestMethod]
        public void AsignarExpresion4_FechaEntregaMenorFechaActual_RetornaMensajeTuvo()
        {
            string cMensajeEsperado = " y tuvo";
            DateTime dtFechaEntrega = DateTime.Now.AddDays(-10);
            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarExpresion4(dtFechaEntrega);
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }

        [TestMethod]
        public void AsignarExpresion4_FechaEntregaMayorFechaActual_RetornaMensajeTendra()
        {
            string cMensajeEsperado = "y tendrá";
            DateTime dtFechaEntrega = DateTime.Now.AddDays(10);
            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarExpresion4(dtFechaEntrega);
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }

        [TestMethod]
        public void AsignarCostoEnvio_ParametroConValor_RetornaMensajeConValor()
        {
            string cMensajeEsperado = " un costo de $100.00";
            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarCostoEnvio(100);
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }

        [TestMethod]
        public void AsignarCostoEnvio_ParametroSinValor_RetornaMensajeSinValor()
        {
            string cMensajeEsperado = " un costo de $0.00";
            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarCostoEnvio(0);
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }

        [TestMethod]
        public void AsignarPaqueteria_ParametroConValor_RetornaMensajeConValor()
        {
            string cMensajeEsperado = " (Cualquier reclamación con DHL).";
            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarPaqueteria("DHL");
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }

        [TestMethod]
        public void AsignarPaqueteria_ParametroSinValor_RetornaMensajeSinValor()
        {
            string cMensajeEsperado = " (Cualquier reclamación con ).";
            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarPaqueteria(string.Empty);
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }

        [TestMethod]
        public void AsignarErrorPaqueteria_IErrorPaqueteriaValorPaqueteria_RetornaMensajeConValor()
        {
            string cMensajeEsperado = "La Paquetería: Correos no se encuentra registrada en nuestra red de distribución.";
            string cPaqueteria = "Correos";
            int iError = (int)EnumErrores.ErrorPaqueteria;
            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarErrorPaqueteria(iError, cPaqueteria);
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }

        [TestMethod]
        public void AsignarErrorPaqueteria_IErrorTansportePaqueteriaSinValor_RetornaMensajeVacio()
        {
            string cMensajeEsperado = string.Empty;
            int iError = (int)EnumErrores.ErrorTransporte;
            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarErrorPaqueteria(iError, string.Empty);
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }

        [TestMethod]
        public void AsignarErrorTransporte_IErrorTransporteValorTransporte_RetornaMensajeConValor()
        {
            string cMensajeEsperado = "Estafeta no ofrece el servicio de transporte Online, te recomendamos cotizar en otra empresa.";
            int iError = (int)EnumErrores.ErrorTransporte;
            string cTransporte = "Online", cPaqueteria = "Estafeta";
            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarErrorTransporte(iError, cPaqueteria, cTransporte);
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }

        [TestMethod]
        public void AsignarErrorTransporte_IErrorPaqueteriaValorTransporte_RetornaMensajeSinValor()
        {
            string cMensajeEsperado = string.Empty;
            int iError = (int)EnumErrores.ErrorPaqueteria;
            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarErrorTransporte(iError, string.Empty, string.Empty);
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }

        [TestMethod]
        public void AsignarPaqueteriaAlternativa_ParametrosConValor_RetornaMensajeConValor()
        {
            string cMensajeEsperado = "Si hubieras pedido en DHL te hubiera costado $210.00 más barato.";
            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarPaqueteriaAlternativa("DHL", 210);
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }

        [TestMethod]
        public void AsignarPaqueteriaAlternativa_ParametrosSinValor_RetornaMensajeSinValor()
        {
            string cMensajeEsperado = "Si hubieras pedido en  te hubiera costado $0.00 más barato.";
            BuilderMensajePedido builderMensajePedido = new BuilderMensajePedido();

            builderMensajePedido.AsignarPaqueteriaAlternativa(string.Empty, 0);
            string cMensaje = builderMensajePedido.ObtenerMensaje();

            Assert.AreEqual(cMensajeEsperado, cMensaje);
        }
    }
}
