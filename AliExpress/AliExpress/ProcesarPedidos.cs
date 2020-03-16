using AliExpress.Fabrica;
using AliExpress.Interfaces.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AliExpress
{
    public class ProcesarPedidos
    {
        static void Main(string[] args)
        {
            string rutaCompleta = Path.GetFullPath(@"Pedidos.txt");
            rutaCompleta = rutaCompleta.Replace("\\AliExpress\\bin\\Debug\\netcoreapp2.1", "");
            if (File.Exists(rutaCompleta))
            {
                rutaCompleta = File.ReadAllText(rutaCompleta);
                List<string> lineas = rutaCompleta.Split(Environment.NewLine).ToList();

                ContenedorDIFactory.ConfigurarStructureMap(new ContenedorFabrica());
                var service = ContenedorDependencias.FactoryMethod.CrearInstancia<IMostrarPedidoViewModel>();
                service.MostrarInformacionPedidos(lineas);
            }

            Console.ReadKey();
        }
    }
}
