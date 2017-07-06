using System.Collections.Generic;
using Toders.FormMVS.Models.Forms;

namespace Toders.FormMVS.Core.Forms.Name
{
    public class Saver
    {
        public Response Save(NameFormModel model)
        {
            // Do something with the model
            // If something goes wrong, return a response with Success = false

            return new Response { Success = true };
        }

        public class Response
        {
            public bool Success { get; set; }

            public IEnumerable<string> Messages { get; set; }
        }
    }
}