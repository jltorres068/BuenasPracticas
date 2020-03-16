using AliExpress.AliExpress.Data.Entites.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliExpress.Interfaces.UI
{
    public interface IBuilderMensajePedido
    {
        void AsignarExpresion1(DateTime _dtFechaEntrega);        
        void AsignarExpresion2(DateTime _dtFechaEntrega);
        void AsignarExpresion3(DateTime _dtFechaEntrega);
        void AsignarExpresion4(DateTime _dtFechaEntrega);
        void AsignarOrigen(string _cCiudadOrigen, string _cPaisOrigen);
        void AsignarDestino(string _ccCiudadDestino, string _cPaisDestino);        
        void AsignarRangoTiempo(string _cRangoTiempo);        
        void AsignarCostoEnvio(Double _dCostoEnvio);
        void AsignarPaqueteria(string _cPaqueteria);
        void AsignarErrorPaqueteria(int _iError, string _cPaqueteria);
        void AsignarErrorTransporte(int _iError, string _cPaqueteria, string _cTransporte);
        void AsignarPaqueteriaAlternativa(string _cPaqueteria, Double _dCostoDiferencia);
        string ObtenerMensaje();
    }
}
