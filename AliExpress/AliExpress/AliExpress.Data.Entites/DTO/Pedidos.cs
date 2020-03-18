using System;

namespace AliExpress.AliExpress.Data.Entites.DTO
{
    public class Pedidos
    {
        public string Procedencia { get; set; }
        public string Destino { get; set; }
        public Double Dist_KM { get; set; }
        public string Empresa { get; set; }
        public string MedioTrans { get; set; }
        public string FechaPedido { get; set; }
    }
}
