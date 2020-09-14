using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TollGates
{
    public class SecurityContext : DbContext
    {
        public SecurityContext() { }
        public readonly IHttpContextAccessor _accessor;
        public SecurityContext(DbContextOptions<SecurityContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options) { _accessor = httpContextAccessor; }

        public DbSet<ScrewIdentifierGrid> ScrewIdentifierGrid { get; set; }
    } 
}
