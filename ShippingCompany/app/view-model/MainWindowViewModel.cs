using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Windows;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ShippingCompany.app.view;
using ShippingCompany.commands;
using ShippingCompany.data.crud;
using ShippingCompany.domain.entities;
using ShippingCompany.Domain.Entities;

namespace ShippingCompany.app.view_model;

public class MainWindowViewModel: BaseViewModel
{
    private readonly UserCrud _userCrud = new UserCrud();
    private string _username;
    public string Username { get => _username;
        set
        {
            if (_username != value)
            {
                _username = value;
                OnPropertyChanged();
            }
        } 
    }
    private string _password;
    public string Password
    {
        get => _password;
        set
        {
            if (_password != value)
            {
                _password = value;
                OnPropertyChanged();
            }
        }
    }
    public ICommand AuthorizeButton { get; set; }
    public ReactiveCommand<Unit, Unit> CancelButton { get; set; }
    
    
    public MainWindowViewModel()
    {
        AuthorizeButton = new RelayCommand(Authorize);
        CancelButton = ReactiveCommand.Create(() =>
        {
            Username = string.Empty;
            Password = string.Empty;
        });

    }
    
    private void Authorize(object parameter)
    {
        try
        {
            User user = _userCrud.ReadByLogin(Username);
            if (user != null)
            {
                CurrentUser.Instance.User = user;
                var currentUser = CurrentUser.Instance.User;

                var hashedPassword = User.HashPassword(Password, user.Salt);
                if (hashedPassword == currentUser.PasswordHash)
                {
                    try
                    {
                        WorkWindow workWindow = new WorkWindow();
                        workWindow.Show();
                        Application.Current.MainWindow.Close();
                        workWindow.Closed += (s, args) => Application.Current.MainWindow.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
                else
                {
                    MessageBox.Show("Неправильный пароль");
                }
            }
            else
            {
                MessageBox.Show("Неправильный логин");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при авторизации: {ex.Message}");
        }
    }
    private void OpenWorkWindow(object obj)
    {
        // Открываем новое окно
        var workWindow = new WorkWindow();
        workWindow.Show();

        // Закрываем текущее окно (MainControl)
        if (obj is Window window)
        {
            window.Close();
        }
    }

    private void CloseApplication(object obj)
    {
        Application.Current.Shutdown();
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
}