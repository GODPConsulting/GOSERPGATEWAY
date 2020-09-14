using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TollGates
{
    public class ScrewIdentifierGrid
    {
        public int ScrewIdentifierGridId { get; set; }
        public int Notifier { get; set; }
        public int Module { get; set; } 
        public bool ActiveOnMobileApp { get; set; }
        public bool ActiveOnWebApp { get; set; }
    }
}
