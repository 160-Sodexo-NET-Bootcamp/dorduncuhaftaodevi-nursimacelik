using AutoMapper;
using Core;
using Data.Uow;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patika2.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly ILogger<ContainerController> _logger;

        private readonly IMapper mapper;

        private readonly IConfiguration configuration;

        public AuthController(ILogger<ContainerController> logger, IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        [HttpPost]
        public LoginResponse AuthLogin([FromBody] LoginRequest request)
        {
            return UserAuthentication.Auth(unitOfWork, request, configuration);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await unitOfWork.User.GetById(id);
            if(item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
