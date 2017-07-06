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
            return View(currentPage);
        }

        [HttpPost]
        public ViewResult Index(FormPage currentPage, FormCollection form)
        {
            var name = form["name"];

            ValidateForm(name);
            SaveForm(name);

            return View(currentPage);
        }

        private void ValidateForm(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                // Handle validation message
            }
        }

        private void SaveForm(name)
        {
            SaveFormSomewhere(name)
        }
    }
}