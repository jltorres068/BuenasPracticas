using AliExpress.AliExpress.Data.Entites.DTO;
using AliExpress.AliExpress.Data.Entites.Enumerables;
using AliExpress.Interfaces.Business;
using System;

namespace AliExpress.AliExpress.Business.Services.Validador
{
    public class ValidadorTransporteService : IValidadorDatosPedidoService
    {
        private IValidadorDatosPedidoService validadorDatosPedidoService;

        public void AsignarSiguienteValidacion(IValidadorDatosPedidoService _validadorDatosPedidoService)
        {
            validadorDatosPedidoService = _validadorDatosPedidoService ?? throw new ArgumentNullException(nameof(_validadorDatosPedidoService));
        }

        public DatosPaqueteDTO ValidarDatosPedido(DatosPaqueteDTO _datosPaqueteDTO)
        {
            switch (_datosPaqueteDTO.cMedioTransporte.ToUpper())
            {
                case "AÉREO":
                case "MARÍTIMO":
                case "TERRESTRE":
                    break;
                default:
                    _datosPaqueteDTO.lError = true;
                    _datosPaqueteDTO.iError = (int)EnumErrores.ErrorTransporte;
                    _datosPaqueteDTO.iColorMensaje = (int)ConsoleColor.Red;
                    break;
            }
            if (validadorDatosPedidoService != null && !_datosPaqueteDTO.lError)
            {
                validadorDatosPedidoService.ValidarDatosPedido(_datosPaqueteDTO);
            }
            return _datosPaqueteDTO;
        }
    }
}
