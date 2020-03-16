using StructureMap;

namespace AliExpress.Fabrica
{
    public static class ContenedorDIFactory
    {
        /// <summary>
        /// Configura el contenedor con las dependencias de la clase recibida
        /// </summary>
        /// <param name="_ConfiguracionDependencias">Clase que contiene las definiciones de las dependencias a utilizar </param>
        public static void ConfigurarStructureMap(Registry _ConfiguracionDependencias)
        {
            var ContenedorStructureMap = new Container(_ConfiguracionDependencias);
            var FactoryStructureMap = new FactoryGenericoStructureMap(ContenedorStructureMap);
            ContenedorDependencias.UsarFabrica(FactoryStructureMap);
        }
    }
}
