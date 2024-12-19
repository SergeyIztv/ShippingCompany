using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using ShippingCompany.data.crud;
using ShippingCompany.Domain.Entities;

namespace ShippingCompany.app.view_model;

public class PasswordChanger : INotifyPropertyChanged
{
    private readonly UserCrud _userCrud = new UserCrud();
    private User _user;
    private string _oldPassword;
    private string _newPassword;
    private string _confirmPassword;
    private string _oldPasswordHash;
    private string _confirmPasswordHash;

    public string OldPassword
    {
        get => _oldPassword;
        set
        {
            _oldPassword = value;
            _oldPasswordHash = User.HashPassword(_oldPassword, _user.Salt);
            OnPropertyChanged();
        }
    }

    public string NewPassword
    {
        get => _newPassword;
        set
        {
            _newPassword = value;
            OnPropertyChanged();
        }
    }

    public string ConfirmPassword
    {
        get => _confirmPassword;
        set
        {
            _confirmPassword = value;
            _confirmPasswordHash = User.HashPassword(_confirmPassword, _user.Salt);
            OnPropertyChanged();
        }
    }

    public string OldPasswordHash { get => _oldPasswordHash; }
    public string ConfirmPasswordHash { get => _confirmPasswordHash; }
    
    // Пустой конструктор
    public PasswordChanger(){}
    public PasswordChanger(User user)
    {
        this._user = user;
    }

    

    public void ChangePasswordCommand(object parameter)
    {
        Console.WriteLine($"OldPasswordHash: {OldPasswordHash}, user.PasswordHash: {_user.PasswordHash}");
        if (OldPasswordHash == _user.PasswordHash)
        {
            if (OldPassword != NewPassword)
            {
                if (NewPassword == ConfirmPassword)
                {
                    _user.PasswordHash = ConfirmPasswordHash;
                    _userCrud.Update(_user);
                    MessageBox.Show("Пароль обновлён!");
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают");
                }
            }
            else
            {
                MessageBox.Show("Новый пароль должен отличаться от предыдущего!");
            }
        }
        else
        {
            MessageBox.Show("Неправильный пароль");
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}