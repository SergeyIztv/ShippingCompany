using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace ShippingCompany.app.view;

public partial class ClientCompaniesListControl : UserControl
{
    public ClientCompaniesListControl()
    {
        InitializeComponent();
    }
    private void DateOnlyPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        // Проверка на ввод только цифр и символов разделителя (-)
        e.Handled = !Regex.IsMatch(e.Text, @"[\d-]");
    }

    private void NumericOnlyPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        // Разрешаем только цифры
        e.Handled = !IsTextNumeric(e.Text);
    }

    private bool IsTextNumeric(string text)
    {
        return text.All(char.IsDigit);
    }

}