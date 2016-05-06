using System.Linq;
using System.Web.Mvc;
using EPiServer.DataAbstraction;
using EPiServer.Framework;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using Toders.Forms2.Models.Blocks;

namespace Toders.Web
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class RemoveTemplateModel : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            /*
                In this example I have two controllers that are registered as TemplateModels for PageListBlock
                I want to unregister one of them from the TemplateModelRepository, this could be a Controller from a third-party provider or add-on
            */
            var templateModelRepository = ServiceLocator.Current.GetInstance<TemplateModelRepository>();

            TemplateModel templateModelToRemove = templateModelRepository.List(typeof (PageListBlock))
                .FirstOrDefault(templateModel => templateModel.TemplateType == typeof (WrongPageListBlockController));

            templateModelRepository.UnregisterTemplate(typeof (PageListBlock), templateModelToRemove);
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }

    [TemplateDescriptor(Default = true)]
    public class WrongPageListBlockController : BlockController<PageListBlock>
    {
        public override ActionResult Index(PageListBlock currentBlock)
        {
            return PartialView();
        }
    }
}