using BaseSolution.Domain.Entities.Base;
using SatoshiCash.Server.Domain.Constants;

namespace BaseSolution.Domain.Entities
{
    public class ExampleEntity : IEntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = EntityStatus.Active;

        public DateTimeOffset CreatedTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long? CreatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset ModifiedTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long? ModifiedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Deleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long? DeletedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset DeletedTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
