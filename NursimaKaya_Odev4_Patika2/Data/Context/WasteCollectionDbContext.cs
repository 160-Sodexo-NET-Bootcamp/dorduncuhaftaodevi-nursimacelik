﻿using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class WasteCollectionDbContext : DbContext,IWasteCollectionDbContext
    {

        public WasteCollectionDbContext(DbContextOptions<WasteCollectionDbContext> options) : base(options)
        {

        }

        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Container> Container { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Order> Order { get; set; }


        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
