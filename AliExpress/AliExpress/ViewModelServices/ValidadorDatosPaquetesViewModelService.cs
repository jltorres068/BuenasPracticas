using AliExpress.AliExpress.Business.Services.Validador;
using AliExpress.AliExpress.Data.Entites.DTO;
using AliExpress.Interfaces.UI;
using System.Collections.Generic;

namespace AliExpress.ViewModelServices
{
    public class ValidadorDatosPaquetesViewModelService : IValidadorDatosPaquetesViewModelService
    {
        public List<DatosPaqueteDTO> ValidarDatosPaquetes(List<DatosPaqueteDTO> _lstdatosPaqueteDTO)
        {
            List<DatosPaqueteDTO> lstDatosPaquete = new List<DatosPaqueteDTO>();
            foreach (DatosPaqueteDTO datosPaquete in _lstdatosPaqueteDTO)
            {
                DatosPaqueteDTO datosPaqueteValidado = new DatosPaqueteDTO();
                ValidadorPaqueteriaService srvValidadorPaqueteria = new ValidadorPaqueteriaService();
                ValidadorTransporteService srvValidadorTransporte = new ValidadorTransporteService();

                srvValidadorPaqueteria.AsignarSiguienteValidacion(srvValidadorTransporte);

                datosPaqueteValidado = srvValidadorPaqueteria.ValidarDatosPedido(datosPaquete);
                lstDatosPaquete.Add(datosPaqueteValidado);
            }
            return _lstdatosPaqueteDTO;
        }

        public bool ValidarTransportesPaqueteria(int _iTransporte, List<int> _lstTransporte)
        {
            int iPaqueteriaTieneTransporte = 0;
            foreach (int iTransporte in _lstTransporte)
            {
                if (iTransporte == _iTransporte)
                {
                    iPaqueteriaTieneTransporte++;
                }
            }
            return iPaqueteriaTieneTransporte > 0 ? true : false;
        }
    }
}
