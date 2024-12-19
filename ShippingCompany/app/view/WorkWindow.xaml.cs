using System.Windows;
using ReactiveUI;
using ShippingCompany.app.view_model;

namespace ShippingCompany.app.view;

public partial class WorkWindow : Window
{
    public WorkWindow()
    {
        InitializeComponent();
        DataContext = new WorkWindowViewModel();
    }
}