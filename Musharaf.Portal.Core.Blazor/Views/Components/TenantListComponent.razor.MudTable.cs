using Force.DeepCloner;
using MudBlazor;
using Musharaf.Portal.Core.Blazor.Models.MudTables;
using Musharaf.Portal.Core.Blazor.Models.TenantViews;

namespace Musharaf.Portal.Core.Blazor.Views.Components
{
    public partial class TenantListComponent
    {

        private IEnumerable<TableColumn> options;

        private List<TableColumn> allColumns;
        private TableColumn Value = new TableColumn();

        private IEnumerable<TableColumn> selectedOptions;
        private MudTable<TenantView> Table { get; set; }
        private string SearchString { get; set; }

        private string[] SearchColumns;

        private (string sortLabel, string sortColumn)[] SortLabelsAndColumns;

        protected void InitializeMudTable()
        {
            this.SearchColumns = new[] { "name", "description" };
            this.SortLabelsAndColumns = new (string sortLabel, string sortColumn)[] {
                (sortLabel: "id_field", sortColumn: nameof(TenantView.Id)),
                (sortLabel: "name_field", sortColumn: nameof(TenantView.Name)),
                (sortLabel: "desc_field", sortColumn: nameof(TenantView.Description)),
                (sortLabel: "dtCreated_field", sortColumn: nameof(TenantView.CreatedDate)),
                (sortLabel: "dtUpdated_field", sortColumn: nameof(TenantView.UpdatedDate))
            };

            this.allColumns = new List<TableColumn>
            {
                new TableColumn{ Name = "Id", DisplayName = "Id", SortLabel = "id_field" },
                new TableColumn{ Name = "Name", DisplayName = "Name", SortLabel = "name_field" },
                new TableColumn{ Name = "Description", DisplayName = "Description", SortLabel = "desc_field" },
                new TableColumn{ Name = "CreatedDate", DisplayName = "Created On", SortLabel = "dtCreated_field" },
                new TableColumn{ Name = "UpdatedDate", DisplayName = "Updated On", SortLabel = "dtUpdated_field" }
            };

            this.options = new HashSet<TableColumn>
            {
                this.allColumns[0],
                this.allColumns[1]
            };
            this.selectedOptions = this.options.DeepClone();
        }
    }
}
