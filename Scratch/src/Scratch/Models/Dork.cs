using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scratch.Models
{
    public class Dork
    {
        public int DorkID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public virtual List<Comic> Comics { get; set; }
    }
}
