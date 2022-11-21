﻿using Microsoft.AspNetCore.Components;
using Musharaf.Portal.Core.Blazor.Models.ContainerComponents;

namespace Musharaf.Portal.Core.Blazor.Views.Components.ContainerComponents
{
    public partial class ContainerStateComponent
    {

        [Parameter]
        public ComponentState State { get; set; }
        [Parameter]
        public RenderFragment LoadingFragment { get; set; }
        [Parameter]
        public RenderFragment ContentFragment { get; set; }
        [Parameter]
        public RenderFragment ErrorFragment { get; set; }
        public RenderFragment GetComponentStateFragment()
        {
            return State switch
            {
                ComponentState.Loading => LoadingFragment,
                ComponentState.Content => ContentFragment,
                ComponentState.Error => ErrorFragment,
                _ => ErrorFragment
            };
        }
    }
}
