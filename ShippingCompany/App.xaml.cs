using System;
using System.Windows;
using ShippingCompany.app.view_model;
using ReactiveUI;
using Splat;

namespace ShippingCompany;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        try
        {
            base.OnStartup(e);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
        
        // // Установите локатор в ReactiveUI
        // Locator.CurrentMutable.RegisterConstant(new AppViewLocator(), typeof(IViewLocator));
    }
}
