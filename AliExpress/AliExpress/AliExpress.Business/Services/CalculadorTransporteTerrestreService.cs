using AliExpress.AliExpress.Data.Entites.DTO;
using AliExpress.AliExpress.Data.Entites.Enumerables;
using AliExpress.Interfaces.Business;
using System;

namespace AliExpress.AliExpress.Business.Services
{
    public class CalculadorTransporteTerrestreService : ICalculadorTransporteService
    {
        public double CalcularCostoEnvio(DatosPaqueteDTO _datosPaqueteDTO)
        {
            Double dCostoEnvio = 0, dCostoKM = 0;
            //CostoKM * distancia * (1 + (Utilidad/100))
            dCostoKM = CalcularCostoKM(_datosPaqueteDTO.dDistancia);

            dCostoEnvio = dCostoKM * _datosPaqueteDTO.dDistancia * (1 + (_datosPaqueteDTO.dUtilidad/100));
            return dCostoEnvio;
        }

        public double CalcularCostoKM(double _distancia)
        {
            Double dCostoKM = 0;

            if (_distancia >= 1 && _distancia <= 50)
            {
                dCostoKM = 15;
            }
            else if (_distancia >= 51 && _distancia <= 200)
            {
                dCostoKM = 10;
            }
            else if (_distancia >= 201 && _distancia <= 300)
            {
                dCostoKM = 8;
            }
            else
            {
                dCostoKM = 7;
            }

            return dCostoKM;
        }

        public double CalcularTiempoTraslado(DatosPaqueteDTO _datosPaqueteDTO)
        {
            Double dTiempoTraslado = 0, dTiempoDescanso = 0, dCostoKM =0;
            //distancia / (dCostoKM * dVelocidad) + dDescansoEstacion 
            dCostoKM = CalcularCostoKM(_datosPaqueteDTO.dDistancia);
            dTiempoDescanso = CalcularTiempoDescansoEstacion(_datosPaqueteDTO.iEstacion);

            dTiempoTraslado = (_datosPaqueteDTO.dDistancia / (dCostoKM * _datosPaqueteDTO.dVelocidad) * dTiempoDescanso) +_datosPaqueteDTO.dTiempoReparto;

            return dTiempoTraslado;
        }

        private Double CalcularTiempoDescansoEstacion(int _iEstacion)
        {
            Double dTiempoDescanso = 0;

            switch(_iEstacion)
            {
                case (int)EnumEstaciones.Invierno:
                    dTiempoDescanso = 8;
                    break;
                case (int)EnumEstaciones.Otoño:
                    dTiempoDescanso = 5;
                    break;
                case (int)EnumEstaciones.Primavera:
                    dTiempoDescanso = 4;
                    break;
                case (int)EnumEstaciones.Verano:
                    dTiempoDescanso = 6;
                    break;
                default:
                    dTiempoDescanso = 0;
                    break;
            }
            return dTiempoDescanso;
        }
    }
}
