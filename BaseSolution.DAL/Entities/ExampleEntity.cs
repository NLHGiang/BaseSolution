using BaseSolution.Domain.Constants;
using BaseSolution.Domain.Entities.Base;

namespace BaseSolution.Domain.Entities
{
    public class ExampleEntity : IEntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = EntityStatus.Active;

        public DateTimeOffset CreatedTime { get; set; }
        public long? CreatedBy { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
        public long? ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public long? DeletedBy { get; set; }
        public DateTimeOffset DeletedTime { get; set; }
    }
}
