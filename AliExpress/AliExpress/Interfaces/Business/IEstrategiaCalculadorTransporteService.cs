using System;
using System.Collections.Generic;
using System.Text;

namespace AliExpress.Interfaces.Business
{
    public interface IEstrategiaCalculadorTransporteService
    {
        ICalculadorTransporteService CrearInstancia(int _iTransporte);
    }
}
