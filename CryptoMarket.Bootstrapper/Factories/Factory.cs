﻿using Autofac;
using CryptoMarket.Domain.Factories;

namespace CryptoMarket.Bootstrapper.Factories;

internal class Factory<TResult> :IFactory<TResult>
{
    private readonly IComponentContext _componentContext;

    public Factory(IComponentContext componentContext)
    {
        _componentContext = componentContext;
    }
    public TResult Create()
    {
        var factory = _componentContext.Resolve<Func<TResult>>();

        return factory.Invoke();
    }
}