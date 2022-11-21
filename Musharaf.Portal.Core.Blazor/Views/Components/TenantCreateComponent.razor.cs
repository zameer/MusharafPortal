﻿using Microsoft.AspNetCore.Components;
using Musharaf.Portal.Core.Blazor.Models.ContainerComponents;
using Musharaf.Portal.Core.Blazor.Models.TenantCreateComponents.Exceptions;
using Musharaf.Portal.Core.Blazor.Models.TenantViews;
using Musharaf.Portal.Core.Blazor.Services.Foundations.TenantViews;
using Musharaf.Portal.Core.Blazor.Views.Bases;

namespace Musharaf.Portal.Core.Blazor.Views.Components
{
    public partial class TenantCreateComponent : ComponentBase
    {
        [Inject]
        public ITenantViewService TenantViewService { get; set; }

        public ComponentState State { get; set; }
        public TenantCreateFormComponentException Exception { get; set; }
        public TenantView TenantView { get; set; }
        public TextBoxBase NameTextBox{ get; set; }
        public TextBoxBase DescriptionTextBox { get; set; }
        public ButtonBase SubmitButton { get; set; }

        protected override void OnInitialized()
        {
            this.State = ComponentState.Content;
        }
    }
}

