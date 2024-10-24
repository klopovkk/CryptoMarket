using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMarket.Infrastructure.Settings
{
    [DataContract]
    internal class MainWindowMemento : WindowMemento
    {
        public MainWindowMemento()
        {
            Left = 100;
            Top = 100;
            Width = 640;
            Height = 400;
            IsMaximized = false;
        }
    }
}