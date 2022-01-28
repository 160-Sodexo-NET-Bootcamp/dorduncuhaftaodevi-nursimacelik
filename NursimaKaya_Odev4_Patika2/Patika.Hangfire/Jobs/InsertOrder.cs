using Data;
using Data.Uow;
using Hangfire;
using System;

namespace Patika.Hangfire.Jobs
{
    public class InsertOrder
    {
        IUnitOfWork unitOfWork;
        public InsertOrder(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            
            // Start a background job that will execute every 15 minutes
            RecurringJob.AddOrUpdate(() => DoJob(), "0/15 * * * *", TimeZoneInfo.Local);
        }

        // Insert an Order to the database
        public void DoJob()
        {
            Order entity = new();
            entity.InsertionTime = DateTime.Now;
            entity.Status = "NEW";
            unitOfWork.Order.Add(entity);
            unitOfWork.Complete();
        }
    }
}
