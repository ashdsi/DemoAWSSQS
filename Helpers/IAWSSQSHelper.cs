using Amazon.SQS.Model;
using DemoAWSSQS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoAWSSQS.Helpers
{
    public interface IAWSSQSHelper
    {
        
        Task<bool> SendMessageAsync(UserDetail userDetail);
        Task<List<Message>> ReceiveMessageAsync();
        Task<bool> DeleteMessageAsync(string messageReceiptHandle);
    
    }
}
