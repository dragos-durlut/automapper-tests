using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AutoMapperTests
{
    public class Tests
    {
        AutoMapper.IMapper _mapper = null;

        [SetUp]
        public void Setup()
        {
            var mappingConfiguration = new AutoMapper.MapperConfiguration(x => x.AddProfile<Profiles.ModelToDtoMappingProfile>());
            AutoMapper.IMapper mapper = mappingConfiguration.CreateMapper();
            _mapper = mapper;
        }

        [Test]
        public void MapFromModelsToDtos()
        {
            IEnumerable<Models.ParentModel> parentModels = new List<Models.ParentModel>()
            { 
                new Models.ParentModel()
                {
                    Id = 1,
                    Name = "Parent1",
                    Children = new List<Models.ChildModel>()
                    {
                        new Models.DerivedChildModel()
                        {
                            Id=1,
                            Name= "DerivedChild1",
                            ParentId= 1,
                            Value = 2,
                            OtherValue= 3,
                            SomeOtherValue = 4
                        }
                    }.AsEnumerable()
                },
                new Models.ParentModel()
                {
                    Id = 2,
                    Name = "Parent2",
                    Children = new List<Models.DerivedChildModel>()
                    {
                        new Models.DerivedChildModel()
                        {
                            Id=2,
                            Name= "DerivedChild2",
                            ParentId= 2,
                            Value = 2,
                            OtherValue= 3,
                            SomeOtherValue = 4
                        }
                    }.AsEnumerable()
                },
                new Models.ParentModel()
                {
                    Id = 3,
                    Name = "Parent3",
                    Children = new List<Models.ChildModel>()
                    {
                        new Models.ChildModel()
                        {
                            Id=3,
                            Name= "Child3",
                            ParentId= 3,
                            Value = 3
                        }
                    }.AsEnumerable()
                }
            };
            var parentDtos = _mapper.Map<IEnumerable<DTOs.ParentDTO>>(parentModels);
            parentDtos.Should().NotBeNullOrEmpty();

            var firstParentDTO = parentDtos.First(x => x.Id == 1);
            firstParentDTO.Id.Should().Be(1);
            firstParentDTO.Name.Should().Be("Parent1");
            firstParentDTO.Children.Should().NotBeNullOrEmpty();
            firstParentDTO.Children.Should().BeOfType<List<DTOs.ChildDTO>>(); // FIXED-FAILED Expected type to be IEnumerable<DerivedChildDTO>, but found List<AutoMapperTests.DTOs.ChildDTO>

            var firstChildOfFirstParent = firstParentDTO.Children.First();
            firstChildOfFirstParent.Id.Should().Be(1);
            firstChildOfFirstParent.Name.Should().Be("DerivedChild1");
            firstChildOfFirstParent.ParentId.Should().Be(1);
            firstChildOfFirstParent.Value.Should().Be(2);
            firstChildOfFirstParent.Should().BeAssignableTo<DTOs.ChildDTO>();
            firstChildOfFirstParent.Should().BeOfType<DTOs.DerivedChildDTO>(); // FIXED-FAILED Expected type to be AutoMapperTests.DTOs.DerivedChildDTO, but found AutoMapperTests.DTOs.ChildDTO

            var secondParentDTO = parentDtos.First(x => x.Id == 2);
            secondParentDTO.Id.Should().Be(2);
            secondParentDTO.Name.Should().Be("Parent2");
            secondParentDTO.Children.Should().NotBeNullOrEmpty();
            secondParentDTO.Children.Should().BeOfType<List<DTOs.ChildDTO>>(); // FIXED-FAILED Expected type to be IEnumerable<DerivedChildDTO>, but found List<AutoMapperTests.DTOs.ChildDTO>

            var firstChildOfSecondParent = secondParentDTO.Children.First();
            firstChildOfSecondParent.Id.Should().Be(2);
            firstChildOfSecondParent.Name.Should().Be("DerivedChild2");
            firstChildOfSecondParent.ParentId.Should().Be(2);
            firstChildOfSecondParent.Value.Should().Be(2);
            firstChildOfSecondParent.Should().BeAssignableTo<DTOs.ChildDTO>();
            firstChildOfSecondParent.Should().BeOfType<DTOs.DerivedChildDTO>(); // FIXED-FAILED Expected type to be AutoMapperTests.DTOs.DerivedChildDTO, but found AutoMapperTests.DTOs.ChildDTO

            var thirdParentDTO = parentDtos.First(x => x.Id == 3);
            thirdParentDTO.Id.Should().Be(3);
            thirdParentDTO.Name.Should().Be("Parent3");
            thirdParentDTO.Children.Should().NotBeNullOrEmpty();
            thirdParentDTO.Children.Should().BeOfType<List<DTOs.ChildDTO>>();

            var firstChildOfThirdParent = thirdParentDTO.Children.First();
            firstChildOfThirdParent.Id.Should().Be(3);
            firstChildOfThirdParent.Name.Should().Be("Child3");
            firstChildOfThirdParent.ParentId.Should().Be(3);
            firstChildOfThirdParent.Value.Should().Be(3);
            firstChildOfThirdParent.Should().BeAssignableTo<DTOs.ChildDTO>();
            firstChildOfThirdParent.Should().BeOfType<DTOs.ChildDTO>();
        }
    }
}