using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Recepdmr.Web.Pages.Components.PersonalTestimonials
{
    public class PersonalTestimonialsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View());
        }
    }
}
