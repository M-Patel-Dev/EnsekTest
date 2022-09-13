using Microsoft.Extensions.Logging;
using Moq;
using MP.EnsekTest.Api.Dtos;
using MP.EnsekTest.Api.ModelBinders;
using MP.EnsekTest.Utilities.Helpers;

namespace MP.EnsekTest.Api.Tests.ModelBinders
{
    [TestFixture]
    public class MeterReadingCsvModelBinderTests
    {
        [Test]
        [TestCaseSource(typeof(TestCases), nameof(TestCases.MeterReadingCsvModelBinderConstructorTestCases))]
        public void Constructor_GivenNullConstructorArgs_ThrowsNullArgsException(
            ICsvParser<MeterReadingDto> csvParser,
            ILogger<MeterReadingCsvModelBinder> logger)
        {
            Assert.Throws<ArgumentNullException>(() => new MeterReadingCsvModelBinder(csvParser, logger));
        }

        [Test]
        public void BindModelAsync_GivenNullBindingContext_ThrowsNullArgsException()
        {
            var mockParser = new Mock<ICsvParser<MeterReadingDto>>();
            var mockLogger = new Mock<ILogger<MeterReadingCsvModelBinder>>();
            var sut = new MeterReadingCsvModelBinder(mockParser.Object, mockLogger.Object);

            Assert.ThrowsAsync<ArgumentNullException>(async () => await sut.BindModelAsync(null));
        }
    }
}
