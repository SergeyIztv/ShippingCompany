using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ShippingCompany.app.view_model;

namespace ShippingCompany.app.view;

public partial class MainWindow : Window
{
    private readonly Timer _timer;
    public MainWindow()
    {
        _timer = new Timer(100); 
        _timer.Elapsed += OnTimedEvent;
        _timer.Start();
        InitializeComponent();

        DataContext = new MainWindowViewModel();

            


        UpdateCapsLockStatus();
        UpdateInputLanguage();
    }

    private void OnTimedEvent(object sender, ElapsedEventArgs e)
    {

        Dispatcher.Invoke(() =>
        {
            UpdateCapsLockStatus();
            UpdateInputLanguage();
        });
    }

    private void UpdateCapsLockStatus()
    {

        if (Keyboard.IsKeyToggled(Key.CapsLock))
        {
            CapsLockLabel.Content = "CapsLock нажата";
        }
        else
        {
            CapsLockLabel.Content = "";
        }
    }

    private void UpdateInputLanguage()
    {
        // Получение текущей раскладки и преобразование в читабельный формат
        var culture = InputLanguageManager.Current.CurrentInputLanguage;

        // Определение языка ввода
        string language;
        switch (culture.TwoLetterISOLanguageName)
        {
            case "ru":
                language = "Язык ввода: Русский";
                break;
            case "en":
                language = "Язык ввода: Английский";
                break;
            default:
                language = "Язык ввода: Другой";
                break;
        }

        // Обновление метки языка ввода
        InputLanguageLabel.Content = language;
    }

    private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        if (DataContext is MainWindowViewModel viewModel && sender is PasswordBox passwordBox)
        {
            viewModel.Password = passwordBox.Password; 
        }    }
}