using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TimeLineBlog.Models
{
    public class TimeLineBlogContext : DbContext
    {
        public TimeLineBlogContext (DbContextOptions<TimeLineBlogContext> options)
            : base(options)
        {
        }

        public DbSet<TimeLineBlog.Models.Article> Article { get; set; }
    }
}
