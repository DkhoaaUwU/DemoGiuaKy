using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DemoGiuaKy.Models;

namespace DemoGiuaKy.Data
{
    public class DemoGiuaKyContext : DbContext
    {
        public DemoGiuaKyContext (DbContextOptions<DemoGiuaKyContext> options)
            : base(options)
        {
        }
        public DbSet<DemoGiuaKy.Models.User> User { get; set; } = default!;

        public DbSet<DemoGiuaKy.Models.Category>? Category { get; set; }

        public DbSet<DemoGiuaKy.Models.Product>? Product { get; set; }

        public DbSet<DemoGiuaKy.Models.Response>? Response { get; set; }
    }
}
