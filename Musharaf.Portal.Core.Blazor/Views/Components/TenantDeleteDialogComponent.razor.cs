using Microsoft.AspNetCore.Components;
using MudBlazor;
using Musharaf.Portal.Core.Blazor.Models.TenantViews.Exceptions;
using Musharaf.Portal.Core.Blazor.Services.Foundations.TenantViews;

namespace Musharaf.Portal.Core.Blazor.Views.Components
{
    public partial class TenantDeleteDialogComponent
    {
        [Inject]
        public ITenantViewService TenantViewService { get; set; }
        [Parameter]
        public EventCallback<string> TenantDeleted { get; set; }
        [Parameter]
        public Guid DeleteId { get; set; }

        private DialogOptions dialogOptions = new() { FullWidth = true };
        private bool visible { get; set; }

        void Cancel() => this.visible = false;

        public void OpenDeleteDialog(Guid Id)
        {
            this.DeleteId = Id;
            this.visible = true;
        }

        public async Task Delete(Guid Id)
        {
            try
            {
                await this.TenantViewService.RemoveTenantByIdAsync(Id);
                this.visible = false;
                await this.TenantDeleted.InvokeAsync("Tenant Deleted Successfully.");
            }
            catch (TenantViewValidationException tenantViewValidationException)
            {
                var validationMessage = tenantViewValidationException.InnerException.Message;
                snackBar.Add($"Tenant Delete Failed. {validationMessage}", Severity.Error);
            }
        }
    }
}
