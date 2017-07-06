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
            ValidateForm(model);
            SaveForm(model);

            return View(currentPage);
        }

        private void GatherFormInput(FormCollection form)
        {
            return new FormModel
            {
                Name = form["name"],
                Email = form["email"],
                Phone = form["phone"],
                Street1 = form["street1"],
                Street2 = form["street2"],
                Postalcode = form["postalcode"],
                City = form["city"],
                Country = form["country"]
            };
        }

        private void ValidateForm(FormModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                // Handle validation message
            }

            var email = model.Email;
            if (string.IsNullOrEmpty(email) || ValidEmail(email) == false)
            {
                // Handle validation message
            }

            if (string.IsNullOrEmpty(model.Phone))
            {
                // Handle validation message
            }

            if (string.IsNullOrEmpty(model.Street1))
            {
                // Handle validation message
            }

            if (string.IsNullOrEmpty(model.Street2))
            {
                // Handle validation message
            }

            if (string.IsNullOrEmpty(model.Postalcode))
            {
                // Handle validation message
            }

            if (string.IsNullOrEmpty(model.City))
            {
                // Handle validation message
            }

            if (string.IsNullOrEmpty(model.Country))
            {
                // Handle validation message
            }
        }

        private void SaveForm(FormModel model)
        {
            SaveFormSomewhere(FormModel model)
        }
    }
}