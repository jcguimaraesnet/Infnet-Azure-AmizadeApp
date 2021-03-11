using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amizade.Domain.Model.Interfaces.Infrastructure
{
    public interface IFunctionService
    {
        Task InvokeAsync(object objeto);
    }
}
