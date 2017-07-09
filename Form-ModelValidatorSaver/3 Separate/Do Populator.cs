namespace Toders.FormMVS.Core.Forms.Name
{
    public class Populator
    {
        public FormModel Populate(FormCollection form)
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
    }
}