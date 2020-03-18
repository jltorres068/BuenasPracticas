using AliExpress.AliExpress.Business.Services;
using AliExpress.AliExpress.Data.Entites.DTO;
using AliExpress.AliExpress.Data.Entites.Enumerables;
using AliExpress.Interfaces.Business;
using AliExpress.Interfaces.UI;
using AliExpress.ViewModelServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliExpressUTest.ViewModelServices
{
    [TestClass]
    public class AsignadorPedidoViewModelServiceUTest
    {
        private Mock<IEstrategiaCalculadorPaqueteriaService> estrategiaCalculadorPaqueteriaService;
        private Mock<IEstrategiaCalculadorTransporteService> estrategiaCalculadorTransporteService;
        private Mock<ICalculadorTiemposViewModelService> calculadorTiemposViewModelService;

        [TestMethod]
        public void AsignarDatosExtraPaquetes_DatosPaquetesCorrectos_AsignaEstacionLstTransporteDUtilidadDVelocidad()
        {
            //Arrange
            estrategiaCalculadorPaqueteriaService = new Mock<IEstrategiaCalculadorPaqueteriaService>();
            estrategiaCalculadorTransporteService = new Mock<IEstrategiaCalculadorTransporteService>();
            calculadorTiemposViewModelService = new Mock<ICalculadorTiemposViewModelService>();

            DatosPaqueteDTO datosPaqueteDTO = LlenarPedidoDatosCorrectos();
            AsignadorPedidoViewModelService asignadorPedidoViewModelService = new AsignadorPedidoViewModelService(estrategiaCalculadorPaqueteriaService.Object, estrategiaCalculadorTransporteService.Object, calculadorTiemposViewModelService.Object);
            estrategiaCalculadorPaqueteriaService.Setup((estrategiaSrv) => estrategiaSrv.CrearInstancia(datosPaqueteDTO.iPaqueteria)).Returns(() => new CalculadorPaqueteriaDHLService());

            //Act
            DatosPaqueteDTO datosPaqueteDTOResultado = asignadorPedidoViewModelService.AsignarDatosExtraPaquetes(datosPaqueteDTO);

            //Assert
            Assert.IsTrue(datosPaqueteDTOResultado.iEstacion > 0 && datosPaqueteDTOResultado.lstTransporte.Count > 0 && datosPaqueteDTOResultado.dUtilidad > 0 && datosPaqueteDTOResultado.dVelocidad > 0);
        }

        [TestMethod]
        public void AsignarDatosExtraPaquetes_DatosPaquetesIncorrectos_NoAsignaEstacionLstTransporteDUtilidadDVelocidad()
        {
            //Arrange
            estrategiaCalculadorPaqueteriaService = new Mock<IEstrategiaCalculadorPaqueteriaService>();
            estrategiaCalculadorTransporteService = new Mock<IEstrategiaCalculadorTransporteService>();
            calculadorTiemposViewModelService = new Mock<ICalculadorTiemposViewModelService>();

            DatosPaqueteDTO datosPaqueteDTO = LlenarPedidoDatosConError();
            AsignadorPedidoViewModelService asignadorPedidoViewModelService = new AsignadorPedidoViewModelService(estrategiaCalculadorPaqueteriaService.Object, estrategiaCalculadorTransporteService.Object, calculadorTiemposViewModelService.Object);
            estrategiaCalculadorPaqueteriaService.Setup((estrategiaSrv) => estrategiaSrv.CrearInstancia(datosPaqueteDTO.iPaqueteria)).Returns(() => new CalculadorPaqueteriaDHLService());

            //Act
            DatosPaqueteDTO datosPaqueteDTOResultado = asignadorPedidoViewModelService.AsignarDatosExtraPaquetes(datosPaqueteDTO);

            //Assert
            Assert.IsFalse(datosPaqueteDTOResultado.iEstacion > 0 && datosPaqueteDTOResultado.lstTransporte.Count > 0 && datosPaqueteDTOResultado.dUtilidad > 0 && datosPaqueteDTOResultado.dVelocidad > 0);
        }

        [TestMethod]
        public void AsignarDatosPaquetes_ListaStringCorrecta_RetornaListaDatosPaquetesMayorA1()
        {
            //Arrange
            estrategiaCalculadorPaqueteriaService = new Mock<IEstrategiaCalculadorPaqueteriaService>();
            estrategiaCalculadorTransporteService = new Mock<IEstrategiaCalculadorTransporteService>();
            calculadorTiemposViewModelService = new Mock<ICalculadorTiemposViewModelService>();

            AsignadorPedidoViewModelService asignadorPedidoViewModelService = new AsignadorPedidoViewModelService(estrategiaCalculadorPaqueteriaService.Object, estrategiaCalculadorTransporteService.Object, calculadorTiemposViewModelService.Object);
            List<string> lstDatosPedidos = LlenarListaStringCorrecto();

            //Act
            List<DatosPaqueteDTO> lstdatosPaqueteDTOResultado = asignadorPedidoViewModelService.AsignarDatosPaquetes(lstDatosPedidos);

            //Assert
            Assert.IsTrue(lstdatosPaqueteDTOResultado.Count > 0);
        }

        [TestMethod]
        public void AsignarDatosPaquetes_ListaStringIncorrecta_RetornaListaDatosPaquetesVacia()
        {
            //Arrange
            estrategiaCalculadorPaqueteriaService = new Mock<IEstrategiaCalculadorPaqueteriaService>();
            estrategiaCalculadorTransporteService = new Mock<IEstrategiaCalculadorTransporteService>();
            calculadorTiemposViewModelService = new Mock<ICalculadorTiemposViewModelService>();

            AsignadorPedidoViewModelService asignadorPedidoViewModelService = new AsignadorPedidoViewModelService(estrategiaCalculadorPaqueteriaService.Object, estrategiaCalculadorTransporteService.Object, calculadorTiemposViewModelService.Object);
            List<string> lstDatosPedidos = LlenarListaStringIncorrecto();

            //Act
            List<DatosPaqueteDTO> lstdatosPaqueteDTOResultado = asignadorPedidoViewModelService.AsignarDatosPaquetes(lstDatosPedidos);

            //Assert
            Assert.IsTrue(lstdatosPaqueteDTOResultado.Count == 0);
        }

        [TestMethod]
        public void AsignarColorMensaje_DatosPaquetesDTOFechaEntregaMayorAHoy_RetornaColorAmarillo()
        {
            //Arrange
            estrategiaCalculadorPaqueteriaService = new Mock<IEstrategiaCalculadorPaqueteriaService>();
            estrategiaCalculadorTransporteService = new Mock<IEstrategiaCalculadorTransporteService>();
            calculadorTiemposViewModelService = new Mock<ICalculadorTiemposViewModelService>();

            AsignadorPedidoViewModelService asignadorPedidoViewModelService = new AsignadorPedidoViewModelService(estrategiaCalculadorPaqueteriaService.Object, estrategiaCalculadorTransporteService.Object, calculadorTiemposViewModelService.Object);
            DatosPaqueteDTO datosPaqueteDTO = LlenarPedidoDatosCorrectos();
            datosPaqueteDTO.dtFechaEntrega = datosPaqueteDTO.dtFechaEntrega.AddDays(2);

            //Act
            int iColorMensaje = asignadorPedidoViewModelService.AsignarColorMensaje(datosPaqueteDTO);

            //Assert
            Assert.IsTrue(iColorMensaje == (int)ConsoleColor.Yellow);
        }

        [TestMethod]
        public void AsignarColorMensaje_DatosPaquetesDTOFechaEntregaMenorAHoy_RetornaColorVerde()
        {
            //Arrange
            estrategiaCalculadorPaqueteriaService = new Mock<IEstrategiaCalculadorPaqueteriaService>();
            estrategiaCalculadorTransporteService = new Mock<IEstrategiaCalculadorTransporteService>();
            calculadorTiemposViewModelService = new Mock<ICalculadorTiemposViewModelService>();

            AsignadorPedidoViewModelService asignadorPedidoViewModelService = new AsignadorPedidoViewModelService(estrategiaCalculadorPaqueteriaService.Object, estrategiaCalculadorTransporteService.Object, calculadorTiemposViewModelService.Object);
            DatosPaqueteDTO datosPaqueteDTO = LlenarPedidoDatosCorrectos();
            datosPaqueteDTO.dtFechaEntrega = datosPaqueteDTO.dtFechaEntrega.AddDays(-5);

            //Act
            int iColorMensaje = asignadorPedidoViewModelService.AsignarColorMensaje(datosPaqueteDTO);

            //Assert
            Assert.IsTrue(iColorMensaje == (int)ConsoleColor.Green);
        }

        private DatosPaqueteDTO LlenarPedidoDatosConError()
        {
            DatosPaqueteDTO datosPaqueteDTO = new DatosPaqueteDTO
            {
                iPaqueteria = (int)EnumPaqueterias.DHL,
                iTransporte = 0,
                dtFechaPedido = DateTime.Now,
                dtFechaEntrega = DateTime.Now
            };
            return datosPaqueteDTO;
        }

        private DatosPaqueteDTO LlenarPedidoDatosCorrectos()
        {
            DatosPaqueteDTO datosPaqueteDTO = new DatosPaqueteDTO
            {
                iPaqueteria = (int)EnumPaqueterias.DHL,
                iTransporte = (int)EnumTransportes.Terrestre,
                dtFechaPedido = DateTime.Now,
                dtFechaEntrega = DateTime.Now
            };
            return datosPaqueteDTO;
        }

        private List<string> LlenarListaStringCorrecto()
        {
            List<string> lstPedidos = new List<string>();
            lstPedidos.Add("80,Estafeta,Terrestre,23-01-2020 12:00:00,México,Ticul,México,Motul");
            lstPedidos.Add("446400, DHL, Aéreo, 23 - 01 - 2020 08:00:00, China, Pekin, México, Cancún");
            lstPedidos.Add("400, DHL, Aéreo, 23 - 01 - 2020 13:50:00, México, Mérida, México, Cozumel");
            return lstPedidos;
        }

        private List<string> LlenarListaStringIncorrecto()
        {
            List<string> lstPedidos = new List<string>();
            lstPedidos.Add("80,Estafeta,Ticul,México,Motul");
            lstPedidos.Add("446400, DHL, Aéreo, 23 - 01 - 2020 08:00:00, China, 23 - 01 - 2020 08:00:00, China, Pekin, México, Cancún");
            return lstPedidos;
        }
    }
}
