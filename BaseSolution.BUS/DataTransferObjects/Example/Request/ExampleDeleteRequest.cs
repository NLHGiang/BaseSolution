namespace BaseSolution.Application.DataTransferObjects.Example.Request
{
    public class ExampleDeleteRequest
    {
        public Guid Id { get; set; }
        public long? DeletedBy { get; set; }
    }
}
