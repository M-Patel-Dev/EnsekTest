using CsvHelper;
using System.Globalization;

namespace MP.EnsekTest.Utilities.Helpers
{
    public class CsvParser<T> : ICsvParser<T>
    {
        public async Task<List<T>> ParseStringAsync(string content)
        {
            ArgumentNullException.ThrowIfNull(content, nameof(content));

            using var stringReader = new StringReader(content);
            using var csv = new CsvReader(stringReader, CultureInfo.CurrentCulture);

            return await Task.FromResult(csv.GetRecords<T>().ToList());
        }
    }
}
