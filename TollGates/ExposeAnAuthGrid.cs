using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TollGates
{
     

    public class ExposeAnAuthGridHandler : IRequestHandler<ExposeAnAuthGrid, AuthSettupSingleGridResponder>
    {
        private readonly SecurityContext _context;
        public ExposeAnAuthGridHandler(SecurityContext context)
        {
            _context = context;
        }
        public async Task<AuthSettupSingleGridResponder> Handle(ExposeAnAuthGrid request, CancellationToken cancellationToken)
        {
            var response = new AuthSettupSingleGridResponder { Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
            var res = await _context.ScrewIdentifierGrid.FindAsync(request.AuthSettupId);
            if(res == null)
            {
                response.Status.Message.FriendlyMessage =  "Search Record Complete"; 
                return response;
            }
            response.AuthSettups =  new AuthSettup
            {
                ActiveOnMobileApp = res.ActiveOnMobileApp,
                ActiveOnWebApp = res.ActiveOnWebApp,
                AuthSettupId = res.ScrewIdentifierGridId,
                Module = res.Module,
                Notifier = res.Notifier,
                ModuleName = Convert.ToString((Modules)res.Module),
                NotifierName = Convert.ToString((Media)res.Notifier),
            } ?? new AuthSettup();
            return response;
        }
    }
}
