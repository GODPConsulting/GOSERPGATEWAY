using System;
using System.Collections.Generic;
using System.Text;

namespace APIGateway.AcceptanceTest.Test_models.Response
{
    public class APIResponseStatus
    {
        public APIResponseStatus()
        {
            Message = new APIResponseMessage();
        }
        public bool IsSuccessful { get; set; }
        public string CustomToken { get; set; }
        public string CustomSetting { get; set; }
        public APIResponseMessage Message { get; set; }
    }
    public class APIResponseMessage
    { 

        public string FriendlyMessage { get; set; }
        public string TechnicalMessage { get; set; }
        public string MessageId { get; set; }
        public string SearchResultMessage { get; set; }
        public string ShortErrorMessage { get; set; }
    }

    public class Backend_response
    {
        public APIResponseStatus Status { get; set; }
    }
}
