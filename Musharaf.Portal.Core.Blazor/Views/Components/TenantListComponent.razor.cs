using Microsoft.AspNetCore.Components;
using MudBlazor;
using Musharaf.Portal.Core.Blazor.Models.ContainerComponents;
using Musharaf.Portal.Core.Blazor.Models.TenantViews;
using Musharaf.Portal.Core.Blazor.Services.Foundations.TenantViews;
using static MudBlazor.CategoryTypes;
using System.Net.Http;

namespace Musharaf.Portal.Core.Blazor.Views.Components
{
    public partial class TenantListComponent 
    {
        [Inject]
        public ITenantViewService TenantViewService { get; set; }

        public ComponentState State { get; set; }
        public TenantView TenantView { get; set; }
        public List<TenantView> TenantViews { get; set; }
        private IEnumerable<TenantView> PagedData { get; set; }
        private MudTable<TenantView> Table { get; set; }
        private int TotalItems { get; set; }
        private string SearchString { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.TenantViews = await this.TenantViewService.RetrieveAllTenantViewsAsync();
            this.State = ComponentState.Content;
        }
        private async Task<TableData<TenantView>> ServerReload(TableState state)
        {
            IEnumerable<TenantView> data = await this.TenantViewService.RetrieveAllTenantViewsAsync();
            data = data.Where(element =>
            {
                if (string.IsNullOrWhiteSpace(this.SearchString))
                    return true;
                if (element.Name.Contains(this.SearchString, StringComparison.OrdinalIgnoreCase))
                    return true;
                if (element.Description.Contains(this.SearchString, StringComparison.OrdinalIgnoreCase))
                    return true;
                return false;
            }).ToArray();
            TotalItems = data.Count();
            switch (state.SortLabel)
            {
                case "mn_field":
                    data = data.OrderByDirection(state.SortDirection, o => o.Name);
                    break;
                case "desc_field":
                    data = data.OrderByDirection(state.SortDirection, o => o.Description);
                    break;
            }

            PagedData = data.Skip(state.Page * state.PageSize).Take(state.PageSize).ToArray();
            return new TableData<TenantView>() { TotalItems = TotalItems, Items = PagedData };
        }

        private void OnSearch(string text)
        {
            SearchString = text;
            this.Table.ReloadServerData();
        }
    }
}
