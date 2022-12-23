using System.Reactive;
using FluentAssertions;
using ViewModels;
using Xunit;
using ReactiveUI;

namespace UnitTests
{
    public class NextKungFuFormViewModelTests
    {
        [Fact]
        public void CallingNextFormGivesRandomForm()
        {
            // Arrange
            var sut = new NextKungFuFormViewModel();

            // Act && Assert
            sut.GetNextForm.Execute(Unit.Default).Subscribe();
            var text1 = sut.NextFormText;
            sut.GetNextForm.Execute(Unit.Default).Subscribe();
            var text2 = sut.NextFormText;
            text1.Should().NotBe(text2);
        }

    }
}