
using AliExpress.AliExpress.Data.Entites.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliExpress.Interfaces.UI
{
    public interface IAsignadorPedidoViewModelService
    {
        List<DatosPaqueteDTO> AsignarDatosPaquetes(List<string> _lstPaquetes);

        DatosPaqueteDTO AsignarDatosExtraPaquetes(DatosPaqueteDTO _datosPaqueteDTO);

        int AsignarColorMensaje(DatosPaqueteDTO _datosPaqueteDTO);

        List<DatosPaqueteDTO> AsignarDatosPaquetesEconomicos(DatosPaqueteDTO _datosPaqueteDTO, int _iCantidadPaqueterias);

        DatosPaqueteDTO AsignarResultadosDatosPaquetes(DatosPaqueteDTO _datosPaqueteDTO);
    }
}
