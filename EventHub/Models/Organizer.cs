using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Models
{
    public class Organizer
    {
        public int Id { get; set; }
[Required]
[MaxLength(100)]
        public string Name { get; set; }
[MaxLength(150)]
        public string? CompanyName { get; set; }

        public bool Verified { get; set; }



    }
}
