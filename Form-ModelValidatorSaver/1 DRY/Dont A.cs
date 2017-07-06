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
            if (string.IsNullOrEmpty(form["name"]))
            {
                // Handle error message
            }
        }

        private void SaveForm(FormCollection form)
        {
            SaveFormSomewhere(form["name"])
        }
    }
}