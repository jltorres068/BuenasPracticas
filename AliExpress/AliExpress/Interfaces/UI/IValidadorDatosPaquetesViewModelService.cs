using AliExpress.AliExpress.Data.Entites.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliExpress.Interfaces.UI
{
    public interface IValidadorDatosPaquetesViewModelService
    {
        List<DatosPaqueteDTO> ValidarDatosPaquetes(List<DatosPaqueteDTO> _lstdatosPaqueteDTO);

        bool ValidarTransportesPaqueteria(int _iTransporte, List<int> _lstTransporte);
    }
}
