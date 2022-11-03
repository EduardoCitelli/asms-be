using ASMS.CrossCutting.Services.Models;

namespace ASMS.CrossCutting.Services.Abstractions
{
    public interface IUserInfoService
    {
        UserInfo? Value { get; }

        void Set(UserInfo userInfo);
    }
}