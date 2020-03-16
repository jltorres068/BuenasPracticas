using AliExpress.AliExpress.Business.Services;
using AliExpress.AliExpress.Data.Entites.Enumerables;
using AliExpress.Interfaces.Business;

namespace AliExpress.AliExpress.Business.Estrategia
{
    public class EstrategiaCalculadorPaqueteriaService : IEstrategiaCalculadorPaqueteriaService
    {
        public ICalculadorPaqueteriaService CrearInstancia(int _iPaqueteria)
        {
            ICalculadorPaqueteriaService calculadorPaqueteriaService = null;
            switch (_iPaqueteria)
            {
                case (int)EnumPaqueterias.DHL:
                    calculadorPaqueteriaService = new CalculadorPaqueteriaDHLService();
                    break;
                case (int)EnumPaqueterias.Estafeta:
                    calculadorPaqueteriaService = new CalculadorPaqueteriaEstafetaService();
                    break;
                case (int)EnumPaqueterias.Fedex:
                    calculadorPaqueteriaService = new CalculadorPaqueteriaFedexService();
                    break;                
            }
            return calculadorPaqueteriaService;
        }
    }
}
