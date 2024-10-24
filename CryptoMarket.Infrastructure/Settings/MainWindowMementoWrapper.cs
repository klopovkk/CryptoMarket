using CryptoMarket.Infrastructure.Common;

namespace CryptoMarket.Infrastructure.Settings;

internal class MainWindowMementoWrapper : WindowMementoWrapper<MainWindowMemento>
{
    public MainWindowMementoWrapper(IPathService pathService)
        : base(pathService)
    {
    }

    protected override string MementoName => "MainWindowMemento";
}