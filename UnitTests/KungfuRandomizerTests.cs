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
        var sut = new KungFuRandomizer(originalForms);

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
        var sut = new KungFuRandomizer(originalForms);

        // Act
        var randomForms = Enumerable.Range(0, 10).Select(_ => sut.NextRandomForm()).ToArray();

        // Assert
        randomForms.Should().OnlyContain(form => originalForms.Contains(form));
        originalForms.Should().OnlyContain(form => randomForms.Count(f => f == form) == 2);
    }

    [Fact]
    public void Calling_NextRandomForm_Respects_Times_Trained()
    {
        // Arrange
        var dates = new List<DateTimeOffset>();
        for (int i = 1; i < 8; i++)
        {
            var dt = new DateTimeOffset(2012, 01, i, 12, 0, 0, TimeSpan.Zero);
            dates.Add(dt);
        }
        var originalForms = new KungFuForm[]
        {
            new("Sap Saam Cheung", new []{dates[0], dates[5]}),
            new("Tang Lung Cheung", new []{dates[1]}),
            new("Tang Lung Cheung2", new []{dates[1]}),
            new("Siu Lum Guan", new []{dates[2]}),
            new("Ng Lun Ma", new []{dates[3]}),
            new("Fu Mei Daan Dou", new[] { dates[4] })
        };
        var sut = new KungFuRandomizer(originalForms);

        // Act
        var uniqueRandomForms = Enumerable.Range(0, 5).Select(_ => sut.NextRandomForm()).ToArray();

        // Assert
        uniqueRandomForms.Should().OnlyContain(f => f == originalForms[1] || f == originalForms[2], "because only form 1 and 2 have only 1 training date and are the oldest.");
        //uniqueRandomForms.Should().BeEquivalentTo(originalForms.Skip(1).Take(2), "because only form 1 and 2 have only 1 training date and are the oldest.");
    }
}