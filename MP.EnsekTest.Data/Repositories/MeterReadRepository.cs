using MP.EnsekTest.Data.Database;
using MP.EnsekTest.Data.Entities;

namespace MP.EnsekTest.Data.Repositories
{
    public class MeterReadRepository : IMeterReadRepository
    {
        private readonly EnsekContext _context;

        public MeterReadRepository(EnsekContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); ;
        }
        public bool AddMeterReading(int accountId, DateTime readDateTime, string value)
        {
            var existingRead = _context.MeterReads.Find(accountId, readDateTime);
            if (existingRead != null) return false;

            _context.MeterReads.Add(new Entities.MeterRead
            {
                AccountId = accountId,
                ReadingDateTime = readDateTime,
                ReadValue = value,
            });
            _context.SaveChanges();
            return true;
        }

        public MeterRead GetLatestReading(int accountId) => _context.MeterReads
                .Where(meterRead => meterRead.AccountId.Equals(accountId))
                .OrderByDescending(a => a.ReadingDateTime)
                .FirstOrDefault();
    }
}
