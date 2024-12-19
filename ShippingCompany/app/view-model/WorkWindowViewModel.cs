using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows;
using System.Windows.Input;
using DynamicData;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ShippingCompany.commands;
using ShippingCompany.data.crud;
using ShippingCompany.domain.entities;
using ShippingCompany.Domain.Entities;

namespace ShippingCompany.app.view_model;

public class WorkWindowViewModel: BaseViewModel
{
    private readonly UserCrud _userCrud = new UserCrud();
    private readonly TownCrud _townCrud = new TownCrud();
    private User _selectedUser;
    private Town _selectedTown;
    private string _login;
    private string _password;
    private string _confirmPassword;
    private Visibility _usersListControlVisible = Visibility.Collapsed;
    private Visibility _homepageVisible = Visibility.Visible;
    private Visibility _settingsVisible = Visibility.Collapsed;
    private Visibility _townsListControlVisible = Visibility.Collapsed;

    public ObservableCollection<User> Users { get; set; }
    public ObservableCollection<Town> Towns { get; set; }

    public User SelectedUser
    {
        get => _selectedUser;
        set
        {
            _selectedUser = value;
            Login = _selectedUser?.Login;
            OnPropertyChanged();
        }
    }

    public Town SelectedTown
    {
        get => _selectedTown;
        set
        {
            _selectedTown = value;
            OnPropertyChanged();
        }
    }

    public string Login
    {
        get => _login;
        set
        {
            if (_login != value)
            {
                _login = value;
                OnPropertyChanged();
            }
        }
    }

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

    public string ConfirmPassword
    {
        get => _confirmPassword;
        set
        {
            if (_confirmPassword != value)
            {
                _confirmPassword = value;
                OnPropertyChanged();
            }
        }
    }

    public Visibility UsersListControlVisible
    {
        get => _usersListControlVisible;
        set
        {
            Console.WriteLine($"UsersListControlVisible изменено на: {value}");
            _usersListControlVisible = value;
            OnPropertyChanged();
        }
    }

    public Visibility HomepageVisible
    {
        get => _homepageVisible;
        set
        {
            _homepageVisible = value;
            OnPropertyChanged();
        }
    }

    public Visibility SettingsVisible
    {
        get => _settingsVisible;
        set
        {
            _settingsVisible = value;
            OnPropertyChanged();
        }
    }

    public Visibility TownsListControlVisible
    {
        get => _townsListControlVisible;
        set
        {
            Console.WriteLine($"TownsListControlVisible изменено на: {value}");
            _townsListControlVisible = value;
            OnPropertyChanged();
        }
    }

    // Команды
    public ICommand BackButton { get; }
    public ICommand SettingsButton { get; }
    public ICommand UsersButton { get; }
    public ICommand DeleteUserButton { get; }
    public ICommand CreateUserButton { get; }
    public ICommand SaveChangesUserButton { get; }
    public ICommand TownsButton { get; }
    public ICommand BackTownButton { get; }
    public ICommand AddTownButton { get; }
    public ICommand EditTownButton { get; }
    public ICommand DeleteTownButton { get; }
    public ICommand CreateTownButton { get; }
    public ICommand SaveChangesTownButton { get; }
    public WorkWindowViewModel()
    {
        SettingsButton = new RelayCommand(SettingsCommand);   

        // Для UsersListControl
        List<User> userList =  _userCrud.ReadAll();
        this.Users = new ObservableCollection<User>(userList); // Преобразуем List в ObservableCollection

        UsersButton = new RelayCommand(UsersCommand);
        DeleteUserButton = new RelayCommand(DeleteUserCommand);
        CreateUserButton = new RelayCommand(CreateUserCommand);
        SaveChangesUserButton = new RelayCommand(SaveChangesUserCommand);
        
        // Для TownsListControl
        List<Town> townsList = _townCrud.ReadAll();
        this.Towns = new ObservableCollection<Town>(townsList);
        
        TownsButton = new RelayCommand(TownsCommand);
        
        
        DeleteTownButton = new RelayCommand(DeleteTownCommand);
        CreateTownButton = new RelayCommand(CreateTownCommand);
        SaveChangesTownButton = new RelayCommand(SaveChangesTownCommand);
    }

    private void SettingsCommand(object parameter)
    {
        HomepageVisible = Visibility.Collapsed;
        SettingsVisible = Visibility.Visible;
    }

    private void UsersCommand(object parameter)
    {
        HomepageVisible = Visibility.Collapsed;
        SettingsVisible = Visibility.Collapsed;
        TownsListControlVisible = Visibility.Collapsed;
        UsersListControlVisible = Visibility.Visible;
    }
    
    private void DeleteUserCommand(object parameter)
    {
        MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить пользователя?", 
            "Подтверждение", 
            MessageBoxButton.YesNo, 
            MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            // Действие при выборе "Да"
            _userCrud.Delete(SelectedUser);
            MessageBox.Show("Пользователь удалён");
        }
    }
    
    private void CreateUserCommand(object parameter)
    {
        Console.WriteLine($"Login: {Login}");
        if (!string.IsNullOrWhiteSpace(Login) && 
            !string.IsNullOrWhiteSpace(Password) &&
            !string.IsNullOrWhiteSpace(ConfirmPassword))
        {
            if (_userCrud.ReadByLogin(Login) == null)
            {
                if (Password == ConfirmPassword)
                {
                    SelectedUser = new User(Login, Password);
                    _userCrud.Create(SelectedUser);
                    MessageBox.Show("Пользователь успешно создан");
                    Users.Add(SelectedUser);
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают");
                }
            }
            else
            {
                MessageBox.Show("Этот логин уже занят");
            }
        }
        else
        {
            MessageBox.Show("Логин не может быть пустым!");
        }
    }
    
    private void SaveChangesUserCommand(object parameter)
    {
        if (!string.IsNullOrWhiteSpace(Login))
        {
            var existingUser = _userCrud.ReadByLogin(Login);
            if (existingUser != null && existingUser.Id != SelectedUser.Id)
            {
                // Пользователь с таким логином уже существует (и это не тот же самый пользователь)
                MessageBox.Show("Пользователь с таким логином уже существует");
            }
            else
            {
                try
                {
                    SelectedUser.Login = Login;
                    _userCrud.Update(SelectedUser);
                    Users.Replace(SelectedUser, SelectedUser);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                MessageBox.Show("Пользователь успешно обновлён");
            }
        }
        else
        {
            MessageBox.Show("Логин пустой");
        }
    }
    
    private void TownsCommand(object parameter)
    {
        HomepageVisible = Visibility.Collapsed;
        SettingsVisible = Visibility.Collapsed;
        UsersListControlVisible = Visibility.Collapsed;
        TownsListControlVisible = Visibility.Visible;
    }
    
    private void BackTownCommand(object parameter)
    {
        HomepageVisible = Visibility.Collapsed;
        SettingsVisible = Visibility.Collapsed;
        UsersListControlVisible = Visibility.Collapsed;
        TownsListControlVisible = Visibility.Visible;
    }
    
    private void DeleteTownCommand(object parameter)
    {
        MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить город?", 
            "Подтверждение", 
            MessageBoxButton.YesNo, 
            MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            // Действие при выборе "Да"
            _townCrud.Delete(SelectedTown);
            MessageBox.Show("Город удалён");
        }
    }
    
    private void CreateTownCommand(object parameter)
    {
        Console.WriteLine($"SelectedTown.Name {SelectedTown.Name}");
        if (!string.IsNullOrWhiteSpace(SelectedTown.Name))
        {
            if (_townCrud.ReadByName(SelectedTown.Name) == null)
            {
                SelectedTown = new Town(SelectedTown.Name);
                _townCrud.Create(SelectedTown);
                MessageBox.Show("Город успешно добавлен");
                    
                    
            }
            else
            {
                MessageBox.Show("Это название уже используется");
            }
        }
        else
        {
            MessageBox.Show("Название не может быть пустым!");
        }
    }
    
    private void SaveChangesTownCommand(object parameter)
    {
        if (!string.IsNullOrWhiteSpace(SelectedTown.Name))
        {
            var existingTown = _townCrud.ReadByName(SelectedTown.Name);
            if (existingTown != null && existingTown.Id != SelectedTown.Id)
            {
                // Город с таким названием уже существует (и это не тот же самый пользователь)
                MessageBox.Show("Город с таким названием уже существует");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите редактировать город?", 
                    "Подтверждение", 
                    MessageBoxButton.YesNo, 
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Действие при выборе "Да"
                    _townCrud.Update(SelectedTown);
                    MessageBox.Show("Город успешно обновлён");
                }
            }
        }
        else
        {
            MessageBox.Show("Название не может быть пустым");
        }
    }
    
    public string? UrlPathSegment => "work_window";
    public IScreen HostScreen { get; }
    public RoutingState Router { get; } = new RoutingState();
}