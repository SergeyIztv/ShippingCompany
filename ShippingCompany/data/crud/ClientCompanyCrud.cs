using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Windows;
using ShippingCompany.domain.entities;

namespace ShippingCompany.data.crud;

public class ClientCompanyCrud: BaseCrud<ClientCompany>
{
    public ClientCompanyCrud()
    {
                
    }
    /// <summary>
    /// Найти компанию по уникальному названию.
    /// </summary>
    /// <param name="companyName">Название компании для поиска.</param>
    /// <returns>Экземпляр компании или null, если не найдено.</returns>
    public ClientCompany? ReadByCompanyName(string companyName)
    {
        try
        {
            // Приводим название компании и искомое название к нижнему регистру для корректного сравнения
            return _context.ClientCompany
                .FirstOrDefault(company => company.Name.ToLower() == companyName.ToLower());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при поиске компании по названию: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            throw;
        }
    }


}