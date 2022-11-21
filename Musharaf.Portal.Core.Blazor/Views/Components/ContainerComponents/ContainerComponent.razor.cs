using Microsoft.AspNetCore.Components;
using Musharaf.Portal.Core.Blazor.Models.ContainerComponents;

namespace Musharaf.Portal.Core.Blazor.Views.Components.ContainerComponents
{
    public partial class ContainerComponent : ComponentBase
    {
        [Parameter]
        public ComponentState State { get; set; }
        [Parameter]
        public RenderFragment Content { get; set; }
        [Parameter]
        public string Error { get; set; }
    }
}
