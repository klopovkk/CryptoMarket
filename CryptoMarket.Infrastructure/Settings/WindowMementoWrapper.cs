using CryptoMarket.Domain.Settings;
using CryptoMarket.Infrastructure.Common;
using Newtonsoft.Json;

namespace CryptoMarket.Infrastructure.Settings;

internal abstract class WindowMementoWrapper<TMemento> : IMainWindowMementoWrapper, IWindowMementoWrapperInitializer,
    IDisposable
    where TMemento : WindowMemento, new()
{
    private readonly IPathService _pathService;
    private bool _initialized;
    private string _settingsFilePath;
    private TMemento _windowMemento;
    protected WindowMementoWrapper(IPathService pathService)
    {
        _pathService = pathService;
        _windowMemento = new TMemento();
    }
    protected abstract string MementoName { get; }
    public double Left
    {
        get
        {
            EnsureInitialized();
            return _windowMemento.Left;
        }
        set
        {
            EnsureInitialized();
            _windowMemento.Left = value;
        }
    }
    public double Top
    {
        get
        {
            EnsureInitialized();
            return _windowMemento.Top;
        }
        set
        {
            EnsureInitialized();
            _windowMemento.Top = value;
        }
    }
    public double Width
    {
        get
        {
            EnsureInitialized();
            return _windowMemento.Width;
        }
        set
        {
            EnsureInitialized();
            _windowMemento.Width = value;
        }
    }
    public double Height
    {
        get
        {
            EnsureInitialized();
            return _windowMemento.Height;
        }
        set
        {
            EnsureInitialized();
            _windowMemento.Height = value;
        }
    }
    public bool IsMaximized
    {
        get
        {
            EnsureInitialized();
            return _windowMemento.IsMaximized;
        }
        set
        {
            EnsureInitialized();
            _windowMemento.IsMaximized = value;
        }
    }

    public async Task InitializeAsync()
    {
        if (_initialized)
            throw new InvalidOperationException($"Wrapper for {typeof(TMemento)} is already initialized");

        _initialized = true;

        const string settingsFolderName = "Settings";

        var settingsPath = Path.Combine(_pathService.ApplicationFolder, settingsFolderName);
        _settingsFilePath = Path.Combine(settingsPath, $"{MementoName}.json");

        Directory.CreateDirectory(settingsPath);

        if (!File.Exists(_settingsFilePath))
            return;

        var serializedMemento = await File.ReadAllTextAsync(_settingsFilePath);

        _windowMemento = JsonConvert.DeserializeObject<TMemento>(serializedMemento);
}

private void EnsureInitialized()
{
    if (!_initialized)
        throw new InvalidOperationException($"Wrapper for{typeof(TMemento)} is not initialized");
}

public async void Dispose()
{
    EnsureInitialized();

    var serializedMemento = JsonConvert.SerializeObject(_windowMemento);
    await File.WriteAllTextAsync(_settingsFilePath, serializedMemento);
}
}