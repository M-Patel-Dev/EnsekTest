using Microsoft.Extensions.Logging;
using Moq;
using MP.EnsekTest.Api.Business.MeterReads;
using MP.EnsekTest.Api.Dtos;
using MP.EnsekTest.Data.Repositories;

namespace MP.EnsekTest.Api.Tests.Business.MeterReads
{
    [TestFixture]
    internal class MeterReadingsPersistorTests
    {
        private MeterReadingsPersistor _sut;
        private Mock<IMeterReadRepository> _meterReadRepository;
        private Mock<ILogger<MeterReadingsPersistor>> _logger;

        [SetUp]
        public void SetUp()
        {
            _meterReadRepository = new Mock<IMeterReadRepository>();    
            _logger = new Mock<ILogger<MeterReadingsPersistor>>();  
            _sut = new MeterReadingsPersistor(_meterReadRepository.Object, _logger.Object);
        }

        [Test]
        public void PersistToDataStore_GivenNullMeterReads_ReturnsZero()
        {
            var result = _sut.PersistToDataStore(null);

            Assert.Multiple(() =>
            {
                Assert.NotNull(result);
                Assert.That(result, Is.Zero);
            });
        }

        [Test]
        public void PersistToDataStore_GivenEmptyMeterReadsList_ReturnsZero()
        {
            var result = _sut.PersistToDataStore(new List<MeterReadingDto>());

            Assert.Multiple(() =>
            {
                Assert.NotNull(result);
                Assert.That(result, Is.Zero);
            });
        }        
    }
}
