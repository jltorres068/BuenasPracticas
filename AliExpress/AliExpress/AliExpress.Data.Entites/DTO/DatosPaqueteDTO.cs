using System;
using System.Collections.Generic;
using System.Text;

namespace AliExpress.AliExpress.Data.Entites.DTO
{
    public class DatosPaqueteDTO
    {
        public Double dDistancia { get; set; }

        public string cPaqueteria { get; set; }     

        public string cMedioTransporte { get; set; }       

        public DateTime dtFechaPedido { get; set; }

        public DateTime dtFechaEntrega { get; set; }

        public string cPaisOrigen { get; set; }

        public string cCiudadOrigen { get; set; }

        public string cPaisDestino { get; set; }

        public string cCiudadDestino { get; set; }

        public Double dCostoEnvio { get; set; }

        public Double dUtilidad { get; set; }

        public int iTransporte { get; set; }

        public int iPaqueteria { get; set; }

        public int iEstacion { get; set; }

        public int iColorMensaje { get; set; }

        public Double dTiempoReparto { get; set; }

        public Double dVelocidad { get; set; }

        public Double dTiempoTraslado { get; set; }

        public List<int> lstTransporte { get; set; }

        public bool lError { get; set; }

        public int iError { get; set; }

        public string cRangoTiempo { get; set; }

        public Double dCostoDiferencia { get; set; }
    }
}
