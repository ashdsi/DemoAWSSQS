using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAWSSQS.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
    }

    public class UserDetail : User
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }


    public class AllMessage                       //like DTO
    {
        public string MessageId { get; set; }
        public string ReceiptHandle { get; set; }
        
        public UserDetail UserDetail { get; set; }
        public AllMessage()
        {
            UserDetail = new UserDetail();
        }
        
    }

    public class DeleteMessage                   //like DTO
    {
        public string ReceiptHandle { get; set; }
    }
}
