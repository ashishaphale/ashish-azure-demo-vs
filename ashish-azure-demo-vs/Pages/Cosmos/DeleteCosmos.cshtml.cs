using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ashish_azure_demo_vs.Data;

namespace ashish_azure_demo_vs.Pages
{
    public class DeleteCosmos : PageModel
    {
        private readonly ashish_azure_demo_vs.Data.IEngineerService _engineerService;

        public DeleteCosmos(IEngineerService engineerService)
        {
            _engineerService = engineerService;
        }

        [BindProperty]
        public Engineer Engineer { get; set; } = default!;

        public async Task OnGetAsync(string? id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Engineer = await _engineerService.GetEngineerDetailsById(id, id);
            }
        }

        public async Task<IActionResult> OnPostAsync(string? id)
        {
            await _engineerService.DeleteEngineer(id, id);
            return RedirectToPage("./Engineers");
        }
    }
}
