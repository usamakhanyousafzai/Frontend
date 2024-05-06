// IUserService.cs

using RaiseHope.Models;

namespace RaiseHope.Services
{
    public interface IUserService
    {
        ServiceResult Register(RegisterViewModel model);
    }
}
