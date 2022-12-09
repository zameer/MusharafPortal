using Microsoft.AspNetCore.Components;
using MudBlazor;
using Musharaf.Portal.Core.Blazor.Models.ContainerComponents;
using Musharaf.Portal.Core.Blazor.Models.TenantViews;
using Musharaf.Portal.Core.Blazor.Models.TenantViews.Exceptions;
using Musharaf.Portal.Core.Blazor.Services.Foundations.TenantViews;
using Musharaf.Portal.Core.Blazor.Views.Bases;

namespace Musharaf.Portal.Core.Blazor.Views.Components
{
    public partial class TenantFormComponent : ComponentBase
    {
        [Inject]
        public ITenantViewService TenantViewService { get; set; }

        [Parameter]
        public EventCallback<string> TenantCreated { get; set; }

        public ComponentState State { get; set; }
        public TenantView TenantView { get; set; }
        public DropDownBase<TenantTypeView> TenantTypeDropDown { get; set; }
        public LabelBase ErrorLabel { get; set; }

        private string FormTitle { get; set; }
        private bool visible { get; set; }
        private bool isEditing { get; set; }


        public delegate void SaveTenant(string message);

        protected override void OnInitialized()
        {
            this.TenantView = new TenantView();
            this.State = ComponentState.Content;
        }

        public void OpenFormDialog(
            bool isEditing,
            string title,
            TenantView tenantView = null)
        {
            this.FormTitle = title;
            this.TenantView = tenantView ?? new TenantView();
            this.visible = true;
            this.isEditing = isEditing;
        }

        void Cancel() => this.visible = false;

        public async void CreateTenantAsync()
        {
            try
            {
                await this.TenantViewService.AddTenantViewAsync(this.TenantView);
                this.visible = false;
                await this.TenantCreated.InvokeAsync("New Tenant Created Successfully.");
            }
            catch (TenantViewValidationException tenantViewValidationException)
            {
                var validationMessage = tenantViewValidationException.InnerException.Message;
                this.ErrorLabel.SetValue(validationMessage);
            }
        }

        public async void UpdateTenantAsync()
        {
            try
            {
                await this.TenantViewService.EditTenantViewAsync(this.TenantView);
                this.visible = false;
                await this.TenantCreated.InvokeAsync("Tenant Updated Successfully.");
            }
            catch (TenantViewValidationException tenantViewValidationException)
            {
                var validationMessage = tenantViewValidationException.InnerException.Message;
                this.ErrorLabel.SetValue(validationMessage);
            }
        }
    }
}