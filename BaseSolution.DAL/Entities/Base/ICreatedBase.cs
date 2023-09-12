namespace BaseSolution.Domain.Entities.Base
{
    public interface ICreatedBase
    {
        public DateTimeOffset CreatedTime { get; set; }

        public long? CreatedBy { get; set; }
    }
}
