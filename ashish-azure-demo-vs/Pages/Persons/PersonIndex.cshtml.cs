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
    public class PersonIndexModel : PageModel
    {
        private readonly ashish_azure_demo_vs.Data.AppDbContext _context;

        public PersonIndexModel(ashish_azure_demo_vs.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Person = await _context.Persons.ToListAsync();
        }
    }
}
