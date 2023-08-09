namespace AutoMapperTests.DTOs
{
    public class ChildDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public int Value { get; set; }
    }

    public class DerivedChildDTO : ChildDTO
    {
        public int OtherValue { get; set; }
        public int SomeOtherValue { get; set; }
    }
}
