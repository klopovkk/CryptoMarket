namespace CryptoMarket.Domain.Factories;

public interface IFactory<out TResult>
{
    TResult Create();
}