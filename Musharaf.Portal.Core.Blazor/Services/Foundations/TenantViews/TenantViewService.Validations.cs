using Musharaf.Portal.Core.Blazor.Models.TenantViews;
using Musharaf.Portal.Core.Blazor.Models.TenantViews.Exceptions;

namespace Musharaf.Portal.Core.Blazor.Services.Foundations.TenantViews
{
    public partial class TenantViewService
    {
        private void ValidateTenantView(TenantView tenantView)
        {
            Validate(
                (Rule: IsValidX(tenantView.Name), Parameter: nameof(tenantView.Name))
            );
        }

        private static dynamic IsValidX(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidTenantException = new InvalidTenantViewException();

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
