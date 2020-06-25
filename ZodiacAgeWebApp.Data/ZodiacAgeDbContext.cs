using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ZodiacAgeWebApp.Core;

namespace ZodiacAgeWebApp.Data
{
    public class ZodiacAgeDbContext : DbContext
    {
        public ZodiacAgeDbContext(DbContextOptions<ZodiacAgeDbContext> options)
            : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants{ get; set; }
    }

}
