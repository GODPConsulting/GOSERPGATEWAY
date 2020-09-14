using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TollGates
{
    public class ExposeAuthGridHandler : IRequestHandler<ExposeAuthGrid, AuthSettupGridResponder>
    {
        private readonly SecurityContext _context;
        public ExposeAuthGridHandler(SecurityContext context)
        {
            _context = context;
        }
        public async Task<AuthSettupGridResponder> Handle(ExposeAuthGrid request, CancellationToken cancellationToken)
        {
            var response = new AuthSettupGridResponder { Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
            var res = await _context.ScrewIdentifierGrid.ToListAsync();
            response.AuthSettups = res.Select(q => new AuthSettup
            {
                ActiveOnMobileApp = q.ActiveOnMobileApp,
                ActiveOnWebApp = q.ActiveOnWebApp,
                AuthSettupId = q.ScrewIdentifierGridId,
                Module = q.Module,
                Notifier = q.Notifier,
                ModuleName = Convert.ToString((Modules)q.Module),
                NotifierName = Convert.ToString((Media)q.Notifier),
            }).ToList() ?? new List<AuthSettup>();
            response.Status.Message.FriendlyMessage = res.Count() > 0 ? string.Empty : "Search Record Complete";
            return response;
        }
    }
}
