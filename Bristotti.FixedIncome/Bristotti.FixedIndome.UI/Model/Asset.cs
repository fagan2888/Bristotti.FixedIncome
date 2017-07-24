using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Bristotti.FixedIndome.UI.Annotations;

namespace Bristotti.FixedIndome.UI.Model
{
    [DataContract(Namespace = "Bristotti.FixedIncome.Model")]
    public class Asset : IExtensibleDataObject, INotifyPropertyChanged
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

        public ExtensionDataObject ExtensionData { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
