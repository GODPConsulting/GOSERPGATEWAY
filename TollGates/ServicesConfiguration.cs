using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TollGates
{
    public class ServicesConfiguration
    {
        public List<ServiceAssembly> Services { get; set; }
    }
    public class ServiceAssembly
    {
        public string AssemblyName { get; set; }
    }
}
