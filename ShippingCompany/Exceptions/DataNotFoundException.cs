using System;

namespace ShippingCompany.Exceptions;

public class DataNotFoundException: Exception
{
    public DataNotFoundException(string message) : base(message){}
}