using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Bristotti.FixedIncome.WebApplication.Model
{
    [DataContract]
    public class AssetDTO
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Ticker { get; set; }
        [DataMember]
        public DateTime IssueDate { get; set; }
        [DataMember]
        public DateTime MaturityDate { get; set; }
        [DataMember]
        public decimal Notional { get; set; }
    }
}