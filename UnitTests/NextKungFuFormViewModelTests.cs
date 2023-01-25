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
            var kungFuForms = new KungFuForm[]
            {
                new("Sap Saam Cheung"), 
                new ("Tang Lung Cheung"),
                new ("Siu Lum Guan")
            };
            IKungfuRandomizer randomizer = new KungFuRandomizer(
                kungFuForms);
            IKungFuFormPersister dummyPersister = new DummyPersister();
            var sut = new NextKungFuFormViewModel(randomizer, dummyPersister, kungFuForms);

            // Act && Assert
            sut.GetNextForm.Execute(Unit.Default).Subscribe();
            var text1 = sut.NextForm.Name;
            sut.GetNextForm.Execute(Unit.Default).Subscribe();
            var text2 = sut.NextForm.Name;
            text1.Should().NotBe(text2);
        }
    }

    public class DummyPersister : IKungFuFormPersister
    {
        public Task PersistKungFuFormsAsync()
        {
            return Task.CompletedTask;
        }
    }
}