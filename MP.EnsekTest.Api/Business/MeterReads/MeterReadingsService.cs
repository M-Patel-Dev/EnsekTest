using MP.EnsekTest.Api.Requests;
using MP.EnsekTest.Api.Responses;

namespace MP.EnsekTest.Api.Business.MeterReads
{
    public class MeterReadingsService : IMeterReadingsService
    {
        private readonly IMeterReadingsValidator _meterReadingsValidator;
        private readonly IMeterReadingsPersistor _meterReadsPersistor;
        private readonly ILogger<MeterReadingsService> _logger;

        public MeterReadingsService(
            IMeterReadingsValidator meterReadingsValidator,
            IMeterReadingsPersistor meterReadsPersistor,
            ILogger<MeterReadingsService> logger)
        {
            _meterReadingsValidator = meterReadingsValidator ?? throw new ArgumentNullException(nameof(meterReadingsValidator));
            _meterReadsPersistor = meterReadsPersistor ?? throw new ArgumentNullException(nameof(meterReadsPersistor));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public MeterReadingsUploadResponse UploadMeterReads(MeterReadingsUploadRequest request)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));
            var response = new MeterReadingsUploadResponse();

            var totalReadings = request.MeterReadings?.Count ?? 0;
            var validReadings = _meterReadingsValidator.ValidateReadings(request?.MeterReadings);
            var successfulReads = _meterReadsPersistor.PersistToDataStore(validReadings);

            response.StatusCode = System.Net.HttpStatusCode.OK;
            response.MeterReadingsUploadResultDto.SuccessfulReads = successfulReads;
            response.MeterReadingsUploadResultDto.FailedReads = totalReadings - successfulReads;
            return response;
        }
    }
}