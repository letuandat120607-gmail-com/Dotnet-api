using BusinessObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;
using Services.InterfaceServcies;
using Services.InterfaceServices;

namespace billx.Controllers
{
    [Route("Api/Role")]
    public class RoleController : Controller
    {
        private readonly IRoleServicescs _roleservices;

        public RoleController(IRoleServicescs roleservices)
        {
            _roleservices = roleservices;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<RoleResponse>> GetAll()
        {
            List<RoleResponse> response = _roleservices.GetAllRoles();
            return Ok(response);
        }

        [HttpGet("GetById")]
        public ActionResult<RoleResponse> GetById([FromBody] int id)
        {
            RoleResponse response = _roleservices.GetRoleById(id);
            return Ok(response);
        }

        [HttpPost("CreateRole")]
        public ActionResult<RoleResponse> CreateRole([FromBody] RoleRequest request)
        {
            RoleResponse response = _roleservices.CreateRole(request);
            return Ok(response);
        }

        [HttpPut("UpdateRole")]
        public ActionResult<RoleResponse> UpdateRole([FromBody] RoleRequest request)
        {
            
            RoleResponse response = _roleservices.UpdateRole(request);
            
            return Ok(response);
        }
    }
}
