namespace Toders.FormMVS.Controllers
{
    public class FormPageController : PageControllerBase<FormPage>
    {
        public ViewResult Index(FormPage currentPage)
        {
            return View(currentPage);
        }

        [HttpPost]
        public ViewResult Index(FormPage currentPage, NameFormModel form)
        {
            var validationResult = new Validator().Validate(form);
            if (validationResult.Success == false)
            {
                // Handle validation message
            }
            else
            {
                var saveResult = new Saver().Save(form);
                if (saveResult.Success == false)
                {
                    // Handle error message from saving
                }
                else
                {
                    // Handle confirmation message
                }
            }

            return View(currentPage);
        }
    }
}