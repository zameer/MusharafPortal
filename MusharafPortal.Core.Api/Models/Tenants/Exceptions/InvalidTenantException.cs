﻿namespace MusharafPortal.Core.Api.Models.Tenants.Exceptions
{
    public class InvalidTenantException : Exception
    {
        public InvalidTenantException(string parameterName, Guid parameterValue)
            : base(message: $"Invalid tenant, " +
                  $"paremeter name: {parameterName}" +
                  $"parameter value: {parameterValue}") { }
        public InvalidTenantException() : base(message: "Invalid tenant. please fix the error and try again") { }  
    }
}
