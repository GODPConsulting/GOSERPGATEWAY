using System;
using System.Collections.Generic;
using System.Text;

namespace APIGateway.AcceptanceTest.APIs
{
    public class General_urls
    {
        public string DefaultGateway { get; set; } = "http://107.180.93.38:5050/";
        public string MainClient { get; set; } = "http://107.180.93.38:6060/"; 
        public string Report_app { get; set; } = "http://192.168.1.100:3031/"; 
    }

    public class Identity_server : General_urls
    {
        public string connection_strings { get; set; } = "Data Source=107.180.93.38;Initial Catalog=GOS_DENTITY_SERVER; User ID=sa; Password=godp1234#;Integrated Security=False"; 
        public string Frontend { get; set; } = "http://107.180.93.38:6060/";
        public string Backend { get; set; } = "http://107.180.93.38:5051/";
    }

    public class Purchase_and_payable : General_urls
    {
        public string connection_strings { get; set; } = "Data Source=107.180.93.38;Initial Catalog=GOS_PURCHASES_AND_PAYABLES; User ID=sa; Password=godp1234#;Integrated Security=False";
        public string Frontend { get; set; } = "http://107.180.93.38:6062/";
        public string Backend { get; set; } = "http://107.180.93.38:5053/";
    }

    public class Credit : General_urls
    {
        public string connection_strings { get; set; } = "Data Source=107.180.93.38, 1433;Initial Catalog=GOS_CREDIT_DB; User ID=sa; Password=godp1234#;Integrated Security=False"; 
        public string Frontend { get; set; } = "http://107.180.93.38:6061/";
        public string Backend { get; set; } = "http://107.180.93.38:5052/";
    }
    public class PPE : General_urls
    {
        public string connection_strings { get; set; } = "Data Source=107.180.93.38;Initial Catalog=GOS_ERP_PPE; User ID=sa; Password=godp1234#;Integrated Security=False"; 
        public string Backend { get; set; } = "http://107.180.93.38:5055/";
    }
    public class Treasury : General_urls
    {
        public string connection_strings { get; set; } = "Data Source=107.180.93.38;Initial Catalog=GOS_ERP_TREASURY; User ID=sa; Password=godp1234#;Integrated Security=False";
        public string Backend { get; set; } = "http://107.180.93.38:5056/";
    }

    public class Finance : General_urls
    {
        public string connection_strings { get; set; } = "Data Source=107.180.93.38;Initial Catalog=GOS_FINANCE_DB; User ID=sa; Password=godp1234#;Integrated Security=False";
        public string Backend { get; set; } = "http://107.180.93.38:5054/";
    }

    public class Report : General_urls {
        public string Backend { get; set; } = "http://107.180.93.38:5057/";
    }

    public class Login
    {
        public string UserName { get; set; } = "can_not_form_this_user";
        public string Password { get; set; } = "fake_Pass_key";
    }

}
