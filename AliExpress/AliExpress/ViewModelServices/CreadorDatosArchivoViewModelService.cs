using AliExpress.Interfaces.UI;
using System.IO;

namespace AliExpress.ViewModelServices
{
    public class CreadorDatosArchivoViewModelService: ICreadorDatosArchivoViewModelService
    {
        public void CrearArchivoTXT(string rutaCompleta)
        {
            File.Create(rutaCompleta + "\\Años.txt").Close();
            File.Create(rutaCompleta + "\\Bimestre.txt").Close();
            File.Create(rutaCompleta + "\\Dias.txt").Close();
            File.Create(rutaCompleta + "\\Horas.txt").Close();
            File.Create(rutaCompleta + "\\Meses.txt").Close();
            File.Create(rutaCompleta + "\\Minutos.txt").Close();
            File.Create(rutaCompleta + "\\Semanas.txt").Close();
        }
    }
}
