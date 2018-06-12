using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QueueSystemRazor.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        [Display(Name = "Navn")]
        public string Name { get; set; }
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        public string PhoneNo { get; set; }
        [Display(Name = "Alder")]
        public int Age { get; set; }
        [Display(Name = "Betalt")]
        public bool IsMember { get; set; } = true;
    }
}
