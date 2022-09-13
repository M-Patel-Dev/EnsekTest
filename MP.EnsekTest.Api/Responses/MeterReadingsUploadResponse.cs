using MP.EnsekTest.Api.Dtos;
using System.Net;

namespace MP.EnsekTest.Api.Responses
{
    public class MeterReadingsUploadResponse
    {
        public MeterReadingsUploadResultDto MeterReadingsUploadResultDto { get; }
            = new MeterReadingsUploadResultDto();
        public HttpStatusCode StatusCode { get; set; }
    }
}
