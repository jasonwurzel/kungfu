using FluentAssertions;
using Models;
using Services;
using Xunit;

namespace UnitTests;

public class KungfuRandomizerTests
{
    [Fact]
    public void Calling_NextRandomForm_Results_In_Collection_With_Same_Elements()
    {
        // Arrange
        var originalForms = new KungFuForm[]
        {
            new("Sap Saam Cheung"),
            new("Tang Lung Cheung"),
            new("Siu Lum Guan"),
            new("Ng Lun Ma"),
            new("Fu Mei Daan Dou")
        };
        var sut = new KungfuRandomizer(originalForms);

        // Act
        var uniqueRandomForms = Enumerable.Range(0, 5).Select(_ => sut.NextRandomForm()).ToArray();

        // Assert
        uniqueRandomForms.Should().BeEquivalentTo(originalForms);
    }

    [Fact]
    public void Calling_NextRandomForm_2N_Times_Results_In_The_Same_Collection_2_Times()
    {
        // Arrange
        var originalForms = new KungFuForm[]
        {
            new("Sap Saam Cheung"),
            new("Tang Lung Cheung"),
            new("Siu Lum Guan"),
            new("Ng Lun Ma"),
            new("Fu Mei Daan Dou")
        };
        var sut = new KungfuRandomizer(originalForms);

        // Act
        var randomForms = Enumerable.Range(0, 10).Select(_ => sut.NextRandomForm()).ToArray();

        // Assert
        randomForms.Should().OnlyContain(form => originalForms.Contains(form));
        originalForms.Should().OnlyContain(form => randomForms.Count(f => f == form) == 2);
    }



}