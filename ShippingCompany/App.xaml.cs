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
        
        // Добавляем обработчик необработанных исключений
        AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
        {
            var exception = args.ExceptionObject as Exception;
            MessageBox.Show($"Unhandled Exception: {exception?.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        };

        // (Опционально) Добавляем обработчик исключений на уровне Dispatcher
        DispatcherUnhandledException += (sender, args) =>
        {
            MessageBox.Show($"Unhandled UI Exception: {args.Exception.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            args.Handled = true; // Указывает, что исключение обработано
        };
    }
}
