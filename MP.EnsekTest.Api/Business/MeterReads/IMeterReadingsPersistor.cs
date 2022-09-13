using MP.EnsekTest.Api.Dtos;

namespace MP.EnsekTest.Api.Business.MeterReads
{
    public interface IMeterReadingsPersistor
    {
        /// <summary>
        /// Adds meter readings to data store
        /// </summary>
        /// <param name="meterReadings"></param>
        /// <returns>Number of readings that were persisted to data store</returns>
        int PersistToDataStore(List<MeterReadingDto> meterReadings);
    }
}
