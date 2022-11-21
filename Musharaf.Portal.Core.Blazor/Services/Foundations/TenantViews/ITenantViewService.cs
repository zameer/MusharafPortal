﻿using Musharaf.Portal.Core.Blazor.Models.TenantViews;

namespace Musharaf.Portal.Core.Blazor.Services.Foundations.TenantViews
{
    public interface ITenantViewService
    {
        ValueTask<TenantView> AddTenantViewAsync(TenantView tenantView);
    }
}