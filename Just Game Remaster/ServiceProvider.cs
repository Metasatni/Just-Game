﻿namespace Just_Game_Remaster;

internal static class ServiceProvider {

    private static IServiceProvider _serviceProvider;

    public static void Initialize(IServiceProvider serviceProvider) {
        _serviceProvider = serviceProvider;
    }

    public static T GetService<T>() {
        return (T)_serviceProvider.GetService(typeof(T))!;
    }
}
