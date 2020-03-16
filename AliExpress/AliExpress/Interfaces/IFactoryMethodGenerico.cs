using System;
using System.Collections.Generic;
using System.Text;

namespace AliExpress.Interfaces
{
    public interface IFactoryMethodGenerico
    {
        T CrearInstancia<T>();

        //T CrearInstancia<T>(string _cIdentificador);
    }
}
