using MP.EnsekTest.Api.Business.MeterReads;
using MP.EnsekTest.Api.Dtos;

namespace MP.EnsekTest.Api.Tests.Business.MeterReads
{
    [TestFixture]
    internal class MeterReadingsValidatorTests
    {
        private MeterReadingsValidator _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new MeterReadingsValidator();
        }

        [Test]
        public void ValidateReadings_GivenNullMeterReads_ReturnsEmptyList()
        {
            var result = _sut.ValidateReadings(null);

            Assert.Multiple(() =>
            {
                Assert.NotNull(result);
                Assert.That(result, Is.Empty);
            });
        }

        [Test]
        public void ValidateReadings_GivenNoMeterReads_ReturnsEmptyList()
        {
            var result = _sut.ValidateReadings(new List<MeterReadingDto>());

            Assert.Multiple(() =>
            {
                Assert.NotNull(result);
                Assert.That(result, Is.Empty);
            });
        }

        [Test]
        [TestCaseSource(typeof(TestCases), nameof(TestCases.MeterReadingsValidatorInvalidDataTestCase))]
        public void ValidateReadings_GivenInvalidReads_ReturnsEmptyList(List<MeterReadingDto> data)
        {

            var result = _sut.ValidateReadings(data);

            Assert.Multiple(() =>
            {
                Assert.NotNull(result);
                Assert.That(result, Is.Empty);
            });
        }

        [Test]
        [TestCaseSource(typeof(TestCases), nameof(TestCases.MeterReadingsValidatorValidDataTestCase))]
        public void ValidateReadings_GivenValidReads_ReturnsValidList(List<MeterReadingDto> data)
        {
            var result = _sut.ValidateReadings(data);

            Assert.Multiple(() =>
            {
                Assert.NotNull(result);
                Assert.IsNotEmpty(result);
                Assert.That(result.Count, Is.EqualTo(data.Count));
            });
        }
    }
}
