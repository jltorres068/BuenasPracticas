using AliExpress.AliExpress.Data.Entites.DTO;
using AliExpress.AliExpress.Data.Entites.Enumerables;
using AliExpress.Interfaces.UI;
using System;

namespace AliExpress.Builder
{
    public class BuilderMensajePedido : IBuilderMensajePedido
    {
        string cMensaje = string.Empty;
        DateTime dtFechaActual = DateTime.Now;

        public void AsignarExpresion1(DateTime _dtFechaEntrega)
        {            
            if (_dtFechaEntrega < dtFechaActual)
            {
                cMensaje += "Tu paquete salió ";
            }
            else
            {
                cMensaje += "Tu paquete ha salido ";
            }
        }

        public void AsignarOrigen(string _cCiudadOrigen, string _cPaisOrigen)
        {
            cMensaje += $" de {_cCiudadOrigen}, {_cPaisOrigen}";
        }

        public void AsignarExpresion2(DateTime _dtFechaEntrega)
        {
            if (_dtFechaEntrega < dtFechaActual)
            {
                cMensaje += " y llegó";
            }
            else
            {
                cMensaje += " y llegará";
            }
        }

        public void AsignarDestino(string _ccCiudadDestino, string _cPaisDestino)
        {
            cMensaje += $" a {_ccCiudadDestino}, {_cPaisDestino}";
        }

        public void AsignarExpresion3(DateTime _dtFechaEntrega)
        {
            if (_dtFechaEntrega < dtFechaActual)
            {
                cMensaje += " hace";
            }
            else
            {
                cMensaje += " dentro de";
            }
        }

        public void AsignarRangoTiempo(string _cRangoTiempo)
        {
            cMensaje += $" {_cRangoTiempo}";
        }

        public void AsignarExpresion4(DateTime _dtFechaEntrega)
        {
            if (_dtFechaEntrega < dtFechaActual)
            {
                cMensaje += " y tuvo";
            }
            else
            {
                cMensaje += "y tendrá";
            }
        }

        public void AsignarCostoEnvio(Double _dCostoEnvio)
        {
            cMensaje += $" un costo de {_dCostoEnvio.ToString("c")}";
        }

        public void AsignarPaqueteria(string _cPaqueteria)
        {
            cMensaje += $" (Cualquier reclamación con {_cPaqueteria}).";
        }

        public string ObtenerMensaje()
        {
            return cMensaje;
        }

        public void AsignarErrorPaqueteria(int _iError, string _cPaqueteria)
        {
            if(_iError == (int)EnumErrores.ErrorPaqueteria)
            {
                cMensaje = $"La Paquetería: {_cPaqueteria} no se encuentra registrada en nuestra red de distribución.";
            }
        }

        public void AsignarErrorTransporte(int _iError, string _cPaqueteria, string _cTransporte)
        {
            if (_iError == (int)EnumErrores.ErrorTransporte)
            {
                cMensaje = $"{_cPaqueteria} no ofrece el servicio de transporte {_cTransporte}, te recomendamos cotizar en otra empresa.";
            }
        }

        public void AsignarPaqueteriaAlternativa(string _cPaqueteria, Double _dCostoDiferencia)
        {
            cMensaje = $"Si hubieras pedido en {_cPaqueteria} te hubiera costado {_dCostoDiferencia.ToString("c")} más barato.";
        }
    }
}
