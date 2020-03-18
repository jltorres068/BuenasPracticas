using AliExpress.Interfaces.UI;
using System.IO;

namespace AliExpress.ViewModelServices
{
    public class EliminadorDatosArchivoViewModelService : IEliminadorDatosArchivoViewModelService
    {
        public void EliminarArchivoTXT(string rutaCompleta)
        {
            File.Delete(rutaCompleta + "\\Años.txt");
            File.Delete(rutaCompleta + "\\Bimestre.txt");
            File.Delete(rutaCompleta + "\\Dias.txt");
            File.Delete(rutaCompleta + "\\Horas.txt");
            File.Delete(rutaCompleta + "\\Meses.txt");
            File.Delete(rutaCompleta + "\\Minutos.txt");
            File.Delete(rutaCompleta + "\\Semanas.txt");
        }
    }
}
