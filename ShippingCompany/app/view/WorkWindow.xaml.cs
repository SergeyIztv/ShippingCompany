using System;
using System.Windows;
using ReactiveUI;
using ShippingCompany.app.view_model;
using ShippingCompany.domain.entities;
using ShippingCompany.Domain.Entities;

namespace ShippingCompany.app.view;

public partial class WorkWindow : Window
{
    public WorkWindow(User currentUser)
    {
        InitializeComponent();
        DataContext = new WorkWindowViewModel(currentUser);
    }
}