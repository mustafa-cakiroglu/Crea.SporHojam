using Crea.SporHojam.Domain.Common;

namespace Crea.SporHojam.ApplicationProcess.Domain.Models
{
    public class Role : Entity
    {
        public int RoleId { get; protected set; }
        public string RoleName { get; set; }
    }
}
