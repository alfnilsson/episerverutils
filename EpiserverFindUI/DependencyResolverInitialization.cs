using EPiServer.Find.UI;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace Toders.Web.Find
{
    [InitializableModule]
    // Note that we're waiting until FindInitializationModule is done
    [ModuleDependency(typeof(FindInitializationModule))]
    public class DependencyResolverInitialization : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            // Saving the current implementation
            var originalFindUIConfiguration = context.Container.GetInstance<IFindUIConfiguration>();
            context.Container.EjectAllInstancesOf<IFindUIConfiguration>();
            
            // And giving it to my custom implementation as I want to reuse most of the original functionality
            context.Container.Configure(x => x.For<IFindUIConfiguration>().Use(() => new WrappingFindUIConfiguration(originalFindUIConfiguration)));
        }

        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void Preload(string[] parameters)
        {
        }
    }
}