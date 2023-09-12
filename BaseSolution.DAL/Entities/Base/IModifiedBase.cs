namespace BaseSolution.Domain.Entities.Base
{
    public interface IModifiedBase
    {
        public DateTimeOffset ModifiedTime { get; set; }

        public long? ModifiedBy { get; set; }

    }
}
