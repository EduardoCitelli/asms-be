﻿namespace ASMS.Domain.Entities
{
    public class User : AuditEntity<long>
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public bool IsEmailConfirmed { get; set; }

        public bool IsBlocked { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

        public ICollection<InstituteMemberNote> Notes { get; set; } = new List<InstituteMemberNote>();
    }
}