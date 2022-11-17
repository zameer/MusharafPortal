using MusharafPortal.Core.Api.Models.Tenants;
using MusharafPortal.Core.Api.Models.Tenants.Exceptions;
using System.Data;
using System.Security.Cryptography.Xml;

namespace MusharafPortal.Core.Api.Services.Foundatons.Tenants
{
    public partial class TenantService
    {
        private void ValidateTenantOnCreate(Tenant tenant)
        {
            ValidateTenant(tenant);

            Validate(
                (Rule: IsValidX(tenant.Id), Parameter: nameof(tenant.Id)),
                (Rule: IsValidX(tenant.Name), Parameter: nameof(tenant.Name)),
                (Rule: IsValidX(tenant.CreatedDate), Parameter: nameof(tenant.CreatedDate)),
                (Rule: IsValidX(tenant.CreatedBy), Parameter: nameof(tenant.CreatedBy)),
                (Rule: IsValidX(tenant.UpdatedDate), Parameter: nameof(tenant.UpdatedDate)),
                (Rule: IsValidX(tenant.UpdatedBy), Parameter: nameof(tenant.UpdatedBy)),
                (Rule: IsNotSame(
                    firstId: tenant.CreatedBy,
                    secondId: tenant.UpdatedBy,
                    secondIdName: nameof(tenant.UpdatedBy)),
                  Parameter: nameof(tenant.CreatedBy)),
                (Rule: IsNotSame(
                    firstDate: tenant.CreatedDate,
                    secondDate: tenant.UpdatedDate,
                    secondDateName: nameof(tenant.UpdatedDate)),
                  Parameter: nameof(tenant.UpdatedDate))
            );
        }

        private static dynamic IsValidX(Guid Id) => new
        {
            Condition = Id == Guid.Empty,
            Message = "Id is required"
        };

        private static dynamic IsValidX(string text) => new
        {
            Condition = String.IsNullOrEmpty(text),
            Message = "text is required"
        };

        private static dynamic IsValidX(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Date is required"
        };

        private static dynamic IsNotSame(
            Guid firstId,
            Guid secondId,
            string secondIdName) => new
            {
                Condition = firstId != secondId,
                Message = $"Id is not the same as {secondIdName}"
            };
        private static dynamic IsNotSame(
            DateTimeOffset firstDate,
            DateTimeOffset secondDate,
            string secondDateName) => new
            {
                Condition = firstDate != secondDate,
                Message = $"Date is not the same as {secondDateName}"
            };

        private static void ValidateTenant(Tenant tenant)
        {
            if (tenant is null)
            {
                throw new NullTenantException();
            }
        }

        private void ValidateTenantId(Guid inputId)
        {
            if (inputId == Guid.Empty)
            {
                throw new InvalidTenantException(
                    parameterName: nameof(inputId),
                    parameterValue: inputId);
            }
        }

        private void ValidateStorageTenant(Tenant tenant, Guid tenantId)
        {
            if (tenant is null)
            {
                throw new NotFoundTenantException(tenantId);
            }
        }

        private void ValidateTenantOnModify(Tenant tenant)
        {
            ValidateTenant(tenant);

            Validate(
                (Rule: IsValidX(tenant.Id), Parameter: nameof(tenant.Id)),
                (Rule: IsValidX(tenant.Name), Parameter: nameof(tenant.Name)),
                (Rule: IsValidX(tenant.CreatedDate), Parameter: nameof(tenant.CreatedDate)),
                (Rule: IsValidX(tenant.CreatedBy), Parameter: nameof(tenant.CreatedBy)),
                (Rule: IsValidX(tenant.UpdatedDate), Parameter: nameof(tenant.UpdatedDate)),
                (Rule: IsValidX(tenant.UpdatedBy), Parameter: nameof(tenant.UpdatedBy)),
                (Rule: IsSame(
                    firstDate: tenant.CreatedDate,
                    secondDate: tenant.UpdatedDate,
                    secondDateName: nameof(tenant.UpdatedDate)),
                  Parameter: nameof(tenant.UpdatedDate))
            );
        }

        private static dynamic IsSame(
           DateTimeOffset firstDate,
           DateTimeOffset secondDate,
           string secondDateName) => new
           {
               Condition = firstDate == secondDate,
               Message = $"Date is the same as {secondDateName}"
           };

        private void ValidateAgainstStorageTenantOnModify(Tenant inputTenant, Tenant storageTenant)
        {
            Validate(
                (Rule: IsNotSame(
                    firstDate: inputTenant.CreatedDate,
                    secondDate: storageTenant.CreatedDate,
                    secondDateName: nameof(storageTenant.CreatedDate)),
                  Parameter: nameof(storageTenant.CreatedDate)),
                (Rule: IsSame(
                    firstDate: inputTenant.UpdatedDate,
                    secondDate: storageTenant.UpdatedDate,
                    secondDateName: nameof(storageTenant.UpdatedDate)),
                  Parameter: nameof(storageTenant.UpdatedDate)),
                (Rule: IsNotSame(
                    firstId: inputTenant.CreatedBy,
                    secondId: storageTenant.CreatedBy,
                    secondIdName: nameof(storageTenant.CreatedBy)),
                  Parameter: nameof(storageTenant.CreatedBy))
            );
        }

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidTenantException = new InvalidTenantException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidTenantException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidTenantException.ThrowIfContainsErrors();
        }
    }
}