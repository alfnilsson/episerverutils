namespace Toders.FormMVS.Controllers
{
    public class FormPageController : PageControllerBase<FormPage>
    {
        public ViewResult Index(FormPage currentPage)
        {
            return View(currentPage);
        }

        [HttpPost]
        public ViewResult Index(FormPage currentPage, FormModel form)
        {
            ApplyFallbacks(form);
            
            if (ValidateForm(model))
            {
                SaveForm(model);
            }

            return View(currentPage);
        }

        private void ApplyFallbacks(FormCollection form)
        {
            if (string.IsNullOrEmpty(form.Name) && User.Identity.IsAuthenticated)
            {
                form.Name = User.Identity.Name;
            }
        }

        private bool ValidateForm(FormModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                // Handle validation message
                return false;
            }

            if (name.StartsWith("alf", StringComparison.InvariantCultureIgnoreCase) == false)
            {
                // Handle validation message
                return false;
            }

            var email = model.Email;
            if (string.IsNullOrEmpty(email) || ValidEmail(email) == false)
            {
                // Handle validation message
                return false;
            }

            if (string.IsNullOrEmpty(model.Phone))
            {
                // Handle validation message
                return false;
            }

            if (string.IsNullOrEmpty(model.Street1))
            {
                // Handle validation message
                return false;
            }

            if (string.IsNullOrEmpty(model.Street2))
            {
                // Handle validation message
                return false;
            }

            if (string.IsNullOrEmpty(model.Postalcode))
            {
                // Handle validation message
                return false;
            }

            if (string.IsNullOrEmpty(model.City))
            {
                // Handle validation message
                return false;
            }

            if (string.IsNullOrEmpty(model.Country))
            {
                // Handle validation message
                return false;
            }
        }

        private void SaveForm(FormModel model)
        {
            SaveFormSomewhere(FormModel model);
            // Handle confirmation message
        }
    }
}