using AliExpress.AliExpress.Data.Entites.DTO;
using AliExpress.AliExpress.Data.Entites.Enumerables;
using AliExpress.Interfaces.Business;
using AliExpress.Interfaces.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliExpress.ViewModelServices
{
    public class AsignadorPedidoViewModelService : IAsignadorPedidoViewModelService
    {
        private readonly IEstrategiaCalculadorPaqueteriaService estrategiaCalculadorPaqueteriaService;
        private readonly IEstrategiaCalculadorTransporteService estrategiaCalculadorTransporteService;
        private readonly ICalculadorTiemposViewModelService calculadorTiemposViewModelService;

        public AsignadorPedidoViewModelService(IEstrategiaCalculadorPaqueteriaService _estrategiaCalculadorPaqueteriaService, IEstrategiaCalculadorTransporteService _estrategiaCalculadorTransporteService, ICalculadorTiemposViewModelService _calculadorTiemposViewModelService)
        {
            estrategiaCalculadorPaqueteriaService = _estrategiaCalculadorPaqueteriaService ?? throw new ArgumentNullException(nameof(_estrategiaCalculadorPaqueteriaService));
            estrategiaCalculadorTransporteService = _estrategiaCalculadorTransporteService ?? throw new ArgumentNullException(nameof(_estrategiaCalculadorTransporteService));
            calculadorTiemposViewModelService = _calculadorTiemposViewModelService ?? throw new ArgumentNullException(nameof(_estrategiaCalculadorTransporteService));
        }

        public DatosPaqueteDTO AsignarDatosExtraPaquetes(DatosPaqueteDTO _datosPaqueteDTO)
        {
            var service = estrategiaCalculadorPaqueteriaService.CrearInstancia(_datosPaqueteDTO.iPaqueteria);

            _datosPaqueteDTO.iEstacion = AsignarEstacion(_datosPaqueteDTO.dtFechaPedido);//Cualquiera
            _datosPaqueteDTO.lstTransporte = AsignarTransportes(_datosPaqueteDTO.iPaqueteria);//Paqueteria
            _datosPaqueteDTO.dUtilidad = service.CalcularMargenUtilidad(_datosPaqueteDTO.dtFechaPedido);//Paqueteria (Service)            
            _datosPaqueteDTO.dTiempoReparto = service.CalculadorTiempoReparto(_datosPaqueteDTO.iTransporte);//Paqueteria (Service)
            _datosPaqueteDTO.dVelocidad = AsignarVelocidad(_datosPaqueteDTO.iTransporte);

            return _datosPaqueteDTO;
        }

        public List<DatosPaqueteDTO> AsignarDatosPaquetes(List<string> _lstPaquetes)
        {
            List<DatosPaqueteDTO> lstDatosPaquetes = new List<DatosPaqueteDTO>();
            foreach (string cPaquete in _lstPaquetes)
            {
                List<string> listaPaquetes = cPaquete.Split(',').ToList();
                if(listaPaquetes.Count == 8)
                {
                    DatosPaqueteDTO paqueteDTO = new DatosPaqueteDTO();
                    paqueteDTO.dDistancia = Convert.ToDouble(listaPaquetes[0]);
                    paqueteDTO.cPaqueteria = listaPaquetes[1];
                    paqueteDTO.cMedioTransporte = listaPaquetes[2];
                    paqueteDTO.dtFechaPedido = Convert.ToDateTime(listaPaquetes[3]);
                    paqueteDTO.cPaisOrigen = listaPaquetes[4];
                    paqueteDTO.cCiudadOrigen = listaPaquetes[5];
                    paqueteDTO.cPaisDestino = listaPaquetes[6];
                    paqueteDTO.cCiudadDestino = listaPaquetes[7];
                    paqueteDTO.iPaqueteria = AsignarPaqueteria(listaPaquetes[1].ToString());
                    paqueteDTO.iTransporte = AsignarTransporte(listaPaquetes[2].ToString());
                    lstDatosPaquetes.Add(paqueteDTO);
                }
            }
            return lstDatosPaquetes;
        }

        public int AsignarColorMensaje(DatosPaqueteDTO _datosPaqueteDTO)
        {
            int iColorMensaje = (int)ConsoleColor.White;
            DateTime dtFechaActual = DateTime.Now;
            if (_datosPaqueteDTO.dtFechaEntrega <= dtFechaActual)
            {
                iColorMensaje = (int)ConsoleColor.Green;
            }
            else
            {
                iColorMensaje = (int)ConsoleColor.Yellow;
            }
            return iColorMensaje;
        }

        public List<DatosPaqueteDTO> AsignarDatosPaquetesEconomicos(DatosPaqueteDTO _datosPaqueteDTO, int _iCantidadPaqueterias)
        {
            List<string> lstPaqueterias = new List<string>();
            List<DatosPaqueteDTO> lstDatosPaquetes = new List<DatosPaqueteDTO>();
            lstPaqueterias.Add($"{_datosPaqueteDTO.dDistancia},DHL,{_datosPaqueteDTO.cMedioTransporte},{_datosPaqueteDTO.dtFechaPedido},{_datosPaqueteDTO.cPaisOrigen}," +
                                $"{_datosPaqueteDTO.cCiudadOrigen},{_datosPaqueteDTO.cPaisDestino},{_datosPaqueteDTO.cCiudadDestino}");
            
            lstPaqueterias.Add($"{_datosPaqueteDTO.dDistancia},Estafeta,{_datosPaqueteDTO.cMedioTransporte},{_datosPaqueteDTO.dtFechaPedido},{_datosPaqueteDTO.cPaisOrigen}," +
                                $"{_datosPaqueteDTO.cCiudadOrigen},{_datosPaqueteDTO.cPaisDestino},{_datosPaqueteDTO.cCiudadDestino}");
            
            lstPaqueterias.Add($"{_datosPaqueteDTO.dDistancia},Fedex,{_datosPaqueteDTO.cMedioTransporte},{_datosPaqueteDTO.dtFechaPedido},{_datosPaqueteDTO.cPaisOrigen}," +
                                $"{_datosPaqueteDTO.cCiudadOrigen},{_datosPaqueteDTO.cPaisDestino},{_datosPaqueteDTO.cCiudadDestino}");
            lstDatosPaquetes = AsignarDatosPaquetes(lstPaqueterias);
            return lstDatosPaquetes;
        }

        public DatosPaqueteDTO AsignarResultadosDatosPaquetes(DatosPaqueteDTO _datosPaqueteDTO)
        {
            var serviceEstrategia = estrategiaCalculadorTransporteService.CrearInstancia(_datosPaqueteDTO.iTransporte);

            _datosPaqueteDTO.dCostoEnvio = serviceEstrategia.CalcularCostoEnvio(_datosPaqueteDTO);
            _datosPaqueteDTO.dTiempoTraslado = serviceEstrategia.CalcularTiempoTraslado(_datosPaqueteDTO);
            _datosPaqueteDTO.dtFechaEntrega = calculadorTiemposViewModelService.CalcularFechaEntrega(_datosPaqueteDTO);
            _datosPaqueteDTO.iColorMensaje = AsignarColorMensaje(_datosPaqueteDTO);
            _datosPaqueteDTO.cRangoTiempo = calculadorTiemposViewModelService.CalcularRangoTiempo(_datosPaqueteDTO);

            return _datosPaqueteDTO;
        }

        private int AsignarEstacion(DateTime _dtFechaPedido)
        {
            int iEstacion = 0, iYear = 0;
            iYear = _dtFechaPedido.Year;

            if (_dtFechaPedido >= new DateTime(iYear, 3, 1) && _dtFechaPedido <= new DateTime(iYear, 5, 31))
            {
                iEstacion = (int)EnumEstaciones.Primavera;
            }
            else if (_dtFechaPedido >= new DateTime(iYear, 6, 1) && _dtFechaPedido <= new DateTime(iYear, 8, 31))
            {
                iEstacion = (int)EnumEstaciones.Verano;
            }
            else if (_dtFechaPedido >= new DateTime(iYear, 9, 1) && _dtFechaPedido <= new DateTime(iYear, 11, 30))
            {
                iEstacion = (int)EnumEstaciones.Otoño;
            }
            else
            {
                iEstacion = (int)EnumEstaciones.Invierno;
            }
            return iEstacion;
        }

        private List<int> AsignarTransportes(int _iPaqueteria)
        {
            List<int> lstTransportes = new List<int>();
            switch (_iPaqueteria)
            {
                case (int)EnumPaqueterias.DHL:
                    lstTransportes.Add((int)EnumTransportes.Aéreo);
                    lstTransportes.Add((int)EnumTransportes.Marítimo);
                    lstTransportes.Add((int)EnumTransportes.Terrestre);
                    break;
                case (int)EnumPaqueterias.Estafeta:
                    lstTransportes.Add((int)EnumTransportes.Marítimo);
                    lstTransportes.Add((int)EnumTransportes.Terrestre);
                    break;
                case (int)EnumPaqueterias.Fedex:
                    lstTransportes.Add((int)EnumTransportes.Aéreo);
                    lstTransportes.Add((int)EnumTransportes.Marítimo);
                    lstTransportes.Add((int)EnumTransportes.Terrestre);
                    break;
            }
            return lstTransportes;
        }

        private int AsignarPaqueteria(string _cPaqueteria)
        {
            int iPaqueteria = 0;
            if (_cPaqueteria.ToUpper() == "DHL")
            {
                iPaqueteria = (int)EnumPaqueterias.DHL;
            }
            else if (_cPaqueteria.ToUpper() == "FEDEX")
            {
                iPaqueteria = (int)EnumPaqueterias.Fedex;
            }
            else if (_cPaqueteria.ToUpper() == "ESTAFETA")
            {
                iPaqueteria = (int)EnumPaqueterias.Estafeta;
            }
            return iPaqueteria;
        }

        private int AsignarTransporte(string _cTransporte)
        {
            int iTransporte = 0;
            if (_cTransporte.ToUpper() == "AÉREO")
            {
                iTransporte = (int)EnumTransportes.Aéreo;
            }
            else if (_cTransporte.ToUpper() == "MARÍTIMO")
            {
                iTransporte = (int)EnumTransportes.Marítimo;
            }
            else if (_cTransporte.ToUpper() == "TERRESTRE")
            {
                iTransporte = (int)EnumTransportes.Terrestre;
            }
            return iTransporte;
        }

        private Double AsignarVelocidad(int _iTransporte)
        {
            Double dVelocidad = 0;
            switch (_iTransporte)
            {
                case (int)EnumTransportes.Aéreo:
                    dVelocidad = 600;
                    break;
                case (int)EnumTransportes.Marítimo:
                    dVelocidad = 46;
                    break;
                case (int)EnumTransportes.Terrestre:
                    dVelocidad = 80;
                    break;
            }
            return dVelocidad;
        }
    }
}
