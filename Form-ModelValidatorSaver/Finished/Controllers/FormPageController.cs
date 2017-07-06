using System.Web.Mvc;
using EPiServer;
using Toders.FormMVS.Core.Forms.Name;
using Toders.FormMVS.Models.Forms;
using Toders.FormMVS.Models.Pages;
using Toders.FormMVS.Models.ViewModels;

namespace Toders.FormMVS.Controllers
{
    public class FormPageController : PageControllerBase<FormPage>
    {
        public ViewResult Index(FormPage currentPage)
        {
            var model = new FormPageViewModel<FormPage>(currentPage);
            return View(string.Format("~/Views/{0}/Index.cshtml", currentPage.GetOriginalType().Name), model);
        }

        [HttpPost]
        public ViewResult Index(StandardPage currentPage, NameFormModel form)
        {
            var model = new FormPageViewModel<StandardPage>(currentPage);

            var validationResult = new Validator().Validate(form);
            if (validationResult.Success == false)
            {
                model.FormMessage = string.Join("<br/>", validationResult.Messages);
            }
            else
            {
                var saveResult = new Saver().Save(form);
                if (saveResult.Success == false)
                {
                    model.FormMessage = string.Join("<br/>", validationResult.Messages);
                }
                else
                {
                    model.FormMessage = "Thank you!";
                    model.HideForm = true;
                }
            }

            return View("~/Views/StandardPage/Index.cshtml", model);
        }
    }
}