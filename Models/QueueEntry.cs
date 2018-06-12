using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QueueSystemRazor.Models
{
    public class QueueEntry
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy HH:mm}")]
        [Display(Name = "Forventet start")]
        public DateTime StartTime { get; set; }
        [Display(Name = "Færdig")]
        public bool IsDone { get; set; } = false;

        public int MemberId { get; set; }
        [Display(Name = "Navn")]
        public Member Member { get; set; }
    }
}
