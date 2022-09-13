using MP.EnsekTest.Api.Dtos;
using MP.EnsekTest.Data.Repositories;

namespace MP.EnsekTest.Api.Business.MeterReads
{
    public class MeterReadingsPersistor : IMeterReadingsPersistor
    {
        private readonly IMeterReadRepository _meterReadRepository;
        private readonly ILogger<MeterReadingsPersistor> _logger;

        public MeterReadingsPersistor(
            IMeterReadRepository meterReadRepository, ILogger<MeterReadingsPersistor> logger)
        {
            _meterReadRepository = meterReadRepository ?? throw new ArgumentNullException(nameof(meterReadRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public int PersistToDataStore(List<MeterReadingDto> meterReadings)
        {
            var persisted = 0;
            if (meterReadings == null || meterReadings.Count == 0)
                return persisted;

            foreach (var reading in meterReadings)
            {
                try
                {
                    var existingRead = _meterReadRepository.GetLatestReading(reading.AccountId);
                    if (existingRead != null && reading.MeterReadingDateTime <= existingRead.ReadingDateTime)
                        continue;

                    var success = _meterReadRepository.AddMeterReading(reading.AccountId, reading.MeterReadingDateTime, reading.MeterReadValue);
                    if (success) persisted++;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            return persisted;
        }
    }
}
