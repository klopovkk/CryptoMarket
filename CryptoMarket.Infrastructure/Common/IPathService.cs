namespace CryptoMarket.Infrastructure.Common;

public interface IPathService
{
    string ApplicationFolder { get; }

}

public interface IPathServiceInitializer
{
    void Initialize();
}