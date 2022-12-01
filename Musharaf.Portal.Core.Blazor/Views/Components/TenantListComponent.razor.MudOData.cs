using MudBlazor;

namespace Musharaf.Portal.Core.Blazor.Views.Components
{
    public static class MudODataQuery
    {
        public static MudODataQueryBuilder Build()
        {
            return new MudODataQueryBuilder();
        }
    }

    public class MudODataQueryBuilder
    {
        private List<string> ODataQueryList = new List<string>();
        public MudODataQueryBuilder Search(string[] searchColumns, string text)
        {
            if (text is null)
                return this;

            var searchQuery = string.Empty;
            foreach (var searchColumn in searchColumns)
            {
                searchQuery = string.IsNullOrEmpty(searchQuery)
                    ? $"$filter={searchQuery}"
                    : $"{searchQuery} Or ";

                searchQuery =
                    $"{searchQuery}contains(ToLower({searchColumn}), " +
                    $"'{text.ToLower()}') eq true";
            }
            ODataQueryList.Add(searchQuery);

            return this;
        }

        public MudODataQueryBuilder SkipTake(int page, int pageSize)
        {
            ODataQueryList.Add($"$top={pageSize}&$skip={page * pageSize}");
            return this;
        }

        public MudODataQueryBuilder OrderBy(
            TableState tableState,
            params (string sortLabel, string sortColumn)[] sortLabelsAndColumns)
        {
            foreach ((string sortLabel, string sortColumn) in sortLabelsAndColumns)
            {
                if (tableState.SortLabel == sortLabel)
                {
                    ODataQueryList.Add(tableState.SortDirection == SortDirection.Ascending 
                        ? $"$orderBy={sortColumn}"
                        : $"$orderBy={sortColumn} desc");
                }
            }

            return this;
        }

        public string AsODataQuery() =>
            $"?{String.Join('&', ODataQueryList.ToArray())}";

    }
}
