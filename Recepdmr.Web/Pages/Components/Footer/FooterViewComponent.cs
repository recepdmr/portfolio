using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Recepdmr.Web.Pages.Components.Footer
{
    public class FooterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View());
        }
    }
}
