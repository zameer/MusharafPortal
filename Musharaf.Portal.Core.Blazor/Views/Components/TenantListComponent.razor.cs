using Force.DeepCloner;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Musharaf.Portal.Core.Blazor.Models.ContainerComponents;
using Musharaf.Portal.Core.Blazor.Models.TenantViews;
using Musharaf.Portal.Core.Blazor.Services.Foundations.TenantViews;

namespace Musharaf.Portal.Core.Blazor.Views.Components
{
    public partial class TenantListComponent
    {
        [Inject]
        public ITenantViewService TenantViewService { get; set; }

        public TenantFormComponent TenantFormComponent { get; set; }
        public TenantDeleteDialogComponent TenantDeleteDialogComponent { get; set; }

        public ComponentState State { get; set; }

        protected override void OnInitialized()
        {
            this.State = ComponentState.Content;

            InitializeMudTable();
        }

        private async Task<TableData<TenantView>> ServerReload(TableState state)
        {
            var mudODataQuery = MudODataQuery
                    .Build()
                    .Select(options.Select(e => e.Name).ToArray())
                    .Search(SearchColumns, this.SearchString)
                    .SkipTake(state.Page, state.PageSize)
                    .OrderBy(state, this.SortLabelsAndColumns)
                    .AsODataQuery();

            IEnumerable<TenantView> pagedData = await this.TenantViewService
                .RetrieveAllTenantViewsAsync(mudODataQuery);

            var totalItems = await this.TenantViewService.RetrieveAllTenantViewsCountAsync();

            return new TableData<TenantView>() { TotalItems = totalItems, Items = pagedData };
        }

        private void OnSearch(string text)
        {
            SearchString = text;
            this.Table.ReloadServerData();
        }

        private void Refresh()
        {
            this.selectedOptions = this.options.DeepClone();
            this.Table.ReloadServerData();
        }

        private void OpenDeleteDialog(Guid Id) =>
            this.TenantDeleteDialogComponent.OpenDeleteDialog(Id);

        private void OpenCreateForm() =>
            this.TenantFormComponent.OpenFormDialog(isEditing: false, "Create Tenant");

        private async Task OpenEditForm(Guid id)
        {
            var tenantView = await this.TenantViewService.RetrieveTenantByIdAsync(id);
            this.TenantFormComponent.OpenFormDialog(isEditing: true, 
                "Edit Tenant", 
                tenantView: tenantView);
        }

        private void TenantCreatedHandler(string message)
        {
            snackBar.Add(message, Severity.Success);
            this.Table.ReloadServerData();
        }

        private void TenantDeletedHandler(string message)
        {
            snackBar.Add(message, Severity.Success);
            this.Table.ReloadServerData();
        }
    }
}