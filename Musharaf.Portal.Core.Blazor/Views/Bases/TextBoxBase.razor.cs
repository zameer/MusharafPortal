﻿using Microsoft.AspNetCore.Components;

namespace Musharaf.Portal.Core.Blazor.Views.Bases
{
    public partial class TextBoxBase : ComponentBase
    {
        [Parameter]
        public string Value { get; set; }
        [Parameter]
        public string Placeholder { get; set; }

        public void SetValue(string value) => this.Value = value;
    }
}
