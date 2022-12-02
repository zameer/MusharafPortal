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

        public ComponentState State { get; set; }

        private MudTable<TenantView> Table { get; set; }
        private string SearchString { get; set; }

        private string[] SearchColumns;

        private (string sortLabel, string sortColumn)[] SortLabelsAndColumns;

        protected override void OnInitialized()
        {
            this.State = ComponentState.Content;

            this.SearchColumns = new[] { "name", "description" };
            this.SortLabelsAndColumns = new (string sortLabel, string sortColumn)[] {
                (sortLabel: "name_field", sortColumn: nameof(TenantView.Name)),
                (sortLabel: "desc_field", sortColumn: nameof(TenantView.Description)),
                (sortLabel: "dtCreated_field", sortColumn: nameof(TenantView.CreatedDate)),
                (sortLabel: "dtUpdated_field", sortColumn: nameof(TenantView.UpdatedDate))
            };
        }

        private async Task<TableData<TenantView>> ServerReload(TableState state)
        {
            var mudODataQuery = MudODataQuery
                    .Build()
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
    }
}