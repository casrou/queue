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
    public class DeleteModel : PageModel
    {
        private readonly QueueSystemRazor.Data.QueueContext _context;

        public DeleteModel(QueueSystemRazor.Data.QueueContext context)
        {
            _context = context;
        }

        [BindProperty]
        public QueueEntry QueueEntry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            QueueEntry = await _context.QueueEntries
                .Include(q => q.Member).FirstOrDefaultAsync(m => m.Id == id);

            if (QueueEntry == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            QueueEntry = await _context.QueueEntries.FindAsync(id);

            if (QueueEntry != null)
            {
                _context.QueueEntries.Remove(QueueEntry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
