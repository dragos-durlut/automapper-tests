using System.Collections.Generic;

namespace AutoMapperTests.DTOs
{
    public class ParentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<ChildDTO> Children { get; set; }
    }
}
