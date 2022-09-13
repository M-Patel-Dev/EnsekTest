namespace MP.EnsekTest.Utilities.Helpers
{
    public interface ICsvParser<T>
    {
        Task<List<T>> ParseStringAsync(string content);
    }
}
