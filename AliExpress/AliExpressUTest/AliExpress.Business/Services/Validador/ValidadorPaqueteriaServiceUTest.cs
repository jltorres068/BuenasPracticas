using AliExpress.AliExpress.Business.Services.Validador;
using AliExpress.AliExpress.Data.Entites.DTO;
using AliExpress.Interfaces.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliExpressUTest.AliExpress.Business.Services.Validador
{
    [TestClass]
    public class ValidadorPaqueteriaServiceUTest
    {
        private Mock<IValidadorDatosPedidoService> validadorDatosPedidoService;

        [TestMethod]
        public void ValidarDatosPedido_CPaqueteriaCorrecta_RetornaDatosPaqueteDTOlErrorFalse()
        {
            //Arrange
            validadorDatosPedidoService = new Mock<IValidadorDatosPedidoService>();
            DatosPaqueteDTO datosPaqueteDTO = LlenarPedidoDatosCorrectos();

            var instanciaValidadorDatosPedidoService = new ValidadorPaqueteriaService();
            validadorDatosPedidoService.Setup((srv) => srv.ValidarDatosPedido(datosPaqueteDTO)).Returns(() => new DatosPaqueteDTO());

            //Act
            DatosPaqueteDTO datosPaqueteDTOResultado = instanciaValidadorDatosPedidoService.ValidarDatosPedido(datosPaqueteDTO);

            //Assert
            Assert.IsFalse(datosPaqueteDTO.lError);
        }

        [TestMethod]
        public void ValidarDatosPedido_CPaqueteriaIncorrecta_RetornaDatosPaqueteDTOlErrorTrue()
        {
            //Arrange
            validadorDatosPedidoService = new Mock<IValidadorDatosPedidoService>();
            DatosPaqueteDTO datosPaqueteDTO = LlenarPedidoDatosConError();

            var instanciaValidadorDatosPedidoService = new ValidadorPaqueteriaService();
            validadorDatosPedidoService.Setup((srv) => srv.ValidarDatosPedido(datosPaqueteDTO)).Returns(() => new DatosPaqueteDTO());

            //Act
            DatosPaqueteDTO datosPaqueteDTOResultado = instanciaValidadorDatosPedidoService.ValidarDatosPedido(datosPaqueteDTO);

            //Assert
            Assert.IsTrue(datosPaqueteDTO.lError);
        }

        private DatosPaqueteDTO LlenarPedidoDatosConError()
        {
            DatosPaqueteDTO datosPaqueteDTO = new DatosPaqueteDTO {
                cPaqueteria = "Correos de México"
            };
            return datosPaqueteDTO;
        }

        private DatosPaqueteDTO LlenarPedidoDatosCorrectos()
        {
            DatosPaqueteDTO datosPaqueteDTO = new DatosPaqueteDTO
            {
                cPaqueteria = "DHL"
            };
            return datosPaqueteDTO;
        }
    }
}
