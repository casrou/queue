using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QueueSystemRazor.Data;
using QueueSystemRazor.Models;

namespace QueueSystemRazor.Pages.Admin.Queue
{
    public class IndexModel : PageModel
    {
        private readonly QueueSystemRazor.Data.QueueContext _context;

        public IndexModel(QueueSystemRazor.Data.QueueContext context)
        {
            _context = context;
        }

        public IList<QueueEntry> QueueEntry { get;set; }

        public async Task OnGetAsync()
        {
            QueueEntry = await _context.QueueEntries
                .OrderBy(qe => qe.StartTime)
                .OrderBy(qe => qe.IsDone)
                .Include(q => q.Member).ToListAsync();
        }
    }
}
