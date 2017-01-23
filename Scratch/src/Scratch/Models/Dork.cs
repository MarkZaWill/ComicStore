using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Scratch.Models
{
    [Table("Dork")]
    public class Dork
    {
        [Key]
        public int DorkID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public virtual List<Comic> Comics { get; set; }
    }
}
