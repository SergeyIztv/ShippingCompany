using System;

namespace ShippingCompany.Exceptions;

public class EntityNotFoundException: Exception
{
    public EntityNotFoundException(long id)
        : base($"Entity with id {id} not found") {}
}