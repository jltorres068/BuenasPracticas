using System;

namespace AliExpress.Interfaces.Business
{
    public interface ICalculadorPaqueteriaService
    {
        Double CalcularMargenUtilidad(DateTime _dtFechaPedido);

        Double CalculadorTiempoReparto(int iTransporte);
    }
}
