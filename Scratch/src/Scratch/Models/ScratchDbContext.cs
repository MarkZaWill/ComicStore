using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Scratch.Models
{
    public class ScratchDbContext: DbContext
    {
       
        public DbSet<Comic> Comics { get; set; }
        public DbSet<Dork> Dorks { get; set; }
    }
}
