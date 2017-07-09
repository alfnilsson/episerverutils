namespace Toders.FormMVS.Core.Forms.Name
{
    public class Validator
    {
        public Response Validate(NameFormModel model)
        {
            var name = model.Name;
            if (string.IsNullOrEmpty(name))
            {
                return new Response
                {
                    Messages = new[] { "You must enter a name" }
                };
            }

            if (name.StartsWith("alf", StringComparison.InvariantCultureIgnoreCase) == false)
            {
                return new Response
                {
                    Messages = new[] { "Your name must start with Alf" }
                };
            }

            return new Response { Success = true };
        }

        public class Response
        {
            public bool Success { get; set; }

            public IEnumerable<string> Messages { get; set; }
        }
    }
}