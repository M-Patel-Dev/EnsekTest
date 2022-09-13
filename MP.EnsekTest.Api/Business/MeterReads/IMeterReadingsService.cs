using MP.EnsekTest.Api.Requests;
using MP.EnsekTest.Api.Responses;

namespace MP.EnsekTest.Api.Business.MeterReads
{
    public interface IMeterReadingsService
    {
        MeterReadingsUploadResponse UploadMeterReads(MeterReadingsUploadRequest request);
    }
}
