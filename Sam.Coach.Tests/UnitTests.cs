using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Sam.Coach.Tests
{
    public class UnitTests
    {
        readonly ILongestRisingSequenceFinder _service;

        public UnitTests()
        {
            // Arrange - setup dependency injection

            var services = new ServiceCollection();

            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            _service = serviceProvider.GetRequiredService<ILongestRisingSequenceFinder>();
        }


        [Theory]
        [InlineData(new[] { 4, 3, 5, 8, 5, 0, 0, -3 }, new[] { 4, 6, -3, 3, 7, 9 }, new[] { 4, 6, -3, 3, 7, 9 })]
        // TODO: add more scenarios to ensure finder is working properly
        public async Task Can_Find_Longer(IEnumerable<int> data, IEnumerable<int> another_data, IEnumerable<int> expected)
        {
            IEnumerable<int> actual = null;

            // TODO: create the finder instance and get the actual result
            // I added it elsewhere to avoid editing this section.

            actual.Should().Equal(expected);
        }

        [Theory]
        [InlineData(new[] { 4, 3, 5, 8, 5, 0, 0, -3 }, new[] { 4, 6, -3, 3, 7, 9 }, new[] { 4, 6, -3, 3, 7, 9 })]
        [InlineData(new[] { 1, 2, 3, 4 }, new[] { 1, 2, 2, 1 }, new[] { 1, 2, 3, 4 })]
        [InlineData(new[] { 10, 9, 2, 5, 3, 7, 10, 18 }, new[] { 3, 4, 23, 12, 12, 15, 16 }, new[] { 10, 9, 2, 5, 3, 7, 10, 18 })]
        public async Task Can_Find_Longer_Valid_Input(int[] data, int[] another_data, int[] expected)
        {
            // Act
            var actual = await _service.Find(data, another_data);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Throws_ArgumentNullException_For_Null_Inputs()
        {
            // Act
            Func<Task> act = async () => await _service.Find(null, null);

            // Assert
            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Returns_Null_When_Subsequences_Are_Equal()
        {
            // Arrange
            var data = new int[] { 1, 2, 3, 4, 5 };
            var another_data = new int[] { 1, 2, 3, 4, 5 };

            // Act
            var result = await _service.Find(data, another_data);

            // Assert
            result.Should().BeNull();
        }


        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ILongestRisingSequenceFinder, LongestRisingSequenceFinder>();
        }
    }
}
