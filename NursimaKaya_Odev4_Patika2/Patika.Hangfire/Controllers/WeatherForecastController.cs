using Data.Uow;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Patika.Hangfire.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patika.Hangfire.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BackgroundJobController : ControllerBase
    {
        private readonly ILogger<BackgroundJobController> logger;
        private IUnitOfWork unitOfWork;

        public BackgroundJobController(ILogger<BackgroundJobController> logger, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("/InsertionJob")]
        public void RunInsert()
        {
            InsertOrder job = new(unitOfWork);
        }

        [HttpPost("/UpdateJob")]
        public void RunUpdate()
        {
            UpdateOrderStatus job = new(unitOfWork);
        }
    }
}
