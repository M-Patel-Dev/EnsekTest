using Microsoft.AspNetCore.Mvc.ModelBinding;
using MP.EnsekTest.Api.Dtos;
using MP.EnsekTest.Api.Requests;
using MP.EnsekTest.Utilities.Helpers;

namespace MP.EnsekTest.Api.ModelBinders
{
    public class MeterReadingCsvModelBinder : IModelBinder
    {
        private readonly ICsvParser<MeterReadingDto> _csvParser;
        private readonly ILogger<MeterReadingCsvModelBinder> _logger;

        public MeterReadingCsvModelBinder(
            ICsvParser<MeterReadingDto> csvParser,
            ILogger<MeterReadingCsvModelBinder> logger)
        {
            _csvParser = csvParser ?? throw new ArgumentNullException(nameof(csvParser));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ArgumentNullException.ThrowIfNull(bindingContext, nameof(bindingContext));

            var text = string.Empty;

            try
            {
                using var streamReader = new StreamReader(bindingContext.HttpContext.Request.Body);
                text = await streamReader.ReadToEndAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to model bind request for meter readings, exception encountered : {ex.Message}");
                bindingContext.Result = ModelBindingResult.Failed();
                return;
            }

            var request = new MeterReadingsUploadRequest
            {
                MeterReadings = await _csvParser.ParseStringAsync(text)
            };

            bindingContext.Result = ModelBindingResult.Success(request);

            return;
        }
    }
}
