using AliExpress.AliExpress.Data.Entites.DTO;
using AliExpress.Fabrica;
using AliExpress.Interfaces.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
                Console.WriteLine("Escriba -f CSV para procesar pedidos con formato CSV");
                Console.WriteLine("Escriba -f JSON para procesar pedidos con formato JSON");
                string cFormato = Console.ReadLine();
                List<string> lstPedidos = new List<string>();
                ContenedorDIFactory.ConfigurarStructureMap(new ContenedorFabrica());

                var serviceArchivos = ContenedorDependencias.FactoryMethod.CrearInstancia<IManipuladorDatosArchivosViewModel>();
                serviceArchivos.SobreEscribirDatosArchivos();

                string cContenidoArchivo = File.ReadAllText(rutaCompleta);

                if (cFormato == "-f CSV")
                {
                    lstPedidos = cContenidoArchivo.Split(Environment.NewLine).ToList();
                }
                else if (cFormato == "-f JSON")
                {
                    rutaCompleta = rutaCompleta.Replace("Pedidos.txt", "PedidosJSON.txt");
                    cContenidoArchivo = File.ReadAllText(rutaCompleta);

                    var serviceFormato = ContenedorDependencias.FactoryMethod.CrearInstancia<IConvertidorFormatoViewModel>();
                    lstPedidos = serviceFormato.ConvertirJSONaListPedido(cContenidoArchivo);
                }
                var service = ContenedorDependencias.FactoryMethod.CrearInstancia<IMostrarPedidoViewModel>();
                service.MostrarInformacionPedidos(lstPedidos);
            }

            Console.ReadKey();
        }
    }
}
