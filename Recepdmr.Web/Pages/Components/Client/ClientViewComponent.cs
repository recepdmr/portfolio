using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Recepdmr.Web.Pages.Components.Client
{
    public class ClientViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View());
        }
    }
}
