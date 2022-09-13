namespace MP.EnsekTest.Api.Dtos
{
    public class MeterReadingsUploadResultDto
    {
        public int SuccessfulReads { get; set; }

        public int FailedReads { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
