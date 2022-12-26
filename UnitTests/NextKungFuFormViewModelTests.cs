using System.Reactive;
using FluentAssertions;
using Interfaces;
using Models;
using ViewModels;
using Xunit;
using ReactiveUI;
using Services;

namespace UnitTests
{
    public class NextKungFuFormViewModelTests
    {
        [Fact]
        public void CallingNextFormGivesRandomForm()
        {
            // Arrange
            IKungfuRandomizer randomizer = new KungfuRandomizer(
                new KungFuForm[]
                {
                    new("Sap Saam Cheung"), 
                    new ("Tang Lung Cheung"),
                    new ("Siu Lum Guan")
                });
            var sut = new NextKungFuFormViewModel(randomizer);

            // Act && Assert
            sut.GetNextForm.Execute(Unit.Default).Subscribe();
            var text1 = sut.NextForm.Name;
            sut.GetNextForm.Execute(Unit.Default).Subscribe();
            var text2 = sut.NextForm.Name;
            text1.Should().NotBe(text2);
        }

    }
}