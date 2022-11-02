namespace ASMS.Domain.Abstractions
{
    public interface IPersonalInfoEntity
    {
        long UserId { get; set; }

        DateOnly BirthDate { get; set; }

        string Phone { get; set; }

        string AddressStreet { get; set; }

        int AddressNumber { get; set; }

        string? AddressExtraInfo { get; set; }

        long IdentificationNumber { get; set; }
    }
}