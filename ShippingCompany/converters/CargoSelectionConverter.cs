using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using ShippingCompany.app.view_model;
using ShippingCompany.domain.entities;

namespace ShippingCompany.converters;

public class CargoSelectionConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is List<TypeOfCargo> selectedTypesOfCargo && parameter is TypeOfCargo cargo)
        {
            return selectedTypesOfCargo.Contains(cargo);
        }
        return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool isChecked && parameter is TypeOfCargo cargo && Application.Current.MainWindow.DataContext is WorkWindowViewModel viewModel)
        {
            if (isChecked)
            {
                if (!viewModel.SelectedTypesOfCargoForShip.Contains(cargo))
                {
                    viewModel.SelectedTypesOfCargoForShip.Add(cargo);
                }
            }
            else
            {
                viewModel.SelectedTypesOfCargoForShip.Remove(cargo);
            }
        }
        return null;
    }
}
