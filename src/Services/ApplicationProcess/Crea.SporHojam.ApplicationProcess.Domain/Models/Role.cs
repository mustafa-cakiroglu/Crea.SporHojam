using Crea.SporHojam.Domain.Common;
using Crea.SporHojam.Domain.Common.Attributes;

namespace Crea.SporHojam.ApplicationProcess.Domain.Models
{
    [AuditableAttribute]
    public class Role : Entity
    {
        public int RoleId { get; protected set; }
        public string RoleName { get; set; }
    }
}
