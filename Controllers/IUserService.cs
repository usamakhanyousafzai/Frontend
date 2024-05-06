using RaiseHope.Models;

namespace RaiseHope.Controllers
{
    internal interface IUserService
    {
        object Register(RegisterViewModel model);
    }
}