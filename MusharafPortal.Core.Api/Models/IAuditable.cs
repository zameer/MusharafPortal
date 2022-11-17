namespace MusharafPortal.Core.Api.Models
{
    public interface IAuditable
    {
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }

        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
