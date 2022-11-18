using Microsoft.AspNetCore.Components;
using Musharaf.Portal.Core.Blazor.Models.Basics;
using Musharaf.Portal.Core.Blazor.Views.Bases;

namespace Musharaf.Portal.Core.Blazor.Views.Components
{
    public partial class TenantFormComponent : ComponentBase
    {
        public TextBoxBase TenantNameTextBox { get; set; }
        public ComponentState State { get; set; }

        protected override void OnInitialized()
        {
            this.State = ComponentState.Content;
        }
    }
}

