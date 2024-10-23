using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Infrastructure.Settings
{
    [DataContract]
    internal class MainWindowMemento
    {
        public MainWindowMemento()
        {
            Left = 100;
            Top = 100;
            Width = 640;
            Height = 400;
            IsMaximized = true;
        }
        [DataMember(Name = "left")]
        public double Left { get; set; }
        [DataMember(Name = "width")]

        public double Width { get; set; }
        [DataMember(Name = "top")]

        public double Top { get; set; }
        [DataMember(Name = "height")]

        public double Height { get; set; }
        [DataMember(Name = "isMaximized")]

        public bool IsMaximized { get; set; }
    }
}
