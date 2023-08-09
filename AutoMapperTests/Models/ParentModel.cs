using System.Collections.Generic;

namespace AutoMapperTests.Models
{
    public class ParentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<ChildModel> Children { get; set; }
    }
}
