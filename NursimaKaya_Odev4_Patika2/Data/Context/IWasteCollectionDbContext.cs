using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public interface IWasteCollectionDbContext
    {
        DbSet<Vehicle> Vehicle { get; set; }
        DbSet<Container> Container { get; set; }
        DbSet<User> User { get; set; }
        DbSet<Order> Order { get; set; }

        int SaveChanges();
    }
}
