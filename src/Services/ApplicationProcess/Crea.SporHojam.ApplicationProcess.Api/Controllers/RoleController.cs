using System;
using System.Threading.Tasks;
using AutoMapper;
using Crea.SporHojam.ApplicationProcess.Api.Model;
using Crea.SporHojam.ApplicationProcess.Domain.Interfaces;
using Crea.SporHojam.ApplicationProcess.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crea.SporHojam.ApplicationProcess.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<ActionResult<RoleDto>> CreateRole(RoleDto roleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = await _roleService.CreateRole(_mapper.Map<Role>(roleDto));
            var roleModelDto = _mapper.Map<RoleDto>(role);

            return Ok(roleModelDto);
        }
    }
}
