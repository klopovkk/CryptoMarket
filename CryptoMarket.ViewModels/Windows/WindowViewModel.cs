﻿using CryptoMarket.Domain.Settings;

namespace CryptoMarket.ViewModels.Windows;

public abstract class WindowViewModel<TWindowMementoWrapper> : ViewModel , IWindowViewModel
where TWindowMementoWrapper : class, IWindowMementoWrapper
{
    private readonly IWindowMementoWrapper _windowMementoWrapper;

    protected WindowViewModel(TWindowMementoWrapper windowMementoWrapper)
    {
        _windowMementoWrapper = windowMementoWrapper;
    }

    public double Left
    {
        get => _windowMementoWrapper.Left;
        set => _windowMementoWrapper.Left = value;
    }

    public double Width
    {
        get => _windowMementoWrapper.Width;
        set => _windowMementoWrapper.Width = value;
    }

    public double Top
    {
        get => _windowMementoWrapper.Top;
        set => _windowMementoWrapper.Top = value;
    }

    public double Height
    {
        get => _windowMementoWrapper.Height;
        set => _windowMementoWrapper.Height = value;
    }

    public bool IsMaximized
    {
        get => _windowMementoWrapper.IsMaximized;
        set => _windowMementoWrapper.IsMaximized = value;
    }
}