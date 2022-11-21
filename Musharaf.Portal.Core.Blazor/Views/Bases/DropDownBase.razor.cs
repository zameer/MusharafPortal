using Microsoft.AspNetCore.Components;

namespace Musharaf.Portal.Core.Blazor.Views.Bases
{
    public partial class DropDownBase<TEnum> : ComponentBase
    {
        [Parameter]
        public TEnum Value { get; set; }
    }
}
