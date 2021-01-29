using APIGateway.AcceptanceTest.Test_models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIGateway.AcceptanceTest.Test_models.Common_models
{
    public class Title 
    {
        public int JobTitleId { get; set; }
        public string Name { get; set; }
        public string JobDescription { get; set; }
        public string Skills { get; set; }
        public string SkillDescription { get; set; } 
    }

    public class CommonLookupRespObj
    {
        public List<CommonLookupsObj> CommonLookups { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class CommonLookupsObj
    {
        public int LookupId { get; set; }
        public int ParentId { get; set; }
        public string LookupName { get; set; }

        //Any Other
        public string Code { get; set; }
        public string ParentName { get; set; }
        public string Description { get; set; }
        public string SkillDescription { get; set; }
        public string Skills { get; set; }
        public double SellingRate { get; set; }
        public double BuyingRate { get; set; }
        public bool BaseCurrency { get; set; }
        public DateTime Date { get; set; }
        public decimal CorporateChargeAmount { get; set; }
        public decimal IndividualChargeAmount { get; set; }
        public int GLAccountId { get; set; }
        public bool IsMandatory { get; set; }
        public int ExcelLineNumber { get; set; }
    }
    public class LookUpRegRespObj
    {
        public int LookUpId { get; set; }
        public APIResponseStatus Status { get; set; }
    }
}
