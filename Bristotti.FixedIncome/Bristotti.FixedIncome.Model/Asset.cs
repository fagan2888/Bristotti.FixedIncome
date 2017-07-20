using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bristotti.FixedIncome.Model
{
    public class Asset
    {
        public virtual Guid Id { get; set; }
        public virtual string Ticker { get; set; }
        public virtual DateTime IssueDate { get; set; }
        public virtual DateTime? MaturityDate { get; set; }
        public virtual decimal Notional { get; set; }
    }
}
