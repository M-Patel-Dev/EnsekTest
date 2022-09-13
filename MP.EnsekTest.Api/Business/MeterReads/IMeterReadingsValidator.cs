using MP.EnsekTest.Api.Dtos;

namespace MP.EnsekTest.Api.Business.MeterReads
{
    public interface IMeterReadingsValidator
    {
        /// <summary>
        /// Validates given meter readings according to business rules
        /// </summary>
        /// <param name="readings"></param>
        /// <returns> a list of valid entries</returns>
        List<MeterReadingDto> ValidateReadings(List<MeterReadingDto> readings);
    }
}
