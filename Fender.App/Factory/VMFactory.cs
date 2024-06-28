using Fender.App.ViewModels;
using Fender.App.ViewModels.Registers;

namespace Fender.App.Factory;

public static class VMFactory
{
    public static AuthViewModel createAuthViewModel()
    {
        return new AuthViewModel();
    }
    public static UserRegistersViewModel createUserRegistersViewModel()
    {
        return new UserRegistersViewModel();
    }
}
