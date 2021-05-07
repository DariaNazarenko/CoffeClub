using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeClub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeClub.Domain
{
    public class CoffeeClubContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Coffee> Coffee { get; set; }

        public CoffeeClubContext(DbContextOptions<CoffeeClubContext> options) : base(options)
        { }

        public void EnsureCreated()
        {
            Database.EnsureCreated();
        }
    }
}
