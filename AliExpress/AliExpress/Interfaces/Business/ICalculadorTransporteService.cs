using AliExpress.AliExpress.Data.Entites.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliExpress.Interfaces.Business
{
    public interface ICalculadorTransporteService
    {
        Double CalcularCostoEnvio(DatosPaqueteDTO _datosPaqueteDTO);

        Double CalcularCostoKM(Double _distancia);

        Double CalcularTiempoTraslado(DatosPaqueteDTO _datosPaqueteDTO);
    }
}
