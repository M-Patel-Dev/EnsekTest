using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using MP.EnsekTest.Api.Business.MeterReads;

namespace MP.EnsekTest.Api.Tests.Business.MeterReads
{
    [TestFixture]
    internal class MeterReadingsServiceTests
    {
        private MeterReadingsService _sut;
        private Mock<IMeterReadingsValidator> _meterReadingsValidator;
        private Mock<IMeterReadingsPersistor> _meterReadingsPersistor;
        private Mock<ILogger<MeterReadingsService>> _logger;
        private Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _meterReadingsValidator = new Mock<IMeterReadingsValidator>();
            _meterReadingsPersistor = new Mock<IMeterReadingsPersistor>();
            _logger = new Mock<ILogger<MeterReadingsService>>();
            _fixture = new Fixture();

            _sut = new MeterReadingsService(
                _meterReadingsValidator.Object,
                _meterReadingsPersistor.Object,
                _logger.Object);
        }

        [Test]
        [TestCaseSource(typeof(TestCases), nameof(TestCases.MeterReadingsServiceConstructorTestCases))]
        public void Constructor_GivenNullConstructorArgs_ThrowsNullArgsException(
            IMeterReadingsValidator meterReadingsValidator,
            IMeterReadingsPersistor meterReadingsPersistor,
            ILogger<MeterReadingsService> logger)
        {
            // Act/Assert
            Assert.Throws<ArgumentNullException>(() => new MeterReadingsService(meterReadingsValidator, meterReadingsPersistor, logger));
        }

        [Test]
        public void UploadMeterReads_GivenNullRequest_ThrowsNullArgsException()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.UploadMeterReads(null));
        }       
    }
}
