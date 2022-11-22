using Microsoft.AspNetCore.Components;

namespace Musharaf.Portal.Core.Blazor.Views.Bases
{
    public partial class LabelBase
    {
        [Parameter]
        public string Value { get; set; }

        public void SetValue(string value)
        {
            this.Value = value;
            StateHasChanged();
        }
    }
}
