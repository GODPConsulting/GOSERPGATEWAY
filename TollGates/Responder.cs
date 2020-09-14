using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TollGates
{
    public class Responder
    {
        public int ResponderId { get; set; }
        public APIResponseStatus Status { get; set; }
    }

    public class APIResponseMessage
    {
        public string FriendlyMessage { get; set; }
        public string TechnicalMessage { get; set; } 
    }

    public class APIResponseStatus
    {
        public Boolean IsSuccessful { get; set; } = false; 
        public APIResponseMessage Message { get; set; }
    }
}
