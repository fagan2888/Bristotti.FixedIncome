using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bristotti.FixedIncome.Model
{
    [DataContract(Namespace = "Bristotti.FixedIncome.Model")]
    public class Asset
    {
        [DataMember]
        public virtual Guid Id { get; set; }
        [DataMember]
        public virtual string Ticker { get; set; }
        [DataMember]
        public virtual DateTime IssueDate { get; set; }
        [DataMember]
        public virtual DateTime? MaturityDate { get; set; }
        [DataMember]
        public virtual decimal Notional { get; set; }
        [DataMember]
        public virtual string CurrencyId { get; set; }
    }
}
