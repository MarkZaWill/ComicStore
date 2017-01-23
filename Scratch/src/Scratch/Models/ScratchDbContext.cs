using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Scratch.Models
{
    public class ScratchDbContext: DbContext
    {
        public ScratchDbContext(DbContextOptions<ScratchDbContext> options) : base(options)
        { }
        public virtual DbSet<Comic> Comics { get; set; }
        public virtual DbSet<Dork> Dorks { get; set; }
    }
}
