using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Recepdmr.Web.Pages.Components.Preloader
{
    public class PreloaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View());
        }
    }
}
