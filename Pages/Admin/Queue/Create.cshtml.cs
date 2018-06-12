using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QueueSystemRazor.Data;
using QueueSystemRazor.Models;

namespace QueueSystemRazor.Pages.Admin.Queue
{
    public class CreateModel : PageModel
    {
        private readonly QueueSystemRazor.Data.QueueContext _context;

        public CreateModel(QueueSystemRazor.Data.QueueContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var members = _context.Set<Member>().Select(m => new
            {
                MemberId = m.MemberId,
                NameAndPhoneNo = $"{m.Name} ({m.PhoneNo})"
            })
            .ToList();
            ViewData["MemberId"] = new SelectList(members, "MemberId", "NameAndPhoneNo");
            return Page();
        }

        [BindProperty]
        public QueueEntry QueueEntry { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.QueueEntries.Add(QueueEntry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}