using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerchantWebApi.Models
{
    public class MerchantDetailWithAddress
    {
        public System.Guid Id { get; set; }
        public string display_name { get; set; }
        public string registered_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string web_url { get; set; }
        public Nullable<int> merchant_id { get; set; }
        public Nullable<System.DateTime> date_modified { get; set; }
        public Nullable<System.DateTime> date_created { get; set; }
        public string status { get; set; }
        public string logo { get; set; }

        public System.Guid addressid { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public Nullable<int> postcode { get; set; }
        public string suburb { get; set; }
        public string address1 { get; set; }
        public System.Guid merchantDetail_Id { get; set; }
    }
}