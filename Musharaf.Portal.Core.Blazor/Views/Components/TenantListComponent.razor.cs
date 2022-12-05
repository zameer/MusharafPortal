using Microsoft.AspNetCore.Components;
using MudBlazor;
using Musharaf.Portal.Core.Blazor.Models.ContainerComponents;
using Musharaf.Portal.Core.Blazor.Models.MudTables;
using Musharaf.Portal.Core.Blazor.Models.TenantViews;
using Musharaf.Portal.Core.Blazor.Services.Foundations.TenantViews;
using System.Data.Common;

namespace Musharaf.Portal.Core.Blazor.Views.Components
{
    public partial class TenantListComponent
    {
        [Inject]
        public ITenantViewService TenantViewService { get; set; }

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
        private void Edit(string id)
        {
        }

        private void Delete(string id)
        {
            snackBar.Add("Customer Deleted.", Severity.Success);
        }
        private void Refresh()
        {
            this.Table.ReloadServerData();
        }
    }
}