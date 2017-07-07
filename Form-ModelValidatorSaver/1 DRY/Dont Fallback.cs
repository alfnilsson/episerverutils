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
            if (ValidateForm(form))
            {
                SaveForm(form);
            }

            return View(currentPage);
        }

        private bool ValidateForm(FormCollection form)
        {
            var name = form["name"] ?? User.Identity.IsAuthenticated ? User.Identity.Name : null;
            if (string.IsNullOrEmpty(name))
            {
                // Handle validation message
                return false;
            }

            if (name.StartsWith("alf", StringComparison.InvariantCultureIgnoreCase) == false)
            {
                // Handle validation message
                return false;
            }

            return true;
        }

        private void SaveForm(FormCollection form)
        {
            SaveFormSomewhere(form["name"] ?? User.Identity.IsAuthenticated ? User.Identity.Name : null);
            // Handle confirmation message
        }
    }
}