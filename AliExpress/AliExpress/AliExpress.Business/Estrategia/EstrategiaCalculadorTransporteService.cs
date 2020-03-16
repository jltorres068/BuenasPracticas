using AliExpress.AliExpress.Business.Services;
using AliExpress.AliExpress.Data.Entites.Enumerables;
using AliExpress.Interfaces.Business;

namespace AliExpress.AliExpress.Business.Estrategia
{
    public class EstrategiaCalculadorTransporteService : IEstrategiaCalculadorTransporteService
    {
        public ICalculadorTransporteService CrearInstancia(int _iTransporte)
        {
            ICalculadorTransporteService calculadorTransporteService = null;
            switch (_iTransporte)
            {
                case (int)EnumTransportes.Aéreo:
                    calculadorTransporteService = new CalculadorTransporteAereoService();
                    break;
                case (int)EnumTransportes.Marítimo:
                    calculadorTransporteService = new CalculadorTransporteMaritimoService();
                    break;
                case (int)EnumTransportes.Terrestre:
                    calculadorTransporteService = new CalculadorTransporteTerrestreService();
                    break;
            }
            return calculadorTransporteService;
        }
    }
}
