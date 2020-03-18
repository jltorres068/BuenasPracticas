using System;
using System.Collections.Generic;
using System.Text;

namespace AliExpress.Interfaces.UI
{
    public interface IConvertidorFormatoViewModel
    {
        List<string> ConvertirJSONaListPedido(string _cArchivoJSON);
    }
}
