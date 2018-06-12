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
    public class DetailsModel : PageModel
    {
        private readonly QueueSystemRazor.Data.MemberContext _context;

        public DetailsModel(QueueSystemRazor.Data.MemberContext context)
        {
            _context = context;
        }

        public Member Member { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Member = await _context.Members.FirstOrDefaultAsync(m => m.MemberId == id);

            if (Member == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
