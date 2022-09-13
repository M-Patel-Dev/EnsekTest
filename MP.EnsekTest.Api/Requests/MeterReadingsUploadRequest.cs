using Microsoft.AspNetCore.Mvc;
using MP.EnsekTest.Api.Dtos;
using MP.EnsekTest.Api.ModelBinders;

namespace MP.EnsekTest.Api.Requests
{
    [ModelBinder(BinderType = typeof(MeterReadingCsvModelBinder))]
    public class MeterReadingsUploadRequest
    {
        public List<MeterReadingDto> MeterReadings { get; set; }
            = new List<MeterReadingDto>();
    }
}
