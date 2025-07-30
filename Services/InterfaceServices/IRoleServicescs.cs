using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;

namespace Services.InterfaceServices
{
    public interface IRoleServicescs
    {
        List<RoleResponse> GetAllRoles();

        RoleResponse GetRoleById(int roleId);

        RoleResponse CreateRole(RoleRequest request);

        RoleResponse UpdateRole(RoleRequest request);
        
    }
}
