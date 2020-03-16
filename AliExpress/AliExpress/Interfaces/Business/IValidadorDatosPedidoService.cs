using AliExpress.AliExpress.Data.Entites.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliExpress.Interfaces.Business
{
    public interface IValidadorDatosPedidoService
    {
        void AsignarSiguienteValidacion(IValidadorDatosPedidoService _validadorDatosPedidoService);

        DatosPaqueteDTO ValidarDatosPedido(DatosPaqueteDTO _datosPaqueteDTO);
    }
}
