using MP.EnsekTest.Data.Entities;

namespace MP.EnsekTest.Data.Repositories
{
    public interface IMeterReadRepository
    {
        bool AddMeterReading(int accountId, DateTime readDateTime, string value);

        MeterRead GetLatestReading(int accountId);
    }
}
