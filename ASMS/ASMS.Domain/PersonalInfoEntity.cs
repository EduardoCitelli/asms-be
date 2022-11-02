using ASMS.Domain.Abstractions;
using ASMS.Domain.Entities;

namespace ASMS.Domain
{
    public class PersonalInfoEntity : AuditEntity<long>, IPersonalInfoEntity
    {
        public long UserId { get; set; }

        public DateOnly BirthDate { get; set; }

        public string Phone { get; set; } = string.Empty;

        public string AddressStreet { get; set; } = string.Empty;

        public int AddressNumber { get; set; }

        public string? AddressExtraInfo { get; set; }

        public long IdentificationNumber { get; set; }

        public virtual User User { get; set; }
    }
}
