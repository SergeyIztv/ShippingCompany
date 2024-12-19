using System.Collections.Generic;

namespace ShippingCompany.data.crud;

public interface IBaseCrud<T>
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    List<T> ReadAll();
    T ReadById(long id);
}