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
            var name;
            var email;
            var phone;
            var street1;
            var street2;
            var postalcode;
            var city;
            var country;

            GatherFormInput(out name, out email, out phone, out street1, out street2, out postalcode, out city, out country);

            if (ValidateForm(name, email, phone, street1, street2, postalcode, city, country))
            {
                SaveForm(name, email, phone, street1, street2, postalcode, city, country);
            }

            return View(currentPage);
        }

        private void GatherFormInput(out string name, out string email, out string phone, out string street1, out string street2,
            out string postalcode, out string city, out string country)
        {
            name = form["name"];
            email = form["email"];
            phone = form["phone"];
            street1 = form["street1"];
            street2 = form["street2"];
            postalcode = form["postalcode"];
            city = form["city"];
            country = form["country"];
        }

        private bool ValidateForm(string name, string email, string phone, string street1, string street2, string postalcode,
            string city, string country)
        {
            if (string.IsNullOrEmpty(name))
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
