using Toders.FormMVS.Models.Pages;

namespace Toders.FormMVS.Models.ViewModels
{
    public class FormPageViewModel<T> : PageViewModel<T>
        where T : SitePageData
    {
        public FormPageViewModel(T currentPage)
            : base(currentPage)
        {
        }

        public bool HideForm { get; set; }

        public string FormMessage { get; set; }
    }
}