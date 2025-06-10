using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DR3_AT.Context;
using DR3_AT.MigrationsScaffold;

namespace DR3_AT.Pages.ScaffoldCrud
{
    public class IndexModel : PageModel
    {
        private readonly DR3_AT.Context.MyDbContext _context;

        public IndexModel(DR3_AT.Context.MyDbContext context)
        {
            _context = context;
        }

        public IList<Cliente> Cliente { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Cliente = await _context.Clientes.Where(c => !c.IsDeleted).ToListAsync();
        }
    }
}
