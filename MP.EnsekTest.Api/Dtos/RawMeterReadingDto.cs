namespace MP.EnsekTest.Api.Dtos
{
    public class RawMeterReadingDto
    {
        public int AccountId { get; set; }

        public string MeterReadingDateTime { get; set; } = string.Empty;

        public string MeterReadValue { get; set; } = String.Empty;
    }
}
