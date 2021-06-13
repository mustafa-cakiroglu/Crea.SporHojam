using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Crea.SporHojam.ApplicationProcess.Domain.Interfaces;
using Crea.SporHojam.ApplicationProcess.Domain.Models;
using Crea.SporHojam.Domain.Common;
using Crea.SporHojam.Domain.Common.Exceptions;

namespace Crea.SporHojam.ApplicationProcess.Domain.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        private readonly IUnitOfWork _context;
        public RoleService(IRoleRepository roleRepository, IUnitOfWork context)
        {
            _roleRepository = roleRepository ?? throw new ArgumentException(nameof(roleRepository));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Role> CreateRole(Role role)
        {
            Guard.ForNull(role, nameof(role));

            _roleRepository.Add(role);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return role;
        }

        public Task DeleteRole(int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Role>> GetAllRole(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public async Task<Role> GetByRoleId(int roleId)
        {
            var role = await _roleRepository
               .Find(roleId)
               .ConfigureAwait(false);

            if (role == null)
            {
                throw new NotFoundException($"{nameof(Role)} with id {roleId} not found.");
            }

            return role;
        }
    }
}
