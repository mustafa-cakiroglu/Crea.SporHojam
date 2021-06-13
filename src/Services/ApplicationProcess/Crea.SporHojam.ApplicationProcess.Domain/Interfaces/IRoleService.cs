using System.Collections.Generic;
using System.Threading.Tasks;
using Crea.SporHojam.ApplicationProcess.Domain.Models;

namespace Crea.SporHojam.ApplicationProcess.Domain.Interfaces
{
    public interface IRoleService
    {
        Task<Role> GetByRoleId(int roleId);
        Task<IEnumerable<Role>> GetAllRole(int offset, int limit);
        Task<Role> CreateRole(Role role);
        Task DeleteRole(int roleId);
    }
}
