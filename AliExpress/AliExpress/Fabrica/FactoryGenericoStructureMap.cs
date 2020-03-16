using AliExpress.Interfaces;
using StructureMap;
using StructureMap.Graph;
using StructureMap.Pipeline;
using System;
using System.Linq;
using System.Reflection;

namespace AliExpress.Fabrica
{
    public class FactoryGenericoStructureMap : IFactoryMethodGenerico, IConstructorSelector
    {
        private readonly IContainer ContenedorDI;

        public FactoryGenericoStructureMap(IContainer _ContenedorDI)
        {
            ContenedorDI = _ContenedorDI;
            ContenedorDI.Configure((DI) => DI.Policies.ConstructorSelector(this));
            ContenedorDI.Configure((DI) => DI.For<IFactoryMethodGenerico>().Use(this));
        }

        public T CrearInstancia<T>()
        {
            return ContenedorDI.GetInstance<T>();
        }

        public ConstructorInfo Find(Type pluggedType, DependencyCollection dependencies, PluginGraph graph)
        {
            ConstructorInfo ConstructorPorEmplear = null;

            ConstructorPorEmplear = ObtenerConstructorMasCodicioso(pluggedType);

            return ConstructorPorEmplear;
        }

        private ConstructorInfo ObtenerConstructorMasCodicioso(Type _TipoDato)
        {
            var ConstructorEncontrado = _TipoDato.GetConstructors().OrderByDescending((C) => C.GetParameters().Count()).FirstOrDefault();
            return ConstructorEncontrado;
        }
    }
}
