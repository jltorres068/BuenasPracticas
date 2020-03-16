using AliExpress.Interfaces;

namespace AliExpress.Fabrica
{
    public class ContenedorDependencias
    {
        /// <summary>
        /// Inicializa la interface estática que se va a estar usando
        /// </summary>
        /// <param name="_Fabrica">Instancia d</param>
        public static void UsarFabrica(IFactoryMethodGenerico _Fabrica)
        {
            FactoryMethod = _Fabrica;
        }

        /// <summary>
        /// Fabrica de instancias genericas
        /// </summary>
        public static IFactoryMethodGenerico FactoryMethod { get; private set; }
    }
}
