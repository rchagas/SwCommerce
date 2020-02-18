using System;

namespace SwCommerce.Services.Exceptions
{
    public class OfferErrorException : ApplicationException
    {
        public OfferErrorException(string message) : base(message)
        {
            
        }
    }
}