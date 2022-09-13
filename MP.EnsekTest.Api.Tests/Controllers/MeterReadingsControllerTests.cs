using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MP.EnsekTest.Api.Business.MeterReads;
using MP.EnsekTest.Api.Controllers;
using MP.EnsekTest.Api.Dtos;
using MP.EnsekTest.Api.Requests;
using MP.EnsekTest.Api.Responses;

namespace MP.EnsekTest.Api.Tests.Controllers
{
    [TestFixture]
    public class MeterReadingsControllerTests
    {
        private MeterReadingsController _sut;
        private Mock<IMeterReadingsService> _meterReads;
        private Mock<ILogger<MeterReadingsController>> _logger;
        private Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _logger = new Mock<ILogger<MeterReadingsController>>();
            _meterReads = new Mock<IMeterReadingsService>();
            _fixture = new Fixture();
            var httpContext = new DefaultHttpContext();

            _sut = new MeterReadingsController(_meterReads.Object, _logger.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };
        }

        [Test]
        [TestCaseSource(typeof(TestCases), nameof(TestCases.MeterReadingsControllerConstructorTestCases))]
        public void Constructor_GivenNullConstructorArgs_ThrowsNullArgsException(IMeterReadingsService meterReadsService, ILogger<MeterReadingsController> logger)
        {
            // Act/Assert
            Assert.Throws<ArgumentNullException>(() => new MeterReadingsController(meterReadsService, logger));
        }

        [Test]
        public async Task UploadMeterReadings_GivenNullRequest_Returns_ZeroUpdatedResults()
        {
            var result = await _sut.UploadMeterReadings(null);
            Assert.IsAssignableFrom<BadRequestObjectResult>(result);
        }

        [Test]
        public async Task UploadMeterReadings_GivenServerErrorProcessingRequest_Returns_InternalServerError()
        {
            var request = new MeterReadingsUploadRequest();
            _meterReads.Setup(a => a.UploadMeterReads(request))
                .Throws<Exception>();

            var result = await _sut.UploadMeterReadings(request);
            Assert.Multiple(() =>
            {
                Assert.IsAssignableFrom<StatusCodeResult>(result);
                Assert.That(((StatusCodeResult)result).StatusCode, Is.EqualTo(StatusCodes.Status500InternalServerError));
            });
        }

        [Test]
        public async Task UploadMeterReadings_GivenValidRequestData_Returns_AllRowsUpdatedResult()
        {
            var request = new MeterReadingsUploadRequest
            {
                MeterReadings = new List<MeterReadingDto>
                {
                     new MeterReadingDto { AccountId = 1234, MeterReadingDateTime = DateTime.Now, MeterReadValue = "12345" },
                     new MeterReadingDto { AccountId = 2234, MeterReadingDateTime = DateTime.Now, MeterReadValue = "32345" },
                     new MeterReadingDto { AccountId = 3464, MeterReadingDateTime = DateTime.Now, MeterReadValue = "12335" },
                },
            };

            var expectedResponse = _fixture.Build<MeterReadingsUploadResponse>().Create();
            _meterReads.Setup(a => a.UploadMeterReads(request))
                .Returns(expectedResponse);

            var result = await _sut.UploadMeterReadings(request);

            Assert.IsAssignableFrom<OkObjectResult>(result);
        }
    }
}