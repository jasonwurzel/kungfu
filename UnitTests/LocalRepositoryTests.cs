using FluentAssertions;
using Services;
using Xunit;

namespace UnitTests
{
    public class LocalRepositoryTests
    {
        [Fact]
        public void TestGetKungFuForms()
        {
            // Arrange
            var sut = new LocalRepository("4KungFuForms.txt", "TestFiles");

            // Act
            var kungFuForms = sut.GetKungFuForms().ToArray();

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
