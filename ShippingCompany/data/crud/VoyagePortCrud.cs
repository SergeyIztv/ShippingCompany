using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using ShippingCompany.domain.entities;

namespace ShippingCompany.data.crud;

public class VoyagePortCrud : BaseCrud<VoyagePort>
{
    /// <summary>
    /// Получить все порты, связанные с указанным рейсом.
    /// </summary>
    /// <param name="voyageId">Id рейса.</param>
    /// <returns>ObservableCollection связанных портов.</returns>
    public ObservableCollection<Port> ReadPortsByVoyageId(long voyageId)
    {
        try
        {
            var ports = _context.VoyagePorts
                .Where(vp => vp.VoyageId == voyageId) // Фильтруем по Id рейса
                .Select(vp => vp.Port) // Получаем связанные порты
                .ToList(); // Преобразуем в List

            // Преобразуем List в ObservableCollection
            return new ObservableCollection<Port>(ports);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при чтении портов для рейса {voyageId}: {ex.Message}");
            throw;
        }
    }
    /// <summary>
    /// Удалить все записи VoyagePort, связанные с указанным рейсом.
    /// </summary>
    /// <param name="voyageId">Id рейса.</param>
    public void DeleteByVoyageId(long voyageId)
    {
        try
        {
            // Находим все записи, связанные с данным рейсом
            var voyagePorts = _context.VoyagePorts
                .Where(vp => vp.VoyageId == voyageId)
                .ToList(); // Загружаем записи в память

            if (!voyagePorts.Any())
            {
                return;
            }

            // Удаляем найденные записи
            _context.VoyagePorts.RemoveRange(voyagePorts);
            _context.SaveChanges();

            MessageBox.Show($"Все записи VoyagePort для рейса {voyageId} успешно удалены.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при удалении записей VoyagePort для рейса {voyageId}: {ex.Message}");
            throw;
        }
    }

}