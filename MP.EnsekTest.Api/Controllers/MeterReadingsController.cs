using Microsoft.AspNetCore.Mvc;
using MP.EnsekTest.Api.Business.MeterReads;
using MP.EnsekTest.Api.Requests;

namespace MP.EnsekTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeterReadingsController : ControllerBase
    {
        private readonly ILogger<MeterReadingsController> _logger;
        private readonly IMeterReadingsService _meterReadService;

        public MeterReadingsController(
            IMeterReadingsService meterReadService,
            ILogger<MeterReadingsController> logger)
        {
            _meterReadService = meterReadService ?? throw new ArgumentNullException(nameof(meterReadService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        [Route("/meter-reading-uploads")]
        public async Task<IActionResult> UploadMeterReadings([FromBody] MeterReadingsUploadRequest request)
        {
            if (request == null)
                return new BadRequestObjectResult(Constants.ControllerErrorMessageConstants.InvalidMeterReadRequest);

            try
            {
                var response = _meterReadService.UploadMeterReads(request);
                return new OkObjectResult(response.MeterReadingsUploadResultDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error was encountered when attempting to upload meter readings", request);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}