using Musharaf.Portal.Core.Blazor.Models.Tenants;
using Musharaf.Portal.Core.Blazor.Models.Tenants.Exceptions;

namespace Musharaf.Portal.Core.Blazor.Services.Foundations.Tenants
{
    public partial class TenantService
    {
        private void ValidateTenantOnCreate(Tenant tenant)
        {
            ValidateTenant(tenant);

            Validate(
                (Rule: IsValidX(tenant.Id), Parameter: nameof(tenant.Id)),
                (Rule: IsValidX(tenant.Name), Parameter: nameof(tenant.Name)),
                (Rule: IsValidX(tenant.CreatedBy), Parameter: nameof(tenant.CreatedBy)),
                (Rule: IsValidX(tenant.UpdatedBy), Parameter: nameof(tenant.UpdatedBy)),
                (Rule: IsValidX(tenant.CreatedDate), Parameter: nameof(tenant.CreatedDate)),
                (Rule: IsValidX(tenant.UpdatedDate), Parameter: nameof(tenant.UpdatedDate))
            );
        }

        private void ValidateTenant(Tenant tenant)
        {
            if (tenant is null)
            {
                throw new NullTenantException();
            }
        }

        private static dynamic IsValidX(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "Id is required"
        };

        private static dynamic IsValidX(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static dynamic IsValidX(DateTimeOffset datetime) => new
        {
            Condition = datetime == default,
            Message = "Date is required"
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
