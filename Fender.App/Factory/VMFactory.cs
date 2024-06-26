using Fender.App.ViewModels;
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
}
