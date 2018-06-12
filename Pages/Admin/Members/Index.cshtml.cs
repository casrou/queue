using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QueueSystemRazor.Data;
using QueueSystemRazor.Models;

namespace QueueSystemRazor.Pages.Admin.Members
{
    public class IndexModel : PageModel
    {
        private readonly QueueSystemRazor.Data.MemberContext _context;

        public IndexModel(QueueSystemRazor.Data.MemberContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; }

        public async Task OnGetAsync()
        {
            Member = await _context.Members.OrderBy(m => m.Name).ToListAsync();
        }
    }
}
