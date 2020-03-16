using System;
using System.Collections.Generic;
using System.Text;

namespace AliExpress.Interfaces.Business
{
    public interface IEstrategiaCalculadorPaqueteriaService
    {
        ICalculadorPaqueteriaService CrearInstancia(int _iPaqueteria);
    }
}
