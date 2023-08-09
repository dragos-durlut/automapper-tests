namespace AutoMapperTests.Models
{
    public class ChildModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public int Value { get; set; }
    }

    public class DerivedChildModel : ChildModel
    {
        public int OtherValue { get; set; }
        public int SomeOtherValue { get; set; }
    }
}
