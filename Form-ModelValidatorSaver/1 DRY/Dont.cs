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
            if (string.IsNullOrEmpty(form["name"]))
            {
                // Handle error message
                return false;
            }

            return true;
        }

        private void SaveForm(FormCollection form)
        {
            SaveFormSomewhere(form["name"]);
            // Handle confirmation message
        }
    }
}