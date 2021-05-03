using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Sample1.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample1
{
    public class ArticleDbContext : DbContext
    {
        public ArticleDbContext(DbContextOptions<ArticleDbContext> options) : base(options)
        {
        }

        public DbSet<Articles> student { get; set; }

       
    }
}
