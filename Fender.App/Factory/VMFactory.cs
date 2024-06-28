using Fender.App.ViewModels;
using Fender.App.ViewModels.Registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
