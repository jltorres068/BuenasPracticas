using AliExpress.AliExpress.Data.Entites.Enumerables;
using AliExpress.Interfaces.Business;
using System;

namespace AliExpress.AliExpress.Business.Services
{
    public class CalculadorPaqueteriaDHLService : ICalculadorPaqueteriaService
    {
        public Double CalcularMargenUtilidad(DateTime _dtFechaPedido)
        {
            Double dUtilidad = 0;
            if(_dtFechaPedido.Month >= 1 && _dtFechaPedido.Month <= 6)
            {
                dUtilidad = 50;
            }
            else if(_dtFechaPedido.Month >= 7 && _dtFechaPedido.Month <= 12)
            {
                dUtilidad = 30;
            }
            return dUtilidad;
        }

        public Double CalculadorTiempoReparto(int iTransporte)
        {
            Double dTiempoReparto = 0;
            switch (iTransporte)
            {
                case (int)EnumTransportes.Aéreo:
                    dTiempoReparto = 3;
                    break;
                case (int)EnumTransportes.Marítimo:
                    dTiempoReparto = 20;
                    break;
                case (int)EnumTransportes.Terrestre:
                    dTiempoReparto = 12;
                    break;
            }
            return dTiempoReparto;
        }
    }
}
