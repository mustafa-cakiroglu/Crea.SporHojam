using System.Collections.Generic;
using System.Threading.Tasks;
using Crea.SporHojam.ApplicationProcess.Domain.Models;

namespace Crea.SporHojam.ApplicationProcess.Domain.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role> Find(int id);
        Task<IEnumerable<Role>> GetAll(int offset, int limit);
        Role Add(Role role);
        Task<int> RoleCount();
    }
}
