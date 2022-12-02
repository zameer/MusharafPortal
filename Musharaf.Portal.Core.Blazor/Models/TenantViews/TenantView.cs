namespace Musharaf.Portal.Core.Blazor.Models.TenantViews
{
    public class TenantView
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public TenantTypeView TenantType { get; set; }
    }
}
