using System;
using System.Collections.Generic;
using System.Text;

namespace APIGateway.AcceptanceTest.APIs
{
    public class General_urls
    {
        public string DefaultGateway { get; set; } = "http://192.168.1.100:90/";
        public string MainClient { get; set; } = "http://192.168.1.100:3030/"; 
        public string Report_app { get; set; } = "http://192.168.1.100:3031/"; 
    }

    public class Identity_server : General_urls
    {
        public string connection_strings { get; set; } = "Data Source=192.168.1.100;Initial Catalog=GOS_DENTITY_SERVER; User ID=sa; Password=GODP1234#;Integrated Security=False"; 
        public string Frontend { get; set; } = "http://192.168.1.100:3030/";
        public string Backend { get; set; } = "http://192.168.1.100:91/";
    }

    public class Purchase_and_payable : General_urls
    {
        public string connection_strings { get; set; } = "Data Source=DESKTOP-FIP18HV\\FLAVE;Initial Catalog=IDENTITY_SERVER;Integrated Security=True";
        public string Frontend { get; set; } = "http://192.168.1.100:3031";
        public string Backend { get; set; } = "http://localhost:5177/";
    }

    public class Credit : General_urls
    {
        public string connection_strings { get; set; } = "Data Source=DESKTOP-FIP18HV\\FLAVE;Initial Catalog=CREDIT_SERVER;Integrated Security=True"; 
        public string Frontend { get; set; } = "http://192.168.1.100:3030/";
        public string Backend { get; set; } = "http://localhost:5174/";
    }
    public class PPE : General_urls
    {
        public string connection_strings { get; set; } = "Data Source=192.168.1.100;Initial Catalog=GOS_ERP_PPE; User ID=sa; Password=GODP1234#;Integrated Security=False"; 
        public string Backend { get; set; } = "http://localhost:5174/";
    }
    public class Treasury : General_urls
    {
        public string connection_strings { get; set; } = "Data Source=192.168.1.100;Initial Catalog=GOS_ERP_PPE; User ID=sa; Password=GODP1234#;Integrated Security=False";
        public string Backend { get; set; } = "http://localhost:5174/";
    }

    public class Finance : General_urls
    {
        public string connection_strings { get; set; } = "Data Source=192.168.1.100;Initial Catalog=GOS_ERP_PPE; User ID=sa; Password=GODP1234#;Integrated Security=False";
        public string Backend { get; set; } = "http://localhost:5174/";
    }


    public class Login
    {
        public string UserName { get; set; } = "can_not_form_this_user";
        public string Password { get; set; } = "fake_Pass_key";
    }

}
