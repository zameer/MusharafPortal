using Musharaf.Portal.Core.Blazor.Models.Tenants;
using Musharaf.Portal.Core.Blazor.Models.Tenants.Exceptions;
using System.Data;

namespace Musharaf.Portal.Core.Blazor.Services.Foundations.Tenants
{
    public partial class TenantService
    {
        private void ValidateTenantOnCreate(Tenant tenant)
        {
            ValidateTenant(tenant);

            Validate(
                (Rule: IsValidX(tenant.Id), Parameter: nameof(tenant.Id))
            );
        }

        private void ValidateTenant(Tenant tenant)
        {
            if (tenant is null)
            {
                throw new NullTenantException();
            }
        }

        private static dynamic IsValidX(Guid id) => new {
            Condition = id == Guid.Empty,
            Message = "Id is required"
        };

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
