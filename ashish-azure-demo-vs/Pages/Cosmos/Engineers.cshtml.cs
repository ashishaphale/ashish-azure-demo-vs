using ashish_azure_demo_vs.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ashish_azure_demo_vs.Pages.Cosmos
{
    public class EngineersModel : PageModel
    {

        private readonly ashish_azure_demo_vs.Data.IEngineerService _engineerService;
        public EngineersModel(IEngineerService engineerService)
        {
            _engineerService = engineerService;
        }
        public IList<Engineer> engineers { get; set; } = default!;
        private async Task DeleteEngineer(Guid? id)
        {
            await _engineerService.DeleteEngineer(id.ToString(), id.ToString());
            engineers = await _engineerService.GetEngineerDetails();
        }
        public async Task OnGetAsync()
        {
            engineers = await _engineerService.GetEngineerDetails();
        }
    }
}
