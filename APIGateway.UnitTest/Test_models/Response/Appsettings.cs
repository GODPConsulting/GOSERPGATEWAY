using System;
using System.Collections.Generic;
using System.Text;

namespace APIGateway.AcceptanceTest.Test_models.Response
{
    public class BaseURIs
    {
        public string LiveGateway { get; set; }
        public string LocalGateway { get; set; }
        public string MainClient { get; set; }
        public string SelfClient { get; set; }
        public string FlutterWave { get; set; }
        public string PayStack { get; set; }
        public string Other { get; set; }
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }

    public class GlobalConfiguration
    {
        public string BaseUrl { get; set; }
    }

    public class AppSettings
    {
        public IList<GlobalConfiguration> GlobalConfiguration { get; set; }
        public IList<object> Routes { get; set; }
    }

    public class GlobalConfigurationBaseURLS
    {
        public string DEFAULTGATEWAY { get; set; }
        public string PURCHASE_PAYABLES_WEB { get; set; }
        public string CREDIT_WEB { get; set; }
    }
}
