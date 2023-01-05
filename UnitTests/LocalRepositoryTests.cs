using FluentAssertions;
using Services;
using Xunit;

namespace UnitTests
{
    public class LocalRepositoryTests
    {
        [Fact]
        public async Task TestGetKungFuForms()
        {
            // Arrange
            var sut = new LocalCsvRepository("4KungFuForms.txt", "TestFiles");

            // Act
            var kungFuFormsEnum = await sut.GetKungFuFormsAsync();
            var kungFuForms = kungFuFormsEnum.ToArray();
            // Assert
            kungFuForms.Should().HaveCount(4);
            kungFuForms.Should().AllSatisfy(form => form.Should().NotBeNull());
            kungFuForms[0].Name.Should().Be("Form 1");
            kungFuForms[1].Name.Should().Be("Form 2");
            kungFuForms[2].Name.Should().Be("Form 3");
            kungFuForms[3].Name.Should().Be("Form 4");
        }

    }
}
