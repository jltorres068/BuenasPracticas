using AliExpress.AliExpress.Data.Entites.Enumerables;
using AliExpress.Interfaces.Business;
using System;

namespace AliExpress.AliExpress.Business.Services
{
    public class CalculadorPaqueteriaEstafetaService : ICalculadorPaqueteriaService
    {
        public Double CalcularMargenUtilidad(DateTime _dtFechaPedido)
        {
            Double dUtilidad = 0;
            if (_dtFechaPedido.Month == 2 && _dtFechaPedido.Day == 14)     
            {
                dUtilidad = 10;
            }
            else if (_dtFechaPedido.Month == 12)   
            {
                dUtilidad = 50;
            }
            else
            {
                dUtilidad = 45;
            }
            return dUtilidad;
        }

        public Double CalculadorTiempoReparto(int iTransporte)
        {
            Double dTiempoReparto = 0;
            switch (iTransporte)
            {

                case (int)EnumTransportes.Marítimo:
                case (int)EnumTransportes.Terrestre:
                    dTiempoReparto = 0.08;
                    break;
            }
            return dTiempoReparto;
        }
    }
}
