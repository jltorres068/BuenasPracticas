using AliExpress.AliExpress.Data.Entites.Enumerables;
using AliExpress.Interfaces.Business;
using System;

namespace AliExpress.AliExpress.Business.Services
{
    public class CalculadorPaqueteriaFedexService : ICalculadorPaqueteriaService
    {
        public double CalculadorTiempoReparto(int _iTransporte)
        {
            Double dTiempoReparto = 0;
            switch (_iTransporte)
            {
                case (int)EnumTransportes.Aéreo:
                    dTiempoReparto = 0;
                    break;
                case (int)EnumTransportes.Marítimo:
                    dTiempoReparto = 21;
                    break;

                case (int)EnumTransportes.Terrestre:
                    dTiempoReparto = 10;
                    break;
            }
            return dTiempoReparto;
        }

        public double CalcularMargenUtilidad(DateTime _dtFechaPedido)
        {
            Double dUtilidad = 0;
            if (CalcularMesesPares(_dtFechaPedido.Month))
            {
                dUtilidad = 40;
            }
            else
            {
                dUtilidad = 30;
            }
            return dUtilidad;
        }

        private bool CalcularMesesPares(int _iMes)
        {
            bool lMesEsPar = false;
            if (_iMes % 2 == 0)
            {
                lMesEsPar = true;
            }
            return lMesEsPar;
        }
    }
}
