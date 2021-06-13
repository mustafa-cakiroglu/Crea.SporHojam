using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Crea.SporHojam.ApplicationProcess.Domain.Interfaces;
using Crea.SporHojam.ApplicationProcess.Domain.Models;
using Crea.SporHojam.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Crea.SporHojam.ApplicationProcess.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationContext _context;

        public RoleRepository(IUnitOfWork context)
        {
            _context = context as ApplicationContext ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public Role Add(Role role)
        {
            if (role.IsTransient())
            {
                return _context
                    .Role
                    .Add(role)
                    .Entity;
            }

            return role;
        }

        public async Task<Role> Find(int id)
        {
            return await _context
             .Role
             .SingleAsync(x => x.Id <= id)
             .ConfigureAwait(false);
        }

        public Task<IEnumerable<Role>> GetAll(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public Task<int> RoleCount()
        {
            throw new NotImplementedException();
        }
    }
}
