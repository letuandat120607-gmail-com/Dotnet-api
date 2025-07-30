using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessObject;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;
using Services.InterfaceServices;

namespace Services.ImplementServices
{
    public class RoleServices : IRoleServicescs
    {
        public RoleResponse CreateRole(RoleRequest request)
        {
            try
            {
                RoleDAO roleDAO = RoleDAO.Instance;
                Role create = new Role();
                create.RoleId = request.RoleId; 
                create.RoleName = request.RoleName;

                Role role = roleDAO.CreateRole(create);
                RoleResponse response = new RoleResponse
                {
                    RoleId = role.RoleId,
                    RoleName = role.RoleName,
                    Status = role.Status
                };
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<RoleResponse> GetAllRoles()
        {
            try
            {
                RoleDAO roleDAO = RoleDAO.Instance;
                List<Role> rs = roleDAO.GetAll();
                if (rs == null)
                {
                    return new List<RoleResponse>();
                }

                List<RoleResponse> roles = new List<RoleResponse>();
                for (int i = 0; i < rs.Count; i++) 
                { 
                Role role = rs[i];
                    RoleResponse roleResponse = new RoleResponse
                    {
                        RoleId = role.RoleId,
                        RoleName = role.RoleName,
                        Status = role.Status
                    };
                    roles.Add(roleResponse);
                }
                return roles;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public RoleResponse GetRoleById(int roleId)
        {
            try
            {
                RoleDAO roleDAO = RoleDAO.Instance;
                Role role = roleDAO.GetById(roleId);

                RoleResponse response = new RoleResponse
                {
                    RoleId = role.RoleId,
                    RoleName = role.RoleName,
                    Status = role.Status
                };
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public RoleResponse UpdateRole(RoleRequest request)
        {
            try
            {
                RoleDAO roleDAO = RoleDAO.Instance;
                Role update = new Role();
                update.RoleId = request.RoleId;
                update.RoleName = request.RoleName;
                Role role = roleDAO.UpdateRole(update);

                RoleResponse response = new RoleResponse
                {
                    RoleId = role.RoleId,
                    RoleName = role.RoleName,
                    Status = role.Status
                };
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
