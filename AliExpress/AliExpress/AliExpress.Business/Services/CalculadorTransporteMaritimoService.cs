using AliExpress.AliExpress.Data.Entites.DTO;
using AliExpress.AliExpress.Data.Entites.Enumerables;
using AliExpress.Interfaces.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliExpress.AliExpress.Business.Services
{
    public class CalculadorTransporteMaritimoService : ICalculadorTransporteService
    {
        public double CalcularCostoEnvio(DatosPaqueteDTO _datosPaqueteDTO)
        {
            Double dCostoEnvio = 0, dCostoKM = 0, dCostoTemporada = 0;
            //CostoKM * distancia * CostoTemporada * (1 + (Utilidad/100))
            dCostoKM = CalcularCostoKM(_datosPaqueteDTO.dDistancia);
            dCostoTemporada = CalcularCostoTemporada(_datosPaqueteDTO.iEstacion);

            dCostoEnvio = dCostoKM * _datosPaqueteDTO.dDistancia * dCostoTemporada * (1 + (_datosPaqueteDTO.dUtilidad / 100));

            return dCostoEnvio;
        }

        public double CalcularCostoKM(double _distancia)
        {
            Double dCostoKM = 0;

            if(_distancia >= 1 && _distancia <= 100)
            {
                dCostoKM = 1;
            }
            else if(_distancia >= 101 && _distancia <= 1000)
            {
                dCostoKM = 0.5;
            }
            else
            {
                dCostoKM = 0.3;
            }

            return dCostoKM;
        }

        public double CalcularTiempoTraslado(DatosPaqueteDTO _datosPaqueteDTO)
        {
            Double dTiempoTraslado = 0, dVelocidadTemporada = 0;
            //distancia / dVelocidadTotal
            dVelocidadTemporada = CalcularCostoVelocidadTemporada(_datosPaqueteDTO.iEstacion, _datosPaqueteDTO.dVelocidad);
            dTiempoTraslado = (_datosPaqueteDTO.dDistancia / dVelocidadTemporada)+ _datosPaqueteDTO.dTiempoReparto;

            return dTiempoTraslado;
        }

        private Double CalcularCostoTemporada(int _iEstacion)
        {
            Double dCostoTemporada = 1;

            switch (_iEstacion)
            {
                case (int)EnumEstaciones.Invierno:
                    dCostoTemporada = 0.23;
                    break;

                case (int)EnumEstaciones.Otoño:
                    dCostoTemporada = 0.15;
                    break;

                case (int)EnumEstaciones.Primavera:
                    dCostoTemporada = 0;
                    break;

                case (int)EnumEstaciones.Verano:
                    dCostoTemporada = 0.10;
                    break;
            }

            return dCostoTemporada;
        }

        private Double CalcularCostoVelocidadTemporada(int _iEstacion, Double _dVelocidad)
        {
            Double dCostoTemporada = 0;

            switch (_iEstacion)
            {
                case (int)EnumEstaciones.Invierno:
                    dCostoTemporada = _dVelocidad - (_dVelocidad * 0.30);
                    break;

                case (int)EnumEstaciones.Otoño:
                    dCostoTemporada = _dVelocidad + (_dVelocidad * 0.15);
                    break;

                case (int)EnumEstaciones.Primavera:
                    dCostoTemporada = 0;
                    break;

                case (int)EnumEstaciones.Verano:
                    dCostoTemporada = _dVelocidad - (_dVelocidad * 0.10);
                    break;

                default:
                    dCostoTemporada = 0;
                    break;
            }

            return dCostoTemporada;
        }
    }
}
