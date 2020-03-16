using AliExpress.AliExpress.Business.Services.Validador;
using AliExpress.AliExpress.Data.Entites.DTO;
using AliExpress.Interfaces.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AliExpressUTest.AliExpress.Business.Services.Validador
{
    [TestClass]
    public class ValidadorTransporteServiceUTest
    {
        private Mock<IValidadorDatosPedidoService> validadorDatosPedidoService;

        [TestMethod]
        public void ValidarDatosPedido_CMedioTransporteCorrecta_RetornaDatosPaqueteDTOlErrorFalse()
        {
            //Arrange
            validadorDatosPedidoService = new Mock<IValidadorDatosPedidoService>();
            DatosPaqueteDTO datosPaqueteDTO = LlenarPedidoDatosCorrectos();

            var instanciaValidadorTransporteService = new ValidadorTransporteService();
            validadorDatosPedidoService.Setup((srv) => srv.ValidarDatosPedido(datosPaqueteDTO)).Returns(() => new DatosPaqueteDTO());

            //Act
            DatosPaqueteDTO datosPaqueteDTOResultado = instanciaValidadorTransporteService.ValidarDatosPedido(datosPaqueteDTO);

            //Assert
            Assert.IsFalse(datosPaqueteDTO.lError);
        }

        [TestMethod]
        public void ValidarDatosPedido_CMedioTransporteIncorrecta_RetornaDatosPaqueteDTOlErrorTrue()
        {
            //Arrange
            validadorDatosPedidoService = new Mock<IValidadorDatosPedidoService>();
            DatosPaqueteDTO datosPaqueteDTO = LlenarPedidoDatosConError();

            var instanciaValidadorTransporteService = new ValidadorTransporteService();
            validadorDatosPedidoService.Setup((srv) => srv.ValidarDatosPedido(datosPaqueteDTO)).Returns(() => new DatosPaqueteDTO());

            //Act
            DatosPaqueteDTO datosPaqueteDTOResultado = instanciaValidadorTransporteService.ValidarDatosPedido(datosPaqueteDTO);

            //Assert
            Assert.IsTrue(datosPaqueteDTO.lError);
        }

        private DatosPaqueteDTO LlenarPedidoDatosConError()
        {
            DatosPaqueteDTO datosPaqueteDTO = new DatosPaqueteDTO
            {
                cMedioTransporte = "Online"
            };
            return datosPaqueteDTO;
        }

        private DatosPaqueteDTO LlenarPedidoDatosCorrectos()
        {
            DatosPaqueteDTO datosPaqueteDTO = new DatosPaqueteDTO
            {
                cMedioTransporte = "Terrestre"
            };
            return datosPaqueteDTO;
        }
    }
}
