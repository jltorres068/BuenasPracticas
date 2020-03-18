using AliExpress.Interfaces.UI;
using System;
using System.IO;

namespace AliExpress.ViewModel
{
    public class ManipuladorDatosArchivosViewModel : IManipuladorDatosArchivosViewModel
    {
        private readonly IEliminadorDatosArchivoViewModelService eliminadorDatosArchivoViewModelService;
        private readonly ICreadorDatosArchivoViewModelService creadorDatosArchivoViewModelService;

        public ManipuladorDatosArchivosViewModel(IEliminadorDatosArchivoViewModelService _eliminadorDatosArchivoViewModelService, ICreadorDatosArchivoViewModelService _creadorDatosArchivoViewModelService)
        {
            eliminadorDatosArchivoViewModelService = _eliminadorDatosArchivoViewModelService ?? throw new ArgumentNullException(nameof(_eliminadorDatosArchivoViewModelService));
            creadorDatosArchivoViewModelService = _creadorDatosArchivoViewModelService ?? throw new ArgumentNullException(nameof(_creadorDatosArchivoViewModelService));
        }

        public void SobreEscribirDatosArchivos()
        {
            SobreEscribirDatosDHL();
            SobreEscribirDatosEstafeta();
            SobreEscribirDatosFedex();
        }

        private void SobreEscribirDatosDHL()
        {
            string rutaCompleta = Path.GetFullPath("DHL");
            string cArchivo = string.Empty;
            rutaCompleta = rutaCompleta.Replace("\\AliExpress\\bin\\Debug\\netcoreapp2.1", "");

            rutaCompleta += "\\Entregados";
            eliminadorDatosArchivoViewModelService.EliminarArchivoTXT(rutaCompleta);
            creadorDatosArchivoViewModelService.CrearArchivoTXT(rutaCompleta);

            rutaCompleta = rutaCompleta.Replace("Entregados", "Pendientes");
            eliminadorDatosArchivoViewModelService.EliminarArchivoTXT(rutaCompleta);
            creadorDatosArchivoViewModelService.CrearArchivoTXT(rutaCompleta);
        }

        private void SobreEscribirDatosEstafeta()
        {
            string rutaCompleta = Path.GetFullPath("Estafeta");
            string cArchivo = string.Empty;
            rutaCompleta = rutaCompleta.Replace("\\AliExpress\\bin\\Debug\\netcoreapp2.1", "");

            rutaCompleta += "\\Entregados";
            eliminadorDatosArchivoViewModelService.EliminarArchivoTXT(rutaCompleta);
            creadorDatosArchivoViewModelService.CrearArchivoTXT(rutaCompleta);

            rutaCompleta = rutaCompleta.Replace("Entregados", "Pendientes");
            eliminadorDatosArchivoViewModelService.EliminarArchivoTXT(rutaCompleta);
            creadorDatosArchivoViewModelService.CrearArchivoTXT(rutaCompleta);
        }

        private void SobreEscribirDatosFedex()
        {
            string rutaCompleta = Path.GetFullPath("Fedex");
            string cArchivo = string.Empty;
            rutaCompleta = rutaCompleta.Replace("\\AliExpress\\bin\\Debug\\netcoreapp2.1", "");

            rutaCompleta += "\\Entregados";
            eliminadorDatosArchivoViewModelService.EliminarArchivoTXT(rutaCompleta);
            creadorDatosArchivoViewModelService.CrearArchivoTXT(rutaCompleta);

            rutaCompleta = rutaCompleta.Replace("Entregados", "Pendientes");
            eliminadorDatosArchivoViewModelService.EliminarArchivoTXT(rutaCompleta);
            creadorDatosArchivoViewModelService.CrearArchivoTXT(rutaCompleta);
        }
    }
}
