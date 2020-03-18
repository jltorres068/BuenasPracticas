using AliExpress.AliExpress.Business.Estrategia;
using AliExpress.AliExpress.Business.Services;
using AliExpress.AliExpress.Business.Services.Validador;
using AliExpress.Interfaces.Business;
using AliExpress.Interfaces.UI;
using AliExpress.ViewModel;
using AliExpress.ViewModelServices;
using StructureMap;

namespace AliExpress.Fabrica
{
    public class ContenedorFabrica: Registry 
    {
        public ContenedorFabrica()
        {
            For<ICalculadorPaqueteriaService>().Use<CalculadorPaqueteriaEstafetaService>();
            For<ICalculadorPaqueteriaService>().Use<CalculadorPaqueteriaDHLService>();
            For<ICalculadorPaqueteriaService>().Use<CalculadorPaqueteriaFedexService>();
            For<ICalculadorTransporteService>().Use<CalculadorTransporteMaritimoService>();
            For<ICalculadorTransporteService>().Use<CalculadorTransporteAereoService>();
            For<ICalculadorTransporteService>().Use<CalculadorTransporteTerrestreService>();
            For<IEstrategiaCalculadorPaqueteriaService>().Use<EstrategiaCalculadorPaqueteriaService>();
            For<IEstrategiaCalculadorTransporteService>().Use<EstrategiaCalculadorTransporteService>();
            For<IValidadorDatosPedidoService>().Use<ValidadorPaqueteriaService>();
            For<IMostrarPedidoViewModel>().Use<MostrarPedidoViewModel>();
            For<IAsignadorPedidoViewModelService>().Use<AsignadorPedidoViewModelService>();
            For<IValidadorDatosPaquetesViewModelService>().Use<ValidadorDatosPaquetesViewModelService>();
            For<ICalculadorTiemposViewModelService>().Use<CalculadorTiemposViewModelService>();
            For<IConvertidorFormatoViewModel>().Use<ConvertidorFormatoViewModel>();
            For<IManipuladorDatosArchivosViewModel>().Use<ManipuladorDatosArchivosViewModel>();
            For<IEliminadorDatosArchivoViewModelService>().Use<EliminadorDatosArchivoViewModelService>();
            For<ICreadorDatosArchivoViewModelService>().Use<CreadorDatosArchivoViewModelService>();
        }
    }
}
