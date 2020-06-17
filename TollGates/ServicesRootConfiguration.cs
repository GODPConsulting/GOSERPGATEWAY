using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TollGates
{ 
        public class FileCacheOptions
        {
            public int TtlSeconds { get; set; }
        }

        public class LoadBalancerOptions
        {
            public string Type { get; set; }
        }

        public class DownStreamHostAndPort
        {
            public string Host { get; set; }
            public string Port { get; set; }
        }

        public class Route
        {
            public string DownstreamPathTemplate { get; set; }
            public string DownstreamScheme { get; set; }
            public FileCacheOptions FileCacheOptions { get; set; }
            public LoadBalancerOptions LoadBalancerOptions { get; set; }
            public IList<DownStreamHostAndPort> DownStreamHostAndPorts { get; set; }
            public string UpstreamPathTemplate { get; set; }
            public IList<string> UpstreamHttpMethod { get; set; }
        }

        public class GlobalConfiguration
        {
            public string BaseUrl { get; set; }
        }

        public class Example
        {
            public IList<Route> Routes { get; set; }
            public GlobalConfiguration GlobalConfiguration { get; set; }
        }



  
}
