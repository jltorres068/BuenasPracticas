using AliExpress.AliExpress.Data.Entites.DTO;
using AliExpress.Interfaces.Business;
using System;

namespace AliExpress.AliExpress.Business.Services
{
    public class CalculadorTransporteAereoService : ICalculadorTransporteService
    {
        public Double CalcularCostoEnvio(DatosPaqueteDTO _datosPaqueteDTO)
        {
            //CostoKm * distancia + CargoExtra * (1+(Utilidad/100))
            Double dCostoEnvio = 0, dCostoKM = 0, dCostoExtra = 0;
            dCostoKM = CalcularCostoKM(_datosPaqueteDTO.dDistancia);
            dCostoExtra = CalcularCostoExtra(_datosPaqueteDTO.dDistancia);

            dCostoEnvio = (dCostoKM * _datosPaqueteDTO.dDistancia + dCostoExtra) * (1 + (_datosPaqueteDTO.dUtilidad / 100));

            return dCostoEnvio;
        }

        public Double CalcularCostoKM(Double _distancia)
        {
            Double dCostoKM = 10;

            return dCostoKM;
        }

        public Double CalcularTiempoTraslado(DatosPaqueteDTO _datosPaquetesDTO)
        {
            Double dTiempoTraslado = 0, dCostoKm = 0;
            int iEscala = 0;
            //distancia / (dCostoKM * dVelocidad) + (Escalas * 6)
            dCostoKm = CalcularCostoKM(_datosPaquetesDTO.dDistancia);
            iEscala = CalcularEscalas(_datosPaquetesDTO.dDistancia);

            dTiempoTraslado = (_datosPaquetesDTO.dDistancia / (dCostoKm * _datosPaquetesDTO.dVelocidad) + (iEscala * 6)) + _datosPaquetesDTO.dTiempoReparto;

            return dTiempoTraslado;
        }

        private Double CalcularCostoExtra(Double _distancia)
        {
            Double dCostoExtra = 0;
            int iEscalas = CalcularEscalas(_distancia);
            Double dCostoEscala = 200;

            dCostoExtra = iEscalas * dCostoEscala;

            return dCostoExtra;
        }

        private int CalcularEscalas(Double _dDistancia)
        {
            int iEscalas = Convert.ToInt32(Math.Round(_dDistancia / 1000));

            return iEscalas;
        }

        private Double CalcularCostoEscala(int _iEscala)
        {
            Double dCosto = _iEscala * 200;

            return dCosto;
        }
    }
}
