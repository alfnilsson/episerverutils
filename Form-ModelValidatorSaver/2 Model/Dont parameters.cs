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
            var email = form["email"];
            var phone = form["phone"];
            var street1 = form["street1"];
            var street2 = form["street2"];
            var postalcode = form["postalcode"];
            var city = form["city"];
            var country = form["country"];

            if (ValidateForm(name, email, phone, street1, street2, postalcode, city, country))
            {
                SaveForm(name, email, phone, street1, street2, postalcode, city, country);
            }

            return View(currentPage);
        }

        private void ValidateForm(string name, string email, string phone, string street1, string street2, string postalcode,
            string city, string country)
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

            if (string.IsNullOrEmpty(email) || ValidEmail(email) == false)
            {
                // Handle validation message
                return false;
            }

            if (string.IsNullOrEmpty(phone))
            {
                // Handle validation message
                return false;
            }

            if (string.IsNullOrEmpty(street1))
            {
                // Handle validation message
                return false;
            }

            if (string.IsNullOrEmpty(street2))
            {
                // Handle validation message
                return false;
            }

            if (string.IsNullOrEmpty(postalcode))
            {
                // Handle validation message
                return false;
            }

            if (string.IsNullOrEmpty(city))
            {
                // Handle validation message
                return false;
            }

            if (string.IsNullOrEmpty(country))
            {
                // Handle validation message
                return false;
            }

            return true;
        }

        private void SaveForm(name, string email, string phone, string street1, string street2, string postalcode, string city,
            string country)
        {
            SaveFormSomewhere(name, string email, string phone, string street1, string street2, string postalcode, string city,
                string country);
            // Handle confirmation message
        }
    }
}
