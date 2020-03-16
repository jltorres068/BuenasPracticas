using AliExpress.AliExpress.Data.Entites.DTO;
using AliExpress.Interfaces.UI;
using System;

namespace AliExpress.ViewModelServices
{
    public class CalculadorTiemposViewModelService : ICalculadorTiemposViewModelService
    {
        public DateTime CalcularFechaEntrega(DatosPaqueteDTO _datosPaquete)
        {
            DateTime dtFechaEntrega;
            dtFechaEntrega = _datosPaquete.dtFechaPedido.AddHours(_datosPaquete.dTiempoTraslado);
            return dtFechaEntrega;
        }

        public string CalcularRangoTiempo(DatosPaqueteDTO _datosPaquete)
        {
            string cTiempoEntrega = string.Empty;
            Double dTiempoHoras = CalcularRangoTiempoHoras(_datosPaquete.dtFechaEntrega);
            Double dTiempoExacto = CalcularTiempoExacto(dTiempoHoras);

            if (dTiempoHoras < 1)
            {
                //Minutos hasta 59 minutos
                cTiempoEntrega = $"{dTiempoExacto.ToString()} minutos";
            }
            else if (dTiempoHoras < 24)
            {
                //Horas hasta 23 horas
                cTiempoEntrega = $"{dTiempoExacto.ToString()} horas";
            }
            else if (dTiempoHoras < 720)
            {
                //Días hasta 30 días
                cTiempoEntrega = $"{dTiempoExacto.ToString()} días";
            }
            else
            {
                //Meses sin límite
                cTiempoEntrega = $"{dTiempoExacto.ToString()} meses";
            }

            return cTiempoEntrega;
        }

        private Double CalcularTiempoExacto(Double _dTiempo)
        {
            Double dTiempoExacto = 0;
            if (_dTiempo < 1)
            {
                dTiempoExacto = 60 * _dTiempo;
            }
            else if (_dTiempo <= 24)
            {
                dTiempoExacto = _dTiempo;
            }
            else if (_dTiempo <= 720)
            {
                dTiempoExacto = _dTiempo / 24;
            }
            else
            {
                dTiempoExacto = _dTiempo / 720;
            }
            dTiempoExacto = Math.Round(dTiempoExacto);

            return dTiempoExacto;
        }

        private Double CalcularRangoTiempoHoras(DateTime _dtFechaEntrega)
        {
            DateTime dtFechaActual = DateTime.Now;
            Double dRangoTiempoHoras = 0;
            if(_dtFechaEntrega < dtFechaActual)
            {
                dRangoTiempoHoras = (dtFechaActual - _dtFechaEntrega).TotalHours;
            }
            else
            {
                dRangoTiempoHoras = (_dtFechaEntrega - dtFechaActual).TotalHours;
            }
            return dRangoTiempoHoras;
        }
    }
}
