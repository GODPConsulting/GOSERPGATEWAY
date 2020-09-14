using MediatR;
using System.Collections.Generic;

namespace TollGates
{
    public class AuthSettupCreate : IRequest<Responder>
    {
        public int AuthSettupId { get; set; }
        public int Notifier { get; set; }
        public int Module { get; set; }
        public bool ActiveOnMobileApp { get; set; }
        public bool ActiveOnWebApp { get; set; }
    }
    public class ExposeAnAuthGrid : IRequest<AuthSettupSingleGridResponder> 
    {
        public ExposeAnAuthGrid() { }
        public int AuthSettupId { get; set; }
        public ExposeAnAuthGrid(int authSettupId)
        {
            AuthSettupId = authSettupId;
        }
    }
    public class ExposeAuthGrid : IRequest<AuthSettupGridResponder> { }
    public class AuthSettupGridResponder
    {
        public List<AuthSettup> AuthSettups { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class AuthSettupSingleGridResponder
    {
        public AuthSettup AuthSettups { get; set; }
        public APIResponseStatus Status { get; set; }
    }

    public class AuthSettup : IRequest<Responder>
    {
        public int AuthSettupId { get; set; }
        public int Notifier { get; set; }
        public int Module { get; set; }
        public bool ActiveOnMobileApp { get; set; }
        public bool ActiveOnWebApp { get; set; } 
        public string ModuleName { get; set; }
        public string NotifierName { get; set; }
    }
    public enum Modules
    {
        SELF = 1,
        PURCHASE_AND_PAYABLES,
        CREDIT
    }

    public enum Media
    {
        SMS = 1,
        EMAIL = 2
    }
}
