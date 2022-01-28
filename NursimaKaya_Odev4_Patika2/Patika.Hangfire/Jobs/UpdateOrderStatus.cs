using Data.Uow;
using Hangfire;
using System;

namespace Patika.Hangfire.Jobs
{
    public class UpdateOrderStatus
    {
        IUnitOfWork unitOfWork;
        public UpdateOrderStatus(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

            // Start a background job that will execute at 18:00 every day 
            RecurringJob.AddOrUpdate(() => DoJob(), "0 18 * * *", TimeZoneInfo.Local);
        }
        
        // Get Orders that was created the same day between 8:00 and 18:00 and change their status to "OLD"
        public void DoJob()
        {
            var today = DateTime.Today;
            var beg = new DateTime(today.Year, today.Month, today.Day, 8, 0, 0);
            var end = new DateTime(today.Year, today.Month, today.Day, 18, 0, 0);
            var orders = unitOfWork.Order.Where(x => x.InsertionTime >= beg && x.InsertionTime <= end);
            foreach(var order in orders)
            {
                order.Status = "OLD";
            }
            unitOfWork.Complete();
        }
    }
}
