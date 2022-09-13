namespace MP.EnsekTest.Api.Dtos
{
    public class MeterReadingDto
    {
        public int AccountId { get; set; }

        public DateTime MeterReadingDateTime { get; set; }

        public string MeterReadValue { get; set; } = String.Empty;
    }
}