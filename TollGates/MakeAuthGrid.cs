using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TollGates
{
    public class MakeAuthSettup : IRequestHandler<AuthSettupCreate, Responder>
    {
        private readonly SecurityContext _security;
        public MakeAuthSettup(SecurityContext security)
        {
            _security = security;
        }
        public async Task<Responder> Handle(AuthSettupCreate request, CancellationToken cancellationToken)
        {
            var response = new Responder { Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
            try
            {
                var domain = new ScrewIdentifierGrid();
                domain.ActiveOnMobileApp = request.ActiveOnMobileApp;
                domain.ActiveOnWebApp = request.ActiveOnWebApp;
                domain.Notifier = request.Notifier;
                domain.ScrewIdentifierGridId = request.AuthSettupId;
                domain.Module = request.Module;
                if (request.AuthSettupId > 0)
                {
                    var item = await _security.ScrewIdentifierGrid.FindAsync(request.AuthSettupId);
                    _security.Entry(item).CurrentValues.SetValues(domain);
                }
                else
                {
                    await _security.ScrewIdentifierGrid.AddAsync(domain);
                }
                await _security.SaveChangesAsync();
                response.ResponderId = domain.ScrewIdentifierGridId;
                response.Status.IsSuccessful = true;
                return response;
            }
            catch (Exception)
            {
                return response;
            }
        }
    }

}
