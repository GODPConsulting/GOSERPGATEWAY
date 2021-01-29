using APIGateway.AcceptanceTest.Test_models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIGateway.AcceptanceTest.Test_models.Common_models
{
    public class DeleteRespObj
    {
        public DeleteRespObj()
        {
            Status = new APIResponseStatus { Message = new APIResponseMessage() };
        }
        public bool Deleted { get; set; }
        public APIResponseStatus Status { get; set; }
    }
}
