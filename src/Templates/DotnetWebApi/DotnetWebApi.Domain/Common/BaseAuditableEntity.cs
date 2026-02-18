namespace DotnetWebApi.Domain.Common
{
    public abstract class BaseAuditableEntity
    {
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
