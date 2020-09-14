using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TollGates
{ 
    public class Expose : Controller
    {
        private readonly IMediator _mediator;
        public Expose(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ExposerInterface.AuthAdd)]
        public async Task<IActionResult> AuthAdd([FromBody] AuthSettup comm)
        {
            var response = await _mediator.Send(comm);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpGet(ExposerInterface.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var que = new ExposeAuthGrid();
            return Ok(await _mediator.Send(que)); 
        }
        [HttpGet(ExposerInterface.GetSiingle)]
        public async Task<IActionResult> GetSiingle([FromQuery] ExposeAnAuthGrid que)
        {
            return Ok(await _mediator.Send(que));  
        }
        public class ExposerInterface
        {
            public const string AuthAdd = "/api/v1/expose/auth/guard/add/update";
            public const string GetAll = "/api/v1/expose/auth/guard/get/all";
            public const string GetSiingle = "/api/v1/expose/auth/guard/get/single";
        } 
    }
}
