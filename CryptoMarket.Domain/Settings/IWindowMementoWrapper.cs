namespace CryptoMarket.Domain.Settings;

public interface IWindowMementoWrapper
{
    public double Left { get; set; }
    public double Width { get; set; }
    public double Top { get; set; }
    public double Height { get; set; }
    public bool IsMaximized { get; set; }
}