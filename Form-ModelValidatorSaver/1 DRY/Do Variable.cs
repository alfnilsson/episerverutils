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

            if (ValidateForm(name))
            {
                SaveForm(name);
            }

            return View(currentPage);
        }

        private bool ValidateForm(string name)
        {
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

        private void SaveForm(name)
        {
            SaveFormSomewhere(name);
            // Handle confirmation message
        }
    }
}
