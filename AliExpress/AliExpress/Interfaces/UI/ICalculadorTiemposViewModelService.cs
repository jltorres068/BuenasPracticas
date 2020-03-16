using AliExpress.AliExpress.Data.Entites.DTO;
using System;

namespace AliExpress.Interfaces.UI
{
    public interface ICalculadorTiemposViewModelService
    {
        DateTime CalcularFechaEntrega(DatosPaqueteDTO _datosPaquete);

        string CalcularRangoTiempo(DatosPaqueteDTO _datosPaquete);
    }
}
