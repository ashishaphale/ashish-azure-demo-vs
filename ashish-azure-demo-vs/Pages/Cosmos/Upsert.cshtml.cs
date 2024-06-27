using ashish_azure_demo_vs.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TextTemplating;

namespace ashish_azure_demo_vs.Pages.Cosmos
{
    public class UpsertModel : PageModel
    {
        private readonly ashish_azure_demo_vs.Data.IEngineerService _engineerService;
        public UpsertModel(IEngineerService engineerService)
        {
            _engineerService = engineerService;
        }

        public async Task OnGetAsync(string? id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Engineer = await _engineerService.GetEngineerDetailsById(id, id);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _engineerService.UpsertEngineer(Engineer);
            return RedirectToPage("./Engineers");
        }

        [BindProperty]
        public Engineer Engineer { get; set; } = default!;
    }
}
