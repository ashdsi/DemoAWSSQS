using DemoAWSSQS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAWSSQS.Services
{
    public interface IAWSSQSService
    {
        Task<bool> PostMessageAsync(User user);
        Task<List<AllMessage>> GetAllMessagesAsync();
        Task<bool> DeleteMessageAsync(DeleteMessage deleteMessage);
    }
}
