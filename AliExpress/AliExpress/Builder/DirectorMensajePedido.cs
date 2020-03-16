using AliExpress.AliExpress.Data.Entites.DTO;
using AliExpress.Interfaces.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliExpress.Builder
{
    public class DirectorMensajePedido
    {
        private IBuilderMensajePedido builderMensajePedido;

        public IBuilderMensajePedido _BuilderMensajePedido
        {
            set { builderMensajePedido = value; }
        }

        public void GenerarEstructuraMensajePedido(DatosPaqueteDTO _datosPaqueteDTO)
        {
            this.builderMensajePedido.AsignarExpresion1(_datosPaqueteDTO.dtFechaEntrega);
            this.builderMensajePedido.AsignarOrigen(_datosPaqueteDTO.cCiudadOrigen, _datosPaqueteDTO.cPaisOrigen);
            this.builderMensajePedido.AsignarExpresion2(_datosPaqueteDTO.dtFechaEntrega);
            this.builderMensajePedido.AsignarDestino(_datosPaqueteDTO.cCiudadDestino, _datosPaqueteDTO.cPaisDestino);
            this.builderMensajePedido.AsignarExpresion3(_datosPaqueteDTO.dtFechaEntrega);
            this.builderMensajePedido.AsignarRangoTiempo(_datosPaqueteDTO.cRangoTiempo);
            this.builderMensajePedido.AsignarExpresion4(_datosPaqueteDTO.dtFechaEntrega);
            this.builderMensajePedido.AsignarCostoEnvio(_datosPaqueteDTO.dCostoEnvio);
            this.builderMensajePedido.AsignarPaqueteria(_datosPaqueteDTO.cPaqueteria);

        }

        public void MostrarMensajeError(DatosPaqueteDTO _datosPaqueteDTO)
        {
            this.builderMensajePedido.AsignarErrorPaqueteria(_datosPaqueteDTO.iError, _datosPaqueteDTO.cPaqueteria);
            this.builderMensajePedido.AsignarErrorTransporte(_datosPaqueteDTO.iError, _datosPaqueteDTO.cPaqueteria, _datosPaqueteDTO.cMedioTransporte);
        }

        public void AsignarPaqueteriaAlternativa(DatosPaqueteDTO _datosPaqueteDTO)
        {
            this.builderMensajePedido.AsignarPaqueteriaAlternativa(_datosPaqueteDTO.cPaqueteria, _datosPaqueteDTO.dCostoDiferencia);
        }
    }
}
