using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Recepdmr.Web.Pages.Components.Header
{
    public class HeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View());
        }
    }
}
