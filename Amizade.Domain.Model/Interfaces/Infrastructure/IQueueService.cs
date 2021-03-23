using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amizade.Domain.Model.Interfaces.Infrastructure
{
    public interface IQueueService
    {
        Task SendAsync(string messageText);
    }
}
