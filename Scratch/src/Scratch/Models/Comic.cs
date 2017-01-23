using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Scratch.Models
{
    [Table("Comic")]
    public class Comic
    {
        [Key]
        public int ComicID { get; set; }
        public string Company { get; set; }
        public string Character { get; set; }
        public int Issue { get; set; }

        public int DorkID { get; set; }

        public virtual int Dork {get; set;}

    }
}
