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
            ValidateForm(form);
            SaveForm(form);

            return View(currentPage);
        }

        private void ValidateForm(FormCollection form)
        {
            if (string.IsNullOrEmpty(form["name"] ?? this.User.Identity.IsAuthenticated ? this.User.Identity.Name : null))
            {
                // Handle validation message
            }
        }

        private void SaveForm(FormCollection form)
        {
            SaveFormSomewhere(form["name"] ?? this.User.Identity.IsAuthenticated ? this.User.Identity.Name : null)
        }
    }
}