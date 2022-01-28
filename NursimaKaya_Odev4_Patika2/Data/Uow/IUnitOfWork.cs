using Data.VehicleRepo;
using Data.ContainerRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Generic;

namespace Data.Uow
{
    public interface IUnitOfWork
    {
        IVehicleRepository Vehicle { get; }
        IContainerRepository Container { get; }
        IGenericRepository<User> User { get; }
        IGenericRepository<Order> Order { get; }
        int Complete();
    }
}
