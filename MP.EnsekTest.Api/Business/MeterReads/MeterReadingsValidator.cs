using MP.EnsekTest.Api.Dtos;

namespace MP.EnsekTest.Api.Business.MeterReads
{
    public class MeterReadingsValidator : IMeterReadingsValidator
    {
        public List<MeterReadingDto> ValidateReadings(List<MeterReadingDto> readings)
        {
            if (readings == null)
                return new List<MeterReadingDto>();

            return readings
                .Where(entry =>
                    !string.IsNullOrWhiteSpace(entry.MeterReadValue) &&
                    int.TryParse(entry.MeterReadValue, out var readValue) &&
                    readValue >= 10000 && readValue <= 99999)
                .ToList();
        }
    }
}