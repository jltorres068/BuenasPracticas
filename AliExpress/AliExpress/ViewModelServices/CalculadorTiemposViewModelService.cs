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
            else if(dTiempoHoras <= 144)
            {
                //Horas hasta 6 días
                cTiempoEntrega = $"{dTiempoExacto.ToString()} día(s)";
            }
            else if (dTiempoHoras < 720)
            {
                //Semanas hasta 29 días
                cTiempoEntrega = $"{dTiempoExacto.ToString()} semana(s)";
            }
            else if(dTiempoHoras == 720)
            {
                //Horas hasta 6 días
                cTiempoEntrega = $"{dTiempoExacto.ToString()} mes";
            }
            else if(dTiempoHoras <= 8640)
            {
                //Horas hasta 6 días
                cTiempoEntrega = $"{dTiempoExacto.ToString()} bimestre(s)";
            }else if(dTiempoHoras > 8640)
            {
                //Horas hasta 6 semestres
                cTiempoEntrega = $"{dTiempoExacto.ToString()} años";
            }

            return cTiempoEntrega;
        }

        private Double CalcularTiempoExacto(Double _dTiempo)
        {
            Double dTiempoExacto = 0;
            if (_dTiempo < 1)//Minutos
            {
                dTiempoExacto = 60 * _dTiempo;
            }
            else if (_dTiempo < 24)//Horas
            {
                dTiempoExacto = _dTiempo;
            }
            else if (_dTiempo <= 144)//Dias
            {
                dTiempoExacto = _dTiempo / 24;
            }
            else if(_dTiempo < 720)//Semanas
            {
                dTiempoExacto = _dTiempo / 144;
                dTiempoExacto = _dTiempo > 4 ? 4 : _dTiempo;
            }
            else if(_dTiempo == 720)//Mes
            {
                dTiempoExacto = _dTiempo;
            }
            else if(_dTiempo <= 8640)//bimestres
            {
                dTiempoExacto = _dTiempo / 1440;
            }
            else if(_dTiempo > 8640)//años
            {
                dTiempoExacto = _dTiempo / 8640;
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
