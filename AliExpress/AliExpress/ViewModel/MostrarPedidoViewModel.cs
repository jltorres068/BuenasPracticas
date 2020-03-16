using AliExpress.AliExpress.Data.Entites.DTO;
using AliExpress.AliExpress.Data.Entites.Enumerables;
using AliExpress.Builder;
using AliExpress.Interfaces.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliExpress.ViewModel
{
    public class MostrarPedidoViewModel : IMostrarPedidoViewModel
    {
        private readonly IAsignadorPedidoViewModelService envioPedidoViewModelService;
        private readonly IValidadorDatosPaquetesViewModelService validadorDatosPaquetesViewModelService;


        public MostrarPedidoViewModel(IAsignadorPedidoViewModelService _envioPedidoViewModelService, IValidadorDatosPaquetesViewModelService _validadorDatosPaquetesViewModelService)
        {
            envioPedidoViewModelService = _envioPedidoViewModelService ?? throw new ArgumentNullException(nameof(_envioPedidoViewModelService));
            validadorDatosPaquetesViewModelService = _validadorDatosPaquetesViewModelService ?? throw new ArgumentNullException(nameof(_validadorDatosPaquetesViewModelService));
        }

        public void MostrarInformacionPedidos(List<string> _lstPedidos)
        {

            List<DatosPaqueteDTO> lstDatosPaquetes = envioPedidoViewModelService.AsignarDatosPaquetes(_lstPedidos);
            lstDatosPaquetes = validadorDatosPaquetesViewModelService.ValidarDatosPaquetes(lstDatosPaquetes);

            foreach (DatosPaqueteDTO datosPaquete in lstDatosPaquetes)
            {
                DatosPaqueteDTO datosPaqueteDTO = new DatosPaqueteDTO();
                string cMensajePedido = string.Empty;
                DirectorMensajePedido director = new DirectorMensajePedido();
                BuilderMensajePedido builderMensaje = new BuilderMensajePedido();
                director._BuilderMensajePedido = builderMensaje;
                datosPaqueteDTO = datosPaquete;

                if (!datosPaquete.lError)
                {
                    datosPaqueteDTO = envioPedidoViewModelService.AsignarDatosExtraPaquetes(datosPaquete);
                    datosPaqueteDTO = envioPedidoViewModelService.AsignarResultadosDatosPaquetes(datosPaqueteDTO);
                    director.GenerarEstructuraMensajePedido(datosPaqueteDTO);
                    cMensajePedido = builderMensaje.ObtenerMensaje();

                    MostrarMensaje(cMensajePedido, datosPaqueteDTO.iColorMensaje);//Original

                    List<DatosPaqueteDTO> lstDatosPaquetesEconomicos = new List<DatosPaqueteDTO>();
                    List<DatosPaqueteDTO> lstDatosPedidosEconomicosFiltrados = new List<DatosPaqueteDTO>();
                    int iCantidadPaqueterias = Enum.GetNames(typeof(EnumTransportes)).Length;
                    lstDatosPaquetesEconomicos = envioPedidoViewModelService.AsignarDatosPaquetesEconomicos(datosPaqueteDTO, iCantidadPaqueterias);
                    lstDatosPaquetesEconomicos = validadorDatosPaquetesViewModelService.ValidarDatosPaquetes(lstDatosPaquetesEconomicos);
                    foreach(DatosPaqueteDTO datosPaqueteExtra in lstDatosPaquetesEconomicos.Where(x => x.iPaqueteria != datosPaqueteDTO.iPaqueteria))
                    {
                        DatosPaqueteDTO datosPaqueteDTOEconomico = new DatosPaqueteDTO();
                        datosPaqueteDTOEconomico = datosPaqueteExtra;
                        if (!datosPaqueteDTOEconomico.lError)
                        {
                            datosPaqueteDTOEconomico = envioPedidoViewModelService.AsignarDatosExtraPaquetes(datosPaqueteExtra);

                            bool lTransporteValido = validadorDatosPaquetesViewModelService.ValidarTransportesPaqueteria(datosPaqueteDTOEconomico.iTransporte, datosPaqueteDTOEconomico.lstTransporte);
                            if (lTransporteValido)
                            {
                                datosPaqueteDTOEconomico = envioPedidoViewModelService.AsignarResultadosDatosPaquetes(datosPaqueteDTOEconomico);
                                lstDatosPedidosEconomicosFiltrados.Add(datosPaqueteDTOEconomico);
                            }
                        }
                    }
                    DatosPaqueteDTO pedidoEconomico = lstDatosPedidosEconomicosFiltrados.Find(x => x.dCostoEnvio < datosPaqueteDTO.dCostoEnvio && x.iPaqueteria != datosPaqueteDTO.iPaqueteria);
                    if(pedidoEconomico != null)
                    {
                        pedidoEconomico.dCostoDiferencia = datosPaqueteDTO.dCostoEnvio - pedidoEconomico.dCostoEnvio;
                        director.AsignarPaqueteriaAlternativa(pedidoEconomico);
                        cMensajePedido = builderMensaje.ObtenerMensaje();
                        MostrarMensaje(cMensajePedido, (int)ConsoleColor.White);//Mas barato
                    }
                }
                else
                {
                    director.MostrarMensajeError(datosPaqueteDTO);
                    cMensajePedido = builderMensaje.ObtenerMensaje();
                    MostrarMensaje(cMensajePedido, datosPaqueteDTO.iColorMensaje);//Error
                }
            }

        }
        public void MostrarMensaje(string _cMensaje, int _iColorMensaje)
        {
            Console.ForegroundColor = (ConsoleColor)_iColorMensaje;
            Console.WriteLine(_cMensaje);
        }
    }
}
