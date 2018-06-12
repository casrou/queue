using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QueueSystemRazor.Data;
using QueueSystemRazor.Models;

namespace QueueSystemRazor.Pages.Admin.Queue
{
    public class EditModel : PageModel
    {
        private readonly QueueSystemRazor.Data.QueueContext _context;

        public EditModel(QueueSystemRazor.Data.QueueContext context)
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
            var members = _context.Set<Member>().Select(m => new
            {
                MemberId = m.MemberId,
                NameAndPhoneNo = $"{m.Name} ({m.PhoneNo})"
            })
             .ToList();
            ViewData["MemberId"] = new SelectList(members, "MemberId", "NameAndPhoneNo");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(QueueEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QueueEntryExists(QueueEntry.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool QueueEntryExists(int id)
        {
            return _context.QueueEntries.Any(e => e.Id == id);
        }
    }
}
