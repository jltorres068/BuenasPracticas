using AliExpress.AliExpress.Data.Entites.DTO;
using AliExpress.Interfaces.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliExpress.ViewModel
{
    public class ConvertidorFormatoViewModel : IConvertidorFormatoViewModel
    {
        public List<string> ConvertirJSONaListPedido(string _cArchivoJSON)
        {
            PedidoJSON lstDatosJSON = JsonConvert.DeserializeObject<PedidoJSON>(_cArchivoJSON);
            List<string> lstPedidos = ConvertirJSONListString(lstDatosJSON);

            return lstPedidos;
        }

        private List<string> ConvertirJSONListString(PedidoJSON _pedidoJSON)
        {
            List<string> lstPedido = new List<string>();
            List<Pedidos> lstPedidos = _pedidoJSON.Pedidos;
            foreach (Pedidos pedido in lstPedidos)
            {
                //Origen, Destino, Distancia, Paqueteria, MedioTransporte y FechaPedido
                //Distancia, Paquetería, Medio de Transporte, Fecha y hora de pedido País Origen, Ciudad Origen, País Destino, Ciudad Destino

                //Distancia, Paqueteria, Medio de Transporte, Fecha y hora de Pedido, VACIO, Origen, VACIO, destino
                string cPedido = $"{pedido.Dist_KM.ToString()},{pedido.Empresa},{pedido.MedioTrans},{pedido.FechaPedido},{pedido.Procedencia},{pedido.Destino}";
                lstPedido.Add(cPedido);
            }

            return lstPedido;
        }
    }
}
