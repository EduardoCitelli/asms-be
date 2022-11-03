using ASMS.CrossCutting.Services.Abstractions;
using ASMS.CrossCutting.Services.Models;

namespace ASMS.CrossCutting.Services
{
    public class UserInfoService : IUserInfoService
    {
        public UserInfo? Value { get; private set; }

        public void Set(UserInfo userInfo)
        {
            Value = userInfo;
        }
    }
}